using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public class Colour
    {
        public List<PetColour> Pets{ get; set; }
        public int ID{ get; set; }
        public string Color { get; set; }
    }
}
