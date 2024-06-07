namespace VirtualPetsSimulator;

public class World
{
    public void Run()
    {
        Console.WriteLine(@"
____   ____.__         __               .__ __________        __   
\   \ /   /|__|_______/  |_ __ _______  |  |\______   \ _____/  |_ 
 \   Y   / |  \_  __ \   __\  |  \__  \ |  | |     ___// __ \   __\
  \     /  |  ||  | \/|  | |  |  // __ \|  |_|    |   \  ___/|  |  
   \___/   |__||__|   |__| |____/(____  /____/____|    \___  >__|  
                                      \/                   \/      
");

        Console.WriteLine("Welcome to the pet simulator!");
        Console.WriteLine("");

        VirtualPet leoTheCat = new VirtualPet("Leo", 12, "Cat", true);
        Console.WriteLine("> Pet1");
        leoTheCat.Greet();
        leoTheCat.Eat("some dry food");

        VirtualPet juniorTheParrot = new VirtualPet("Junior", 50, "Parrot", false);
        Console.WriteLine("> Pet2");
        juniorTheParrot.Greet();
        juniorTheParrot.Eat("a worm");
        juniorTheParrot.Sleep();

        VirtualPet callieTheUnicorn = new VirtualPet("Callie", 250, "Unicorn", true);
        callieTheUnicorn.Greet();
        callieTheUnicorn.Eat("something");


        Console.ReadKey();
    }
}
