using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FinalDigicoApi.Objects
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Table("Occupations")]
    [PrimaryKey("selfRef")]
    public class BasicOccupation
    {
        public string? name { get; set; }

        [NotMapped]
        public string[]? alternativeNames { get; set; }
        [Key]
        public string? selfRef { get; set; }

        public string? description { get; set; }

        [ForeignKey(nameof(optionalSkills))]
        public List<BasicSkill>? optionalSkills { get; set; }

        [ForeignKey(nameof(optionalSkills))]
        public List<BasicSkill>? essentialSkills { get; set; }

    }
}

