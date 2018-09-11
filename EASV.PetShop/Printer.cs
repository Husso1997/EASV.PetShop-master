using Easv.PetShop.Core.Application.Services.ApplicationService;
using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EASV.PetShop
{
    internal class Printer
    {
        private IPetService petService;

        internal Printer(IPetService petService)
        {
            this.petService = petService;

            WelcomeToThePetShopMsg();
            UserSelection();
        }
        
        public void WelcomeToThePetShopMsg()
        {
            PrintLine("Welcome To Our PetShop \n");
            PrintLine("Select one of the following options \n");
            OptionMessage();
            

        }

        public void UserSelection()
        {
            int selection;
            while(!int.TryParse(Console.ReadLine(), out selection) || selection<8 || selection>1)
            {
                switch (selection)
                {
                    case 1:
                        PrintAllPets();
                        break;
                    case 2:
                        PrintAllPetsByType();
                        break;
                    case 3:
                        PrintOrderedByPricePet();
                        break;
                    case 4:
                        PrintFiveCheapestPets();
                        break;
                    case 5:
                        CreatePet();
                        break;
                    case 6:
                        UpdatePet();
                        break;
                    case 7:
                        DeletePet();
                        break;
                    default:
                        PrintLine("\nInvalid input - Choose between 1-7 and no letters \n");
                        break;
                }
                OptionMessage();
            }
        }
        // Method call for five cheapest. To be used.
        public void PrintFiveCheapestPets()
        {
            
            foreach(var pet in petService.GetFiveCheapestPets())
            {
                PrintPetInfo(pet);
            }
        }

        public void PrintOrderedByPricePet()
        {
            foreach(var pet in petService.GetPetsSortedPrice())
            {
                PrintPetInfo(pet);
            }
        }

        public void CreatePet()
        {
            Pet newPet = new Pet
            {
                PetName = AskQuestion("Name: "),
                PetColor = AskQuestion("Color: "),
                PetPrice = SetPetPrice(),
                PetType = GetPetTypeEnum(AskQuestion("Pet-type: ")),
                SoldDate = DateTime.Today,
                PetPreviousOwner = "None"
            };

            PrintLine("Enter the pet's BirthDate (yy/mm/dd)");
            DateTime dateTime;
            while(!DateTime.TryParse(Console.ReadLine(), out dateTime) || dateTime > DateTime.Today)
            {
                PrintLine("You didn't select a valid birthdate");
            }

            newPet.PetBirthDate = dateTime;
            petService.CreatePet(newPet);
        }


        public void DeletePet()
        {
            var id =  Convert.ToInt32(AskQuestion("Type the ID of the pet you want to delete"));
            bool petDeleted = petService.DeletePet(id);
            if(petDeleted)
            {
                PrintLine($"Pet successfully deleted with the ID: {id}");
            }
            else
            {
                PrintLine("Pet didn't get deleted - invalid ID");
            }
        }

        public void UpdatePet()
        {
            PrintLine("Type the ID of the pet you want to update.");
            int selectedPetId;
            while(!int.TryParse(Console.ReadLine(), out selectedPetId))
            {
                PrintLine("Only numbers.");
            }

            Pet petToUpdate = petService.GetPetByID(selectedPetId);
            if(petToUpdate != null)
            {
                Pet newPet = new Pet
                {
                    PetID = petToUpdate.PetID,
                    PetName = AskQuestion("Name: "),
                    PetColor = AskQuestion("Color: "),
                    PetPrice = SetPetPrice(),
                    SoldDate = DateTime.Today,
                    PetPreviousOwner = AskQuestion("Previous owner: ")
                };
                petService.UpdatePet(newPet);
            }
            else
            {
                PrintLine("You selected an invalid ID, returning you to main-menu");
            }

        }

        public double SetPetPrice()
        {
            double price;
            PrintLine("Price: ");
            while(!double.TryParse(Console.ReadLine(), out price))
            {
                PrintLine("Only numbers allowed");
            }
            return price;
        }

        public void PrintAllPets()
        {
            foreach(var pet in petService.GetAllPets().ToList())
            {
                PrintPetInfo(pet);
            }
        }

        public MyEnum GetPetTypeEnum(string type)
        {
            string petType = type.ToLower();
            switch(type)
            {
                case "cat":
                    return MyEnum.Cat;
                case "dog":
                    return MyEnum.Dog;
                case "goat":
                    return MyEnum.Goat;
            }
            return MyEnum.Unknown;
        }

        public void PrintAllPetsByType()
        {

            PrintLine("What type of pet-type do you wanna search for?");
            PrintMyEnumsToString();

            List<Pet> petListType = petService.GetAllPetByType(GetPetTypeEnum(Console.ReadLine()));

            if (petListType.Count != 0)
            {
                foreach (var pet in petListType)
                {
                    PrintPetInfo(pet);
                };
            }
            else
            {
                PrintLine("No pets were found");
            }

        }

        public void PrintPetInfo(Pet pet)
        {
            PrintLine($"Pet-ID: {pet.PetID} Name: {pet.PetName} BirthDate: {pet.PetBirthDate.ToString("dd.MM.yyy")}" +
            $" Price: {pet.PetPrice} \n\nPet-Type: {pet.PetType} Color: {pet.PetColor} Sold-Date:" +
            $" {pet.SoldDate.ToString("dd.MM.yyy")} PreviousOwner: {pet.PetPreviousOwner} \n ----------------------------" +
            $"----------------------------------------------------- \n");
        }

        public void PrintMyEnumsToString()
        {
            var values = Enum.GetValues(typeof(MyEnum));
            foreach (var value in values)
            {
                PrintLine(value.ToString() + " ");
            }
            PrintLine("\n");
        }

        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        public void OptionMessage()
        {
            var optionCounter = 1;
            PrintLine($"{optionCounter++}: Show all pets");
            PrintLine($"{optionCounter++}: Search pets by specfic pet-type");
            PrintLine($"{optionCounter++}: Sort pets by price");
            PrintLine($"{optionCounter++}: Get the 5 cheapest pets");
            PrintLine($"{optionCounter++}: Create new pet");
            PrintLine($"{optionCounter++}: Update pet");
            PrintLine($"{optionCounter++}: Delete pet");

        }
    }
}
