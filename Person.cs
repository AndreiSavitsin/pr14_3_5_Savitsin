using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace pr14_3_5_Savitsin
{
    class Person
    {
        string surname;
        string name;
        string otchestvo;
        int age;
        double weight;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Otchestvo
        {
            get { return otchestvo; }
            set { otchestvo = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Person(string surname, string name, string otchestvo, int age, double weight)
        {
            this.surname = surname;
            this.name = name;
            this.otchestvo = otchestvo;
            this.age = age;
            this.weight = weight;
        }
        public string ToString()
        {
            return $"{surname} {name} {otchestvo}. Возраст: {age}. Вес: {weight}";
        }
    }
}
