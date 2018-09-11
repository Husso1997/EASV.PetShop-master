using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public class Owner
    {
        private List<Pet> getPets = new List<Pet>();

        public string Name { get; set; }
        public int Id { get; set; }

        public List<Pet> GetPets()
        {
            return getPets;
        }

    }
}
