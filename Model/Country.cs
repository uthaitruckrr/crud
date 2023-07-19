using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class Country
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Shortname { get; set; }
        [Required]
        [MaxLength(10)]
        public string Countrycode { get; set; }

    }
}
