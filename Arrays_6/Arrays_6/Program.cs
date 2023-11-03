Console.Write("N = ");
int N = Convert.ToInt32(Console.ReadLine());
int[] n = new int[N];
string s = Console.ReadLine();
string[] S = s.Split(' ');
for (int i = 0; i < S.Length; i++)
{
    n[i] = int.Parse(S[i]);
}
bool flag = false;
for (int i = 1; i < N; i++)
{
    if (Math.Abs(n[i - 1] - n[i]) == 1)
    {
        flag = true;
        break;
    }
}
if (flag) Console.WriteLine("true");
else Console.WriteLine("false");