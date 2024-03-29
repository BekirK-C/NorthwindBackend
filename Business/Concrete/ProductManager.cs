﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Dependency Injection
        // Cross Cutting Concerns - Validation, Cache, Log, Performance, Authorization, Transaction
        // AOP - Aspect Oriented Programming

        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        //[TransactionScopeAspect]
        //[ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductsListed);
        }

        //[SecuredOperation("admin")]
        [CacheAspect(duration: 10)]
        //[PerformanceAspect(3)]    //Output'da bilgilendirme yapılıyor.
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(3000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList(), Messages.ProductsListed);

        }

        // [ExceptionLogAspect(typeof(FileLogger))]   Bu şekilde hepsine tek tek yazmak yerine AspectInterceptorSelector'dan merkezi hale getiriyoruz
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList(), Messages.ProductsListed);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            // IResult result = CheckIfProductNameExists(product.ProductName);  BusinessRules ile yapacağım
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), ChecIfCategoryIsEnabled());
            if (result != null)
            {
                return result;
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);

        }

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(p => p.ProductName == productName) != null)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult ChecIfCategoryIsEnabled()
        {
            if (_categoryService.GetList().Data.Count > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
    }
}
