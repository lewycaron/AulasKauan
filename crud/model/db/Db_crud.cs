using Microsoft.EntityFrameworkCore;

namespace crud.model.db{
    class Db_crud : DbContext  {
        public Db_crud(DbContextOptions database): base(database) {

        }
        
        
        public DbSet<Refrigerante> Refrigerante{ get; set; }
        public DbSet<Pizzas> Pizzas{ get; set; }
    }

}