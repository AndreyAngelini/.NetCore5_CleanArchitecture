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
   
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category object with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category 01");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category object with invalid Id")]
        public void CreateCategory_NegativeValue_ResultObjectInvalidId()
        {
            Action action = () => new Category(-1, "Category 01");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The id must be greater than zero.");
        }

        [Fact(DisplayName = "Create category name with short name")]
        public void CreateCategory_ShortName_ResultObjectInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is too short the minimum size is 3 characters.");
        }

        [Fact(DisplayName = "Create category without name")]
        public void CreateCategory_MissingValueName_ResultObjectInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is empty or null.");
        }
    }
}
