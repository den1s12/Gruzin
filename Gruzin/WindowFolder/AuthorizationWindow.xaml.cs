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
using Gruzin.WindowFolder.AdminFolder;
using Gruzin.WindowFolder.DirectorFolder;
using Gruzin.WindowFolder.ManagerFolder;

namespace Gruzin.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void LohInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MBClass.ErrorMB("Введите логин");
                txtEmail.Focus();
            }
            else if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                passwordBox.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User.FirstOrDefault(u => u.LoginUser == txtEmail.Text);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Введен не верный логин");
                        txtEmail.Focus();
                        return;
                    }
                    if (user.PasswordUser != passwordBox.Password)
                    {
                        MBClass.ErrorMB("Введен не верный пароль");
                        passwordBox.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new MenuManagerWindow().Show();
                                Close();
                                break;
                                       case 2:
                                new MenuDirecotrWindow().Show();
                                Close();
                                break;
                            case 3:
                                new ManuAdminWindow().Show();
                                Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }

            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
