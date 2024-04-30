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
using System.Windows.Shapes;

namespace Gruzin.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCoursesWindow.xaml
    /// </summary>
    public partial class AddCoursesWindow : Window
    {
        public AddCoursesWindow()
        {
            InitializeComponent();
            TypesCoursesCb.ItemsSource = DBEntities.GetContext()
            .TypesOfCourses.ToList();
        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Courses.Add(new Courses()
            {
                NameCourses = NameCoursesTb.Text,
                CountCoursesPayment = Int32.Parse(CountPaymentTb.Text),
                IdTypeOfCourses = Int32.Parse(TypesCoursesCb.SelectedValue.ToString())
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Курс успешно добавлен");
            if (VariableClass.ListCoursesPage1 != null) VariableClass.ListCoursesPage1.UpdateList();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void AddTypesOfCourses_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AddTypesCoursesWindow().ShowDialog();
        }
    }
}
