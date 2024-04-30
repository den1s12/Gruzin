using Gruzin.ClassFolder;
using Gruzin.DataFolder;
using Gruzin.PageFolder.AdminFolder;
using System;
using System.Collections;
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

namespace Gruzin.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User user = new User();
        public EditUserWindow(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user.IdUser = user.IdUser;

            RoleCB.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = DBEntities.GetContext().User
                   .FirstOrDefault(u => u.IdUser == user.IdUser);
                user.LoginUser = LoginTb.Text;
                user.PasswordUser = PasswordTb.Text;
                user.IdRole = Int32.Parse(
                   RoleCB.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.ListUserPage1 != null) VariableClass.ListUserPage1.UpdateList();
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
