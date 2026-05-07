using System.Collections.ObjectModel;
using System.Linq;
using UserRoleManager_Чернышков.Classes;
using UserRoleManager_Чернышков.Context;
using UserRoleManager_Чернышков.Models;
using System.Windows;

namespace UserRoleManager_Чернышков.ViewModels
{
    public class VM_Users : Notification
    {
        public UserRoleContext userRoleContext = new UserRoleContext();

        public ObservableCollection<Users> Users { get; set; }
        public ObservableCollection<Roles> Roles { get; set; }

        public VM_Users()
        {
            Users = new ObservableCollection<Users>();
            Roles = new ObservableCollection<Roles>();
            ReloadData();
        }

        public void ReloadData()
        {
            Users.Clear();
            Roles.Clear();

            var roles = userRoleContext.Roles.OrderBy(x => x.Name).ToList();
            var users = userRoleContext.Users.OrderBy(x => x.FIO).ToList();

            foreach (var role in roles)
                Roles.Add(role);

            foreach (var user in users)
            {
                user.Role = roles.FirstOrDefault(r => r.Id == user.IdRole);
                Users.Add(user);
            }

            OnPropertyChanged("Users");
            OnPropertyChanged("Roles");
        }

        public RealyCommand OnAddUser
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (Roles.Count == 0)
                    {
                        MessageBox.Show("Сначала добавьте хотя бы одну роль.", "Предупреждение");
                        return;
                    }

                    Users newUser = new Users()
                    {
                        FIO = "Новый пользователь",
                        Login = "new_login",
                        IdRole = Roles.First().Id
                    };

                    userRoleContext.Users.Add(newUser);
                    userRoleContext.SaveChanges();

                    newUser.Role = userRoleContext.Roles.FirstOrDefault(x => x.Id == newUser.IdRole);
                    Users.Add(newUser);
                });
            }
        }

        public RealyCommand OnDeleteUser
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Users? user = obj as Users;
                    if (user == null) return;

                    Users? oldUser = userRoleContext.Users.FirstOrDefault(x => x.Id == user.Id);
                    if (oldUser != null)
                    {
                        userRoleContext.Users.Remove(oldUser);
                        userRoleContext.SaveChanges();
                    }

                    Users.Remove(user);
                });
            }
        }

        public RealyCommand OnSaveUser
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Users? user = obj as Users;
                    if (user == null) return;

                    Users? oldUser = userRoleContext.Users.FirstOrDefault(x => x.Id == user.Id);
                    if (oldUser == null) return;

                    oldUser.FIO = user.FIO;
                    oldUser.Login = user.Login;
                    oldUser.IdRole = user.IdRole;

                    user.Role = userRoleContext.Roles.FirstOrDefault(x => x.Id == user.IdRole);

                    userRoleContext.SaveChanges();
                });
            }
        }
    }
}