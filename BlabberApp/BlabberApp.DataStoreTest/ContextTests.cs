using BlabberApp.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class ContextTests
    {
        [TestMethod]
        public void OnModelCreating()
        {
            // Arrange
            var modelBuilder = new ModelBuilder(new ConventionSet());
            var expectedModelBuilder = modelBuilder;
            expectedModelBuilder.ApplyConfiguration(new BlabConfiguration());
            expectedModelBuilder.ApplyConfiguration(new UserConfiguration());

            var context = new Context(new Microsoft.EntityFrameworkCore.DbContextOptions<Context>());

            // Act
            context.InternalOnModelCreating(modelBuilder);

            // Assert
            Assert.AreEqual(expectedModelBuilder, modelBuilder);
        }
    }
}