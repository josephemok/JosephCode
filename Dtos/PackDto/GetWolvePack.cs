using System.Collections.Generic;
using JosephCode.Models;

namespace JosephCode.Dtos.PackDto
{
    public class GetWolvePack
    {
       public int Id { get; set; }

       public string Name { get; set; }

       public List<Wolve> Wolves { get; set; }

        
    }
}