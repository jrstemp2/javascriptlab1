using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public Allegiances[] Allegiances { get; set; }
        public string Culture { get; set; }
        public string Gender {get; set;}
        public string Born { get; set; }
        

    }

    public class Allegiances
    {
        public string Name { get; set; }
    }

    
}
