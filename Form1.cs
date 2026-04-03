using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace pr14_3_5_Savitsin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPusk_Click(object sender, EventArgs e) //Кнопка пуск
        {
            listBox1.Items.Clear();
            int n = (int)numericUpDown1.Value;

            Queue<int> queue = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }
            listBox1.Items.Add($"n = {n}");
            listBox1.Items.Add($"Размерность очереди = {queue.Count}");
            listBox1.Items.Add($"Верхний элемент очереди = {queue.Peek()}");
            listBox1.Items.Add($"Размерность очереди = {queue.Count}");
            string nums = "";
            for (int i = 1; i <= queue.Count; i++)
            {
                nums += $"{i} ";
            }
            listBox1.Items.Add($"Содержимое очереди: {nums}");
            while (queue.Count > 0)
            {
                queue.Dequeue();
            }
            listBox1.Items.Add($"Новая размерность очереди: {queue.Count}");
        }

        private void btnShow_Click(object sender, EventArgs e) //Кнопка вывести информацию
        {
            listBox2.Items.Clear();
            if (File.Exists("task4.txt"))
            {
                Queue<Person> queue = new Queue<Person>();

                using (StreamReader sr = new StreamReader("task4.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        string[] parts = str.Split(' ');

                        Person person = new Person("", "", "", 0, 0.0);

                        person.Surname = parts[0];
                        person.Name = parts[1];
                        person.Otchestvo = parts[2];
                        if (int.TryParse(parts[3], out int age))
                        {
                            person.Age = int.Parse(parts[3]);
                        }
                        else
                        {
                            person.Age = 20;
                        }
                        if (double.TryParse(parts[4], out double weight))
                        {
                            person.Weight = double.Parse(parts[4]);
                        }
                        else
                        {
                            person.Weight = 60;
                        }

                        queue.Enqueue(person);
                    }
                }
                var youngPeople = queue.Where(p => p.Age < 40);
                var oldPeople = queue.Where(p => p.Age >= 40);
                listBox2.Items.Add("Люди младше 40");
                listBox2.Items.Add("");
                foreach (var p in youngPeople)
                {
                    listBox2.Items.Add(p.ToString());
                }

                listBox2.Items.Add("");
                listBox2.Items.Add("Люди старше 40");
                listBox2.Items.Add("");
                foreach(var p in oldPeople)
                {
                    listBox2.Items.Add(p.ToString());
                }
            }
            else
            {
                MessageBox.Show("Текстовый файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btnShow2_Click(object sender, EventArgs e) //Кнопка показать
        {
            listBox3.Items.Clear();

            string fileFIO = "task5_names.txt";
            string fileData = "task5_data.txt";

            if (File.Exists(fileFIO) && File.Exists(fileData))
            {
                string[] fioLines = File.ReadAllLines(fileFIO);
                string[] dataLines = File.ReadAllLines(fileData);

                Queue<Person> queue = new Queue<Person>();

                for (int i = 0; i < fioLines.Length; i++)
                {
                    Person pe = new Person("", "", "", 0, 0.0);

                    string[] fio = fioLines[i].Split(' ');
                    string[] data = dataLines[i].Split(' ');
                    pe.Surname = fio[0];
                    pe.Name = fio[1];
                    pe.Otchestvo = fio[2];
                    if (int.TryParse(data[0], out int age))
                    {
                        pe.Age = int.Parse(data[0]);
                    }
                    else
                    {
                        pe.Age = 20;
                    }
                    if (double.TryParse(data[1], out double weight))
                    {
                        pe.Weight = double.Parse(data[1]);
                    }
                    else
                    {
                        pe.Weight = 60;
                    }
                   
                    queue.Enqueue(pe);
                }

                var groups = queue.GroupBy(p => p.Surname[0]).OrderBy(g => g.Key);

                foreach (var group in groups)
                {
                    foreach (Person p in group.OrderBy(person => person.Age))
                    {
                        listBox3.Items.Add(p.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
