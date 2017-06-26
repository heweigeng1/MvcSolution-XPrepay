using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Text;
using Xprepay.Data.Entities;

namespace Xprepay.Data
{
    public class XprepayDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleRL> UserRoleRLs { get; set; }
        public DbSet<Area> Areas { get; set; }

        public DbSet<Address> Addresses{get;set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Commodity> Commoditys { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<UserDistributorRL> UserDistributorRLs { get; set; }
        public DbSet<Dictionary> Dictionarys { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public XprepayDbContext():base("name=XprepayDbContext")//这里根据配置文件连接数据库
        {
            Database.SetInitializer(new Init());//创建数据库
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mappings = GetType().Assembly.GetInheritedTypes(typeof(EntityTypeConfiguration<>));//这里获取所有entity
            foreach (var mapping in mappings)
            {
                dynamic instance = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(instance);
            }
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["XprepayDbContext"].ConnectionString;
        }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var item in error.ValidationErrors)
                    {
                        sb.AppendLine(item.PropertyName + ": " + item.ErrorMessage);
                    }
                }
                Logger.Error("SaveChanges.DbEntityValidation", ex.GetAllMessages() + sb);
                throw;
            }
        }
    }
}
