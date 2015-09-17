using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class SportsEquipmentLegacyStore
    {
        public string GetGloves(string size)
        {
            switch (size)
            {
                case "Small":
                    {
                        return "Hwarang gloves (size - S)";
                    }
                case "Medium":
                    {
                        return "Raptor gloves (size - M)";
                    }
                case "Large":
                    {
                        return "Harbinger gloves (size - L)";
                    }
                case "Extra large":
                    {
                        return "Everlast gloves (size - XL)";
                    }
                default:
                    {
                        return "There are no gloves with the desired size available";
                    }
            }
        }

        public string GetShoes(string size, string brand)
        {
            switch (brand)
            {
                case "Nike":
                    {
                        return String.Format("Nike Lunarglide 6 (size - {0})", size);
                    }
                case "Puma":
                    {
                        return String.Format("Puma Savage 3 (size - {0})", size);
                    }
                case "Underarmour":
                    {
                        return String.Format("Underarmour Flyweight (size - {0})", size);
                    }
                case "Asics":
                    {
                        return String.Format("Asics Gel (size - {0})", size);
                    }
                default:
                    {
                        return "There are no shoes with the desired brand and size available";
                    }
            }
        }

        public string GetPants(string size, string type)
        {
            switch(type)
            {
                case "Sweatpants":
                    {
                        return String.Format("Air Jordan Sweatpants (size - {0}).", size);
                    }
                case "Trousers":
                    {
                        return String.Format("UA Army Trousers (size - {0}).", size);
                    }
                case "Shorts":
                    {
                        return String.Format("Nike Combat Pro (size - {0}).", size);
                    }
                default:
                    {
                        return "There are no pants with the desired type and size available.";
                    }
            }
        }
    }
}
