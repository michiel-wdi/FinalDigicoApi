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

        public List<OccationBasicSkill>? Skills { get; set; } = new List<OccationBasicSkill>();

    }


    [PrimaryKey("Id")]
    public class OccationBasicSkill
    {
        [Key]
        public string Id { get; set; }
        public bool IsEssential { get; set; }
        public BasicSkill skill { get; set; }
    }
}

