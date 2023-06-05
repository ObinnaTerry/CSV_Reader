using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSV_Reader.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Hauptartikelnr { get; set; }
        public string? Artikelname { get; set; }
        public string? Hersteller { get; set; }
        public string? Beschreibung { get; set; }
        public string? Materialangaben { get; set; }
        public string? Geschlecht { get; set; }
        public string? Produktart { get; set; }
        [JsonPropertyName("Armel")]
        public string? Ärmel { get; set; }
        public string? Bein { get; set; }
        public string? Kragen { get; set; }
        public string? Herstellung { get; set; }
        public string? Taschenart { get; set; }
        public string? Grammatur { get; set; }
        public string? Material { get; set; }
        public string? Ursprungsland { get; set; }
        public string? Bildname { get; set; }
    }
}
