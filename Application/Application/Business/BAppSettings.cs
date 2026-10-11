using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;

namespace Application.Business
{
    public static class BAppSettings
    {
        private const string _showEfficiencyOnStickersName = "ShowEfficiencyOnStickers";

        private static bool? _showEfficiencyOnStickers;

        /// <summary>
        /// Bepaalt of de efficiency op de Type Sticker, de ATEX-sticker en het ATEX-document komt.
        /// Staat standaard uit, totdat Systemair de go geeft om de efficiency te vermelden.
        /// Er is bewust geen knop in de app voor: de waarde wordt rechtstreeks in de tabel AppSettings
        /// gezet (rij "ShowEfficiencyOnStickers", waarde "True" of "False"). De waarde wordt één keer
        /// per sessie uit de database gelezen; een wijziging is dus pas zichtbaar na het herstarten
        /// van de app.
        /// </summary>
        public static bool ShowEfficiencyOnStickers
        {
            get
            {
                _showEfficiencyOnStickers ??= GetBool(_showEfficiencyOnStickersName);
                return _showEfficiencyOnStickers.Value;
            }
        }

        private static bool GetBool(string name)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            var setting = dbContext.AppSettings.AsNoTracking().FirstOrDefault(x => x.Name == name);
            return bool.TryParse(setting?.Value, out bool value) && value;
        }
    }
}
