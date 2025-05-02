using System;
using System.Collections.Generic;
using System.IO;

class FileExplorer
{
    static string currentDir;

    static void Main(string[] args)
    {
        currentDir = Environment.CurrentDirectory;
        bool running = true;

        while (running)
        {
            Console.Clear();
            DisplayCurrentDirectory();
            var entries = GetEntries(currentDir);
            DisplayEntries(entries);

            Console.WriteLine("\nКоманды: \nВведите номер для выбора файла/папки \nC - создать папку \nF - создать файл \nD - удалить файл \nU - переместиться выше по пути \nQ - выйти");
            Console.Write("> ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (int.TryParse(input, out int selectedNumber))
            {
                HandleNumberInput(selectedNumber, entries);
            }
            else
            {
                switch (input)
                {
                    case "C": CreateDirectory(); break;
                    case "F": CreateFile(); break;
                    case "D": DeleteItem(entries); break;
                    case "U": NavigateUp(); break;
                    case "Q": running = false; break;
                    default: 
                        Console.WriteLine("Ошибка ввода. Нажмите на любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    static void DisplayCurrentDirectory()
    {
        Console.WriteLine($"Путь: {currentDir}\n");
    }

    static List<(string name, bool isDirectory)> GetEntries(string path)
    {
        var entries = new List<(string, bool)>();
        foreach (var dir in Directory.GetDirectories(path))
            entries.Add((Path.GetFileName(dir), true));
            
        foreach (var file in Directory.GetFiles(path))
            entries.Add((Path.GetFileName(file), false));
        return entries;
    }

    static void DisplayEntries(List<(string name, bool isDirectory)> entries)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            Console.ForegroundColor = entries[i].isDirectory ? 
                ConsoleColor.Blue : ConsoleColor.White;
            Console.WriteLine($"{i + 1}. {(entries[i].isDirectory ? "[DIR] " : "")}{entries[i].name}");
            Console.ResetColor();
        }
    }

    static void HandleNumberInput(int number, List<(string name, bool isDirectory)> entries)
    {
        if (number < 1 || number > entries.Count) return;

        var entry = entries[number - 1];
        string path = Path.Combine(currentDir, entry.name);

        if (entry.isDirectory)
        {
            currentDir = path;
        }
        else if (Path.GetExtension(path).Equals(".txt", StringComparison.OrdinalIgnoreCase))
        {
            OpenFile(path);
        }
        else
        {
            Console.WriteLine("Открыть можно только файлы формата .txt");
            Console.ReadKey();
        }
    }

    static void OpenFile(string path)
    {
        Console.Clear();
        try
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.WriteLine("\nНажмите на любую клавишу...");
        Console.ReadKey();
    }

    static void CreateDirectory()
    {
        Console.Write("Название папки: ");
        string name = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(name)) return;

        try
        {
            Directory.CreateDirectory(Path.Combine(currentDir, name));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void CreateFile()
    {
        Console.Write("Название файла: ");
        string name = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(name)) return;

        Console.WriteLine("Введите текст (Ctrl+Z чтобы закончить):");
        string content = Console.In.ReadToEnd();

        try
        {
            File.WriteAllText(Path.Combine(currentDir, name), content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void DeleteItem(List<(string name, bool isDirectory)> entries)
    {
        Console.Write("Введите номер файла/папки для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int number)) return;
        if (number < 1 || number > entries.Count) return;

        var entry = entries[number - 1];
        Console.Write($"Удалить {entry.name}? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y") return;

        try
        {
            string path = Path.Combine(currentDir, entry.name);
            if (entry.isDirectory)
                Directory.Delete(path, true);
            else
                File.Delete(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void NavigateUp()
    {
        try
        {
            DirectoryInfo parent = Directory.GetParent(currentDir);
            if (parent != null) currentDir = parent.FullName;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadKey();
        }
    }
}