using AuthProjectJWT.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
