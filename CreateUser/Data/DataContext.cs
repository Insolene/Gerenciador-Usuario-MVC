using CreateUser.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateUser.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        { 
        }

        public DbSet<ContactModel> Contacts { get; set; }   
    }
}
