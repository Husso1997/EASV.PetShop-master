using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public class PetColour
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
