class Program
{
    static void Main(String[] args)
    {
        Book b1 = new Book("War and Peace", "Tolstoi", 2543);
        BookGenrePubl b2 = new BookGenrePubl("The Little Prince", "Antoine de Saint-Exupéry", 243, "novella", "MosPechat");
        b1.Print();
        Console.WriteLine();
        b1.AuthorName = "Leo Tolstoy";
        b1.Print();
        Console.WriteLine();
        b2.Print();
    }
}

class Book
{
    private string name = "No name";
    private string authorName = "No name";
    private int price = 0;
    
    public Book (string name, string authorName, int price)
    {
        this.name = name;
        this.authorName = authorName;
        this.price = price;
    }

    public string Name { get { return name; } set { name = value; } }
    public string AuthorName { get { return authorName; } set { authorName = value; } }
    public int Price { get { return price; } set { price = value; } }

    public void Print()
    {
        Console.Write("'{0}' - {1}; Price {2}", name, authorName, price);
    }
}

class BookGenre : Book
{
    private string genre = "No genre";

    public BookGenre(string name, string authorName, int price, string genre) : base(name, authorName, price)
    {
        this.genre = genre;
    }

    public string Genre { get { return genre; } set { genre = value; } }

    public void Print()
    {
        base.Print();
        Console.Write("; Genre - {0}", genre);
    }
}

sealed class BookGenrePubl : BookGenre
{
    private string publ = "No publisher";

    public BookGenrePubl(string name, string authorName, int price, string genre, string publ) : base(name, authorName, price, genre)
    {
        this.publ = publ;
    }

    public string Publ { get { return publ; } set { publ = value; } }

    public void Print()
    {
        base.Print();
        Console.Write("; Publisher - {0}", publ);
    }
}