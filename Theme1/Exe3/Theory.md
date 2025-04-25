## Вопрос 1
Почему следующая программа не компилируется:<br>
``` c#
using System;

namespace HelloApp
{
class Program
{
static void Main(string[] args)
{
Person tom = new Employee();
Console.ReadKey();
}
}

internal class Person
{

}
public class Employee : Person
{

}
}
```
<br>Ответ: Производный класс не может быть болле доступен, чем базовый класс ('public class Employee : Person' > 'internal class Person').

## Вопрос 2
Даны следующие классы:<br>
``` c#
class Person
{
string name;
int age;

public Person()
{
}
public Person(string name) : this(name, 18)
{
}
public Person(string name, int age)
{
this.name = name;
this.age = age;
}
}
class Employee : Person
{
string company;

public Employee()
{
}
public Employee(string name, int age, string company): base(name, age)
{
this.company = company;
}
public Employee(string name, string company) : base(name)
{
this.company = company;
}
}
```
<br>Допустим, мы создаем объект класса Employee следующим образом:<br>

``` c#
1
Employee tom = new Employee("Tom", "Microsoft");
```
<br>Какие конструкторы и в каком порядке в данном случае будет выполняться?<br>
<br>Ответ: Инициализируем новый обьект на базе класса Employee и передаем ему имя Tom, компанию Microsoft -> Из-за предоставленных данных (имя, компания) выбирается второй метод, который записывает компанию и вызывает базовый класс, предоставляя ему имя -> Из-за предоставленных данных (имя) выбирается первый метод, который записывет имя и ставит по умолчанию возраст 18

## Вопрос 3
Как запретить наследование от класса?<br><br>
Ответ: Указываем модификатор sealed у класса
## Вопрос 4
Что выведет на консоль следующая программа и почему?<br>

``` c#
class Auto // легковой автомобиль
{
public int Seats { get; set; } // количество сидений
public Auto(int seats)
{
Seats = seats;
}
}
class Truck : Auto // грузовой автомобиль
{
public decimal Capacity { get; set; } // грузоподъемность
public Truck(int seats, decimal capacity)
{
Seats = seats;
Capacity = capacity;
}
}
class Program
{ 
static void Main(string[] args)
{
Truck truck = new Truck(2, 1.1m);
Console.WriteLine($"Грузовик с грузоподъемностью {truck.Capacity} тонн");
Console.ReadKey();
}
}
```
<br>Ответ: Программа не скомпилируется, т.к. не передает параметр seats параметров в конструктор базового класса (надо добавить ': base(seats)' к конструктору Truck)

## Вопрос 5
Что выведет на консоль следующая программа и почему?<br>

``` c#
class Auto // легковой автомобиль
{
public int Seats { get; set; } // количество сидений
public Auto()
{
Console.WriteLine("Auto has been created");
}
public Auto(int seats)
{
Seats = seats;
}
}
class Truck : Auto // грузовой автомобиль
{
public decimal Capacity { get; set; } // грузоподъемность
public Truck(decimal capacity)
{
Seats = 2;
Capacity = capacity;
Console.WriteLine("Truck has been created");
}
}
class Program
{ 
static void Main(string[] args)
{
Truck truck = new Truck(1.1m);
Console.WriteLine($"Truck with capacity {truck.Capacity}");
Console.ReadKey();
}
}
```
<br>Ответ:
``` lang-txt
Auto has been created
Truck has been created
Truck with capacity 1.1
```
Сначала вызывется базовый класс, потом производный

Вопрос 6
Что выведет на консоль следующая программа и почему?<br>

``` c#
class Person
{
public string Name { get; set; } = "Ben";

public Person(string name)
{
Name = "Tim";
}
}

class Employee : Person
{
public string Company { get; set; }

public Employee(string name, string company)
: base("Bob")
{
Company = company;
}
}

class Program
{ 
static void Main(string[] args)
{
Employee emp = new Employee("Tom", "Microsoft") { Name = "Sam" };

Console.WriteLine(emp.Name); // Ben Tim Bob Tom Sam
Console.ReadKey();
}
} 
```
<br>Ответ: Программа выведет на консоль имя Sam, т.к. инициализатор выполняться в самую последнюю очередь
