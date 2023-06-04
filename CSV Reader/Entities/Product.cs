using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSV_Reader.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public string? MaterialInformation { get; set; }
        public string? Gender { get; set; }
        public string? ProductType { get; set; }
        public string? Sleeve { get; set; }
        public string? Leg { get; set; }
        public string? Collar { get; set; }
        public string? Manufacture { get; set; }
        public string? BagType { get; set; }
        public double GramWeight { get; set; }
        public string? Material { get; set; }
        public string? CountryOfOrigin { get; set; }
        public string? ImageName { get; set; }
    }
}
