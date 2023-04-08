using AuthWindow;
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
using static MedicalCards.DAL.Entities.User;

namespace WindowsInterfaces
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private bool isEditable = false;
        private int selectedId { get; set; }

        public List<AccessType> AccessList { get; set; } = new List<AccessType> {
                    AccessType.Blocked,
                    AccessType.UnderInvestigation,
                    AccessType.Active
        };

        public AdminWindow()
        {
            InitializeComponent();
            DataContext = this;
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

                isEditable = false;
                UsersGrid.IsReadOnly = true;
                var users_list = await userService.GetAllUsers();
                UsersGrid.Visibility = Visibility.Visible;
                var users = (System.Collections.IEnumerable)users_list;
                UsersGrid.ItemsSource = users;

                EditButton.Visibility = Visibility.Visible;
                //DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void UsersGrid_Double_Click(object sender, RoutedEventArgs e)
        {
            selectedId = ((User)UsersGrid.SelectedItem).UserId;
        }

        /*
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
        */
        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isEditable)
            {
                return;
            }

            else
            {
                // Получение комбобокса, который вызвал событие
                var comboBox = sender as ComboBox;

                // Получение строки DataGrid, которой принадлежит комбобокс
                var dataGridRow = FindVisualParent<DataGridRow>(comboBox);

                // Получение объекта данных строки DataGrid
                var user = dataGridRow.DataContext as User;

                // Получение выбранного значения комбобокса
                var selectedAccessType = (AccessType)comboBox.SelectedItem;

                // Изменение свойства объекта данных на основе выбранного значения комбобокса;

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
                user.Access = (AccessType)selectedAccessType;
                var user1 = await userService.UpdateUser(user);
                MessageBox.Show("Статус аккаунта " + user1.Login.ToString() + " успешно изменён");
                
            }

        }

        private static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            isEditable = true;
            UsersGrid.IsReadOnly = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();     
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
}
