using Ecomm.Models;
using Ecomm.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecomm.ViewModel
{
    public class UserProductViewModel : Pagination
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<LatestNew> LatestNews { get; set; }
        public Product Product { get; set; }
        public bool IsSuccess { get; set; }
    }
}

