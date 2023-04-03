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
    /// Логика взаимодействия для AddDiagnosisWindow.xaml
    /// </summary>
    public partial class AddDiagnosisWindow : Window
    {
        private int selectedId { get; set; }
        private Doctor temp_doctor = new Doctor();
        public AddDiagnosisWindow(Doctor doctor)
        {
            InitializeComponent();
            temp_doctor = doctor;
        }

        private void PatientsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedId = ((Patient)PatientsGrid.SelectedItem).PatientId;
            MessageBox.Show(selectedId.ToString());
            PatientTextBlock.Text = ((Patient)PatientsGrid.SelectedItem).LastName + " " + ((Patient)PatientsGrid.SelectedItem).FirstName;
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                using var diagnosisService = new DiagnosisService(
                           new DiagnosisRepository(
                               new MedicalCards.DAL.AppContext()
                               ),
                           new DoctorRepository(
                               new MedicalCards.DAL.AppContext()
                               )
                           );
                Diagnosis diagnosis = new Diagnosis();
                //diagnosis.Doctor = temp_doctor;
                diagnosis.DoctorId = temp_doctor.DoctorId;
                diagnosis.Name = DiagnosNameTextBox.Text;
                diagnosis.PatientId = selectedId;
                diagnosis.Comment = CommentTextBox.Text;
                diagnosis.DateOfDiagnosis = Convert.ToDateTime(DateOfDiagnos.SelectedDate);

                diagnosisService.AddDiagnosis(diagnosis);
                MessageBox.Show("Успешно");

                DoctorWindow doctorWindow = new DoctorWindow(temp_doctor);
                doctorWindow.Show();
                this.Close();
            }
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
    }
}
