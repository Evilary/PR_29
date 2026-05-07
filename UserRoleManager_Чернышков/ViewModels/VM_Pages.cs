using UserRoleManager_Чернышков.Classes;

namespace UserRoleManager_Чернышков.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Users vm_users = new VM_Users();
        public VM_Roles vm_roles = new VM_Roles();
        public VM_Stats vm_stats = new VM_Stats();

        public RealyCommand OnOpenUsers
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init!.frame.Navigate(new View.Users(vm_users));
                });
            }
        }

        public RealyCommand OnOpenRoles
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init!.frame.Navigate(new View.Roles(vm_roles));
                });
            }
        }

        public RealyCommand OnOpenStats
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    vm_stats.LoadStats();
                    MainWindow.init!.frame.Navigate(new View.Stats(vm_stats));
                });
            }
        }
    }
}