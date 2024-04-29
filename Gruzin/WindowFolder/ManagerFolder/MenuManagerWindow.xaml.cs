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

namespace Gruzin.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuManagerWindow.xaml
    /// </summary>
    public partial class MenuManagerWindow : Window
    {
        public MenuManagerWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListStaffPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ListStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListStaffPage());
        }

        private void ListCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.ManagerFolder.ListCoursesPage());
        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCoursesStaffWindow().Show();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
