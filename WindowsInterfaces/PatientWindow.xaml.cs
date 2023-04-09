using AuthWindow;
using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        private async void Researches_Button_Click(object sender, RoutedEventArgs e)
        {
            using var researchService = new ResearchService(
                   new ResearchRepository(
                       new MedicalCards.DAL.AppContext()
                       )
                   );

            FilterName.Visibility = Visibility.Visible;
            ApplyButton.Visibility = Visibility.Visible;
            FirstDate.Visibility = Visibility.Visible;
            SecondDate.Visibility = Visibility.Visible;


            var reserches_list = await researchService.GetPatientResearches(temp_patient.PatientId);
            ResearchGrid.ItemsSource = reserches_list;
            AddButton.Visibility = Visibility.Hidden;

            AppointmentGrid.Visibility = Visibility.Hidden;
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

            FilterSurname.Visibility = Visibility.Hidden;
        }

        private async void Diagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            try
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
            }

            catch(Exception)
            {
                MessageBox.Show("Этому пациенту еще не был назначен диагноз.", "Диагноз не найден", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            AddButton.Visibility = Visibility.Hidden;
            AppointmentGrid.Visibility = Visibility.Hidden;
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


            FilterName.Visibility = Visibility.Hidden;
            ApplyButton.Visibility = Visibility.Hidden;
            FirstDate.Visibility = Visibility.Hidden;
            SecondDate.Visibility = Visibility.Hidden;
            FilterSurname.Visibility = Visibility.Hidden;
        }

        private async void Allergy_Button_Click(object sender, RoutedEventArgs e)
        {
            using var addService = new AdditionalService(
                    new FeaturesRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AllergyRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

            var allergy_list = await addService.GetAllergies(temp_patient.PatientId);
            AllergiesGrid.ItemsSource = allergy_list;
            AddButton.Visibility = Visibility.Visible;

            AppointmentGrid.Visibility = Visibility.Hidden;
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

            FilterName.Visibility = Visibility.Hidden;
            ApplyButton.Visibility = Visibility.Hidden;
            FirstDate.Visibility = Visibility.Hidden;
            SecondDate.Visibility = Visibility.Hidden;
            FilterSurname.Visibility = Visibility.Hidden;
        }

        private async void Features_Button_Click(object sender, RoutedEventArgs e)
        {
            try
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
            }
            

            catch(Exception)
            {
                MessageBox.Show("У вас не заполнены личные данные, посетите кабинет 322.", "Данные не найдены", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DescName.Visibility = Visibility.Hidden;
            DescFIO.Visibility = Visibility.Hidden;
            DescComment.Visibility = Visibility.Hidden;
            DescDate.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            FIO.Visibility = Visibility.Hidden;
            Comment.Visibility = Visibility.Hidden;
            Date.Visibility = Visibility.Hidden;

            FilterName.Visibility = Visibility.Hidden;
            ApplyButton.Visibility = Visibility.Hidden;
            FirstDate.Visibility = Visibility.Hidden;
            SecondDate.Visibility = Visibility.Hidden;
            FilterSurname.Visibility = Visibility.Hidden;

            AddButton.Visibility = Visibility.Hidden;
            AppointmentGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;
        }

        private async void Appointment_Button_Click(object sender, RoutedEventArgs e)
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

            FilterSurname.Visibility = Visibility.Visible;
            ApplyButton.Visibility = Visibility.Visible;
            FirstDate.Visibility = Visibility.Visible;
            SecondDate.Visibility = Visibility.Visible;

            AppointmentGrid.Visibility = Visibility.Visible;
            var appointments = await POMS.GetAppointmentsByPatient(temp_patient.PatientId);
            AppointmentGrid.ItemsSource = appointments;

            AddButton.Visibility = Visibility.Hidden;

            ResearchGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;

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

            FilterName.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddAllergyWindow addAllergyWindow = new AddAllergyWindow(temp_patient);
            this.Close();
            addAllergyWindow.Show();
        }

        private List<Research> FilterResearchesByName(List<Research> researches, string temp)
        {
            return researches.Where(r=>r.Name.ToLower().Contains(temp)).ToList();
        }

        private List<Research> FilterResearches(List<Research> researches, DateTime firstDate, DateTime secondDate, string temp)
        {
            return researches.Where(r => r.DateOfResearch >= firstDate && r.DateOfResearch <= secondDate && r.Name.ToLower().Contains(temp)).ToList();
        }

        private List<Appointment> FilterAppointmentsByDoctor(List<Appointment> appointments, string temp)
        {
            return appointments.Where(a => a.Doctor.LastName.ToLower().Contains(temp)).ToList();
        }

        private List<Appointment> FilterAppointments(List<Appointment> appointments, DateTime firstDate, DateTime secondDate, string temp)
        {
            return appointments.Where(a => a.DateTimeAppointment >= firstDate 
                                        && a.DateTimeAppointment <= secondDate 
                                        && a.Doctor.LastName.ToLower().Contains(temp)).ToList();
        }

        private async void FilterByNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using var researchService = new ResearchService(
                   new ResearchRepository(
                       new MedicalCards.DAL.AppContext()
                       )
                   );
            
            var reserches_list = await researchService.GetPatientResearches(temp_patient.PatientId);
            var filtered_researches_list = FilterResearchesByName(reserches_list, FilterByNameTextBox.Text.ToLower().ToString());

            ResearchGrid.ItemsSource = filtered_researches_list;
            
        }

        private async void ApplyButton_Click(object sender, RoutedEventArgs e)
        {

            if (ResearchGrid.Visibility == Visibility.Visible)
            {
                using var researchService = new ResearchService(
                   new ResearchRepository(
                       new MedicalCards.DAL.AppContext()
                       )
                   );

                if (FirstDate.SelectedDate == null)
                {
                    FirstDate.SelectedDate = new DateTime(1900, 1, 1);
                }

                if (SecondDate.SelectedDate == null)
                {
                    SecondDate.SelectedDate = DateTime.Now;
                }

                var reserches_list = await researchService.GetPatientResearches(temp_patient.PatientId);
                var filtered_researches_list = FilterResearches(reserches_list, (DateTime)FirstDate.SelectedDate, (DateTime)SecondDate.SelectedDate, FilterByNameTextBox.Text.ToLower().ToString());
                ResearchGrid.ItemsSource = filtered_researches_list;
            }

            else if(AppointmentGrid.Visibility == Visibility.Visible)
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

                if (FirstDate.SelectedDate == null)
                {
                    FirstDate.SelectedDate = new DateTime(1900, 1, 1);
                }

                if (SecondDate.SelectedDate == null)
                {
                    SecondDate.SelectedDate = DateTime.Now;
                }

                var appointments = await POMS.GetAppointmentsByPatient(temp_patient.PatientId);
                var filtered_appointments = FilterAppointments(appointments, (DateTime)FirstDate.SelectedDate, (DateTime)SecondDate.SelectedDate, FilterBySurnameTextBox.Text);
                AppointmentGrid.ItemsSource = filtered_appointments;
            }
            

        }

        private async void FilterBySurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

            var appointments = await POMS.GetAppointmentsByPatient(temp_patient.PatientId);
            var filtered_appointments = FilterAppointmentsByDoctor(appointments, FilterBySurnameTextBox.Text.ToLower().ToString());
            AppointmentGrid.ItemsSource = filtered_appointments;
        }
    }
}
