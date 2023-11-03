List<string> commands = new List<string>();
string command = Console.ReadLine();
Stack stack = new Stack();
while (command != "exit")
{
    commands.Add(command);
    command = Console.ReadLine();
}
foreach (string cmd in commands)
{
    if ((cmd.Split(" ").Length == 2) && (cmd.Split(" ")[0] == "push"))
    {
        int item = int.Parse(cmd.Split(" ")[1]);
        stack.push(item);
        Console.WriteLine("ok, pushed " + item);
    }
    else
    {
        switch (cmd)
        {
            case "size":
                Console.WriteLine(stack.size());
                break;
            case "clear":
                stack.clear();
                Console.WriteLine("ok, cleared");
                break;
            case "back":
                Console.WriteLine(stack.back());
                break;
            case "pop":
                Console.WriteLine(stack.pop());                
                break;
            default:
                Console.WriteLine("Wrong command");
                break;
        }
    }
}
Console.WriteLine("Bye");




public class Stack
{
    private int[] data;
    private int count;

    public Stack() { 
        data = new int[0];
        count = 0;
    }

    public Stack(int item)
    {
        data = new int[1];
        data[0] = item;
        count++;
    }

    public Stack(int[] data)
    {
        this.data = data;
        count = data.Length;
    }

    public void push(int item)
    {
        count++;
        if (count >= data.Length)
        {
            int[] newArray = new int[count*2];
            data.CopyTo( newArray, 0 );
            data = newArray;
        }
        data[count - 1] = item;
    }

    public int pop()
    {
        int item = data[count - 1];
        count--;
        return item;
    }

    public int back()
    {
        return data[count - 1];
    }

    public int size()
    {
        return count;
    }

    public void clear()
    {
        count = 0;
    }
}