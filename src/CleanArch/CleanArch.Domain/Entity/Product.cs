using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entity
{
    public sealed class Product: EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        
        public Product(int id,
                       string name,
                       string description,
                       decimal price,
                       int stock,
                       string image)
        {
            ValidateDomain(id,
                           name,
                           description,
                           price,
                           stock,
                           image);
        }

        public Product(string name,
                       string description,
                       decimal price,
                       int stock,
                       string image)
        {
            ValidateDomain(name,
                           description,
                           price,
                           stock,
                           image);
        }
        private void Update(string name,
                            string description,
                            decimal price,
                            int stock,
                            string image, 
                            int categoryId)
        {
            ValidateDomain(name,
                           description,
                           price,
                           stock,
                           image);
            this.CategoryId = categoryId;
        }

        private void ValidateDomain(int id,
                                    string name,
                                    string description,
                                    decimal price,
                                    int stock,
                                    string image)
        {
            DomainExceptionValidation.When((id <= 0), "The id must be greater than zero.");
            this.Id = id;
            ValidateDomain(name,
                           description,
                           price,
                           stock,
                           image);
        }

        private void ValidateDomain(string name,
                                    string description,
                                    decimal price,
                                    int stock,
                                    string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is empty or null.");
            DomainExceptionValidation.When((name.Length < 3), "Name is too short the minimum size is 3 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is empty or null.");
            DomainExceptionValidation.When((description.Length < 10), "Description is too short the minimum size is 10 characters.");
            DomainExceptionValidation.When((price < 0), "The price must be greater than zero.");
            DomainExceptionValidation.When((stock < 0), "The stock must be greater than zero.");
            DomainExceptionValidation.When((image.Length < 25), "The image is too short the minimum size is 250 characters.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
