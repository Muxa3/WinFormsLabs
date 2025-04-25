# Теоретические вопросы

## Вопрос 1
Какие модификаторы доступа есть в C#?<br>
Ответ:<br>
public: код в любой сборке может получить доступ к этому типу или члену. Уровень специальных возможностей содержащего типа определяет уровень доступности общедоступных членов типа.<br>
private: только код, объявленный в том же или class struct может получить доступ к этому члену.<br>
protected: только код в том же class или в производном class может получить доступ к этому типу или члену.<br>
internal: доступ к этому типу или члену может получить только код в одной сборке.<br>
protected internal: доступ к этому типу или члену может получить только код в той же сборке или в производном классе в другой сборке.<br>
private protected: только код в одной сборке и в том же классе или производном классе может получить доступ к типу или члену.
## Вопрос 2
Вам надо определить в классе переменную, которая должна быть доступна из любого места в текущем проекте. Какой модификатор (или модификаторы, если их несколько) вы будете использовать?<br>
Ответ:
## Вопрос 3
В чем различие между модификаторами protected и private protected?<br>
Ответ:
## Вопрос 4
Если классы и члены класса не имеют никаких модификаторов, какие модификаторы доступа к ним применяются по умолчанию?<br>
Ответ:
## Вопрос 5
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
Ответ:
# Свойства
## Вопрос 1
Что будет выведено на консоль в результате выполнения следующей программы?
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
Ответ:
Варианты ответов:
15

25

0

Программа не скомпилируется
## Вопрос 2
Что будет выведено на консоль в результате выполнения следующей программы и почему?
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
Ответ:
## Вопрос 3
Что будет выведено на консоль в результате выполнения следующей программы и почему?
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
Ответ:
