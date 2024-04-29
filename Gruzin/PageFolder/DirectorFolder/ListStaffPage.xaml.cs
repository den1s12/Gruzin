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
using Gruzin.WindowFolder.DirectorFolder;
using Gruzin.WindowFolder.ManagerFolder;

namespace Gruzin.PageFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListStaffPage.xaml
    /// </summary>
    public partial class ListStaffPage : Page
    {
        Staff staff = new Staff();
        public ListStaffPage()
        {
            InitializeComponent();
            VariableClass.ListStaffPage = this;
            UpdateList();
        }

        public void UpdateList()
        {
            ListStaffLb.ItemsSource = DBEntities.GetContext()
          .Staff.Where(u => u.FIOStaff
          .StartsWith(SearchDT.Text))
          .ToList().OrderBy(u => u.FIOStaff);
        }
        private void SearchDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void EditEM_Click(object sender, RoutedEventArgs e)
        {
            new EditStaffWindow(ListStaffLb.SelectedItem as Staff).ShowDialog();
            UpdateList();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddStaffWindow().Show();
        }
    }
}
