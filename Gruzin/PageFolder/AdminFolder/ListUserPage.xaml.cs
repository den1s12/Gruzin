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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gruzin.ClassFolder;
using Gruzin.DataFolder;

namespace Gruzin.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            User user = new User(); 
            InitializeComponent();
            VariableClass.ListUserPage1 = this;
            UpdateList();
        }

        public void UpdateList()
        {
            CoursesDT.ItemsSource = DBEntities.GetContext()
                .User.Where(u => u.LoginUser
                .StartsWith(SearchDT.Text))
                   .ToList().OrderBy(u => u.LoginUser);
        }
        private void SearchDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        private void DeleteCB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCB_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
