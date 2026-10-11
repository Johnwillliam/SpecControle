using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Models;

namespace Application.Business
{
    public static class BAppSettings
    {
        private const string _showEfficiencyOnStickersName = "ShowEfficiencyOnStickers";

        private static bool? _showEfficiencyOnStickers;

        /// <summary>
        /// Bepaalt of de efficiency op de Type Sticker, de ATEX-sticker en het ATEX-document komt.
        /// Staat standaard uit, totdat Systemair de go geeft om de efficiency te vermelden.
        /// De waarde wordt één keer per sessie uit de database gelezen; een wijziging op een andere
        /// werkplek is daar dus pas zichtbaar na het herstarten van de app.
        /// </summary>
        public static bool ShowEfficiencyOnStickers
        {
            get
            {
                _showEfficiencyOnStickers ??= GetBool(_showEfficiencyOnStickersName);
                return _showEfficiencyOnStickers.Value;
            }
            set
            {
                SetBool(_showEfficiencyOnStickersName, value);
                _showEfficiencyOnStickers = value;
            }
        }

        private static bool GetBool(string name)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            var setting = dbContext.AppSettings.AsNoTracking().FirstOrDefault(x => x.Name == name);
            return bool.TryParse(setting?.Value, out bool value) && value;
        }

        private static void SetBool(string name, bool value)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            var setting = dbContext.AppSettings.FirstOrDefault(x => x.Name == name);
            if (setting == null)
            {
                setting = new AppSetting { Name = name };
                dbContext.AppSettings.Add(setting);
            }
            setting.Value = value.ToString();
            dbContext.SaveChanges();
        }
    }
}
