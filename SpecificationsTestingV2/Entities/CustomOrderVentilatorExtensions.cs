using EntityFrameworkModelV2.Models;

namespace SpecificationsTesting.Entities
{
    public static class CustomOrderVentilatorExtensions
    {
        public static bool IsAtex(this CustomOrderVentilator customOrderVentilator)
        {
            return !string.IsNullOrEmpty(customOrderVentilator.Atex) && customOrderVentilator.GroupTypeID != null && !customOrderVentilator.GroupType.Description.ToLower().Contains("n.v.t");
        }

        public static bool IsDirectBelt(this CustomOrderVentilator customOrderVentilator)
        {
            return !customOrderVentilator.VentilatorType.Description.ToUpper().Contains("V-BELT") && !customOrderVentilator.VentilatorType.Description.ToUpper().Contains("VBELT");

		}
    }
}
