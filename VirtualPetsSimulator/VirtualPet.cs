namespace VirtualPetsSimulator;

public class VirtualPet
{
    // Field
    // public = access modifier
    // string = type
    // Name   = identifier
    public string FullName;
    public int Age;
    public string Species;
    public bool IsAwake;
    private int ExperiencePoints;

    public VirtualPet(string petName, int petAge, string petSpecies, bool petIsAwake)
    {
        FullName = petName;
        Age = petAge;
        Species = petSpecies;
        IsAwake = petIsAwake;
    }


    // Method definition:
    public void Greet()
    {
        Console.WriteLine($"My name is {FullName}, {Species}");
        Console.WriteLine($"I am {Age} years old");
        Console.WriteLine($"Is awake ? {IsAwake}");
    }

    public void Sleep()
    {
        IsAwake = false;
        Console.WriteLine($"{FullName} is now happily snoring.... zzzz");
    }

    public void Eat(string foodName)
    {
        Console.WriteLine($"{FullName} is now eating {foodName}");
    }
}

