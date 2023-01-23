
namespace ModuleNine
{
    class Program
    {
        public static void Main(string[] args)
        {
            // задание 1
            Exception[] exceptions =
            {
                new FormatException(),
                new EnterException(),
                new ArgumentOutOfRangeException(),
                new OutOfMemoryException(),
                new FileLoadException()
            };
            int i = 0;
            while(i < exceptions.Length)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНажмите Enter!\n");
                    Console.ResetColor();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        throw exceptions[i]; 
                    }
                }
                catch (FormatException e)
                {
                    ExceptionWriter(e);
                }
                catch (EnterException e)
                {
                    ExceptionWriter(e);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    ExceptionWriter(e);
                }
                catch (OutOfMemoryException e)
                {
                    ExceptionWriter(e);
                }
                catch (FileLoadException e)
                {
                    ExceptionWriter(e);
                }
                finally
                {
                    Console.WriteLine("----------------------------------------------");
                }
                i++;
            }
            Console.ReadLine();
            Console.Clear();
            // задание 2
            string[] surNames =
            {
                "Морозов",
                "Яковлев",
                "Алексеев",
                "Нестеров",
                "Адамов"
            };

            Sorter sorter = new();
            sorter.SortStringsEvent += StringSorter;
            while (true)
            {
                try
                {
                    sorter.SortString(surNames);
                }
                catch (Exception e)
                {
                    ExceptionWriter(e);
                }
                // очищение консоли
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНажмите Backspace, чтобы очисть консоль, иначе - Enter");
                    Console.ResetColor();
                    if (Console.ReadKey().Key == ConsoleKey.Backspace)
                    {
                        Console.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// сортирует массив строк
        /// </summary>
        /// <param name="strings">массив строк</param>
        /// <param name="order">порядок сортировки</param>
        /// <returns>отсортированный массив</returns>
        public static string[] StringSorter(string[] strings, sbyte order)
        {
            string temp = string.Empty;
            // А-Я
            if (order == 1)
            {
                for (int k = 0; k < strings.Length; k++)
                {
                    for (int i = 0; i < strings.Length - 1; i++)
                    {
                        if (string.Compare(strings[i], strings[i + 1]) > 0)
                        {
                            temp = strings[i];
                            strings[i] = strings[i + 1];
                            strings[i + 1] = temp;
                        }
                    }
                }
            }
            // Я-А
            if(order == 2)
            {
                for (int k = 0; k < strings.Length; k++)
                {
                    for (int i = 0; i < strings.Length - 1; i++)
                    {
                        if (string.Compare(strings[i], strings[i + 1]) < 0)
                        {
                            temp = strings[i + 1];
                            strings[i + 1] = strings[i];
                            strings[i] = temp;
                        }
                    }
                }
            }
            return strings;
        }

        /// <summary>
        /// выводит сведения об ошибке
        /// </summary>
        /// <param name="e"></param>
        public static void ExceptionWriter(Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
            e.HelpLink ??= "learn.microsoft.com";
            Console.WriteLine("Полезная ссылка: " + e.HelpLink);
            e.Data.Add(Console.CursorTop, $"Дата ошибки - {DateTime.Now}");
            Console.WriteLine(e.Data[Console.CursorTop]);
        }
    }

}
