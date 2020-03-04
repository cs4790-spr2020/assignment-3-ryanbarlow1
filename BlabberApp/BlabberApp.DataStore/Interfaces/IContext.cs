using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore
{
    // Creating an interface for my DbContext so it can be mocked and unit tested
    public interface IContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}