using System.Collections.Generic;

using JosephCode.Models;

namespace JosephCode.Dtos.PackDto
{
    public class AddWolvetoPackDto
    {
        
       public int Id {get;set;}

        public string Name {get;set;}

        public string Gender {get;set;}

        public string Birthday {get;set;}

        public double Latitide {get;set;}

        public double Logitude {get;set;}

        public int PackId {get;set;}
        
    }
}