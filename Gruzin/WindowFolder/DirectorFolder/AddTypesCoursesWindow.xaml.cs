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
    /// Логика взаимодействия для AddTypesCoursesWindow.xaml
    /// </summary>
    public partial class AddTypesCoursesWindow : Window
    {
        public AddTypesCoursesWindow()
        {
            InitializeComponent();
        }

        private void AddTypeCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().TypesOfCourses.Add(new TypesOfCourses()
            {
                NameTypeOfCourses = NameTypeCoursesTb.Text
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Курс успешно добавлен");
            Close();
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
