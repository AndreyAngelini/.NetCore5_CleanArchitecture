using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entity
{
    public sealed class Category: EntityBase
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            ValidateDomain(id);
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is empty or null.");
            DomainExceptionValidation.When((name.Length < 3), "Name is too short the minimum size is 3 characters.");
            this.Name = name;
        }
        private void ValidateDomain(int id)
        {
            DomainExceptionValidation.When((id < 0), "The id must be greater than zero.");
            this.Id = id;
        }
        public ICollection<Product> Products { get; set; }
}
}
