using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DoctorAddFeaturesWindow.xaml
    /// </summary>
    public partial class DoctorAddFeaturesWindow : Window
    {
        private int selectedId = -1;
        public DoctorAddFeaturesWindow()
        {
            InitializeComponent();
        }

        private async void Finish_Button_Click(object sender, RoutedEventArgs e)
        {

            if(HeightTextBox.Text.IsNullOrEmpty() 
               || HeightTextBox.Text.IsNullOrEmpty()
               || WeghtTextBox.Text.IsNullOrEmpty()
               || PulseTextBox.Text.IsNullOrEmpty()
               || UpPressureTextBox.Text.IsNullOrEmpty()
               || DownPressureTextBox.Text.IsNullOrEmpty()
               || BMITextBox.Text.IsNullOrEmpty()
               || CholesterolTextBox.Text.IsNullOrEmpty()
               || selectedId == -1)
            {
                MessageBox.Show("Заполните все данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using var addService = new AdditionalService(
                    new FeaturesRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AllergyRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

                Features features = new Features();

                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

                features.Height = float.Parse(HeightTextBox.Text.ToString(), formatter);
                features.Weight = float.Parse(WeghtTextBox.Text.ToString(), formatter);

                features.Pulse = Convert.ToInt32(PulseTextBox.Text);
                features.UpPressure = Convert.ToInt32(UpPressureTextBox.Text);
                features.DownPressure = Convert.ToInt32(DownPressureTextBox.Text);

                IFormatProvider new_formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
                features.BMI = float.Parse(BMITextBox.Text.ToString(), new_formatter);

                features.Сholesterol = Convert.ToInt32(CholesterolTextBox.Text);

                //features.PatientId = selectedId;

                using var patientService = new PatientService(
                    new PatientRepository(
                        new MedicalCards.DAL.AppContext()
                        ),
                    new AddressRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

                var temp = await patientService.GetPatient(selectedId);

                addService.AddFeaturesToPatient(features, selectedId);
                

                MessageBox.Show("Успешно добавлены данные.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                Owner.Show();
                this.Close();
            }
            
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void PatientsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedId = ((Patient)PatientsGrid.SelectedItem).PatientId;
            PatientTextBlock.Text = ((Patient)PatientsGrid.SelectedItem).LastName + " " + ((Patient)PatientsGrid.SelectedItem).FirstName;
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!HeightTextBox.Text.IsNullOrEmpty() && !WeghtTextBox.Text.IsNullOrEmpty())
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                var height = (float)double.Parse(HeightTextBox.Text.ToString(), formatter);
                var weight = (float)double.Parse(WeghtTextBox.Text.ToString(), formatter);

                BMITextBox.Text = (weight / (height * height)).ToString();
            }
        }

        private void WeghtTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!HeightTextBox.Text.IsNullOrEmpty() && !WeghtTextBox.Text.IsNullOrEmpty())
            {
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                var height = (float)double.Parse(HeightTextBox.Text.ToString(), formatter);
                var weight = (float)double.Parse(WeghtTextBox.Text.ToString(), formatter);

                BMITextBox.Text = (weight / (height * height)).ToString();
            }
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

