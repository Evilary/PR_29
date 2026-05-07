using System.Windows;
using UserRoleManager_Чернышков.ViewModels;

namespace UserRoleManager_Чернышков
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            DataContext = new VM_Pages();

            var vm = DataContext as VM_Pages;
            frame.Navigate(new View.Users(vm!.vm_users));
        }
    }
}