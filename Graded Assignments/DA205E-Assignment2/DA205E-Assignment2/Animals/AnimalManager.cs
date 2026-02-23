using DA205E_Assignment2.GenericList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DA205E_Assignment2.Animals
{
    public class AnimalManager : ListManager<Animal>
    {
        private static int startID = 100;

        public void SetNewID(Animal animal)
        {
            Category category = animal.Category;
            string newID = string.Empty;

            switch (category)
            {
                case Category.Bird:
                    newID = "B";
                    break;
                case Category.Insect:
                    newID = "I";
                    break;
                case Category.Reptile:
                    newID = "R";
                    break;
                default:
                    newID = "U";
                    break;
            }

            animal.Id = newID + (startID++).ToString();
        }

        public string[] ToStringSummaryAllAnimals()
        {
            string[] infoStrings = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                infoStrings[i] = TheList[i].ToStringSummary();
            }

            return infoStrings;
        }
    }
}
