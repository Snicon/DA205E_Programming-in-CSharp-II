// Sixten Peterson (AQ9300) 2026-05-18
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace DA205E_Assignment5.Model.AppData
{
    /// <summary>
    /// The persistence manager is responsible for the logic related to serialization and de-serialization.
    /// </summary>
    public class PersistenceManager
    {
        protected static JsonSerializerSettings options = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// Serializes the provided AppData record and stores it in a .json file.
        /// </summary>
        /// <param name="appData">The AppData object to serialize</param>
        /// <param name="fileName">The file name/path to store the serilized data in.</param>
        public static void Serialize(AppData appData, string fileName)
        {
            try
            {
                string? jsonString = JsonConvert.SerializeObject(appData, options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something went wrong while trying to serialize to JSON: " + exception.Message, "Failed to serialize");
            }
        }

        /// <summary>
        /// Deserilizes the provided AppData record from a .json file into an appData object.
        /// </summary>
        /// <param name="appData">The appdata object to add the deserialized data to</param>
        /// <param name="fileName">The file name/path to deserialized data from</param>
        public static void Deserialize(AppData appData, string fileName)
        {
            string? jsonString = File.ReadAllText(fileName);

            try
            {
                if (jsonString != null)
                {
                    var deserialized = JsonConvert.DeserializeObject<AppData>(jsonString, options);

                    if (deserialized != null)
                    {
                        AppData deserializedAppData = deserialized;
                        appData.Categories.AddAll(deserializedAppData.Categories.Collection);
                        appData.Transactions.AddAll(deserializedAppData.Transactions.Collection);
                    }
                }
            }
            catch (Exception exception) 
            {
                MessageBox.Show("Something went wrong while trying to de-serialize from JSON: " + exception.Message, "Failed to de-serialize");
            }
        }
    }
}
