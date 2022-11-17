using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Dependency Injection

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList().ToList();
#warning ToList() ifadesi gerçekten gerekli mi kontrol et.
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
