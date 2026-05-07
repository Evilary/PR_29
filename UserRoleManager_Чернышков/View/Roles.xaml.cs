using System.Windows.Controls;

namespace UserRoleManager_Чернышков.View
{
    /// <summary>
    /// Логика взаимодействия для Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        public Roles(object context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
