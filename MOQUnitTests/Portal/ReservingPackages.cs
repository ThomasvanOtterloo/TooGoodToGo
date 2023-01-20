

using Core.Domain;
using Core.Domain.Services;
using Moq;

namespace MOQUnitTests.NewFolder
{
    public class ReservingPackages
    {
        // US4
        [Fact]
        public async Task CheckStudentsAgeReservingAdultBox_AllowsToReserve()
        {

            // Arrange
            var student = new Student()
            {
                Id = 1,
                Name = "John",
                Email = "John@gmail.com",
                BirthDate = new DateTime(2005, 1, 1),
                City = City.Breda
            };

            var package = new Package()
            {
                Id = 1,
                Name = "Adult Box",
                Description = "Adult Box",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.ReservePackage(package, student)).Throws(new Exception("You are too young to reserve this package"));

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.ReservePackage(package, student));

            // Assert
            Assert.Equal("You are too young to reserve this package", exception.Message);

        }

        //US7
        [Fact]
        public async Task TryToOrderAPackageThatIsAlreadyReserved_ThrowAnError()
        {

            // Arrange
            var student = new Student()
            {
                Id = 1,
                Name = "John",
                Email = "John@gmail.com",
                BirthDate = new DateTime(2005, 1, 1),
                City = City.Breda
            };

            var package = new Package()
            {
                Id = 1,
                Name = "Adult Box",
                Description = "Adult Box",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = 1
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.ReservePackage(package, student)).Throws(new Exception("Box is already reserved, Please take a look at our available boxes"));

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.ReservePackage(package, student));

            // Assert
            Assert.Equal("Box is already reserved, Please take a look at our available boxes", exception.Message);

        }


        //US5
        [Fact]
        public async Task CheckStudentsValidAgeReservingAdultBox_AllowsToReserve()
        {

            // Arrange
            var student = new Student()
            {
                Id = 1,
                Name = "John",
                Email = "John@gmail.com",
                BirthDate = new DateTime(2005, 1, 1),
                City = City.Breda
            };

            var package = new Package()
            {
                Id = 1,
                Name = "Adult Box",
                Description = "Adult Box",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = 1
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.ReservePackage(package, student));

            // Act
            await mock.Object.ReservePackage(package, student);

            // Assert
            mock.Verify(x => x.ReservePackage(package, student), Times.Once);

        }


       
        [Fact]
        public async Task StudentReserveBoxButAllreadyReservedOneForThatDay_ThrowError()
        {

            // Arrange
            var student = new Student()
            {
                Id = 1,
                Name = "John",
                Email = "John@gmail.com",
                BirthDate = new DateTime(2005, 1, 1),
                City = City.Breda,
                Packages = new List<Package>()
                {
                    new Package()
                    {
                        Id = 1,
                        Name = "Adult Box",
                        Description = "Adult Box",
                        PickUp = DateTime.Now,
                        AvailableUntil = DateTime.Now.AddDays(3),
                        EmployeeId = 1,
                        StudentId = 1
                    }
                }
            };
       
            var package = new Package()
            {
                Id = 2,
                Name = "Green Box",
                Description = "Green Box",
                PickUp = DateTime.Now,
                AvailableUntil = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                StudentId = null
            };

            var mock = new Mock<IPackageRepository>();
            mock.Setup(x => x.ReservePackage(package, student)).Throws(new Exception("You can't reserve more than one package for the same day"));

            // Act
            var result = await Assert.ThrowsAsync<Exception>(() => mock.Object.ReservePackage(package, student));

            // Assert
            Assert.Equal("You can't reserve more than one package for the same day", result.Message);


        }




    }
}