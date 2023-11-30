using System;
using System.Reflection;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add more properties as needed
}
class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } // Additional property in Destination
    // Add more properties as needed
}
class Program
{
    static void MapProperties(Source source, Destination destination)
    {
        // Get the properties of the Source and Destination classes
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();

        // Loop through the properties and map the common ones
        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    // Map the property value from source to destination 
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source)); break;
                }
            }
        }
    }
    static void Main()
    { // Step 3: Test the Dynamic Property Mapping
      // Create instances of the Source and Destination classes 
        Source source = new Source { Id = 1, Name = "SourceObject" };
        Destination destination = new Destination { Id = 0, Name = "", Description = "" }; // Initialize with default values
        // Assign values to the properties of the Source class 11
        //....
        // Call the MapProperties method to map the properties
        MapProperties(source, destination);

        //Display the values of the properties of the source class
        Console.WriteLine("Mapped Properties in Destination:");
        Console.WriteLine($"Id: {destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Description: {destination.Description}");

        //Ensure that the mapping was successful
    }
}