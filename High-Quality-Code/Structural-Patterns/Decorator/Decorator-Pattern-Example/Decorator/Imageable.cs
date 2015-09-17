using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Decorator
{
    internal class Imageable : Decorator
    {
        public Imageable(FactoryItem factoryItem, Image image)
            : base(factoryItem)
        {
            this.Image = image;
        }

        public Image Image { get; set; }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("     Image: {0}", this.Image.ToString());
        }
    }
}
