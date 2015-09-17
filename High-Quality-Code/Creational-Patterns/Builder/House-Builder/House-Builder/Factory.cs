using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House_Builder_Library;

namespace House_Builder
{
    public class Factory
    {
        static void Main(string[] args)
        {
            var director = new HouseConstructor();
            var builder = new HouseBuilder();

            director.BuildHouse(builder);
        }
    }
}
