using MedicalCards.DAL.Entities;
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
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        private Doctor temp_doctor = new Doctor(); 
        public DoctorWindow(Doctor doctor)
        {
            InitializeComponent();
            temp_doctor = doctor;
        }

        private void Researches_Button_Click(object sender, RoutedEventArgs e)
        {
            var reserches_list = temp_doctor.Research;
            ResearchGrid.ItemsSource = reserches_list;
            DiagnosisGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Visible;
        }

        private void Diagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            var diagnosis_list = temp_doctor.Diagnosis;
            DiagnosisGrid.ItemsSource = (System.Collections.IEnumerable)diagnosis_list;
            AllergiesGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            DiagnosisGrid.Visibility = Visibility.Visible;
        }

        private void Allergy_Button_Click(object sender, RoutedEventArgs e)
        {
            var allergy_list = temp_doctor.Allergy;
            AllergiesGrid.ItemsSource = allergy_list;
            DiagnosisGrid.Visibility = Visibility.Hidden;
            ResearchGrid.Visibility = Visibility.Hidden;
            FeaturesGrid.Visibility = Visibility.Hidden;
            AllergiesGrid.Visibility = Visibility.Visible;
        }

        private void Features_Button_Click(object sender, RoutedEventArgs e)
        {
            var features_list = temp_doctor.Features;
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
