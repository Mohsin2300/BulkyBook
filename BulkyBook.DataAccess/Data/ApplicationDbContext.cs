using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } // this wil create a table Based on the Category class/model in the models folder and it will be named Categories

        public DbSet<CoverType> CoversTypes { get; set; }

        public DbSet<Product> Products { get; set; }
    }

    //public class AAAA
    //{
    //    public AAAA(int tal) {
    //        tal = Id;
    //    }
    //    public int Id { get; set; }
    //    public int Test { get; set; }
    //}

    //public class BBBB : AAAA
    //{
    //    public BBBB() : base(5)
    //    {
            
    //    }
    //    public int MyProperty { get; set; }
        
    //}

    //public class CCCC
    //{
    //    public int MyProperty() {

    //        BBBB test = new BBBB();
    //        test.Id = 10;

    //        AAAA test2 = new AAAA(4);

    //        return 1;

    //    }
    //}
}
