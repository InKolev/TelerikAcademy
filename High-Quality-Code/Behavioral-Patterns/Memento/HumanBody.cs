using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class HumanBody
    {
        public HumanBody(double height, double weight, double bodyFatPercentage)
        {
            this.Height = height;
            this.Weight = weight;
            this.BodyFatPercentage = bodyFatPercentage;
        }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BodyFatPercentage { get; set; }  

        public void Eat()
        {
            this.Weight += 0.500;
        }

        public void Grow()
        {
            this.Height += 0.100;
        }

        public void LoseFat()
        {
            this.BodyFatPercentage -= 0.300;
        }

        public void GainFat()
        {
            this.BodyFatPercentage += 0.400;
        }

        public override string ToString()
        {
            return String.Format(" Weight: {1} KG, {0} Height: {2} CM, {0} Body Fat: {3} %.{0}", Environment.NewLine, this.Weight, this.Height, this.BodyFatPercentage);
        }

        public BodyStatistics Save()
        {
            return new BodyStatistics(this.Height, this.Weight, this.BodyFatPercentage);
        }

        public void Restore(BodyStatistics stats)
        {
            this.Height = stats.Height;
            this.Weight = stats.Weight;
            this.BodyFatPercentage = stats.BodyFatPercentage;
        }
    }
}
