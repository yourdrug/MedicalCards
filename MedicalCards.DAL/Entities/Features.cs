using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Features
    {
        public int FeaturesId { get; set; }

        public int PatientId { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public int Pulse { get; set; }

        public int UpPressure { get; set; }

        public int DownPressure { get; set; }

        public float BMI { get; set; }

        public int Сholesterol { get; set; }


        public Patient? Patient { get; set; }

    }
}
