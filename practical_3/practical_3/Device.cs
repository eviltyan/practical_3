using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practical_3
{
    internal class Device : IComparable<Device>, IComparer<Device>, ICloneable
    {
		public int CompareTo(Device? dev)
        {
			if (dev is Device device) return Brand.CompareTo(device.Brand);
			else throw new ArgumentException("Некорректное значение параметра");
		}

		public int Compare(Device? d1, Device? d2)
		{
			if (d1 is null || d2 is null)
				throw new ArgumentException("Некорректное значение параметра");
			return d1.Brand.Length - d2.Brand.Length;
		}

		public object Clone() => new Device(Brand, Model, Price, Year);

		protected int year;
		protected float price;
		protected string brand, model;

		public int Year
		{
			get
			{
				return year;
			}
			set
			{
				if (value < 0 || value > DateTime.Now.Year)
					throw new Exception("Неправильный ввод! Год не может быть меньше 0 или больше текущего");
				year = value;
			}
		}
		public float Price
		{
			get
			{
				return price;
			}
			set
			{
				if (value <= 0)
					throw new Exception("Неправильный ввод! Цена не может быть меньше или равной 0");
				price = value;
			}
		}

		public string Brand
		{
			get
			{
				return brand;
			}
			set
			{
				if (value.StartsWith(' ') || value == "")
					throw new Exception("Неправильный ввод! Название бренда не должно начинаться с пробела или быть пустым");
				brand = value;
			}
		}
		public string Model
		{
			get
			{
				return model;
			}
			set
			{
				if (value.StartsWith(' ') || value == "")
					throw new Exception("Неправильный ввод! Название модели не должно начинаться с пробела или быть пустым");
				model = value;
			}
		}

		public Device(string brand = "Не определено", string model = "Не определено", float price = 1.0f, int year = 2000)
		{
			this.Brand = brand;
			this.Model = model;
			this.Price = price;
			this.Year = year;
		}
	}
}
