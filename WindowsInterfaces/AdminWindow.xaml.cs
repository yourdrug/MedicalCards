using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WindowsInterfaces
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private int selectedId { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
        }

        private async void Users_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                using var userService = new UserService(
                    new UserRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new PatientRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new DoctorRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

                var users_list = await userService.GetAllUsers();
                UsersGrid.Visibility = Visibility.Visible;
                var users = (System.Collections.IEnumerable)users_list;
                UsersGrid.ItemsSource = users;

            }
        }

        private void UsersGrid_Double_Click(object sender, RoutedEventArgs e)
        {
            selectedId = ((User)UsersGrid.SelectedItem).UserId;
        }

        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                using var userService = new UserService(
                    new UserRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new PatientRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new DoctorRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

                if (UsersGrid.Visibility == Visibility.Visible)
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить пользователя " + (((User)UsersGrid.SelectedItem).Login).ToString() + "", "INFO", MessageBoxButton.YesNo);
                    if(result == MessageBoxResult.Yes)
                    {
                        User user = await userService.DeleteById(selectedId);
                        MessageBox.Show("Пользователь " + user.Login.ToString() + " успешно удалён.");
                    }
                    
                    else
                    {
                        
                    }
                   
                }
            }
        }
    }
}
