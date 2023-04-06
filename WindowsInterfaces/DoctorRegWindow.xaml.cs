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

namespace WindowsInterfaces
{
    /// <summary>
    /// Логика взаимодействия для DoctorRegWindow.xaml
    /// </summary>
    public partial class DoctorRegWindow : Window
    {
        public string[] sexTyping { get; set; }

        private User temp_user { get; set; }

        public DoctorRegWindow(User user)
        {
            InitializeComponent();
            temp_user = user;
            sexTyping = new string[] { "Мужской", "Женский" };
            DataContext = this;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
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

                userService.CancelSignUp(temp_user);
                Owner.Show();
                this.Close();
            }
        }

        private async void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                using var doctorService = new DoctorService(
                    new DoctorRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AddressRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );
                Doctor temp_doctor = new Doctor();
                Address temp_address = new Address();

                temp_doctor.DoctorId = temp_user.UserId;
                temp_doctor.LastName = LastNameTextBox.Text;
                temp_doctor.FirstName = FirstNameTextBox.Text;
                temp_doctor.Patronymic = PatranomicTextBox.Text;
                temp_doctor.DateOfBirth = Convert.ToDateTime(DateOfBirth.SelectedDate);
                temp_doctor.PhoneNumber = PhoneTextBox.Text;
                temp_doctor.Sex = SexComboBox.Text;

                temp_address.City = CityTextBox.Text;
                temp_address.Street = StreetTextBox.Text;
                temp_address.HouseNumber = Convert.ToInt32(HouseNumTextBox.Text);
                temp_address.FlatNumber = Convert.ToInt32(FlatNumTextBox.Text);

                var doctor = await doctorService.SignAsDoctor(temp_doctor, temp_address);


                this.Close();

                AddQualificationWindow newWin = new AddQualificationWindow(doctor);
                newWin.Show();

            }
        }

    }
}
