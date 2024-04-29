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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        Staff staff = new Staff();
        public EditStaffWindow(Staff staff)
        {
            InitializeComponent();
            if (staff != null) selectedFileName = "фото есть";
            DataContext = staff;

            this.staff.IdStaff = staff.IdStaff;

            GenderCb.ItemsSource = DBEntities.GetContext()
                   .Gender.ToList();
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
        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staff = DBEntities.GetContext().Staff
                   .FirstOrDefault(u => u.IdStaff == staff.IdStaff);
                staff.FIOStaff = FIOTb.Text;
                staff.MobilePhoneStaff = NumberPhoneStaffTb.Text;
                staff.EmailStaff = EmailTb.Text;
                staff.IdGender = Int32.Parse(
                    GenderCb.SelectedValue.ToString());
                if (selectedFileName != "фото есть")
                    staff.PhotoStaff = ImageClass.ConvertImageToByteArray(selectedFileName);
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                if (VariableClass.ListStaffPage != null) VariableClass.ListStaffPage.UpdateList();
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
