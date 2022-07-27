using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=localhost;Port=3306;DataBase=dbAPI2;Uid=root;Pwd=mudar@123";
            //var connectionString = "Server=.\\SQLEXPRESS2017;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            //optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
