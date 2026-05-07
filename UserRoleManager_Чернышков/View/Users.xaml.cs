using System.Windows.Controls;

namespace UserRoleManager_Чернышков.View
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users(object context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}

