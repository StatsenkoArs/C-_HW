int N = 1000;
Random random = new Random();
int[] a = new int[N * N];
int[] b = new int[N * N];
int[] c = new int[N * N];
for (int i = 0; i < N * N; i += N)
{
    for (int u = 0; u < N; u++)
    {
        a[i + u] = random.Next(10);
        b[i + u] = random.Next(10);
    }
}
for (int i = 0; i < N * N; i += N)
{
    for(int u = 0; u < N; u++)
    {
        c[i + u] = 0;
        for (int j = 0; j < N; j++)
        {
            c[i + u] += a[i + j] * b[N * j + u];
        }
    }
}
for (int i = 0; i < N * N; i+=N)
{
    for (int u = 0; u < N; u++)
    {
        Console.Write(c[i + u] + " ");
    }
    Console.WriteLine();
}