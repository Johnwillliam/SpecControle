using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BVentilator
    {
        //private static readonly SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel();
        public static List<string> DisplayPropertyNames = new List<string>
        {
            "Name", "AirVolume", "PressureTotal", "PressureStatic", "PressureDynamic",
            "RPM", "Efficiency", "ShaftPower", "SoundLevel", "BladeAngle"
        };

    }
}
