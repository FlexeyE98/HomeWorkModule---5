using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HomeWorkModule4__finished
{
    internal class Program
    {
        static void Main(string[] args)
        {

            (string name, string lastname, int age) anketa = GetUserInfo();
            ShowUserInfo(anketa);


        }








        static (string name, string lastName, int age) GetUserInfo() //основной метод, собирающий информацию о пользователе и вызывающий методы для создания массива
        {

            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            string age = Console.ReadLine();
            bool isCorrectAge = CheckCorrectNum(age, out int intAge);
            Console.Write("Есть ли у вас питомец: (Да/Нет): ");
            string havePet = Console.ReadLine();

            if (havePet.Contains("Да") || havePet.Contains("да"))
            {
                Console.Write("Сколько у вас питомцев: ");
                string countPets = Console.ReadLine();
                bool isCorrectPets = CheckCorrectNum(countPets, out int intPets);
                string[] pets = GetArrayPets(ref intPets);
            }
            else
            {
                Console.WriteLine("Очень жаль, что у вас нет домашних животных :(");
            }

            Console.Write("Введите количество любимых цветов: ");
            string countColor = Console.ReadLine();
            bool isCorrecttypeColoe = CheckCorrectNum(countColor, out int intColor);
            string[] colors = GetArrayColors(ref intColor);
            return (name, lastName, intAge);

        }


        static string[] GetArrayPets(ref int countPets) // в случае если есть домашние животные, возвращает массив животных
        {

            string[] array = new string[countPets];
            Console.WriteLine("Введите название ваших питомцев: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Имя питомца номер {i + 1}: ");
                string namePet = Console.ReadLine();
                array[i] = namePet;

            }
            return array;

        }

        static string[] GetArrayColors(ref int countColors) //возвращает массив цветов
        {
            string[] array = new string[countColors];
            Console.WriteLine("Введите название ваших цветов: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Название цвета номер {i + 1}: ");
                string nameColor = Console.ReadLine();
                array[i] = nameColor;


            }
            return array;

        }

        static bool CheckCorrectNum(string number, out int value) //костыль проверки корректности ввода данных, (по другому пока не придумал как написать :( )
        {
            string str;
            bool isCorrect;

            if (int.TryParse(number, out int intvalue))
            {
                if (intvalue > 0)
                {
                    value = intvalue;
                    return true;
                }
                else if (intvalue < 0 || intvalue == 0)
                {
                    while (intvalue < 0 || intvalue == 0)
                    {
                        Console.Write("Неверное значение. Повторите попытку: ");
                        str = Console.ReadLine();
                        isCorrect = int.TryParse(str, out intvalue);
                        if (isCorrect == true && intvalue > 0)
                            break;
                    }


                }

            }
            else if (!(int.TryParse(number, out intvalue)))
            {
                if (intvalue < 0 || intvalue == 0)
                {
                    while (intvalue < 0 || intvalue == 0)
                    {
                        Console.Write("Неверное значение. Повторите попытку: ");
                        str = Console.ReadLine();
                        isCorrect = int.TryParse(str, out intvalue);
                        if (isCorrect == true && intvalue > 0)
                            break;

                    }

                }

            }


            value = intvalue;
            return false;

        }

        static void ShowUserInfo((string name, string lastname, int age) userInfo)
        {
            Console.WriteLine();
            Console.WriteLine($"Ваше имя: {userInfo.Item1}");
            Console.WriteLine($"Ваша фамилия: {userInfo.Item2}");
            Console.WriteLine($"Вам {userInfo.Item3} лет");

            //метод, отображающий данные пользователя (не придумал как вывести на консоль массивы
            // т.к один массив находится в условии, то если есть животные есть и массив
            // но столкнулся с еще одной проблемой, в кортеж нельзя положить модификатор ref или out, будет ошибка, следовательно
            //если попытаться запросить инфу в массиве, то он будет пустой

            //если вызвать массивы в Main, то цикл заполнения массива будет запущен повторно и будет дублировать информацию, которую 
            //уже ввел пользователь (т.к массивы вызываются в методе GetUserInfo)
            //следовательно либо я не понял задания, либо что-то упустил, прошу подсказать   


        }

    }
}


