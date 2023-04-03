using AuthWindow;
using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Логика взаимодействия для AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        private readonly Doctor temp_doctor;

        private Patient temp_patient { get; set; }
        private int selectedId { get; set; }

        public AddAppointmentWindow(Doctor doctor)
        {
            temp_patient = new Patient();
            temp_doctor = doctor;
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddMedicinesWindow temp = new AddMedicinesWindow();
            this.Hide();
            temp.Owner = this;
            temp.Show();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow(temp_doctor);
            doctorWindow.Show();
            this.Close();
        }

        private async void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            using var patientService = new PatientService(
                       new PatientRepository(
                           new MedicalCards.DAL.AppContext()
                           ),
                       new AddressRepository(
                           new MedicalCards.DAL.AppContext()
                           )
                       );

            var patients_list = await patientService.GetAll();
            PatientsGrid.ItemsSource = (System.Collections.IEnumerable)patients_list;
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            using var POMS = new PrescriptionOfMedicinesService(
                   new PrescriptionOfMedicinesRepository(
                       new MedicalCards.DAL.AppContext()
                       ),
                   new AppointmentRepository(
                       new MedicalCards.DAL.AppContext()
                       ),
                   new MedicinesRepository(
                       new MedicalCards.DAL.AppContext()
                       )
                   );

            var temp_medicines = POMS.AddMedicines(Data.medicines);

            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            double price = double.Parse(PriceTextBox.Text.ToString(), formatter);

            DateTime date = (DateTime)DateOfAppointment.SelectedDate;

            POMS.CreateAppointment(price, date, temp_medicines, temp_doctor, temp_patient);

            MessageBox.Show("Успешно");

            DoctorWindow doctorWindow = new DoctorWindow(temp_doctor);
            doctorWindow.Show();
            this.Close();

        }

        private async void PatientsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedId = ((Patient)PatientsGrid.SelectedItem).PatientId;
            MessageBox.Show(selectedId.ToString());
            PatientTextBlock.Text = ((Patient)PatientsGrid.SelectedItem).LastName + " " + ((Patient)PatientsGrid.SelectedItem).FirstName;

            using var patientService = new PatientService(
                  new PatientRepository(
                      new MedicalCards.DAL.AppContext()
                      ),
                  new AddressRepository(
                      new MedicalCards.DAL.AppContext()
                      )
                  );

            temp_patient = await patientService.GetPatient(selectedId);
        }
    }
}
