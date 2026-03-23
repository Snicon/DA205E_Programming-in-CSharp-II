// Sixten Peterson (AQ9300) 2026-02-24
using DA205E_Assignment3.Animals.Bird;
using DA205E_Assignment3.Animals.Insect;
using DA205E_Assignment3.Animals.Insect.Species.Beetle;
using DA205E_Assignment3.Animals.Insect.Species.Butterfly;
using DA205E_Assignment3.Animals.Reptile;
using DA205E_Assignment3.Exceptions;
using DA205E_Assignment3.GenericList;
using DA205E_Assignment3.Utils;
using Newtonsoft.Json;
using System.Data;

namespace DA205E_Assignment3.Animals
{
    /// <summary>
    /// The animal manager is a specialized version of the ListManager which implements the IListManager interface. In short the additional logic consists of ID generation and getting an array of all string summaries.
    /// 
    /// It's purpose is to handle a list of animals.
    /// </summary>
    public class AnimalManager : ListManager<Animal>
    {
        private static int startID = 100; // The very first number for the ID generation. This number is added to by one for each ID generated.

        private const string FileToken = "EAMS_SixtenPeterson";
        private const double FileVersion = 3.0; // 3.0 as in assignment 3

        /// <summary>
        /// Generates a simple unique id for the animal object that is passed in the parameter based on the category of animal a letter is prefixed to the ID number. Example of an ID may be B101 for a bird.
        /// </summary>
        /// <param name="animal">The animal object to assign the new ID to</param>
        public void SetNewID(Animal animal)
        {
            Category category = animal.Category;
            string newID = string.Empty; // Will be replace by a new value via the switch statement

            switch (category)
            {
                case Category.Bird:
                    newID = "B"; // B as in bird
                    break;
                case Category.Insect:
                    newID = "I"; // I as in insect
                    break;
                case Category.Reptile:
                    newID = "R"; // R as in reptile
                    break;
                default:
                    newID = "U"; // U as in unknown
                    break;
            }

            animal.Id = newID + (startID++).ToString(); // the id of the animal object is set
        }

        /// <summary>
        /// Makes an array of all the ToStringSummary()-strings from the different animal classes in the AnimalManager by iterating over the TheList().
        /// </summary>
        /// <returns>The array containg all the strings from the ToStringSummary() for each animal</returns>
        public string[] ToStringSummaryAllAnimals()
        {
            string[] infoStrings = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                infoStrings[i] = TheList[i].ToStringSummary();
            }

            return infoStrings;
        }

        /// <summary>
        /// Calculates and returns the total amount of animals and the average age of the animals in the list.
        /// </summary>
        /// <returns>A tuple containing the amount of animals as an int and the average age of the animals in the list as a double</returns>
        public (int, double) CalculateBasicStatistics()
        {
            int totalAnimalAmount = 0;
            double averageAnimalAge = 0.0;

            try
            {
                totalAnimalAmount = (from animal in base.TheList
                                         select animal).Count();

                averageAnimalAge = (from animal in base.TheList
                                           select animal.Age).Average();
            }
            catch (Exception exception)
            {
                ValidationUtility.WarnUser("The outputted data may not make sense if there are no animals created inside of the application.");
            }

            return (totalAnimalAmount, averageAnimalAge);
        }

        /// <summary>
        /// Filters the animals list by a range of age and returns a new list of animals containing all animals within the range.
        /// </summary>
        /// <param name="minAge">The minimum age in the range (inclusive)</param>
        /// <param name="maxAge">The maximum age in the range (inclusive)</param>
        /// <returns>A new list of animals within the age range.</returns>
        public List<Animal> FilterByAgeRange(double minAge, double maxAge) 
        {
            return (from animal in base.TheList
                    where animal.Age >= minAge && animal.Age <= maxAge
                    select animal).ToList();
        }

        public List<Animal> SearchByID(string id)
        {
            // TODO: Exception handling?
            id = id.ToLower().Trim();

            return (from animal in base.TheList
                    where animal.Id.ToLower().Contains(id)
                    select animal).ToList();
        }


        public override void JsonSerialize(string fileName)
        {
            bool validData = true;

            try
            {
                ValidateNoDuplicates();
            }
            catch (DuplicateAnimalNameException exception) 
            {
                validData = false;
                ValidationUtility.WarnUser(exception.Message + Environment.NewLine + exception.Name);
            }

            if (validData)
            {
                try
                {
                    string? jsonString = JsonConvert.SerializeObject(TheList, base.options);
                    File.WriteAllText(fileName, jsonString);
                }
                catch (Exception exception)
                {
                    ValidationUtility.WarnUser("Something went wrong while trying to serialize to JSON: " + exception.Message);
                }
            }
        }

        public override void JsonDeserialize(string fileName)
        {
            string? jsonString = File.ReadAllText(fileName);
            if (jsonString != null)
            {
                TheBaseList = JsonConvert.DeserializeObject<List<Animal>>(jsonString, options); // TODO: Can I resolve the warning?
                reassignStartID();
            }
        }

        public void ValidateNoDuplicates()
        {
            var duplicates = (from animal in base.TheList
                              group animal by animal.Name into g
                              where g.Count() > 1
                              select g.Key).ToList();

            if (duplicates.Count > 0) 
            {
                string duplicateNames = string.Join(", ", duplicates);
                throw new DuplicateAnimalNameException("Duplicates found in the animal list", null, duplicateNames);
            }
        }

        public void SaveFileAs(string fileName, AnimalManager animalManager)
        {
            int animalCount = animalManager.Count;
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(FileToken); // Writing the file token which is used when reading to make sure the file that is read is indeed from (or formatted for) the application
                    writer.WriteLine(FileVersion); // Writing the file version to allow for implementation of backwards compatability in the future if needed.
                    writer.WriteLine(animalCount); // Writing the count of animals to aid the reading of the text file by letting the program know how many animals to process.

                    foreach (Animal animal in animalManager.TheList)
                    {
                        writer.WriteLine(animal.ToStringTxt());
                    }
                }
            }
            catch (Exception)
            {
                ValidationUtility.WarnUser("Something went wrong while saving a file!");
            }
        }

        public void OpenFile(string fileName, AnimalManager animalManager)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    // TODO: Improve code below:
                    string fileToken = reader.ReadLine();
                    double fileVersion = double.Parse(reader.ReadLine());

                    if (fileVersion != FileVersion)
                    {
                        throw new FileVersionMissmatchException("Missmatching file versions. This file is incompatible with the program.", null, FileVersion, fileVersion);
                    }

                    int animalCount = int.Parse(reader.ReadLine());

                    for (int i = 0; i < animalCount; i++)
                    {
                        string species = reader.ReadLine();

                        Dictionary<string, object> animalData = new Dictionary<string, object>
                        {
                            ["Id"] = reader.ReadLine().Split(':')[1].Trim(),
                            ["Name"] = reader.ReadLine().Split(':')[1].Trim(),
                            ["Age"] = double.Parse(reader.ReadLine().Split(':')[1].Trim()),
                            ["Gender"] = (GenderType)Enum.Parse(typeof(GenderType), reader.ReadLine().Split(':')[1].Trim()),
                            ["Weight"] = double.Parse(reader.ReadLine().Split(':')[1].Trim()),
                            ["SleepTime"] = double.Parse(reader.ReadLine().Split(':')[1].Trim())
                        };

                        Animal animal = null;

                        switch (species.ToLower()) // Making sure the casing is lower, just in case
                        {
                            case "dove":
                                animalData.Add("Wingspan", double.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("BeakType", (BeakType)Enum.Parse(typeof(BeakType), reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("MilkProduction", double.Parse(reader.ReadLine().Split(':')[1].Trim()));

                                animal = BirdFactory.CreateBird(Animals.Bird.Species.BirdSpecies.Dove, animalData);
                                break;
                            case "raven":
                                animalData.Add("Wingspan", double.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("BeakType", (BeakType)Enum.Parse(typeof(BeakType), reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("BeakSize", double.Parse(reader.ReadLine().Split(':')[1].Trim()));

                                animal = BirdFactory.CreateBird(Animals.Bird.Species.BirdSpecies.Raven, animalData);
                                break;
                            case "beetle":
                                animalData.Add("HasWings", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("LifecycleStage", (LifecycleStage)Enum.Parse(typeof(LifecycleStage), reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("BodyType", (BodyType)Enum.Parse(typeof(BodyType), reader.ReadLine().Split(':')[1].Trim()));

                                animal = InsectFactory.CreateInsect(Animals.Insect.Species.InsectSpecies.Beetle, animalData);
                                break;
                            case "butterfly":
                                animalData.Add("HasWings", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("LifecycleStage", (LifecycleStage)Enum.Parse(typeof(LifecycleStage), reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("WingPattern", (WingPattern)Enum.Parse(typeof(WingPattern), reader.ReadLine().Split(':')[1].Trim()));

                                animal = InsectFactory.CreateInsect(Animals.Insect.Species.InsectSpecies.Butterfly, animalData);
                                break;
                            case "snake":
                                animalData.Add("LivesInWater", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("CanRegrowTail", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("Venomous", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));

                                animal = ReptileFactory.CreateReptile(Animals.Reptile.Species.ReptileSpecies.Snake, animalData); // Its still null after second iteration for some reason...
                                break;
                            case "turtle":
                                animalData.Add("LivesInWater", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("CanRegrowTail", bool.Parse(reader.ReadLine().Split(':')[1].Trim()));
                                animalData.Add("ShellWidth", double.Parse(reader.ReadLine().Split(':')[1].Trim()));

                                animal = ReptileFactory.CreateReptile(Animals.Reptile.Species.ReptileSpecies.Turtle, animalData);
                                break;
                            default:
                                ValidationUtility.WarnUser("The species read from the .txt-file did not match any of the expected species. Is it a valid species?");
                                break;
                        }

                        if (animal != null)
                        {
                            animalManager.Add(animal); // Adding animal if it is not null (as in an animal object was successfully created based on the data from the .txt file)

                            if (i == animalCount - 1) // If it is the last animal assure the startID is updated so that any new animals get a unique id.
                                reassignStartID();
                        }
                        else
                        {
                            ValidationUtility.WarnUser($"Unable to add animal of species {species} in iteration #{i}.");
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                ValidationUtility.WarnUser(exception.ToString()); // TODO: Replace with user friendly alternative
            }
        }

        private void reassignStartID()
        {
            if (Count > 0) // Making sure the list is not empty
            {
                startID = int.Parse(GetAt(Count - 1).Id.Substring(1)) + 1; // Setting startID to the biggest id from the list plus one.
            }
        }
    }
}
