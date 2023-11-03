using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

int[] CreateArray(int n)
{
    int[] array = new int[n];
    Random random = new Random();
    for(int i = 0; i < n; i++)
    {
        array[i] = random.Next(50);
    }
    return array;
}

int[] SumArray(int[] a, int[] b)
{
    if (a.Length != b.Length) return new int[0];
    int[] result = new int[a.Length];
    for (int i = 0; i < a.Length; i++)
    {
        result[i] = a[i] + b[i];
    }
    return result;
}

int[] MultArray(int[] a, int b)
{
    int[] result = new int[a.Length];
    for(int i = 0;i < a.Length;i++)
    {
        result[i] = a[i] * b;
    }
    return result;
}

int[] GeneralElements(int[] a, int[] b)
{
    List<int> result = new List<int>();
    for (int i = 0; i < a.Length; i++)
    {
        for (int u = 0; u < b.Length; u++)
        {
            if ((!result.Contains(a[i])) && (a[i] == b[u])) result.Add(a[i]);
        }
    }
    return result.ToArray();
}

void PrintArray(int[] a)
{
    Array.ForEach(a, x => Console.Write(x + " "));
}

int[] SortArray(int[] a)
{
    int k, j;
    for (int i = 1; i < a.Length; i++)
    {
        k = a[i];
        j = i - 1;
        while (j >= 0 && a[j] <= k)
        {
            a[j + 1] = a[j];
            a[j] = k;
            j--;
        }
    }
    return a;
}

(int, int, double) MinMaxAv(int[] a)
{
    int min = a[0];
    int max = a[0];
    int average = 0;
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i] > max) max = a[i];
        if (a[i] < min) min = a[i];
        average += a[i];
    }
    average /= a.Length;
    return (min, max, average);
}

Console.Write("N = ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("M = ");
int m  = Convert.ToInt32(Console.ReadLine());
int[] a = CreateArray(n);
int[] b = CreateArray(m);
PrintArray(a);
Console.WriteLine();
PrintArray(b);
Console.WriteLine();
Console.Write("Sum: ");
PrintArray(SumArray(a, b));
Console.WriteLine();
Console.Write("k = ");
int k = Convert.ToInt32(Console.ReadLine());
Console.Write("Multiplication by k for first array: ");
PrintArray(MultArray(a, k));
Console.WriteLine();
Console.Write("General: ");
PrintArray(GeneralElements(a, b));
Console.WriteLine();
Console.Write("Sort for first array: ");
PrintArray(SortArray(a));
Console.WriteLine();
int min, max;
double avg;
(min, max, avg) = MinMaxAv(a);
Console.WriteLine("Min, max, average for first array: " + min + ", " + max + ", " + avg);