using System.Collections.ObjectModel;
using System.Linq;
using UserRoleManager_Чернышков.Classes;
using UserRoleManager_Чернышков.Context;

namespace UserRoleManager_Чернышков.ViewModels
{
    public class RoleStat
    {
        public string RoleName { get; set; } = string.Empty;
        public int UsersCount { get; set; }
    }

    public class VM_Stats : Notification
    {
        public UserRoleContext userRoleContext = new UserRoleContext();

        public int UsersCount { get; set; }
        public int RolesCount { get; set; }
        public int UsersWithoutRoleCount { get; set; }
        public string TopRoleName { get; set; } = "-";
        public int TopRoleUsersCount { get; set; }

        public ObservableCollection<RoleStat> UsersByRole { get; set; } = new ObservableCollection<RoleStat>();

        public VM_Stats()
        {
            
        }

        public void LoadStats()
        {
            UsersByRole.Clear();

            var roles = userRoleContext.Roles.ToList();
            var users = userRoleContext.Users.ToList();

            UsersCount = users.Count;
            RolesCount = roles.Count;

            var grouped = users
                .GroupBy(x => x.IdRole)
                .Select(g => new
                {
                    IdRole = g.Key,
                    Count = g.Count()
                })
                .ToList();

            foreach (var item in grouped)
            {
                var role = roles.FirstOrDefault(x => x.Id == item.IdRole);
                UsersByRole.Add(new RoleStat
                {
                    RoleName = role != null ? role.Name : "Без роли",
                    UsersCount = item.Count
                });
            }

            UsersWithoutRoleCount = users.Count(x => !roles.Any(r => r.Id == x.IdRole));

            var top = UsersByRole.OrderByDescending(x => x.UsersCount).FirstOrDefault();
            if (top != null)
            {
                TopRoleName = top.RoleName;
                TopRoleUsersCount = top.UsersCount;
            }
            else
            {
                TopRoleName = "-";
                TopRoleUsersCount = 0;
            }

            OnPropertyChanged("UsersCount");
            OnPropertyChanged("RolesCount");
            OnPropertyChanged("UsersWithoutRoleCount");
            OnPropertyChanged("TopRoleName");
            OnPropertyChanged("TopRoleUsersCount");
            OnPropertyChanged("UsersByRole");
        }

        public RealyCommand OnRefresh
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    LoadStats();
                });
            }
        }
    }
}