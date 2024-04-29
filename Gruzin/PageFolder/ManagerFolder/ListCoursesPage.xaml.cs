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

namespace Gruzin.PageFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListCoursesPage.xaml
    /// </summary>
    public partial class ListCoursesPage : Page
    {
        public ListCoursesPage()
        {
            Courses courses = new Courses();
            InitializeComponent();
            VariableClass.ListCoursesPage2 = this;
            UpdateList();
        }

        public void UpdateList()
        {
                        CoursesDT.ItemsSource = DBEntities.GetContext()
          .Courses.Where(u => u.NameCourses
          .StartsWith(SearchDT.Text))
          .ToList().OrderBy(u => u.NameCourses);
        }

        private void SearchDT_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
