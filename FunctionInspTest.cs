using System;
using InspectorLib;

class FunctionInspTest
{
    static void Main(string[] args)
    {
        FunctionInsp Inspector = new FunctionInsp(); //Объект Inspector для работы с методами класса FunctionInsp

        //Вывод информации о гл. инспекторе и названии автоинспекции
        Console.WriteLine(Inspector.GetInspector());
        Console.WriteLine(Inspector.GetСarInspection());

        //Блок, где меняется имя главного инспектора
        Console.Write("Введите ФИО: ");
        string FIO_NewBoss = Console.ReadLine();
        try
        {
            Inspector.SetInspector(FIO_NewBoss); //Установка введенного имени, если оно есть в списке (из библиотеки)
            Console.WriteLine($"Главный инспектор: {Inspector.NameInspectorBoss}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); //Сообщение об ошибке
        }

        //Генерация госномера
        Console.Write("Введите символ: ");
        try
        {
            string Symbol = Console.ReadLine();
            if (string.IsNullOrEmpty(Symbol) || Symbol.Length != 1) //Проверка, что введено не пустое и равное 1 по длине значение
            {
                throw new ArgumentException("Необходимо ввести один символ");
            }
            char symbol = Symbol[0];
            string GosNumber = Inspector.GenerateNumber(symbol); //Генерация номера с помощью метода из  бибилиотеки
            Console.WriteLine($"Сгенерированный номер: {GosNumber}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}"); //Сообщение об ошибке
        }

        //Вывод списка сотрудников
        var FIO_workers = Inspector.GetWorker();
        Console.WriteLine("Сотрудники: ");
        foreach (var worker in FIO_workers) //Вывод по одному с помощью цикла
        {
            Console.WriteLine(worker);
        }

        //Добавление нового сотрудника
        Console.Write("Введите ФИО нового сотрудника: ");
        string NewWorker = Console.ReadLine();
        Inspector.AddWorker(NewWorker); //Добавление сотрудников
        Console.WriteLine("Новый список сотрудников: ");
        FIO_workers = Inspector.GetWorker();
        foreach (var worker in FIO_workers) //Вывод по одному с помощью цикла
        {
            Console.WriteLine(worker);
        }
    }
}