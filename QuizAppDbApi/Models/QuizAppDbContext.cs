using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizAppDbApi.Models
{
  public class QuizAppDbContext : DbContext
  {
    public QuizAppDbContext (DbContextOptions<QuizAppDbContext> options) : base(options)
    {
    }
    public DbSet<qa_users> Qa_users { get; set; }
    public DbSet<qa_class> Qa_class { get; set; }
    public DbSet<qa_questions> Qa_questions { get; set; }
  }
}
