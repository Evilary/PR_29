using System.Collections.ObjectModel;
using System.Linq;
using UserRoleManager_Чернышков.Classes;
using UserRoleManager_Чернышков.Context;
using UserRoleManager_Чернышков.Models;

namespace UserRoleManager_Чернышков.ViewModels
{
    public class VM_Roles : Notification
    {
        public UserRoleContext userRoleContext = new UserRoleContext();

        public ObservableCollection<Roles> Roles { get; set; }

        public VM_Roles() =>
            Roles = new ObservableCollection<Roles>(userRoleContext.Roles.OrderBy(x => x.Name));

        public RealyCommand OnAddRole
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Roles newRole = new Roles()
                    {
                        Name = "Новая роль"
                    };

                    Roles.Add(newRole);
                    userRoleContext.Roles.Add(newRole);
                    userRoleContext.SaveChanges();
                });
            }
        }

        public RealyCommand OnDeleteRole
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Roles? role = obj as Roles;
                    if (role == null) return;

                    userRoleContext.Roles.Remove(role);
                    Roles.Remove(role);
                    userRoleContext.SaveChanges();
                });
            }
        }
    }
}