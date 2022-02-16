using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.ProductDto
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool IsDelete { get; set; }
    }
}
