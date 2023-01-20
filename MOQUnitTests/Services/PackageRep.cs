using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Services;
using Infrastructure;
using Moq;

namespace MOQUnitTests.Domain
{
    public class PackageRepTest
    {
        //US8
        [Fact]
        public void GetPackagesByFilter_ReturnsExpectedPackages()
        {
            // Arrange
            var testPackages = new List<Package>()
                {
                    new Package() { Id = 1, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Breakfast, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },
                    new Package() { Id = 2, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Dinner, StudentId = null ,Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                    new Package() { Id = 3, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Breakfast, StudentId = null, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                    new Package() { Id = 4, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Dinner, StudentId = 1 , Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },

                };
            var mockRepo = new Mock<IPackageRepository>();

            mockRepo.Setup(x => x.GetPackagesByFilter(City.Breda, Meal.Dinner, "Available", null))
            .Returns(testPackages.Where(p => p.Employee.Canteen.City == City.Breda &&
                                            p.Meal == Meal.Dinner &&
                                            p.StudentId == null));

            // Act
            var result = mockRepo.Object.GetPackagesByFilter(City.Breda, Meal.Dinner, "Available", null);

            // Assert
            Assert.Single(result);
            Assert.Equal(2, result.First().Id);
        }

        //US2
        [Fact]
        public void GetPackagesByFilter_ReturnsExpectedPackagesWithCanteenFilter()
        {

            // Arrange
            var testPackages = new List<Package>()
            {
                new Package() { Id = 1, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda , LocationName = "LA" , Id = 1}}, Meal = Meal.Breakfast, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },
                new Package() { Id = 2, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda ,LocationName = "LA", Id = 1 } }, Meal = Meal.Dinner, StudentId = null ,Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                new Package() { Id = 3, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg,LocationName = "LD", Id = 2 } }, Meal = Meal.Breakfast, StudentId = null, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                new Package() { Id = 4, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg,LocationName = "LD", Id = 2  } }, Meal = Meal.Dinner, StudentId = 1 , Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },

            };

            var mockRepo = new Mock<IPackageRepository>();

            mockRepo.Setup(x => x.GetPackagesByFilter(null, null, null, 1))
            .Returns(testPackages.Where(p => p.Employee.Canteen.LocationName == "LA"));

            // Act
            var result = mockRepo.Object.GetPackagesByFilter(null, null, null, 1);

            // Assert
            Assert.Equal(2, result.Count());
        }
        
        //US1
        [Fact]
        public void GetAllReservedPackagesByStudent_ReturnsExpectedPackages()
        {
            // Arrange
            var testStudent = new Student() { Id = 1 };
            var testPackages = new List<Package>()
            {
            new Package() { Id = 1, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Breakfast, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },
            new Package() { Id = 2, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Dinner, StudentId = null, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
            new Package() { Id = 3, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Breakfast, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
            new Package() { Id = 4, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Dinner, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },

            };
            
            var mockRepo = new Mock<IPackageRepository>();

            mockRepo.Setup(x => x.GetAllReservedPackagesByStudent(testStudent))
                .Returns(testPackages.Where(p => p.StudentId == testStudent.Id)
                .OrderBy(p => p.PickUp));

            // Act
            var result = mockRepo.Object.GetAllReservedPackagesByStudent(testStudent);

            // Assert
            Assert.Equal(3, result.Count());
           
        }



        [Fact]
        public void GetAllUnreservedPackages_ReturnsExpectedPackages()
        {
            // Arrange
            var testPackages = new List<Package>()
                {
                new Package() { Id = 1, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Breakfast, StudentId = 1, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },
                new Package() { Id = 2, Employee = new Employee() { Canteen = new Canteen() { City = City.Breda } }, Meal = Meal.Dinner, StudentId = null ,Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                new Package() { Id = 3, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Breakfast, StudentId = null, Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3)},
                new Package() { Id = 4, Employee = new Employee() { Canteen = new Canteen() { City = City.Tilburg } }, Meal = Meal.Dinner, StudentId = 1 , Price = 10, PickUp = DateTime.Now, AvailableUntil = DateTime.Now.AddDays(3) },
                };



            var mockRepo = new Mock<IPackageRepository>();

            mockRepo.Setup(x => x.GetAllAvailablePackages())
            .Returns(testPackages.Where(p => p.StudentId == null));

            // Act
            var result = mockRepo.Object.GetAllAvailablePackages();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.First().Id);
        }
    }

}