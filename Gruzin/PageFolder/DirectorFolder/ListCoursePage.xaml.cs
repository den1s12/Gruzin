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

namespace Gruzin.PageFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListCoursePage.xaml
    /// </summary>
    public partial class ListCoursePage : Page
    {
        public ListCoursePage()
        {
            Courses courses = new Courses();
            InitializeComponent();
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

        private void EditCB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteCB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
