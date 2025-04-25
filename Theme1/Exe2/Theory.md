#Теоретические вопросы

##Вопрос 1
Какие модификаторы доступа есть в C#?
##Вопрос 2
Вам надо определить в классе переменную, которая должна быть доступна из любого места в текущем проекте. Какой модификатор (или модификаторы, если их несколько) вы будете использовать?
##Вопрос 3
В чем различие между модификаторами protected и private protected?
##Вопрос 4
Если классы и члены класса не имеют никаких модификаторов, какие модификаторы доступа к ним применяются по умолчанию?
##Вопрос 5
Что выведет на консоль следующая программа и почему?
``` C#
class Person
{
    int age = 26;
    string name = "Tom";
 
    public Person(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}
class Program
{ 
    static void Main(string[] args)
    {
        Person person = new Person(19, "Bob");
        Console.WriteLine(person.name);
             
        Console.ReadKey();
    }
}
```
Свойства
Вопрос 1
Что будет выведено на консоль в результате выполнения следующей программы?
class Person
{
    private int age = 15;
 
    public int Age
    {
        get { return age; }
        set { }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Person tom = new Person();
        tom.Age = 25;
        Console.WriteLine(tom.Age);
 
        Console.ReadKey();
    }
}

Варианты ответов:
15

25

0

Программа не скомпилируется
Вопрос 2
Что будет выведено на консоль в результате выполнения следующей программы и почему?

class Person
{
    internal string Name { get; set; } = "Bob";
}
class Program
{
    static void Main(string[] args)
    {
        Person tom = new Person { Name = "Tom" };
        Console.WriteLine(tom.Name);
 
        Console.ReadKey();
    }
}

Вопрос 3
Что будет выведено на консоль в результате выполнения следующей программы и почему?

class Person
{
    internal string Name { internal get; set; } = "Bob";
}
class Program
{
    static void Main(string[] args)
    {
        Person tom = new Person { Name = "Tom" };
        Console.WriteLine(tom.Name);
 
        Console.ReadKey();
    }
}
