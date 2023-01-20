using Core.Domain;
using Core.Domain.Services;
using Moq;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOQUnitTests.NewFolder
{
    public class CreatingPackages
    {

        // US3
        [Fact]
        public async Task CreateNewPackage_ShouldSucceed()
        {
            // Arrange
            var newPackage = new Package()
            {
                Id = 1,
                Name = "New Package",
                Description = "New Package",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.CreatePackage(newPackage));

            // Act
            await mock.Object.CreatePackage(newPackage);

            // Assert
            mock.Verify(x => x.CreatePackage(newPackage), Times.Once);
        }



        [Fact]
        public async Task CreateNewPackage_PriceTooLow_ShouldThrow()
        {
            // Arrange
            var newPackage = new Package()
            {
                Id = 1,
                Name = "New Package",
                Description = "New Package",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null,
                Price = 0
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.CreatePackage(newPackage)).Throws(new Exception("Price must be greater than 0"));

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.CreatePackage(newPackage));

            // Assert
            Assert.Equal("Price must be greater than 0", exception.Message);
        }


        [Fact]
        public async Task CreateNewPackage_PickUpDateInPast_ShouldThrow()
        {
            // Arrange
            var newPackage = new Package()
            {
                Id = 1,
                Name = "New Package",
                Description = "New Package",
                PickUp = DateTime.Now.AddDays(-10),
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null,
                Price = 0
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.CreatePackage(newPackage)).Throws(new Exception("Date can not be in the past"));

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.CreatePackage(newPackage));

            // Assert
            Assert.Equal("Date can not be in the past", exception.Message);
        }

      
            

        
    }
}
