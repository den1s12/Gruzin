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
using Gruzin.DataFolder;

namespace Gruzin.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditCoursesStaffWindow.xaml
    /// </summary>
    public partial class EditCoursesStaffWindow : Window
    {
        CoursesStaff coursesStaff = new CoursesStaff();
        public EditCoursesStaffWindow(CoursesStaff coursesStaff)
        {
            InitializeComponent();
            DataContext = coursesStaff;
            this.coursesStaff.IdCoursesStaff = coursesStaff.IdCoursesStaff;

            CoursesCb.ItemsSource = DBEntities.GetContext()
                  .Courses.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                   .Staff.ToList();
            PaymentCb.ItemsSource = DBEntities.GetContext()
                  .Payment.ToList();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                coursesStaff = DBEntities.GetContext().CoursesStaff
                   .FirstOrDefault(u => u.IdCoursesStaff == coursesStaff.IdCoursesStaff);
                coursesStaff.IdCourses = Int32.Parse(
                    CoursesCb.SelectedValue.ToString());
                coursesStaff.IdStaff = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                coursesStaff.IdPayment = Int32.Parse(
                   PaymentCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.ListStaffPage1 != null) VariableClass.ListStaffPage1.UpdateList();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
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
