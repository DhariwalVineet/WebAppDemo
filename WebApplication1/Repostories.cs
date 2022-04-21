using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class UserRepository
    {
        public List<UserDto> DefaultUsersInMemory = new List<UserDto>()
            {

                new UserDto(){Id = 1, Name = "John", Age = 25, City = "Houston"},
                new UserDto(){Id = 2, Name = "Marry", Age = 24, City = "London"},
                new UserDto(){Id = 3, Name = "Ramesh", Age = 44, City = "Bangalore"},

            };

        private UserRepository()
        {
            Users = DefaultUsersInMemory;
        }

        private List<UserDto> Users;

        private static UserRepository userRepository;

        public static UserRepository Instance
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository();
                }

                return userRepository;
            }
        }

        public List<UserDto> GetUsers()
        {
            // Get it from DB

            return this.Users;
        }

        public UserDto GetUserById(int userId)
        {
            // Get it from DB

            return this.Users.FirstOrDefault(x => x.Id == userId);
        }


        public UserDto AddUser(UserDto user)
        {
            // Add to database.
            this.Users.Add(user);
            return user;
        }


        public bool DeleteUser(int userId)
        {
            var user = this.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                this.Users.Remove(user);
            }
           
            return true;
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            var existingUser = this.Users.FirstOrDefault(x => x.Id == userDto.Id);
            if (existingUser != null)
            {
                this.Users.Remove(existingUser);
            }
            
            this.Users.Add(userDto);

            return userDto;
        }
    }

    public class ProductRepository
    {
        public List<ProductDto> DefaultProductInMemory = new List<ProductDto>()
        {

            new ProductDto(){Id = 1, Name = "WashingMachine", Price = 100, Category = "Appliances"},
            new ProductDto(){Id = 2, Name = "TV", Price = 1000, Category = "Appliances"},
            new ProductDto(){Id = 3, Name = "Chess", Price = 50, Category = "Toys"},
            new ProductDto(){Id = 4, Name = "Ludo", Price = 10, Category = "Toys"},
            new ProductDto(){Id = 5, Name = "Rich Dad Poor Dad", Price = 25, Category = "Books"},
        };

        
        private static ProductRepository productRepository;

        public static ProductRepository Instance
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository();
                }

                return productRepository;
            }
        }

        private List<ProductDto> products;
        private ProductRepository()
        {
            products = DefaultProductInMemory;
        }
        public List<ProductDto> GetProducts()
        {
            // Get it from DB

            return this.products;
        }

        public ProductDto GetProductById(int productId)
        {
            // Get it from DB

            return this.products.FirstOrDefault(x=>x.Id == productId);
        }

        public ProductDto GetProductByName(string productName)
        {
            // Get it from DB

            return this.products.FirstOrDefault(x => x.Name == productName);
        }

        public ProductDto AddProduct(ProductDto product)
        {
            // Add to database.
            this.products.Add(product);
            return product;
        }


        public bool DeleteProduct(int userId)
        {
            var user = this.products.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                this.products.Remove(user);
            }

            return true;
        }

        public ProductDto UpdateProduct(ProductDto productDto)
        {
            var existingUser = this.products.FirstOrDefault(x => x.Id == productDto.Id);
            if (existingUser != null)
            {
                this.products.Remove(existingUser);
            }

            this.products.Add(productDto);

            return productDto;
        }
    }


}
