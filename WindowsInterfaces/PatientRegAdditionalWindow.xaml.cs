using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WindowsInterfaces
{
    /// <summary>
    /// Логика взаимодействия для PatientRegAdditionalWindow.xaml
    /// </summary>
    public partial class PatientRegAdditionalWindow : Window
    {
        public string[] severtyTyping { get; set; }

        public Patient temp_patient { get; set; }

        public User temp_user { get; set; }

        public PatientRegAdditionalWindow(User user, Patient patient)
        {
            InitializeComponent();
            temp_patient = patient;
            temp_user = user;
            severtyTyping = new string[] { "Лёгкая", "Средняя", "Тяжелая" };
            DataContext = this;
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
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

            MessageBox.Show(features.BMI.ToString());

            features.Сholesterol = Convert.ToInt32(CholesterolTextBox.Text);
            features.PatientId = temp_patient.PatientId;
            addService.AddFeaturesToPatient(features);

            if(!AllergenTextBox.Text.IsNullOrEmpty() && !ReactionTextBox.Text.IsNullOrEmpty() && !SevertyComboBox.Text.IsNullOrEmpty())
            {
                Allergy allergy = new Allergy();
                allergy.Allergen = AllergenTextBox.Text;
                allergy.Reaction = ReactionTextBox.Text;
                allergy.Severity = SevertyComboBox.Text;
                allergy.PatientId = temp_patient.PatientId;
                addService.AddAllergyToPatient(allergy);
            }

            MessageBox.Show("Успешно");
            PatientWindow patientWindow = new PatientWindow(temp_patient);
            patientWindow.Show();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
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
    }
}
