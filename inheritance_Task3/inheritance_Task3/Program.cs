class Program
{
    static void Main(String[] args)
    {
        TriangleColor t = new TriangleColor("Треугольник Боб", 3, 4, 5, "Красный");
        Console.WriteLine(t.Area());
        t.Print();
    }
}
abstract class Figure
{
    private string name;

    public Figure(string name) { this.name = name; }
    
    public string Name { get { return name; } set { name = value; } }

    public abstract double Area2 { get; }

    public abstract double Area();

    public virtual void Print() 
    {
        Console.Write(name);
    }
}

class Triangle : Figure
{
    private int a;
    private int b;
    private int c;

    public Triangle(string name, int a, int b, int c): base(name) 
    { 
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void SetABC(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void GetABC(out int a, out int b, out int c)
    {
        a = this.a;
        b = this.b;
        c = this.c;
    }

    public override double Area2 { get { return Math.Sqrt(((a + b + c) / 2) * ((a+b+c)/2 - a) * ((a + b + c) / 2 - b) * ((a + b + c) / 2 - c)); } }

    public override double Area()
    {
        return Area2;
    }

    public override void Print() 
    {
        base.Print();
        Console.Write(" a = {0}, b = {1}, c = {2}", a, b, c);
    }
}

class TriangleColor : Triangle 
{
    private string color;

    public TriangleColor(string name, int a, int b, int c, string color) : base(name, a, b, c)
    {
        this.color = color;
    }

    public string Color { get { return color; } set { color = value; } }

    public override double Area2 => base.Area2;

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.Write("; Color - {0}", color);
    }
}
