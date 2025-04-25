# Теоретические вопросы

## Вопрос 1
Какие модификаторы доступа есть в C#?<br><br>
Ответ: publi, private, protected, internal, protected internal и private protected
## Вопрос 2
Вам надо определить в классе переменную, которая должна быть доступна из любого места в текущем проекте. Какой модификатор (или модификаторы, если их несколько) вы будете использовать?<br><br>
Ответ: Для определения переменной, которая должна быть доступна из любого места в текущем проекте, можно использовать модификатор public или internal
## Вопрос 3
В чем различие между модификаторами protected и private protected?<br><br>
Ответ: Оба дают доступн коду только внутри класса или его производных, но у private protected дополниткльное улсовие - код должен находиться в той же сборке
## Вопрос 4
Если классы и члены класса не имеют никаких модификаторов, какие модификаторы доступа к ним применяются по умолчанию?<br><br>
Ответ: internal, но для членов класса и вложенные классов - private 
## Вопрос 5
Что выведет на консоль следующая программа и почему?<br>
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
<br>Ответ: Программа не скомпилируется, т.к. мы вызываем переменную name вне класса, а она имеет модификатор private по умолчанию
# Свойства
## Вопрос 1
Что будет выведено на консоль в результате выполнения следующей программы?<br>
``` C#
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
```
<br>Ответ: 15
Программа не скомпилируется
## Вопрос 2
Что будет выведено на консоль в результате выполнения следующей программы и почему?<br>
``` C#
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
```
<br>Ответ:
## Вопрос 3
Что будет выведено на консоль в результате выполнения следующей программы и почему?<br>
``` C#
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
```
<br>Ответ: Tom, т.к. при инициализации обьекта класса Person мы присвоили ему имя Tom
