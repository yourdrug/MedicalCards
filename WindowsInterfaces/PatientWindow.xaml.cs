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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private Patient temp_patient;

        public PatientWindow(Patient patient)
        {
            InitializeComponent();
            temp_patient = patient;
            FullName.Text = new string(patient.LastName + " " + patient.FirstName);
        }

        private void Researches_Button_Click(object sender, RoutedEventArgs e)
        {
            var reserches_list = temp_patient.Research;
            ResearchGrid.ItemsSource = reserches_list;


            AllergiesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Visible;

            DescHeight.Visibility = Visibility.Hidden;
            DescWeight.Visibility = Visibility.Hidden;
            DescPulse.Visibility = Visibility.Hidden;
            DescBMI.Visibility = Visibility.Hidden;
            DescUpPressure.Visibility = Visibility.Hidden;
            DescDownPressure.Visibility = Visibility.Hidden;
            DescChorosterol.Visibility = Visibility.Hidden;

            Height.Visibility = Visibility.Hidden;
            Weight.Visibility = Visibility.Hidden;
            Pulse.Visibility = Visibility.Hidden;
            BMI.Visibility = Visibility.Hidden;
            UpPressure.Visibility = Visibility.Hidden;
            DownPressure.Visibility = Visibility.Hidden;
            Chorosterol.Visibility = Visibility.Hidden;

            DescName.Visibility = Visibility.Hidden;
            DescFIO.Visibility = Visibility.Hidden;
            DescComment.Visibility = Visibility.Hidden;
            DescDate.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            FIO.Visibility = Visibility.Hidden;
            Comment.Visibility = Visibility.Hidden;
            Date.Visibility = Visibility.Hidden;
        }

        private async void Diagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            DescName.Visibility = Visibility.Visible;
            DescFIO.Visibility = Visibility.Visible;
            DescComment.Visibility = Visibility.Visible;
            DescDate.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            FIO.Visibility = Visibility.Visible;
            Comment.Visibility = Visibility.Visible;
            Date.Visibility = Visibility.Visible;



            using var diagnosisService = new DiagnosisService(
                    new DiagnosisRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new DoctorRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );
            
            var diagnosis = await diagnosisService.GetDiagnosisByPatient(temp_patient.PatientId);
            var doctor = await diagnosisService.GetDoctorByDiagnosis(diagnosis.DoctorId);
            Name.Text = diagnosis.Name.ToString();
            FIO.Text = doctor.LastName + " " + doctor.FirstName + " " + doctor.Patronymic;
            Comment.Text = diagnosis.Comment.ToString();
            Date.Text = diagnosis.DateOfDiagnosis.ToShortDateString();

            AllergiesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;

            DescHeight.Visibility = Visibility.Hidden;
            DescWeight.Visibility = Visibility.Hidden;
            DescPulse.Visibility = Visibility.Hidden;
            DescBMI.Visibility = Visibility.Hidden;
            DescUpPressure.Visibility = Visibility.Hidden;
            DescDownPressure.Visibility = Visibility.Hidden;
            DescChorosterol.Visibility = Visibility.Hidden;

            Height.Visibility = Visibility.Hidden;
            Weight.Visibility = Visibility.Hidden;
            Pulse.Visibility = Visibility.Hidden;
            BMI.Visibility = Visibility.Hidden;
            UpPressure.Visibility = Visibility.Hidden;
            DownPressure.Visibility = Visibility.Hidden;
            Chorosterol.Visibility = Visibility.Hidden;
        }

        private void Allergy_Button_Click(object sender, RoutedEventArgs e)
        {
            var allergy_list = temp_patient.Allergy;
            AllergiesGrid.ItemsSource = allergy_list;


            ResearchGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Visible;

            DescHeight.Visibility = Visibility.Hidden;
            DescWeight.Visibility = Visibility.Hidden;
            DescPulse.Visibility = Visibility.Hidden;
            DescBMI.Visibility = Visibility.Hidden;
            DescUpPressure.Visibility = Visibility.Hidden;
            DescDownPressure.Visibility = Visibility.Hidden;
            DescChorosterol.Visibility = Visibility.Hidden;

            Height.Visibility = Visibility.Hidden;
            Weight.Visibility = Visibility.Hidden;
            Pulse.Visibility = Visibility.Hidden;
            BMI.Visibility = Visibility.Hidden;
            UpPressure.Visibility = Visibility.Hidden;
            DownPressure.Visibility = Visibility.Hidden;
            Chorosterol.Visibility = Visibility.Hidden;

            DescName.Visibility = Visibility.Hidden;
            DescFIO.Visibility = Visibility.Hidden;
            DescComment.Visibility = Visibility.Hidden;
            DescDate.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            FIO.Visibility = Visibility.Hidden;
            Comment.Visibility = Visibility.Hidden;
            Date.Visibility = Visibility.Hidden;
        }

        private async void Features_Button_Click(object sender, RoutedEventArgs e)
        {
            using var featuresService = new FeaturesService(
                new FeaturesRepository(
                    new MedicalCards.DAL.AppContext()
                    )
                );
            
            var feature = await featuresService.GetFeaturesByPatient(temp_patient.PatientId);

            Height.Text = feature.Height.ToString();
            Weight.Text = feature.Weight.ToString();
            Pulse.Text = feature.Pulse.ToString();
            BMI.Text = feature.BMI.ToString();
            UpPressure.Text = feature.UpPressure.ToString();
            DownPressure.Text = feature.DownPressure.ToString();
            Chorosterol.Text = feature.Сholesterol.ToString();


            ResearchGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;

            DescHeight.Visibility = Visibility.Visible;
            DescWeight.Visibility = Visibility.Visible;
            DescPulse.Visibility = Visibility.Visible;
            DescBMI.Visibility = Visibility.Visible;
            DescUpPressure.Visibility = Visibility.Visible;
            DescDownPressure.Visibility = Visibility.Visible;
            DescChorosterol.Visibility = Visibility.Visible;

            Height.Visibility = Visibility.Visible;
            Weight.Visibility = Visibility.Visible;
            Pulse.Visibility = Visibility.Visible;
            BMI.Visibility = Visibility.Visible;
            UpPressure.Visibility = Visibility.Visible;
            DownPressure.Visibility = Visibility.Visible;
            Chorosterol.Visibility = Visibility.Visible;

            DescName.Visibility = Visibility.Hidden;
            DescFIO.Visibility = Visibility.Hidden;
            DescComment.Visibility = Visibility.Hidden;
            DescDate.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            FIO.Visibility = Visibility.Hidden;
            Comment.Visibility = Visibility.Hidden;
            Date.Visibility = Visibility.Hidden;
        }

        private void Appointment_Button_Click(object sender, RoutedEventArgs e)
        {



        }

        private void AppointmentGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ResearchGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ResearchGrid.SelectedIndex;
        }
    }
}
