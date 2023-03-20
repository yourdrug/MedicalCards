using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
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
using WindowsInterfaces;

namespace AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public string[] roleTyping {get; set;}
        public RegistrationWindow()
        {
            InitializeComponent();
            roleTyping = new string[] { "Patient", "Doctor", "Admin" };
            DataContext = this;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Owner.Show();
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

        private void RepeatPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordTextBox.Password.Length > 0)
            {
                RepeatWatermark.Visibility = Visibility.Collapsed;
            }

            else
            {
                RepeatWatermark.Visibility = Visibility.Visible;
            }
        }

        private async void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                using var userService = new UserService(
                    new UserRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );


               /* MessageBoxResult result = MessageBox.Show("Учетная запись зарегистрирована!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                    Owner.Show();
                }*/


                if (PasswordTextBox.Password != RepeatPasswordTextBox.Password)
                {
                    MessageBox.Show("Пароли должны совпадать!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    User user = await userService.SignUp(LoginTextBox.Text, PasswordTextBox.Password, ComboBox1.Text);

                    switch (user.Role)
                    {
                        case User.RoleType.Patient:
                            {
                                this.Hide();
                                PatientRegWindow patientRegWindow = new PatientRegWindow(user);
                                patientRegWindow.Owner = this;
                                patientRegWindow.Show();
                                break;
                            }

                        case User.RoleType.Doctor:
                            {
                                this.Hide();
                                DoctorRegWindow doctorRegWindow = new DoctorRegWindow();
                                doctorRegWindow.Owner = this;
                                doctorRegWindow.Show();
                                break;
                            }

                        case User.RoleType.Admin:
                            {
                               
                                break;
                            }
                    }
                }   

            }

        }
    }
}
