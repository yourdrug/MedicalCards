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
    /// Логика взаимодействия для PatientRegWindow.xaml
    /// </summary>
    public partial class PatientRegWindow : Window
    {
        public string[] sexTyping { get; set; }

        private User temp_user { get; set; } 

        public string[] FamilyStatusTyping { get; set; }

        public PatientRegWindow(User user)
        {
            InitializeComponent();
            temp_user = user;
            sexTyping = new string[] { "Мужской", "Женский" };
            FamilyStatusTyping = new string[] { "Женат", "Замужем", "Холост", "Не замужем", "Вдова", "Вдовец" };
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
                using var patientService = new PatientService(
                    new PatientRepository(
                        new MedicalCards.DAL.AppContext()
                        ), 
                    new AddressRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );
                Patient temp_patient = new Patient();
                Address temp_address = new Address();

                temp_patient.PatientId = temp_user.UserId;
                temp_patient.LastName = LastNameTextBox.Text;
                temp_patient.FirstName = FirstNameTextBox.Text;
                temp_patient.Patronymic = PatranomicTextBox.Text;
                temp_patient.DateOfBirth = Convert.ToDateTime(DateOfBirth.SelectedDate);
                temp_patient.PhoneNumber = PhoneTextBox.Text;
                temp_patient.Sex = SexComboBox.Text;
                temp_patient.FamilyStatus = FamilyStatusComboBox.Text;
                temp_patient.WorkPlace = WorkPlaceTextBox.Text;

                temp_address.City = CityTextBox.Text;
                temp_address.Street = StreetTextBox.Text;
                temp_address.HouseNumber = Convert.ToInt32(HouseNumTextBox.Text);
                temp_address.FlatNumber = Convert.ToInt32(FlatNumTextBox.Text);
                
                var patient = await patientService.SignAsPatient(temp_patient, temp_address);

                
                
                PatientWindow patientWindow = new PatientWindow(patient);
                patientWindow.Owner = this;
                patientWindow.Show();
                this.Close();

            }
        }
    }
}
