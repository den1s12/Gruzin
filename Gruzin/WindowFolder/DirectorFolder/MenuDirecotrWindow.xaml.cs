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

namespace Gruzin.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuDirecotrWindow.xaml
    /// </summary>
    public partial class MenuDirecotrWindow : Window
    {
        public MenuDirecotrWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListStaffPage());
        }

        private void ListCourseStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListCoursePage());
        }

        private void ListCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListCourseStaffPage());
        }

        private void ListStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListStaffPage());
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
