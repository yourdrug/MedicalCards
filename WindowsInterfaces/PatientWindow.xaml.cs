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
            DiagnosisGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Visible;
        }

        private void Diagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            var diagnosis_list = temp_patient.Diagnosis;
            DiagnosisGrid.ItemsSource = (System.Collections.IEnumerable)diagnosis_list;
            AllergiesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            DiagnosisGrid.Visibility = Visibility.Visible;
        }

        private void Allergy_Button_Click(object sender, RoutedEventArgs e)
        {
            var allergy_list = temp_patient.Allergy;
            AllergiesGrid.ItemsSource = allergy_list;
            DiagnosisGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Visible;
        }

        private void Features_Button_Click(object sender, RoutedEventArgs e)
        {
            var features_list = temp_patient.Features;
            AllergiesGrid.ItemsSource = (System.Collections.IEnumerable)features_list;
            DiagnosisGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Visible;
        }

        private void Appointment_Button_Click(object sender, RoutedEventArgs e)
        {



        }
    }
}
