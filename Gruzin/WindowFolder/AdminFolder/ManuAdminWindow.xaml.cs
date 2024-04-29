using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gruzin.ClassFolder;

namespace Gruzin.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ManuAdminWindow.xaml
    /// </summary>
    public partial class ManuAdminWindow : Window
    {
        public ManuAdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.AdminFolder.ListUserPage());
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
        }

        private void ListUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.AdminFolder.ListUserPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();      
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
