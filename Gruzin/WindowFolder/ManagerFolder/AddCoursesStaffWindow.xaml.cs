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
    /// Логика взаимодействия для AddCoursesStaffWindow.xaml
    /// </summary>
    public partial class AddCoursesStaffWindow : Window
    {
        CoursesStaff coursesStaff = new CoursesStaff();
        public AddCoursesStaffWindow()
        {
            InitializeComponent();
            CoursesCb.ItemsSource = DBEntities.GetContext()
                   .Courses.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                   .Staff.ToList();
            PaymentCb.ItemsSource = DBEntities.GetContext()
                   .Payment.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().CoursesStaff.Add(new CoursesStaff()
            {
                IdCourses = Int32.Parse(CoursesCb.SelectedValue.ToString()),
                IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
                IdPayment = Int32.Parse(PaymentCb.SelectedValue.ToString())
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Сотрудник успешно добавлен");
            if (VariableClass.ListStaffPage1 != null) VariableClass.ListStaffPage1.UpdateList();
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
