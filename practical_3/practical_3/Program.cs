using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;


namespace practical_3
{
    public class Program
    {
        public static void Main() 
        {
            z1();
            z2();
            z3();

            Program pr = new Program();
            pr.z4();
        }

		public static void z1()
        {
            ArrayList arrlist = new ArrayList();
            var num = new Random();

            arrlist.Add(num.Next(0, 100));
            arrlist.Add(num.Next(0, 100));
            arrlist.Add(num.Next(0, 100));
            arrlist.Add(num.Next(0, 100));
            arrlist.Add(num.Next(0, 100));
            string str = "hello world";
            arrlist.Add(str);
            
            Console.WriteLine("Коллекция: ");
            foreach (var item in arrlist)
            {
                Console.WriteLine(item);
            }

			Console.WriteLine("\nВведите индекс удаляемого элемента: ");
            int del = Convert.ToInt32(Console.ReadLine());
            arrlist.RemoveAt(del);

			Console.WriteLine($"\nКоличество элементов: {arrlist.Count}");

			Console.WriteLine("\nКоллекция: ");
            foreach (var item in arrlist)
            {
                Console.WriteLine(item);
            }

			Console.WriteLine("\nВведите искомое значение элемента: ");
            string fnd = Console.ReadLine();
            int fnd_int;

            if (int.TryParse(fnd, out fnd_int))
            {
				Console.WriteLine("\nИскомый элемент: ");
                if (arrlist.IndexOf(fnd_int) == -1)
                    Console.WriteLine("\nЭлемент не найден!");
                else
                    Console.WriteLine(arrlist.IndexOf(fnd_int));
            }
            else
            {
				Console.Write("\nИскомый элемент: ");
                if (arrlist.IndexOf(fnd) == -1)
                    Console.WriteLine("\nЭлемент не найден!");
                else
                    Console.WriteLine(arrlist.IndexOf(fnd));
            }
        }

        public static void z2()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>()
            {
                {"Ширина", 5.0f},
                {"Высота", 2.5f},
                {"Длина", 10.0f}
            };

			Console.WriteLine("\nСловарь: ");
            foreach(var item in dict)
            {
                Console.WriteLine($"{ item.Key }: { item.Value }");
            }

			Console.WriteLine("\nКоличество удаляемых элементов: ");
            int del = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            foreach(var item in dict)
            {
                if (i == del)
                    break;
                dict.Remove(item.Key);
                i++;
            }

			Console.WriteLine("\nСловарь: ");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            dict.Add("Площадь", 50f);
            dict.Add("Периметр", 30f);
            dict["Объем"] = 125f;

            Queue<double> q = new Queue<double>();
            foreach (var item in dict)
            {
                q.Enqueue(item.Value); 
            }

			Console.WriteLine("\nОчередь: ");
            foreach (double item in q)
            {
                Console.WriteLine(item);
            }

			Console.WriteLine("\nВведите индекс искомого элемента: ");
            int fnd = Convert.ToInt32(Console.ReadLine());
            i = 0;
            
            foreach (double item in q)
            {
                if (fnd == i)
                    Console.WriteLine($"\nИскомый элемент: {item}");
                i++;
            }
        }

        public static void z3()
        {
			Device d1 = new("Xiaomi", "Redmi Note 10", 10999, 2020);
			Device d2 = new("HP", "laser-jet 1010", 25000, 2005);
			Device d3 = new("Samsung", "A3", 45990, 2021);

			Device[] devices = { d1, d2, d3 };
			Array.Sort(devices);

			Console.WriteLine("\n");
			foreach (Device device in devices)
			{
				Console.WriteLine($"{device.Brand} - {device.Model} - {device.Price} - {device.Year}");
            }

            Device d4 = (Device)d1.Clone();
            Console.WriteLine($"{d4.Brand} - {d4.Model} - {d4.Price} - {d4.Year}");

            Console.WriteLine(d2.CompareTo(d3));

            Console.WriteLine(d3.Compare(d3, d4));
		}



		public delegate void AddElement(string message);
		public event AddElement? Notify_add;
		public delegate void RemoveElement(string message);
		public event RemoveElement? Notify_del;
		public void z4()
        {
            ObservableCollection<Device> devices = new ObservableCollection<Device>();
            Device d1 = new("Xiaomi", "Redmi Note 10", 10999, 2020);
            Device d2 = new("HP", "laser-jet 1010", 25000, 2005);
            Device d3 = new("Samsung", "A3", 45990, 2021);
            Device d4 = new("Honor", "9", 11000, 2015);
            Device d5 = new("Lenovo", "hbt32423", 60990, 2024);

            Notify_add += DisplayRedMessage;
            Notify_del += DisplayGreenMessage;

			Console.WriteLine("\n");
			Ad(devices, d1);
            Ad(devices, d2);
            Ad(devices, d3);
            Del(devices, d2);
            Ad(devices, d4);
            Del(devices, d3);
            Del(devices, d1);
            Ad(devices, d5);

        }

        void Ad(ObservableCollection<Device> d, Device device)
		{
			d.Add(device);
			Notify_add?.Invoke("Добавлен новый элемент!");
		}

		void Del(ObservableCollection<Device> d, Device device)
		{
			d.Remove(device);
			Notify_del?.Invoke("Элемент удален!");
		}

		void DisplayRedMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		void DisplayGreenMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}