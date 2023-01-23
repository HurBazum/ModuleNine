using System.Diagnostics.Metrics;
namespace ModuleNine
{
    class Sorter
    {
        public delegate void SortStrings(string[] strings, sbyte order);
        public event SortStrings SortStringsEvent;
        public void SortString(string[] strings)
        {
            // переменная для выбрасывания исключений
            bool successfulEnter;
            Console.WriteLine("Выберете вариант сортировки(1\\2):\n1.А-Я\n2.Я-А");
            
            successfulEnter = sbyte.TryParse(Console.ReadLine(), out sbyte enter);

            if (!successfulEnter)
            {
                throw new FormatException();
            }
            if(successfulEnter)
            {
                if(enter != 1 && enter != 2)
                {
                    throw new EnterException();
                }
            }

            NumberEntered(strings, enter);

            // вывод отсортированного массива
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }
        protected virtual void NumberEntered(string[] strings, sbyte enter)
        {
            SortStringsEvent?.Invoke(strings, enter);
        }
    }

}
