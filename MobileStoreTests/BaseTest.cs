using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;
using Moq;

namespace MobileStoreTests
{
    public class BaseTest
    {

        protected readonly Mock<IDbContext> DbContext;

        public BaseTest()
        {
            DbContext = new Mock<IDbContext>();
        }

        protected static DbSet<T> MockDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            var queryableList = list.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return dbSetMock.Object;
        }

    }
}
