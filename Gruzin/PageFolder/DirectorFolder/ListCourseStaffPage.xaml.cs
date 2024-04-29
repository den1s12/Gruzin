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
using Gruzin.DataFolder;

namespace Gruzin.PageFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListCourseStaffPage.xaml
    /// </summary>
    public partial class ListCourseStaffPage : Page
    {
        public ListCourseStaffPage()
        {
            CoursesStaff coursesStaff = new CoursesStaff();
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            StAFFT.ItemsSource = DBEntities.GetContext()
          .CoursesStaff.Where(u => u.Staff.FIOStaff
          .StartsWith(SearchDT.Text))
          .ToList().OrderBy(u => u.Staff.FIOStaff);
        }
        private void SearchDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void EditCM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCourseStaffBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
