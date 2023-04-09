using MedicalCards.BLL.Services;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using MedicalCards.DAL.Repositories.Interfaces;
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
    /// Логика взаимодействия для AddQualificationWindow.xaml
    /// </summary>
    public partial class AddQualificationWindow : Window
    {
        private Doctor temp_doctor { get; set; }
        public AddQualificationWindow(Doctor doctor)
        {
            InitializeComponent();
            temp_doctor = doctor;
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            Qualification qualification = new Qualification();
            qualification.DoctorId = temp_doctor.DoctorId;
            qualification.NameOfSpeciality = SpetialityTextBox.Text.ToString();
            qualification.WorkExperience = Convert.ToInt32(StageTextBox.Text.ToString());
            qualification.StartDate = (DateTime)StartOfWork.SelectedDate;
            qualification.FinishDate = (DateTime)FinishOfWork.SelectedDate;

            using var qualificationService = new QualificationService(
                    new QualificationRepository(
                        new MedicalCards.DAL.AppContext()
                        )
                    );

            qualificationService.CreateQualification(qualification);

            this.Close();

            AuthWindow doctorWindow = new AuthWindow();
            doctorWindow.Show();
        }
    }
}
