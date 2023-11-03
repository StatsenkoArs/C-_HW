Console.Write("N = ");
int N = Convert.ToInt32(Console.ReadLine());
int[] n = new int[N]; 
string s = Console.ReadLine();
string[] S = s.Split(' ');
for (int i = 0; i < S.Length; i++)
{
    n[i] = int.Parse(S[i]);
}
for (int i = 2; i < N; i++)
{
    if ((n[i] == 0)) n[i] += n[i - 1] + n[i - 2];
}
Array.ForEach(n, x => Console.Write(x + " "));