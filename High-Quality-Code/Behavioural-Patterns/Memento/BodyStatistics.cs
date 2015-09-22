using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class BodyStatistics
    {
        public BodyStatistics(double height, double weight, double bodyFatPercentage)
        {
            this.Height = height;
            this.Weight = weight;
            this.BodyFatPercentage = bodyFatPercentage;
        }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BodyFatPercentage { get; set; }
    }
}
