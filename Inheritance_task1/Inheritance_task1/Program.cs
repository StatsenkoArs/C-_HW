
class Program
{
    static List<string> Parents(Person p)
    {
        List<string> result = new List<string>();
        Type t = p.GetType();
        while (t.BaseType != null)
        {
            result.Add(t.ToString());
            t = t.BaseType;
        }
        return result;
    }
    static void Main(String[] args)
    {
        // вывод цепочки наследование до основного материнского класса
        Teacher teacher = new Teacher();
        Console.WriteLine(string.Join(" -> ", Parents(teacher).ToArray()));
        // пример работы ToString(), GetHashCode(), Equals()
        Person p1 = new Person("Олег", 22);
        Person p2 = new Person("Глеб", 45);
        Teacher t = new Teacher("Иван Александрович", 30, new List<Student>() { new Student("Лера", 21), new Student("Лена", 20) });
        Console.WriteLine("Person p1: " + p1.ToString() + " / " + p1.GetHashCode());
        Console.WriteLine("Person p2: " + p2.ToString() + " / " + p2.GetHashCode());
        Console.WriteLine(p1.Equals(p2) ? "p1 == p2" : "p1 != p2");
        Console.WriteLine(p1.Equals(p1) ? "p1 == p1" : "p1 != p1");
        Console.WriteLine("Teacher t: " + t.ToString() + " / " + t.GetHashCode());
        Console.WriteLine(t.Equals(p1) ? "t == p1" : "t != p1");
        // Clone()
        List<Person> people = new List<Person>();
        people.Add(p1);
        people.Add(t);
        people.Add(p2);
        List<Person> clones = new List<Person>();
        foreach (Person person in people)
        {
            clones.Add(person.Clone());
        }
        bool equals = true;
        for (int i = 0; i < clones.Count; i++)
        {
            equals = people[i].Equals(clones[i]);
        }
        Console.WriteLine(equals ? "Clone() is working fine" : "Clone() has failed");
        // посчитать типы в people
        int per = 0;
        int stu = 0;
        int teach = 0;
        int stuwa = 0;
        foreach (Person person in people)
        {
            if (person is Teacher)
            {
                teach++;
            }
            else if (person is Student)
            {
                stu++;
            }
            else if (person is StudentWithAdvisor)
            {
                stuwa++;
            }
            else if (person is Person)
            {
                per++;
            }
        }
        Console.WriteLine("People: {0}, Student: {1}, StudentWtihAdvisor: {2}, Teacher: {3}", per, stu, stuwa, teach);
    }
}


class Person
{
    protected static Random random = new Random();
    protected string name;
    protected int age;
    public string Name { get { return name; } set { name = value; } }
    public int Age { get { return age; } set { if (value < 0) value = 0; age = value; } }

    public Person() { name = "No name"; age = 0; }

    public Person(string name, int age) { this.name = name; this.age = age; }

    public override string ToString()
    {
        return string.Format("Name: {0}, Age: {1}", name, age);
    }

    public override int GetHashCode()
    {
        return (name + age).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        else if (obj is Person person) { return (name == person.name) && (age == person.age); }
        else
        {
            return false;
        }
    }

    public virtual void Print()
    {
        Console.WriteLine("Name: {0}, Age: {1}", name, age);
    } 

    public static Person RandomPerson(Person[] persons)
    {
        return persons[random.Next(0, persons.Length - 1)];
    }

    public virtual Person Clone()
    {
        return new Person(name, age);
    }
}

class Student : Person
{

    public Student():base() { }

    public Student(string name, int age):base(name, age) { }

    public override string ToString()
    {
        return string.Format("Name: {0}, Age: {1}", name, age);
    }

    public override int GetHashCode()
    {
        return (name + age).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        else if (obj is Student student) { return (name == student.name) && (age == student.age); }
        else
        {
            return false;
        }
    }

    public override void Print()
    {
        Console.WriteLine("Name: {0}, Age: {1}", name, age);
    }

    public static Student RandomStudent(Student[] students)
    {
        return students[random.Next(0, students.Length - 1)];
    }

    public override Student Clone()
    {
        return new Student(name, age);
    }
}

class Teacher : Student
{
    protected List<Student> students;
    public List<Student> Students { get; set; }
    
    public Teacher():base() { students = new List<Student>(); }
    public Teacher(string name, int age, List<Student> students):base(name, age)
    {
        this.students = students;
    }

    public override string ToString()
    {
        string t = base.ToString() + ", Students: ";
        foreach (Student student in students)
        {
            t += student.ToString() + "; ";
        }
        return t;
    }

    public override int GetHashCode()
    {
        string t = name + age;
        foreach (Student student in students)
        {
            t += student.Name + student.Age;
        }
        return (t).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        else if (obj is Teacher teacher)
        {
            bool t = name == teacher.name;
            t = t && (age == teacher.age);
            for (int i = 0; i < students.Count; i++)
            {
                t = t && students[i].Equals(teacher.students[i]);
            }
            return t;
        }
        else
        {
            return false;
        }
    }

    public override void Print()
    {
        string t = base.ToString() + ", Students: ";
        foreach (Student student in students)
        {
            t += student.ToString() + "; ";
        }
        Console.WriteLine(t);
    }

    public static Teacher RandomTeacher(Teacher[] teachers)
    {
        return teachers[random.Next(0, teachers.Length - 1)];
    }

    public override Teacher Clone()
    {
        return new Teacher(name, age, students);
    }
}

class StudentWithAdvisor : Person
{
    protected Teacher teacher;
    public Teacher Teacher { get; set; }
    public StudentWithAdvisor() : base() { teacher = new Teacher(); }

    public StudentWithAdvisor(string name, int age, Teacher teacher) : base(name, age) { this.teacher = teacher; }

    public override string ToString()
    {
        return base.ToString() + ", Teacher - " + teacher.ToString();
    }

    public override int GetHashCode()
    {
        return (name + age + teacher.Name + teacher.Age).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        else if (obj is StudentWithAdvisor advisor) { 
            return (name == advisor.name) 
                && (age == advisor.age) 
                && (teacher.Equals(advisor.teacher)); }
        else
        {
            return false;
        }
    }

    public override void Print()
    {
        Console.WriteLine("Name: {0}, Age: {1}, Teacher - {2}", name, age, teacher.ToString());
    }

    public static StudentWithAdvisor RandomStudentWithAdvisor(StudentWithAdvisor[] studentsWithAdvisor)
    {
        return studentsWithAdvisor[random.Next(0, studentsWithAdvisor.Length - 1)];
    }

    public override Person Clone()
    {
        return new StudentWithAdvisor(name, age, teacher);
    }
}

