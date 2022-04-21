using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int Age { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }
    }


}
