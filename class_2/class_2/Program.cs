class Program
{
    static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int M = Convert.ToInt32(Console.ReadLine());
        int T = Convert.ToInt32(Console.ReadLine());
        string input = Console.ReadLine();
        Pizzeria dodo = new Pizzeria(N, M, T);
        while (input != "#")
        {
            Console.WriteLine("-----------------");
            if (input != "")
            {
                dodo.AddOrder(input);
            }
            dodo.CheckFreeMakers();

            dodo.CheckFreeCuriers();
            Console.WriteLine("-----------------");
            input = Console.ReadLine();
        }

        dodo.PrintStatistics();
        dodo.PrintTableStatics();
    }
}

public class Pizzeria
{
    Queue<Order> orders;
    List<PizzaMaker> makerList;
    List<Curier> curierList;
    Storage storage;

    bool wasNoOrders;

    public Pizzeria(int N, int M, int T)
    {
        orders = new Queue<Order>();
        makerList = new List<PizzaMaker>();
        for (int i = 0; i < N; i++)
        {
            makerList.Add(new PizzaMaker(i + 1));
        }
        curierList = new List<Curier>();
        for (int i = 0; i < M; i++)
        {
            curierList.Add(new Curier(i + 1));
        }
        storage = new Storage(T);
        wasNoOrders = false;
    }

    public void AddOrder(string input)
    {
        orders.Enqueue(new Order(input));
        Console.WriteLine("We took order " + input);
    }

    public void CheckFreeMakers()
    {
        for (int i = 0; i < makerList.Count; i++)
        {
            if (makerList[i].CheckFree())
            {
                if (orders.Count != 0)
                {
                    makerList[i].TakeOrder(orders.Dequeue());
                    Console.WriteLine("Pizzamaker " + makerList[i].Id() + " took " + makerList[i].GetOrder().GetName());
                }
                else
                {
                    wasNoOrders = true;
                }
            }
            else
            {
                if (makerList[i].GetOrder().CheckReady())
                {
                    if (!storage.IsFull())
                    {
                        storage.Add(makerList[i].FinishOrder());
                        Console.WriteLine("Pizzamaker " + makerList[i].Id() + " finished " + makerList[i].GetOrder().GetName() + " and sent it to storage");
                    }
                }
            }
        }
    }

    public void CheckFreeCuriers()
    {
        for (int i = 0; i < curierList.Count; i++)
        {
            if (curierList[i].CheckFree() && !storage.IsEmpty())
            {
                Console.WriteLine("Curier " + curierList[i].Id() + " went to storage to take some pizzas");
                curierList[i].TakeDelivery(ref storage);
            }
        }
    }

    public void PrintStatistics()
    {
        Console.WriteLine("******************");
        if (wasNoOrders)
        {
            Console.WriteLine("Pizzeria can take more orders");
        }

        if (storage.WasFull())
        {
            Console.WriteLine("Pizzeria's storage is too small");
        }

        int min = makerList[0].CollectStatistics();
        for (int i = 0; i < makerList.Count; i++)
        {
            if (min > makerList[i].CollectStatistics())
            {
                min = makerList[i].CollectStatistics();
            }
        }
        Console.Write("Pizzamakers: ");
        for (int i = 0; i < makerList.Count; i++)
        {
            if (makerList[i].CollectStatistics() == min)
            {
                Console.Write(makerList[i].Id() + " ");
            }
        }
        Console.WriteLine("works worse then others");

        if (min != 0) Console.WriteLine("Maybe pizzeria need more pizzamakers");

        min = curierList[0].CollectStatistics();
        for (int i = 0; i < curierList.Count; i++)
        {
            if (min > curierList[i].CollectStatistics())
            {
                min = curierList[i].CollectStatistics();
            }
        }
        Console.Write("Curiers: ");
        for (int i = 0; i < curierList.Count; i++)
        {
            if (curierList[i].CollectStatistics() == min)
            {
                Console.Write(curierList[i].Id() + " ");
            }
        }
        Console.WriteLine("works worse then others");

        if (min != 0) Console.WriteLine("Maybe pizzeria need more curiers");

        Console.WriteLine("******************");
    }

    public void PrintTableStatics()
    {
        Console.WriteLine("__________________");
        for (int i = 0; i < makerList.Count; i++)
        {
            Console.WriteLine("Pizzamaker " + makerList[i].Id() + " done " + makerList[i].CollectStatistics() + " orders");
        }
        Console.WriteLine("__________________");
        for (int i = 0; i < curierList.Count; i++)
        {
            Console.WriteLine("Curier " + curierList[i].Id() + " done " + curierList[i].CollectStatistics() + " orders");
        }
        Console.WriteLine("__________________");
    }
}

public class Storage
{
    bool wasFull;
    int size;
    int capacity;
    Queue<Order> orders;

    public Storage(int capacity)
    {
        orders = new Queue<Order>(capacity);
        this.capacity = capacity;
        size = 0;
        wasFull = false;
    }

    public bool IsFull()
    {
        Console.WriteLine("Strorage is full");
        wasFull = wasFull || (size == capacity);
        return size == capacity;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Add(Order order)
    {
        orders.Enqueue(order);
        size++;
    }

    public Order Pop()
    {
        size--;
        return orders.Dequeue();
    }

    public bool WasFull() => wasFull;
}

public class PizzaMaker
{
    bool isFree;
    Order order;
    int workTime;
    int timeToMake;
    int id;

    int pizzasMade;

    public PizzaMaker(int id)
    {
        Random r = new Random();
        timeToMake = r.Next(2, 5);
        isFree = true;
        workTime = 0;
        pizzasMade = 0;
        this.id = id;
    }

    public bool CheckFree()
    {
        if (!isFree)
        {
            workTime++;
            if (workTime >= timeToMake) order.SetCooked();
        }
        return isFree;
    }

    public void TakeOrder(Order order)
    {
        this.order = order;
        isFree = false;
        workTime = 0;
    }

    public Order GetOrder() => order;

    public Order FinishOrder()
    {
        isFree = true;
        workTime = 0;
        pizzasMade++;
        return order;
    }

    public int CollectStatistics() => pizzasMade;

    public int Id() => id;
}

public class Curier
{
    int id;
    bool isFree;
    Queue<Order> orders;
    int timeToDeliver;
    int workTime;
    int backpackSize;
    int backpackWeight;

    int deliveriesDone;

    public Curier(int id)
    {
        Random r = new Random();
        backpackSize = r.Next(2, 4);
        backpackWeight = 0;
        timeToDeliver = r.Next(1, 5);
        workTime = 0;
        orders = new Queue<Order>();
        isFree = true;
        this.id = id;
        deliveriesDone = 0;
    }

    public bool CheckFree()
    {
        if (!isFree)
        {
            workTime++;
            if ((workTime == timeToDeliver) && (orders.Count != 0))
            {
                Order temp = orders.Dequeue();
                workTime = 0;
                Console.WriteLine(temp.GetName() + " arrived to client");
                deliveriesDone++;
            }
            if (orders.Count == 0)
            {
                isFree = true;
                workTime = 0;
                backpackWeight = 0;
                Console.WriteLine("Curier " + id + " returned to pizzeria");
            }
        }
        return isFree;
    }

    public void TakeDelivery(ref Storage storage)
    {
        while ((!storage.IsEmpty()) && (backpackWeight < backpackSize))
        {
            orders.Enqueue(storage.Pop());
            backpackWeight++;
        }
        Console.WriteLine("Curier " + id + " took " + backpackWeight + " pizzas");
        isFree = false;
    }

    public int Id() => id;

    public int CollectStatistics() => deliveriesDone;
}

public class Order
{
    string name;
    bool isReady;

    public Order(string name)
    {
        this.name = name;
        isReady = false;
    }

    public void SetCooked()
    {
        isReady = true;
    }

    public bool CheckReady() => isReady;

    public string GetName() => name;
}
