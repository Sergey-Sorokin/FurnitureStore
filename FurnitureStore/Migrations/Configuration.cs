namespace FurnitureStore.Migrations {
    using Areas.Administration.Models;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            //foreach (var role in manager.Roles.ToList()) {
            //    manager.Delete(role);
            //}

            //manager.Create(new ApplicationRole { Name = "Admin", Description = "ѕраво админстрировани€ портала" });
            //manager.Create(new ApplicationRole { Name = "FurnitureAdmin", Description = "ѕраво админстрировани€ предложений" });
            //manager.Create(new ApplicationRole { Name = "CanEditFurtiture", Description = "ѕраво просмотра списка предложений и изменени€ предложений" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteFurtiture", Description = "ѕраво просмотра списка предложений и удалени€ предложений" });
            //manager.Create(new ApplicationRole { Name = "ProducerAdmin", Description = "ѕраво админстрировани€ производителей" });
            //manager.Create(new ApplicationRole { Name = "CanEditProducer", Description = "ѕраво просмотра списка производителей и изменени€ производителей" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteProducer", Description = "ѕраво просмотра списка производителей и удалени€ производителей" });
            //manager.Create(new ApplicationRole { Name = "UserAdmin", Description = "ѕраво админстрировани€ пользователей" });
            //manager.Create(new ApplicationRole { Name = "CanEditUser", Description = "ѕраво просмотра списка пользователей и изменени€ пользователей" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteUser", Description = "ѕраво просмотра списка пользователей и удалени€ пользователей" });
        }
    }
}
