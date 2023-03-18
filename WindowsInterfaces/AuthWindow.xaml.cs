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
                if (user.Role == User.RoleType.Admin)
                {
                    this.Hide();
                    AccountWindow accountWindow = new AccountWindow();
                    accountWindow.Show();
                }
                
            }
        }
    }
}
