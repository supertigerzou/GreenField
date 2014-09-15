using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using System.Data.Entity;

namespace GreenField.Books.Data
{
    public class BookContext : GFDbContext
    {
        public BookContext()
            : base("GFContext")
        {
            
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //dynamically load all configuration

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

        }
    }
}
