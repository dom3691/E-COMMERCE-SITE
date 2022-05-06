using Ecomm.Contracts;
using Ecomm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecomm.Utilities
{
    public class Pagination
    {
        public int ProductPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount(List<Product> products)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(products.Count) / Convert.ToDecimal(ProductPerPage)));
        }

        public IEnumerable<Product> Paginate(List<Product> products)
        {
            int start = (CurrentPage - 1) * ProductPerPage;
            return products.OrderBy(x => x.Id).Skip(start).Take(ProductPerPage);
        }
    }
}
