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
            VariableClass.ListCoursesPage1 = this;
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
            new EditCoursesWindow(CoursesDT.SelectedItem as Courses).ShowDialog();
            UpdateList();
        }

        private void DeleteCB_Click(object sender, RoutedEventArgs e)
        {
            Courses courses = CoursesDT.SelectedItem as Courses;
            if (CoursesDT.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите курс" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"курс " +
                    $"{courses.NameCourses}?"))
                {
                    DBEntities.GetContext().Courses
                        .Remove(CoursesDT.SelectedItem as Courses);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Курс удален");
                    CoursesDT.ItemsSource = DBEntities.GetContext()
                        .Courses.ToList().OrderBy(u => u.IdCourses);
                }

            }
        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCoursesWindow().Show();
        }
    }
}
