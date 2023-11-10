class Program
{
    static void Main(string[] args)
    {
        IntArray a = new IntArray(3);
        IntArray b = new IntArray(3);
        a.InputDataRandom();
        b.InputDataRandom();
        a.Print(0, 2);
        Console.WriteLine();
        b.Print(0, 2);
        Console.WriteLine();
        int[] c = new int[] { 1, 2, 3 };
        a.Add(in c);
        a.Print(0, 5);
        Console.WriteLine();
        IntArray d = new IntArray(3);
        d.InputData(in c);
        d.Print(0, 5);
        Console.WriteLine();
        Console.WriteLine(String.Join(", ", d.FindValue(1)));
        d.DelValue(1);
        d.Print(0, 5);
        Console.WriteLine();
        a.Sort();
        a.Print(-1, 5);
    }
}

public class IntArray
{
    int[] data;
    int count;

    public IntArray(in int n)
    {
        count = n;
        data = new int[n];
    }

    public void InputData(in int[] data)
    {
        count = data.Length;
        this.data = new int[count];
        for (int i = 0; i < count; i++)
        {
            this.data[i] = data[i];
        }
    }

    public void InputDataRandom()
    {
        Random r = new Random();
        for (int i = 0; i < count; i++)
        {
            data[i] = r.Next(1, 50); 
        }
    }

    public void Print(in int left, in int right)
    {
        int a = left;
        int b = right;
        if (a < 0) a = 0;
        if (b >= count) b = count - 1;
        for (int i = a; i <= b; i++)
        {
            Console.Write(data[i] + " ");
        }
    }

    public int[] FindValue(in int a)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            if (data[i] == a) list.Add(i);
        }
        return list.ToArray();  
    }

    public void DelValue(in int a)
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i] == a)
            {
                for (int u = i; u < count - 1; u++)
                {
                    data[u] = data[u + 1];
                }
                count--;
                i--;
            }
        }
    }

    public void Add(in int[] a)
    {
        if (a.Length == count)
        {
            for (int i = 0; i < count; i++)
            {
                data[i] += a[i];
            }
        }
    }

    public void Sort()
    {
        for (int i = 1; i < count; i++)
        {
            int u = data[i];
            int j = i - 1;

            while (j >= 0 && data[j] > u)
            {
                data[j + 1] = data[j];
                data[j] = u;
                j--;
            }
        }
    }


    //For tests

    public string GetDataString()
    {
        int[] data = new int[count];
        Array.Copy(this.data, data, count);
        return String.Join(", ", data);
    }
}