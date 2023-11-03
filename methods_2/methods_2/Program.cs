List<string> commands = new List<string>();
string command = Console.ReadLine();
Queue queue = new Queue();
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
        queue.push(item);
        Console.WriteLine("ok, pushed " + item);
    }
    else
    {
        switch (cmd)
        {
            case "size":
                Console.WriteLine(queue.size());
                break;
            case "clear":
                queue.clear();
                Console.WriteLine("ok, cleared");
                break;
            case "front":
                Console.WriteLine(queue.front());
                break;
            case "pop":
                Console.WriteLine(queue.pop());
                break;
            default:
                Console.WriteLine("Wrong command");
                break;
        }
    }
}
Console.WriteLine("Bye");

public class Queue
{
    Node first;
    Node last;
    int count;
    
    public Queue() 
    {
        count = 0;
    }

    public Queue(int a)
    {
        count = 0;
        this.push(a);
    }

    public Queue(int[] data)
    {
        count = 0;
        for (int i = 0; i < data.Length; i++)
        {
            this.push(data[i]);
        }
    }

    public void push(int data)
    {
        Node temp = new Node(data);
        if (count == 0)
        {
            first = temp;
            last = temp;
        }
        else
        {
            last.next = temp;
            last = last.next;
        }
        count++;
    }

    public int pop() 
    { 
        count--;
        int temp = first.data;
        if (count != 0)
        {
            first = first.next;
        }
        return temp;
    }

    public int front()
    {
        return first.data;
    }

    public int size()
    {
        return count;
    }

    public void clear() {
        count = 0;
    }
}

public class Node
{
    public int data { get; set; }
    public Node next { get; set; }

    public Node(int data)
    {
        this.data = data;
    }
}