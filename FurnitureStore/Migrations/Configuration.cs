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

            //manager.Create(new ApplicationRole { Name = "Admin", Description = "����� ���������������� �������" });
            //manager.Create(new ApplicationRole { Name = "FurnitureAdmin", Description = "����� ���������������� �����������" });
            //manager.Create(new ApplicationRole { Name = "CanEditFurtiture", Description = "����� ��������� ������ ����������� � ��������� �����������" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteFurtiture", Description = "����� ��������� ������ ����������� � �������� �����������" });
            //manager.Create(new ApplicationRole { Name = "ProducerAdmin", Description = "����� ���������������� ��������������" });
            //manager.Create(new ApplicationRole { Name = "CanEditProducer", Description = "����� ��������� ������ �������������� � ��������� ��������������" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteProducer", Description = "����� ��������� ������ �������������� � �������� ��������������" });
            //manager.Create(new ApplicationRole { Name = "UserAdmin", Description = "����� ���������������� �������������" });
            //manager.Create(new ApplicationRole { Name = "CanEditUser", Description = "����� ��������� ������ ������������� � ��������� �������������" });
            //manager.Create(new ApplicationRole { Name = "CanDeleteUser", Description = "����� ��������� ������ ������������� � �������� �������������" });
        }
    }
}
