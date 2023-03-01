using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
