using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Controllers;
using MobileStore.Models;
using Xunit;

namespace MobileStoreTests
{
    public class RegistrationControllerTest : BaseTest
    {

        private readonly RegistrationController _target;
        private readonly User _user = new User { Id = 1 };

        public RegistrationControllerTest()
        {
            _target = new RegistrationController(DbContext.Object);
            var usersList = new List<User>() { _user };
            var dbUsersList = MockDbSet(usersList);
            DbContext.Setup(x => x.Users).Returns(dbUsersList);
        }

        [Fact]
        public void GetRegistration()
        {
            // Act
            var result = _target.Registration();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.ViewData);
        }

        [Fact]
        public void Register()
        {
            // Act
            var result = _target.Register();

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Registration", viewResult.ActionName);
        }

        [Fact]
        public void PostRegistration()
        {
            // Act
            var result = _target.Registration(_user);

            // Assert
            Assert.Equal("Thanks for registration", result);
        }

    }
}
