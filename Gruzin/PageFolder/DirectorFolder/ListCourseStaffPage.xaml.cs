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
using Gruzin.WindowFolder.ManagerFolder;

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
            if (StAFFT.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                try
                {
                    new EditCoursesStaffWindow(StAFFT.SelectedItem as CoursesStaff).ShowDialog();
                    UpdateList();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void DeleteCM_Click(object sender, RoutedEventArgs e)
        {
            CoursesStaff coursesStaff = StAFFT.SelectedItem as CoursesStaff;
            if (StAFFT.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"сотрудника " +
                    $"{coursesStaff.IdCourses}?"))
                {
                    DBEntities.GetContext().CoursesStaff
                        .Remove(StAFFT.SelectedItem as CoursesStaff);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Сотрудник удален");
                    StAFFT.ItemsSource = DBEntities.GetContext()
                        .CoursesStaff.ToList().OrderBy(u => u.IdCourses);
                }

            }
        }

        private void AddCourseStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCoursesStaffWindow().Show();
        }
    }
}
