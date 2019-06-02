using Laba10;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Laba11
{
    public partial class FormAddDelList : Form
    {
        List<Person> listPeople;
        public FormAddDelList(List<Person> people)
        {
            InitializeComponent();
            listPeople = people;
            comboBox4.DataSource = new List<string>() { "Администратор", "Инженер", "Рабочий" };
            comboBox5.DataSource = new List<Gender>() { Gender.Male, Gender.Female };
            comboBox6.DataSource = new List<Category>() { Category.Beginner, Category.Middle, Category.God };
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == (int)Prof.Administration)
            {
                label13.Visible = true;
                numericUpDown2.Visible = true;
                label12.Visible = false;
                comboBox6.Visible = false;
            }
            else if (comboBox4.SelectedIndex == (int)Prof.Engineer || comboBox4.SelectedIndex == (int)Prof.Working)
            {
                label13.Visible = false;
                numericUpDown2.Visible = false;
                label12.Visible = true;
                comboBox6.Visible = true;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, "^[А-Я][а-я]") && Regex.IsMatch(textBox5.Text, "^[А-Я][а-я]"))
            {
                if (comboBox4.SelectedIndex == (int)Prof.Administration)
                {
                    listPeople.Add(new Administration(textBox4.Text, textBox5.Text, ((List<Gender>)comboBox5.DataSource)[comboBox5.SelectedIndex], (int)numericUpDown2.Value));
                }
                else if (comboBox4.SelectedIndex == (int)Prof.Engineer)
                {
                    listPeople.Add(new Engineer(textBox4.Text, textBox5.Text, ((List<Gender>)comboBox5.DataSource)[comboBox5.SelectedIndex], ((List<Category>)comboBox6.DataSource)[comboBox6.SelectedIndex]));
                }
                else if (comboBox4.SelectedIndex == (int)Prof.Working)
                {
                    listPeople.Add(new Working(textBox4.Text, textBox5.Text, ((List<Gender>)comboBox5.DataSource)[comboBox5.SelectedIndex], ((List<Category>)comboBox6.DataSource)[comboBox6.SelectedIndex]));
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (Person ob in listPeople)
                {
                    Console.WriteLine($"{ob}");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int index = (int)numericUpDown3.Value;
            if (index < listPeople.Count)
            {
                listPeople.RemoveAt(index);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Person ob in listPeople)
            {
                Console.WriteLine($"{ob}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            listPeople.Sort();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Person ob in listPeople)
            {
                Console.WriteLine($"{ob}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, "^[А-Я][а-я]") && Regex.IsMatch(textBox5.Text, "^[А-Я][а-я]"))
            {
                int index = -1;
                for (int i = 0; i < listPeople.Count; i++)
                {
                    if (listPeople[i].Firstname == textBox4.Text && listPeople[i].Surname == textBox5.Text)
                    {
                        index = i;
                        break;
                    }
                }

                if (index > -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(listPeople[index]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Не найдено!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
