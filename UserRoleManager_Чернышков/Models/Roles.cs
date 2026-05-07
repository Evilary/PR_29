using UserRoleManager_Чернышков.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleManager_Чернышков.Models
{
    public class Roles : Notification
    {
        public int Id { get; set; }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [Schema.NotMapped]
        public string RoleInfo
        {
            get { return $"Роль: {Name}"; }
        }
    }
}