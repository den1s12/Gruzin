using Gruzin.ClassFolder;
using Gruzin.DataFolder;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Gruzin.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditCoursesWindow.xaml
    /// </summary>
    public partial class EditCoursesWindow : Window
    {
        Courses courses = new Courses();
        public EditCoursesWindow(Courses courses)
        {
            InitializeComponent();
            DataContext = courses;
            this.courses.IdCourses = courses.IdCourses;

            TypesCoursesCb.ItemsSource = DBEntities.GetContext()
                .TypesOfCourses.ToList();
        }

        private void EditCourseBtn_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    courses = DBEntities.GetContext().Courses
                       .FirstOrDefault(u => u.IdCourses == courses.IdCourses);
                    courses.NameCourses = NameCoursesTb.Text;
                    courses.IdTypeOfCourses = Int32.Parse(
                       TypesCoursesCb.SelectedValue.ToString());
                    UpdateList();    
                //courses.CountCoursesPayment = Convert.ToString(CountPaymentTb.Text);

                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно отредактированы");
                    if (VariableClass.ListCoursesPage1 != null) VariableClass.ListCoursesPage1.UpdateList();
                    Close();
                }
                catch (Exception ex)
                {
                }          
        }
        public void UpdateList()
        {
            try
            {
                string input = CountPaymentTb.Text.Trim();
                input = input.Replace(",", ".");

                courses.CountCoursesPayment = decimal.Parse(input);
            }
            catch (Exception ex)
            {
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
