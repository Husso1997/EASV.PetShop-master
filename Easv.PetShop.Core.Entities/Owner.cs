using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public class Owner
    {

        public Owner()
        {
            Pets = new List<Pet>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public List<Pet> Pets { get; set; }


    }
}
