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
using Microsoft.Win32;

namespace Gruzin.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        Staff staff = new Staff();
        public AddStaffWindow()
        {
            InitializeComponent();
            GenderCb.ItemsSource = DBEntities.GetContext()
              .Gender.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            DBEntities.GetContext().Staff.Add(new Staff()
            {
                FIOStaff = FIOTb.Text,
                MobilePhoneStaff = NumberPhoneStaffTb.Text,
                EmailStaff = EmailTb.Text,
                IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName)
            });
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Сотрудник успешно добавлен");
            if (VariableClass.ListStaffPage != null) VariableClass.ListStaffPage.UpdateList();
            Close();
        }

        private void LoadImBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
        string selectedFileName = "";
        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(staff.PhotoStaff);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
