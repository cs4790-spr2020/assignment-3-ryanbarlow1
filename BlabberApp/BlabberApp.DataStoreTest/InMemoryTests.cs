using BlabberApp.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_EntityIsNull()
        {
            // Arrange
            var inMemory = new InMemory<TestEntity>(new Context(null));

            // Act
            inMemory.Insert(null);

            // Assert
        }

        [TestMethod]
        public void Insert_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Add(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            inMemory.Insert(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Add(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_EntityIsNull()
        {
            // Arrange
            var inMemory = new InMemory<TestEntity>(new Context(null));

            // Act
            inMemory.Update(null);

            // Assert
        }

        [TestMethod]
        public void Update_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Update(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            inMemory.Update(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Update(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_EntityIsNull()
        {
            // Arrange
            var inMemory = new InMemory<TestEntity>(new Context(null));

            // Act
            inMemory.Delete(null);

            // Assert
        }

        [TestMethod]
        public void Delete_Success()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Remove(It.IsAny<TestEntity>()));

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(c => c.SaveChanges());

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            inMemory.Delete(new TestEntity());

            // Assert
            mockDbSet.Verify(d => d.Remove(It.IsAny<TestEntity>()), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetById_ReturnNull()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<TestEntity>>();
            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            var actual = inMemory.GetById(-1);

            // Assert
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetById_Success()
        {
            // Arrange
            var expected = new TestEntity { Id = 22, Name = "HelloWorld" };

            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.Find(22)).Returns(expected);

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            var actual = inMemory.GetById(22);

            // Assert
            mockDbSet.Verify(d => d.Find(22), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            var testEntities = new List<TestEntity> { new TestEntity {Id = 22, Name = "One"}, new TestEntity {Id = 23, Name = "Two"} }.AsQueryable();

            var mockDbSet = new Mock<DbSet<TestEntity>>();
            mockDbSet.Setup(d => d.AsQueryable()).Returns(testEntities);

            var mockContext = new Mock<IContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockDbSet.Object);

            var inMemory = new InMemory<TestEntity>(mockContext.Object);

            // Act
            var actual = inMemory.GetAll();

            // Assert
            mockDbSet.Verify(d => d.AsQueryable(), Times.Once);
            mockContext.Verify(c => c.Set<TestEntity>(), Times.Once);
            
            Assert.AreEqual(testEntities, actual);
        }
    }
}
