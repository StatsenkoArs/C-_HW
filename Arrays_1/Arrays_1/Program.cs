Random r = new Random();
Console.Write("N = ");
int n = Convert.ToInt32(Console.ReadLine());
int[] N = new int[n];
for  (int i = 0; i < n; i++)
{
    N[i] = r.Next(100);
}
Console.WriteLine(String.Join(", ", N));
Console.Write("M = ");
int m = Convert.ToInt32(Console.ReadLine());
int[] M = new int[m];
for (int i = 0; i < m; i++)
{
    M[i] = r.Next(100);
}
Console.WriteLine(String.Join(", ", M));
Console.Write("K = ");
int k = Convert.ToInt32(Console.ReadLine());
int[] T = new int[n + m];
Array.Copy(N, T, k);
Array.Copy(M, 0, T, k, m);
Array.Copy(N, k, T, k + m, n - k);
N = T;
Console.WriteLine(String.Join(", ", N));
