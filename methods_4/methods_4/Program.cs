Deque<int> a = new Deque<int>(new int[] { 1, 2, 3, 4 });
a.print();
Console.WriteLine();
a.pushForward(0);
a.print();
Console.WriteLine("\n\n");

Deque<string> b = new Deque<string> ("Only one string");
b.print();
Console.WriteLine();
b.pushBack("Second string");
b.print();
Console.WriteLine();
Console.WriteLine(b.popFront());
b.print();
Console.WriteLine("\n\n");

Deque<int> c = new Deque<int>();
c.pushBack(1);
c.pushForward(2);
c.pushBack(1);
c.print();
Console.WriteLine();
int[] found = c.find(1);
foreach (int i in found)
{
    Console.Write(i + " ");
}
Console.WriteLine("\n\n");

Deque<int> d = new Deque<int>(new int[] { 1, 2, 3, 4 }); 
d.print();
Console.WriteLine();
d.delete(3);
d.print();


public class Deque<T>
{
    Node<T> first;
    Node<T> last;
    int count;

    public Deque()
    {
        count = 0;
    }

    public Deque(T a)
    {
        count = 0;
        this.pushBack(a);
    }

    public Deque(T[] a)
    {
        count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            this.pushBack((T)a[i]);
        }
    }

    public void pushForward(T data)
    {
        Node<T> temp = new Node<T>(data);
        if (count == 0)
        {
            first = temp;
            last = temp;
        }
        else
        {
            first.prev = temp;
            temp.next = first;
            first = temp;
        }
        count++;
    }

    public void pushBack(T data)
    {
        Node<T> temp = new Node<T>(data);
        if (count == 0)
        {
            first = temp;
            last = temp;
        }
        else
        {
            last.next = temp;
            temp.prev = last;
            last = temp;
        }
        count++;
    }

    public T popFront()
    {
        count--;
        T temp = first.data;
        first = first.next;
        return temp;
    }

    public T popBack()
    {
        count--;
        T temp = last.data;
        last = last.prev;
        return temp;
    }

    public T front()
    {
        return first.data;
    }

    public T back()
    {
        return last.data;
    }

    public int size()
    {
        return count;
    }

    public void clear()
    {
        count = 0;
    }

    public void print()
    {
        Node<T> t = first;
        for (int i = 0; i < count; i++)
        {
            Console.Write(t.data + "  ");
            t = t.next;
        }
    }

    public int[] find(T a)
    {
        int[] ind = new int[count];
        int q = 0;
        Node <T> t = first;
        for (int i = 0; i < count; i++)
        {
            if (t.data.Equals(a))
            {
                ind[q] = i;
                q++;
            }
            t = t.next;
        }
        return ind[0..q];
    }

    public void delete(T a)
    {
        Node<T> t = first;
        int c = count;
        for (int i = 0; i < c; i++)
        {
            if (t.data.Equals(a))
            {
                if (t == first)
                {
                    first = t.next;
                }
                else if (t == last)
                {
                    last = t.prev;
                }
                else
                {
                    t.prev.next = t.next;
                    t.next.prev = t.prev;
                }
                count--;
            }

            t = t.next;
        }
    }
}

public class Node<T>
{
    public T data { get; set; }
    public Node<T> next { get; set; }
    public Node<T> prev { get; set; }

    public Node(T data)
    {
        this.data = data;
    }
}