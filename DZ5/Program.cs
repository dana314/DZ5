//1 Написать программу, которая вычисляет число гласных и согласных букв в файле.
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        Task1(args);
        Task2();
        Task3();
        TaskDZ1(args);
        TaskDZ3();
    }

    static void Task1(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Укажите файл-аргумент");
            return;
        }

        string file = args[0];
        try
        {
            string fileReaded = File.ReadAllText(file);
            char[] letters = fileReaded.ToCharArray();
            (int vowels, int consonants) = VowelsAndConsonants(letters);
            Console.WriteLine($"Гласных:  {vowels}");
            Console.WriteLine($"Согласных: {consonants}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода");
        }
    }

    static (int, int) VowelsAndConsonants(char[] letters)
    {
        string vowelsString = "аеёиоуэюяАЕЁИОУЭЮЯ";
        int vowelsCount = 0;
        int consonantsCount = 0;

        foreach (char i in letters)
        {
            if (char.IsLetter(i))
            {
                if (vowelsString.Contains(i))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
            }
        }

        return (vowelsCount, consonantsCount);
    }



    //2 Написать программу, реализующую умножению двух матриц, заданных в виде двумерного массива.
    static void Task2()
    {
        Console.WriteLine("Введите количество строк 1-ой матрицы");
        int row1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов 1-ой матрицы");
        int col1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите числа 1-ой матрицы");
        int[,] matriza1 = new int[row1, col1];

        for (int i = 0; i < row1; i++)
        {
            for (int j = 0; j < col1; j++)
            {
                matriza1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введите количество строк 2-ой матрицы");
        int row2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов 2-ой матрицы");
        int col2 = int.Parse(Console.ReadLine());

        if (col2 != row1)
        {
            Console.WriteLine("Столбцы 2-ой матрицы должны быть равными по количеству со строками 1-й матрицы");
            return;
        }

        int[,] matriza2 = new int[row2, col2];
        Console.WriteLine("Введите числа 2-ой матрицы");
        for (int i = 0; i < row2; i++)
        {
            for (int j = 0; j < col2; j++)
            {
                matriza2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[,] res = Multiply(matriza1, matriza2);
        Console.WriteLine("Результат умножения 2-х матриц:");
        PrintMatriza(res);
    }

    static int[,] Multiply(int[,] matriza1, int[,] matriza2)
    {
        int row1 = matriza1.GetLength(0);
        int col1 = matriza1.GetLength(1);
        int row2 = matriza2.GetLength(0);
        int col2 = matriza2.GetLength(1);
        int[,] matrizaResult = new int[row1, col2];

        for (int i = 0; i < row1; i++)
        {
            for (int j = 0; j < col2; j++)
            {
                for (int n = 0; n < col1; n++)
                {
                    matrizaResult[i, j] += matriza1[i, n] * matriza2[n, j];
                }
            }
        }

        return matrizaResult;
    }

    static void PrintMatriza(int[,] matriza)
    {
        int row = matriza.GetLength(0);
        int col = matriza.GetLength(1);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(matriza[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // 3 Написать программу, вычисляющую среднюю температуру за год.
    static void Task3()
    {
        int[,] temperature = new int[12, 30];
        Random digits = new Random();
        for (int month = 0; month < 12; month++)
        {
            for (int day = 0; day < 30; day++)
            {
                temperature[month, day] = digits.Next(-31, 35);
            }
        }

        double[] middleValue = CalculateTemperatures(temperature);
        Console.WriteLine("среднее значение температуры:");
        for (int i = 0; i < middleValue.Length; i++)
        {
            Console.WriteLine($"месяц: {i + 1}, температура: {middleValue[i]:F2} градусов");
        }

        Array.Sort(middleValue);
        Console.WriteLine("Температуры по возрастанию:");
        foreach (double i in middleValue)
        {
            Console.WriteLine($"{i:F2} градусов");
        }
    }

    static double[] CalculateTemperatures(int[,] temperature)
    {
        double[] middle = new double[12];
        for (int month = 0; month < 12; month++)
        {
            double sum = 0;
            for (int day = 0; day < 30; day++)
            {
                sum += temperature[month, day];
            }
            middle[month] = sum / 30;
        }
        return middle;
    }
    // дз1 выполнить 6.1 с List<T>
    static void TaskDZ1(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("укажите файл-аргумент");
            return;
        }

        string file = args[0];
        try
        {
            List<char> letters = new List<char>(File.ReadAllText(file));
            (int vowels, int consonants) = VowelsAndConsonants2(letters);
            Console.WriteLine($"гласных:  {vowels}");
            Console.WriteLine($"согласных: {consonants}");
        }
        catch (FormatException)
        {
            Console.WriteLine("ошибка ввода");
        }
    }
    static (int, int) VowelsAndConsonants2(List<char> letters)
    {
        string vowelsString = "аеёиоуэюяАЕЁИОУЭЮЯ";
        int vowelsCount = 0;
        int consonantsCount = 0;

        foreach (char i in letters)
        {
            if (char.IsLetter(i))
            {
                if (vowelsString.Contains(i))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
            }
        }

        return (vowelsCount, consonantsCount);
    }
    // дз 2 6.3 с linkedList
    static void TaskDZ3()
    {
        double[,] temperature = new double[12, 30];
        Random digits = new Random();
        for (int month = 0; month < 12; month++)
        {
            for (int day = 0; day < 30; day++)
            {
                temperature[month, day] = digits.Next(-31, 36);
            }
        }
        Dictionary<string, double> middleTemperature = CalculateTemperatures(temperature);
        Console.WriteLine("средняя температура каждого месяца");
        foreach (var i in middleTemperature)
        {
            Console.WriteLine($"{i.Key}: {i.Value:F2}");
        }
        var sortedMiddleTemperature = SortTemperature(middleTemperature);
        foreach (var i in sortedMiddleTemperature)
        {
            Console.WriteLine($"{i.Key}: {i.Value:F2} градусов");
        }
    }
    static Dictionary<string, double> CalculateTemperatures(double[,] temperature)
    {
        Dictionary<string, double> middleTemperature = new Dictionary<string, double>();
        string[] months = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
        for (int month = 0; month < 12; month++)
        {
            double sum = 0;
            for (int day = 0; day < 30; day++)
            {
                sum += temperature[month, day];
            }
            double middle = sum / 30;
            middleTemperature[months[month]] = middle;
        }

        return middleTemperature;
    }
    static SortedDictionary<double, string> SortTemperature(Dictionary<string, double> middleTemperatures)
    {
        SortedDictionary<double, string> sortedTemperature = new SortedDictionary<double, string>();

        foreach (var i in middleTemperatures)
        {
            sortedTemperature[i.Value] = i.Key;
        }

        return sortedTemperature;
    }




}
