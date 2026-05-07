using System.Windows.Controls;

namespace UserRoleManager_Чернышков.View
{
    /// <summary>
    /// Логика взаимодействия для Stats.xaml
    /// </summary>
    public partial class Stats : Page
    {
        public Stats(object context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
