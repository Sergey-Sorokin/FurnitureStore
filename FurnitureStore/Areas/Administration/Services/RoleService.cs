using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureStore.Areas.Administration.ViewModels;
using FurnitureStore.Areas.Administration.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using NLog;

namespace FurnitureStore.Areas.Administration.Services {
    public class RoleService : IDisposable {

        private ApplicationRoleManager roleManager;

        private ApplicationUserManager userManager;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public RoleService(ApplicationRoleManager roleManager, ApplicationUserManager userManager) {
            logger.Info("Start");
            this.roleManager = roleManager;
            logger.Debug("roleManager: {0}", roleManager);
            this.userManager = userManager;
            logger.Debug("userManager: {0}", userManager);
            logger.Info("End");
        }

        public async Task<AccountRolesViewModel> GetUserRolesAsync(ApplicationUser user) {
            try {
                logger.Info("Start");
                var accountRoles = new List<AccountRolesViewModel.AccountRole>();
                foreach (ApplicationRole role in await roleManager.Roles.ToListAsync()) {
                    accountRoles.Add(new AccountRolesViewModel.AccountRole {
                        Name = role.Name,
                        Description = role.Description,
                        Checked = await userManager.IsInRoleAsync(user.Id, role.Name)
                    });
                }

                logger.Info("End");
                return new AccountRolesViewModel {
                    User = user,
                    Roles = accountRoles
                };
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        public async Task<IdentityResult> ChangeUserRolesAsync(ApplicationUser user, AccountRolesViewModel model) {
            IdentityResult result = null;
            try {
                logger.Info("Start");
                logger.Info("User Id: {0}", user.Id);
                logger.Debug("Change UserName from {0} to {1}", user.UserName, model.User.UserName);
                user.UserName = model.User.UserName;
                logger.Debug("Change PhoneNumber from {0} to {1}", user.PhoneNumber, model.User.PhoneNumber);
                user.PhoneNumber = model.User.PhoneNumber;
                logger.Debug("Change Email from {0} to {1}", user.Email, model.User.Email);
                user.Email = model.User.Email;

                result = await userManager.UpdateAsync(user);
                logger.Debug("Update result: {0}", result.Succeeded);
                if (result.Succeeded) {
                    foreach (var role in await userManager.GetRolesAsync(user.Id)) {
                        logger.Debug("User role: {0}", role);
                        result = await userManager.RemoveFromRoleAsync(user.Id, role);
                        logger.Debug("RemoveFromRole result: {0}", result.Succeeded);
                        if (!result.Succeeded)
                            return result;
                    }

                    result = await userManager.AddToRolesAsync(user.Id, model.Roles.Where(x => x.Checked).Select(x => x.Name).ToArray());
                    logger.Debug("AddToRoles result: {0}", result.Succeeded);
                }

                logger.Debug("return result: {0}", result.Succeeded);
                return result;
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                // TODO: освободить управляемое состояние (управляемые объекты).
            }
        }

        public void Dispose() {
            Dispose(true);
        }
    }
}