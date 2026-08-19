using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Models;

namespace Application.Business
{
    public static class BLookupData
    {
        private static readonly Lazy<List<SoundLevelType>> _soundLevelTypes = CreateLazy(dbContext => dbContext.SoundLevelTypes);
        private static readonly Lazy<List<VentilatorType>> _ventilatorTypes = CreateLazy(dbContext => dbContext.VentilatorTypes);
        private static readonly Lazy<List<GroupType>> _groupTypes = CreateLazy(dbContext => dbContext.GroupTypes);
        private static readonly Lazy<List<TemperatureClass>> _temperatureClasses = CreateLazy(dbContext => dbContext.TemperatureClasses);
        private static readonly Lazy<List<CatType>> _catTypes = CreateLazy(dbContext => dbContext.CatTypes);
        private static readonly Lazy<List<User>> _users = CreateLazy(dbContext => dbContext.Users);

        public static List<SoundLevelType> SoundLevelTypes => _soundLevelTypes.Value;
        public static List<VentilatorType> VentilatorTypes => _ventilatorTypes.Value;
        public static List<GroupType> GroupTypes => _groupTypes.Value;
        public static List<TemperatureClass> TemperatureClasses => _temperatureClasses.Value;
        public static List<CatType> CatTypes => _catTypes.Value;
        public static List<User> Users => _users.Value;

        /// <summary>
        /// Deze tabellen wijzigen niet tijdens het draaien van de app, dus laden we ze één keer en
        /// hergebruiken we ze de rest van de sessie. Voorheen werd bijvoorbeeld het Order-scherm bij
        /// elke tabwissel opnieuw bevraagd, wat over de VPN-verbinding van de klant flink optelt.
        /// Preload start het laden meteen bij het opstarten op de achtergrond, zodat de data al klaar
        /// staat tegen de tijd dat een scherm ze nodig heeft.
        /// </summary>
        public static void Preload()
        {
            Task.Run(() => _soundLevelTypes.Value);
            Task.Run(() => _ventilatorTypes.Value);
            Task.Run(() => _groupTypes.Value);
            Task.Run(() => _temperatureClasses.Value);
            Task.Run(() => _catTypes.Value);
            Task.Run(() => _users.Value);
        }

        private static Lazy<List<T>> CreateLazy<T>(Func<SpecificationsDatabaseModel, IQueryable<T>> query) where T : class
        {
            return new Lazy<List<T>>(() =>
            {
                using var dbContext = new SpecificationsDatabaseModel();
                return query(dbContext).AsNoTracking().ToList();
            }, LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}
