class Program
{
    static void Main(String[] args)
    {
        ChaoticArray cA = new ChaoticArray();
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            cA.Add(new ChaoticLine(s));
        }
        int max;
        int min;
        int sum;
        cA.Max(out max);
        cA.Min(out min);
        Console.WriteLine("All max " + max + " All min " + min);
        for (int i = 0; i < n; i++)
        {
            cA[i].Max(out max);
            cA[i].Min(out min);
            cA[i].Sum(out sum);
            Console.WriteLine("max, min, sum for " + (i + 1) + " line: " + max + ", " + min + ", " + sum);
        }
    }
}

public class ChaoticArray
{
    ChaoticLine[] array;

    public ChaoticArray()
    {
        array = new ChaoticLine[0];
    }

    public void Add(ChaoticLine cL)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = cL;
    }

    public ChaoticLine this[int i]
    {
        get { return array[i]; }
        set { array[i] = value; }
    }

    public void Min(out int min)
    {
        array[0].Min(out min);
        int temp;
        foreach (ChaoticLine cL in array)
        {
            cL.Min(out temp);
            if (temp < min) temp = min;
        }
    }

    public void Max(out int max)
    {
        array[0].Max(out max);
        int temp;
        foreach (ChaoticLine cL in array)
        {
            cL.Max(out temp);
            if (temp > max) temp = max;
        }
    }
}

public class ChaoticLine
{
    int[] line;

    public ChaoticLine(string s)
    {
        line = new int[0];
        string[] str = s.Split(" ");
        int temp;
        foreach (string el in str)
        {
            if (el.Length > 0)
            {
                Array.Resize(ref line, line.Length + 1);
                if (Int32.TryParse(el, out temp))
                {
                    line[line.Length - 1] = temp;
                }
                else
                {
                    line[line.Length - 1] = 0;
                }
            }
        }
    }

    public void Min(out int min)
    {
        min = line[0];
        foreach (int i in line)
        {
            if (i < min) min = i;
        }
    }

    public void Max(out int max)
    {
        max = line[0];
        foreach (int i in line)
        {
            if (i > max) max = i;
        }
    }

    public void Sum(out int s)
    {
        s = 0;
        foreach (int i in line)
        {
            s += i;
        }
    }
}
