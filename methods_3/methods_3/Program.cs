string input = Console.ReadLine();
Brackets b = new Brackets(input);
Console.WriteLine(b.solveBrackets());

public class Brackets
{
    string input;
    public Brackets(string input)
    {
        this.input = input;
    }
    public string solveBrackets()
    {
        Stack<char> brackets = new Stack<char>();
        foreach (char br in input)
        {
            if (br == '(')
            {
                brackets.Push(br);
            }
            if (br == ')')
            {
                if (brackets.Count > 0)
                {
                    brackets.Pop();
                }
                else
                {
                    brackets.Push('!');
                    break;
                }
            }
        }
        if (brackets.Count == 0)
        {
            return "Yes";
        }
        else if (brackets.Peek() == '!')
        {
            return "No, too many )";
        }
        else
        {
            return "No, too many (";
        }
    }
}
