Random random = new Random();
Console.Write("N = ");
double n = Convert.ToInt32(Console.ReadLine());
int[] N = new int[(int) n];
for (int i = 0; i < n; i++)
{
    N[i] = random.Next(50);
}
Console.WriteLine("Starting array");
Array.ForEach(N, x => Console.Write(x + " "));
Console.WriteLine();
for (int i = 0; i < Math.Floor(n / 2.0); i++)
{
    (N[i], N[i + (int)Math.Ceiling(n / 2.0)]) = (N[i + (int)Math.Ceiling(n / 2.0)], N[i]);
}
Console.WriteLine("Changed array");
Array.ForEach(N, x => Console.Write(x + " "));