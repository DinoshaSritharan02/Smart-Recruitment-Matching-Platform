using Microsoft.EntityFrameworkCore;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets...

    }
}
