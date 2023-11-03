int n, m;
string s = Console.ReadLine();
string[] S = s.Split(' ');
n = int.Parse(S[0]);
m =int.Parse(S[1]);
int[,] a = new int[n, m];
for (int i = 0; i < n; i++)
{
    s = Console.ReadLine();
    S = s.Split(' ');
    for (int u = 0; u < S.Length; u++)
    {
        a[i, u] = int.Parse(S[u]);
    }
}
int k = Convert.ToInt32(Console.ReadLine());
int q = 0, cur;
for (int  i = 0;  i < n;  i++)
{
    cur = 0;
    for (int u = 0; u < m; u++)
    {
        if (a[i, u] == 0)
        {
            cur++;
        }
        else
        {
            cur = 0;
        }
        if (cur == k)
        {
            q = i + 1; 
            break;
        }
    }
    if (q != 0) break;
}
Console.WriteLine(q);