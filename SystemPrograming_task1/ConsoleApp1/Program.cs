namespace MySpace
{

    class Program
    {

        public static void Main(string[] args)
        {

            //Task 4-5

            int[] numbers = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 10001);
//                Викликається метод Next у об'єкта класу Random (rand), який генерує випадкове ціле число.
                  //Параметри 1 і 10001 вказують діапазон для генерації чисел.Метод Next генерує ціле число, яке буде більше або дорівнює 1 і менше 10001.
                  //Це означає, що фактичний діапазон згенерованих чисел — від 1 до 10 000 включно.
            }

            // Змінні для зберігання результатів
            int max = int.MinValue;
            int min = int.MaxValue;
            double average = 0;

            // Потік для пошуку максимального значення
            Thread maxThread = new Thread(() =>
            {
                max = numbers.Max();
            });

            // Потік для пошуку мінімального значення
            Thread minThread = new Thread(() =>
            {
                min = numbers.Min();
            });

            // Потік для обчислення середнього значення
            Thread averageThread = new Thread(() =>
            {
                average = numbers.Average();
            });


            // Запуск потоків
            maxThread.Start();
            minThread.Start();
            averageThread.Start();

            // Очікування завершення всіх потоків
            maxThread.Join();
            minThread.Join();
            averageThread.Join();

            // Виведення результатів
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Average: {average}");
        }
    }
}