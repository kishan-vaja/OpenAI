using Microsoft.EntityFrameworkCore;

namespace OpenAI.Models
{
    public class GenAIToolsDbContext : DbContext
    {
        public GenAIToolsDbContext(DbContextOptions<GenAIToolsDbContext> options) : base(options)
        {

        }
        public DbSet<RegitrationModel> RegitrationSet { get; set; }
        public DbSet<GenAIToolsModel> DbSet { get; set; }
    }
}
