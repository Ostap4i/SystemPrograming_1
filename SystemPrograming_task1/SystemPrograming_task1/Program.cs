using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {

        // Task 1-3

        Console.WriteLine("Enter the start diapazon:"); // : Виводить на екран запит для користувача, щоб ввести початок діапазону чисел.
        int startRange = int.Parse(Console.ReadLine()); // Читає введене значення з консолі (введення користувача) і перетворює його в ціле число (int), яке зберігається у змінну startRange..

        Console.WriteLine("Enter the end diapazon:"); // Console.WriteLine("Введіть кінець діапазону:"): Виводить на екран запит для користувача, щоб ввести кінець діапазону чисел.
        int endRange = int.Parse(Console.ReadLine()); // nt endRange = int.Parse(Console.ReadLine());: Читає введене значення з консолі і перетворює його в ціле число, яке зберігається у змінну endRange.

        if (startRange > endRange) // if (startRange > endRange): Перевіряє, чи початок діапазону не перевищує його кінець. Якщо startRange більше за endRange, то це помилка.
        {
            Console.WriteLine("Початок діапазону не може бути більшим за кінець."); // Console.WriteLine("Початок діапазону не може бути більшим за кінець.");: Виводить повідомлення про помилку, якщо умова вище виконується.
            return;
        }

        Console.WriteLine("Enter conter thred");
        int threadCount = int.Parse(Console.ReadLine()); // Опис: Читає введене користувачем значення з консолі і перетворює його в ціле число (int),
                                                         // яке зберігається у змінну threadCount. Це визначає кількість потоків, які будуть створені.

        // Обчислюємо кількість чисел, які кожен потік повинен обробити
        int rangePerThread = (endRange - startRange + 1) / threadCount;
        int remaining = (endRange - startRange + 1) % threadCount; // бчислює залишок від ділення загальної кількості чисел на кількість потоків


        // Створює масив об'єктів Thread розміром threadCount, в якому будуть зберігатися всі створені потоки.
        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            // Визначаємо початковий і кінцевий індекс для поточного потоку
            int threadStart = startRange + i * rangePerThread;
            int threadEnd = (i == threadCount - 1) ? endRange : threadStart + rangePerThread - 1;

            if (i == threadCount - 1)
            {
                threadEnd += remaining; // Додаємо залишок до останнього потоку
            }

            // Створюємо і запускаємо потік
            threads[i] = new Thread(() => DisplayNumbers(threadStart, threadEnd));
            threads[i].Start();
        }

        // Очікуємо завершення всіх потоків
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("End.");
    }

    static void DisplayNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {i}");
            Thread.Sleep(100);
        }
    }
}