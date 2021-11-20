using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BMotor
    {
        //private static readonly SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel();
        public static List<string> DisplayPropertyNames = new List<string>
        {
            "Name", "Version", "IEC", "IP", "BuildingType",
            "ISO", "Power", "RPM", "Amperage", "StartupAmperage"
        };

    }
}
