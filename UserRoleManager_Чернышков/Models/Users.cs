using UserRoleManager_Чернышков.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleManager_Чернышков.Models
{
    public class Users : Notification
    {
        public int Id { get; set; }

        private string fio = string.Empty;
        public string FIO
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }

        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public int IdRole { get; set; }

        public Roles? Role { get; set; }

        [Schema.NotMapped]
        public string RoleName
        {
            get { return Role != null ? Role.Name : "Без роли"; }
        }
    }
}