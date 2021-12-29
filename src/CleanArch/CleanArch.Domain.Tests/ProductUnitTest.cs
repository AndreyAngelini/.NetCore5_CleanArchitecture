using CleanArch.Domain.Entity;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product object with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            
            Action action = () => new Product(1, "Product 01","Product is new.",1,1,"adadadadsvfsdfsfvdveffvdvdfvsdfvsdvsdvf");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product object with invalid Id")]
        public void CreateProduct_NegativeValue_ResultObjectInvalidId()
        {
            Action action = () => new Product(-1, "Product 01", "Product is new.", 1, 1, "adadadadsvfsdfsfvdveffvdvdfvsdfvsdvsdvf");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The id must be greater than zero.");
        }

        [Fact(DisplayName = "Create Product name with short name")]
        public void CreateProduct_ShortName_ResultObjectInvalidName()
        {
            Action action = () => new Product(1, "Ca", "Product is new.", 1, 1, "aadadadadsvfsdfsfvdveffvdvdfvsdfvsdvsdvfd");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is too short the minimum size is 3 characters.");
        }

        [Fact(DisplayName = "Create Product without name")]
        public void CreateProduct_MissingValueName_ResultObjectInvalidName()
        {
            Action action = () => new Product(1, "", "Product is new.", 1, 1, "adadadadsvfsdfsfvdveffvdvdfvsdfvsdvsdvf");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is empty or null.");
        }

        [Theory(DisplayName = "Create Product with invalid stock")]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStock_ResultObjectInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product new", "Product is new.", 1, value, "adadadadsvfsdfsfvdveffvdvdfvsdfvsdvsdvf");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The stock must be greater than zero.");
        }
    }
}
