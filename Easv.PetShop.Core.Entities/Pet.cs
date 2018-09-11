using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Entities
{
    public enum MyEnum
    {
        Dog,
        Cat,
        Goat,
        Unknown
    }

    public class Pet
    {
        MyEnum PetEnum;

        public int PetID { get; set; }
        public string PetName { get; set; }

        public MyEnum PetType { get; set; }
        public DateTime PetBirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string PetColor { get; set; }
        public string PetPreviousOwner { get; set; }
        public double PetPrice { get; set; }
        public Owner PetOwner { get; set; }
    }
}
