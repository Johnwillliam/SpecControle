using EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationsTesting.Entities
{
    public static class CustomOrderVentilatorExtensions
    {
        public static bool IsAtex(this CustomOrderVentilator customOrderVentilator)
        {
            return !string.IsNullOrEmpty(customOrderVentilator.Atex) && customOrderVentilator.GroupTypeID != null && !customOrderVentilator.GroupType.Description.ToLower().Contains("n.v.t");
        }
    }
}
