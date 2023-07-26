using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using library ; 
public class AppContext : DbContext
{
    public AppContext(){}
    public AppContext(DbContextOptions<AppContext> options)
        :base(options){}
   
    public DbSet<myitem> items {get ; set ; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {  
        optionsBuilder.UseSqlite(@"Data Source=TodoListApp.db");

    }
    
}