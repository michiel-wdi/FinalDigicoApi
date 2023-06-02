using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FinalDigicoApi.Objects
{
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Table("Skill")]
    [PrimaryKey("selfRef")]
    public class BasicSkill
    {

        [JsonProperty("title")]
        public string? name { get; set; }
        public string? discription { get; set; }

        
        [JsonProperty("href")]
        [Key]
        public string? selfRef { get; set; }

    }
}
