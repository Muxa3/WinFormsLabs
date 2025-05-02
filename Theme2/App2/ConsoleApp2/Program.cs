using System;
using System.IO;
using System.Collections.Generic;

class DiskManager
{
    private enum Mode { Drives, Directories }
    private static Mode currentMode = Mode.Drives;
    private static string currentPath = "";
    private static DriveInfo currentDrive;

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                
                switch (currentMode)
                {
                    case Mode.Drives:
                        DisplayDrives();
                        HandleDriveSelection();
                        break;
                    case Mode.Directories:
                        DisplayDirectory();
                        HandleDirectoryOperations();
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }

    static void DisplayDrives()
    {
        Console.WriteLine("Диски:\n");
        DriveInfo[] drives = DriveInfo.GetDrives();
        
        for (int i = 0; i < drives.Length; i++)
        {
            if (drives[i].IsReady)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{i + 1}. [DRIVE] {drives[i].Name}");
                Console.ResetColor();
                Console.WriteLine($" ({FormatSize(drives[i].AvailableFreeSpace)} свободно из {FormatSize(drives[i].TotalSize)})");
            }
        }
        
        Console.WriteLine("\nКоманды: \nQ - выйти");
    }

    static void DisplayDirectory()
    {
        Console.WriteLine($"Путь: {currentPath}\n");
        var entries = GetDirectoryEntries(currentPath);
        
        for (int i = 0; i < entries.Count; i++)
        {
            Console.ForegroundColor = entries[i].isDirectory ? ConsoleColor.Blue : ConsoleColor.White;
            Console.WriteLine($"{i + 1}. {(entries[i].isDirectory ? "[DIR] " : "[FILE]")} {entries[i].name}");
            Console.ResetColor();
        }
        
        Console.WriteLine("\nКоманды: \nB - назад \nI - инфо \nC - создать папку \nF - создать файл \nD - удалить \nQ - выйти");
    }

    static List<(string name, bool isDirectory)> GetDirectoryEntries(string path)
    {
        var entries = new List<(string, bool)>();

        foreach (var dir in Directory.GetDirectories(path))
            entries.Add((Path.GetFileName(dir), true));

        foreach (var file in Directory.GetFiles(path))
             entries.Add((Path.GetFileName(file), false));
        
        return entries;
    }

    static void HandleDriveSelection()
    {
        Console.Write("\nВведите номер диска или команду: ");
        string input = Console.ReadLine().Trim().ToUpper();

        switch (input)
        {
            case "Q":
                Environment.Exit(0);
                break;
            default:
                if (int.TryParse(input, out int index)) SelectDrive(index - 1);
                break;
        }
    }

    static void HandleDirectoryOperations()
    {
        Console.Write("\nВведите команду или номер: ");
        string input = Console.ReadLine().Trim().ToUpper();

        switch (input)
        {
            case "B":
                NavigateBack();
                break;
            case "I":
                ShowDriveInfo();
                break;
            case "C":
                CreateDirectory();
                break;
            case "F":
                CreateFile();
                break;
            case "D":
                DeleteItem();
                break;
            case "Q":
                Environment.Exit(0);
                break;
            default:
                if (int.TryParse(input, out int index)) OpenItem(index - 1);
                break;
        }
    }

    static void SelectDrive(int index)
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        if (index < 0 || index >= drives.Length) return;
        
        currentDrive = drives[index];
        currentPath = currentDrive.RootDirectory.FullName;
        currentMode = Mode.Directories;
    }

    static void OpenItem(int index)
    {
        var entries = GetDirectoryEntries(currentPath);
        if (index < 0 || index >= entries.Count) return;

        string newPath = Path.Combine(currentPath, entries[index].name);
        
        if (entries[index].isDirectory)
        {
            currentPath = newPath;
        }
        else
        {
            if (Path.GetExtension(newPath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                OpenFile(newPath);
            else
                ShowError("Открыть можно только файл формата .txt)");
        }
    }

    static void NavigateBack()
    {
        if (currentPath == currentDrive.RootDirectory.FullName)
            currentMode = Mode.Drives;
        else
            currentPath = Directory.GetParent(currentPath)?.FullName ?? currentPath;
    }

    static void ShowDriveInfo()
    {
        Console.Clear();
        Console.WriteLine($"Drive Information:\n" +
                          $"Имя: {currentDrive.Name}\n" +
                          $"Тип: {currentDrive.DriveType}\n" +
                          $"Формат: {currentDrive.DriveFormat}\n" +
                          $"Обьем: {FormatSize(currentDrive.TotalSize)}\n" +
                          $"Своюодно: {FormatSize(currentDrive.AvailableFreeSpace)}\n");
        Console.WriteLine("Нажмите на любую клавишу...");
        Console.ReadKey();
    }

    static void CreateDirectory()
    {
        Console.Write("Введите название для папки: ");
        string name = Console.ReadLine().Trim();
        Directory.CreateDirectory(Path.Combine(currentPath, name));
    }

    static void CreateFile()
    {
        Console.Write("Введите название для файла: ");
        string name = Console.ReadLine().Trim();
        Console.WriteLine("Введите текст (Ctrl+Z to finish):");
        string content = Console.In.ReadToEnd();
        File.WriteAllText(Path.Combine(currentPath, name), content);
    }

    static void DeleteItem()
    {
        var entries = GetDirectoryEntries(currentPath);
        Console.Write("Введите номер файла/папки для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int index)) return;
        if (index < 1 || index > entries.Count) return;

        string path = Path.Combine(currentPath, entries[index - 1].name);
        Console.Write($"Удалить {path}? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y") return;

        if (entries[index - 1].isDirectory)
            Directory.Delete(path, true);
        else
            File.Delete(path);
    }

    static void OpenFile(string path)
    {
        Console.Clear();
        Console.WriteLine(File.ReadAllText(path));
        Console.WriteLine("\nНажмите на любую клавишу...");
        Console.ReadKey();
    }

    static string FormatSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        double size = bytes;
        
        while (size >= 1024 && order < sizes.Length - 1)
        {
            order++;
            size /= 1024;
        }
        
        return $"{size:0.##} {sizes[order]}";
    }

    static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nОшибка: {message}");
        Console.ResetColor();
        Console.WriteLine("Нажмите на любую клавишу...");
        Console.ReadKey();
    }
}