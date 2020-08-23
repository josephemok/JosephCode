using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JosephCode.Models
{
    public class Pack
    {
       public int Id { get; set; }

       public string Name { get; set; }

      [JsonIgnore]
       public List<Wolve> Wolves { get; set; }
    }
}