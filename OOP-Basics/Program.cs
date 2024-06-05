using System;

public class Car{
    public bool EngineStarted = false;

    public Car(){

    }

    public void StartEngine(){
        // Appropriate methods are called to start the car engine
        EngineStarted = true;
    }
}

public class Program{
    public static void Main(){
        Car car = new Car();

        car.StartEngine();

        Console.WriteLine(car.EngineStarted);
    }
}

