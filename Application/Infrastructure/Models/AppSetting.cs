namespace Infrastructure.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Centrale instellingen die voor alle werkplekken gelden (in tegenstelling tot de lokale
    /// gebruikersinstellingen per pc, zoals de laatst gebruikte printer).
    /// </summary>
    public class AppSetting
    {
        [Key]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
