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
using AuthWindow;
using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using WindowsInterfaces;

namespace KURS
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoginTextBox.Text = "";
            this.PasswordTextBox.Clear();
            this.Hide();
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Owner = this;
            regWindow.Show();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }

            else 
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }

        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            {
                using var userService = new UserService(
                    new UserRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

                User user = await userService.Authentificate(LoginTextBox.Text, PasswordTextBox.Password);
                if(user.Access == User.AccessType.Active)
                {

                    switch (user.Role)
                    {
                        case User.RoleType.Patient:
                            {
                                this.Hide();
                                PatientWindow patientWindow = new PatientWindow();
                                patientWindow.Owner = this;
                                patientWindow.Show();
                                break;
                            }

                        case User.RoleType.Doctor:
                            {
                                this.Hide();
                                DoctorWindow doctorWindow = new DoctorWindow();
                                doctorWindow.Owner = this;
                                doctorWindow.Show();
                                break;
                            }

                        case User.RoleType.Admin:
                            {
                                this.Hide();
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.Owner = this;
                                adminWindow.Show();
                                break;
                            }
                    }
                   
                }

                else
                {
                    MessageBox.Show("Ваша учетная запись заблокирована или находится на рассмотрении!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
               
                
            }
        }
    }
}
