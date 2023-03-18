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

namespace AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
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

        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            if(false)
            {

            }

            else
            {
                MessageBoxResult result = MessageBox.Show("Учетная запись зарегистрирована!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                    Owner.Show();
                }
            }
        }
    }
}
