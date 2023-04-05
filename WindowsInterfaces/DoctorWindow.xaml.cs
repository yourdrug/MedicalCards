﻿using AuthWindow;
using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            FullName.Text = new string(temp_doctor.LastName + " " + temp_doctor.FirstName);
        }

        private async void Diagnosis_Button_Click(object sender, RoutedEventArgs e)
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
                var diagnosis_list = await  diagnosisService.GetDiagnosisByDoctor(temp_doctor.DoctorId);
                DiagnosisGrid.ItemsSource = (System.Collections.IEnumerable)diagnosis_list;
                AppointmentGrid.Visibility = Visibility.Hidden;
                DiagnosisGrid.Visibility = Visibility.Visible;
            }
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


            var appointment_list = await POMS.GetAppointmentsByDoctor(temp_doctor.DoctorId);
            AppointmentGrid.ItemsSource = appointment_list;
            DiagnosisGrid.Visibility = Visibility.Hidden;
            AppointmentGrid.Visibility = Visibility.Visible;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if(AppointmentGrid.Visibility == Visibility.Visible)
            {
                AddAppointmentWindow addAppointmentWindow = new AddAppointmentWindow(temp_doctor);
                addAppointmentWindow.Show();
                addAppointmentWindow.Owner = this;
                this.Hide();
                
            }

           else if(DiagnosisGrid.Visibility == Visibility.Visible)
           {
                AddDiagnosisWindow addDiagnosisWindow = new AddDiagnosisWindow(temp_doctor);
                addDiagnosisWindow.Show();
                addDiagnosisWindow.Owner = this;
                this.Hide();
           }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Show();
            this.Close();
        }
    }


}
