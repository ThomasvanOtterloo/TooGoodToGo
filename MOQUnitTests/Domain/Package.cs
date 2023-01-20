using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;


namespace MOQUnitTests.Domain
{
    public class PackageObjectTest
    {
      
        [Fact]
        public void Package_InvalidProperties_ShouldFailValidation()
        {
            // Arrange
            var package = new Package()
            {
                Id = 1,
                Name = null,
                Description = null,
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null,
                Price = -1,
            };

            // Act
            var validationContext = new ValidationContext(package);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(package, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
            Assert.True(validationResults.Any(vr => vr.ErrorMessage == "Please enter a name"));
            Assert.True(validationResults.Any(vr => vr.ErrorMessage == "Price must be greater than 0"));
        }

        //US6
        [Fact]
        public void PackageCreationRequiresProducts()
        {
            // Arrange
            var package = new Package()
            {
                Id = 1,
                Name = "Green Box",
                Description = "Green Box",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null,
                Price = 10,
                Products = null
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(package, new ValidationContext(package), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains("Please add at least one product to the package", validationResults.Select(r => r.ErrorMessage));
        }




    }

}
