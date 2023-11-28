namespace EntityFrameworkModelV2.Config
{
    public class ConfigurationSettings : BaseConfiguration
    {
        #region App setting

        public static string DefaultConnectionStrings
        {
            get
            {
                var connectionString = GetConnectionString(typeof(string), "SpecificationsDatabase");
                if (connectionString == null)
                {
                    return string.Empty;
                }
                return connectionString.ToString();
            }
        }

        #endregion App setting
    }
}