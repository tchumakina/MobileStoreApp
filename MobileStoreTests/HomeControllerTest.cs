using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Controllers;
using MobileStore.Models;
using Xunit;

namespace MobileStoreTests
{
    public class HomeControllerTest : BaseTest
    {
        private readonly HomeController _target;
        private readonly Order _order = new Order {PhoneId = 1};
        private readonly Order _emptyOrder = new Order();
        private readonly Phone _expiredPhone = new Phone {Id = 567, ReleaseYear = 1989};

        public HomeControllerTest()
        {
            _target = new HomeController(DbContext.Object);
            var ordersList = new List<Order> {_order, _emptyOrder};
            var dbOrdersList = MockDbSet(ordersList);
            var phonesList = MockDbSet(new List<Phone> {new Phone {Id = 123}, _expiredPhone});
            DbContext.Setup(x => x.Orders).Returns(dbOrdersList);
            DbContext.Setup(x => x.Phones).Returns(phonesList);
        }

        [Fact]
        public void GetBuyTest()
        {
            // Act
            var result = _target.Buy(_order.PhoneId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Single(viewResult.ViewData);
        }

        [Fact]
        public void PostBuyTest()
        {
            // Act
            var result = _target.Buy(_order);

            // Assert
            Assert.Equal("Thanks", result);
        }

        [Fact]
        public void PrivacyPolicyTest()
        {
            // Act
            var result = _target.PrivacyPolicy();

            // Assert
            Assert.Equal("Very important privacy policy!", result);
        }

        [Fact]
        public void IndexTest()
        {
            // Act
            var result = _target.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Phone>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void BuyPhoneWithNullIdTest()
        {
            // Act
            var result = _target.Buy(_emptyOrder.PhoneId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Phone>>(viewResult.ViewData.Model);
            Assert.Single(model);
        }

        [Fact]
        public void BuyExpiredPhoneTest()
        {
            // Act
            var result = _target.Buy(_expiredPhone.Id);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ExpiredOrder", viewResult.ActionName);
        }

        [Fact]
        public void ExpiredOrderTest()
        {
            // Act
            var result = _target.ExpiredOrder();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.ViewData);
        }
    }
}