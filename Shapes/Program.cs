namespace Shapes;

class Program
{
    static void Main(string[] args)
    {
        DrawShapes();

        Console.ReadKey();
    }

    public static void DrawShapes()
    {
        Shape shape = null;
        do 
        {
            Console.Clear();
            Console.WriteLine("[1] Triangle");
            Console.WriteLine("[2] Circle");
            Console.WriteLine("[3] Rectangle");
            Console.WriteLine("[4] All");

            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    shape = new Triangle();
                    break;
                case ConsoleKey.D2:
                    shape = new Circle();
                    break;
                case ConsoleKey.D3:
                    shape = new Rectangle();
                    break;
                case ConsoleKey.D4:
                    shape = new Shape();
                    break;
            }

            // if(shape!=null)
            // {
            //     shape.Draw();
            // } 
            // or just write like this
            shape?.Draw();
        }
        while (Console.ReadKey().Key != ConsoleKey.Spacebar);
    }
}

public class Shape
{
    public virtual void Draw()
    {
        var shapes = new List<Shape>
        {
            new Rectangle(),
            new Circle(),
            new Triangle()
        };

        foreach(Shape shape in shapes)
        {
            Console.WriteLine();

            shape.Draw();
        }
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        int n = 9;

        Console.WriteLine();
        for (int i = 1; i <= n; i++)
        {
            for (int x = i; x <= n; x++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= i; j++)
            {
                Console.Write("^" + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Rectangle : Shape
{
    private int _width;
    private int _height;
    private int _locationX;
    private int _locationY;
    private ConsoleColor _borderColor;
    public override void Draw()
    {
        _width = 20;
        _height = 5;
        _locationX = 1;
        _locationY = 5;
        _borderColor = ConsoleColor.Green;

        Console.ForegroundColor = _borderColor;
        Console.CursorTop = _locationY;
        Console.CursorLeft = _locationX;

        // draw top border

        string s = "╔";
        string space = "";
        string temp = "";

        for (int i = 0; i < _width; i++)
        {
            space += " ";
            s += "=";
        }

        // currently s is this
        // ╔==============

        // space is every space for occurence of =
        // it is like left empty space from the left
        for (int j = 0; j < _locationX; j++)
        {
            temp += " ";
        }
        // temp is every space with _locationX width
        s += "╗" + "\n";

        // now s is this
        // ╔==============╗\n

        for (int i = 0; i < _height; i++)
        {
            s += temp + "║" + space + "║" + "\n";
        }

        // now s become like this(printed version in console)
        // ╔==============╗
        // ║              ║
        // ║              ║
        //    ..........
        //
        //
        // ║              ║


        // make bottom border
        s += temp + "╚";

        for (int i = 0; i < _width; i++)
        {
            s += "═";
        }

        s += "╝" + "\n";

        Console.Write(s);
        Console.ResetColor();
    }

}


public class Circle : Shape
{
    public override void Draw()
    {
        double radius;
        double thickness = 0.4;
        ConsoleColor borderColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = borderColor;
        char symbol = '*';

        radius = 10;

        Console.WriteLine();
        double rIn = radius - thickness, rOut = radius+thickness;

        // idea is to draw point
        // between circle rIn and circle rOut
        for(double y = radius;y>=-radius;--y)
        {
            for(double x=-radius;x<rOut;x+=0.5)
            {
                double value = x*x + y*y;
                if(value>=rIn*rIn && value<=rOut*rOut)
                {
                    Console.Write(symbol);
                }
                else{
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }
}