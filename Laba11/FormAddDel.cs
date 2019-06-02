using Laba10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Laba11
{
    enum Prof
    {
        Administration,
        Engineer,
        Working
    }
    public partial class FormAddDel : Form
    {

        SortedList sortedListPeople;
        public FormAddDel(SortedList _sortedListPeople)
        {
            InitializeComponent();
            sortedListPeople = _sortedListPeople;
            comboBox1.DataSource = new List<string>() { "Администратор", "Инженер", "Рабочий" };
            comboBox2.DataSource = new List<Gender>() { Gender.Male, Gender.Female };
            comboBox3.DataSource = new List<Category>() { Category.Beginner, Category.Middle, Category.God };
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == (int)Prof.Administration)
            {
                label6.Visible = true;
                numericUpDown1.Visible = true;
                label5.Visible = false;
                comboBox3.Visible = false;
            }
            else if (comboBox1.SelectedIndex == (int)Prof.Engineer || comboBox1.SelectedIndex == (int)Prof.Working)
            {
                label6.Visible = false;
                numericUpDown1.Visible = false;
                label5.Visible = true;
                comboBox3.Visible = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "^[А-Я][а-я]") && Regex.IsMatch(textBox2.Text, "^[А-Я][а-я]"))
            {
                string key = textBox2.Text + textBox1.Text;
                try
                {
                    if (comboBox1.SelectedIndex == (int)Prof.Administration)
                    {
                        sortedListPeople.Add(key, new Administration(textBox1.Text, textBox2.Text, ((List<Gender>)comboBox2.DataSource)[comboBox2.SelectedIndex], (int)numericUpDown1.Value));
                    }
                    else if (comboBox1.SelectedIndex == (int)Prof.Engineer)
                    {
                        sortedListPeople.Add(key, new Engineer(textBox1.Text, textBox2.Text, ((List<Gender>)comboBox2.DataSource)[comboBox2.SelectedIndex], ((List<Category>)comboBox3.DataSource)[comboBox3.SelectedIndex]));
                    }
                    else if (comboBox1.SelectedIndex == (int)Prof.Working)
                    {
                        sortedListPeople.Add(key, new Working(textBox1.Text, textBox2.Text, ((List<Gender>)comboBox2.DataSource)[comboBox2.SelectedIndex], ((List<Category>)comboBox3.DataSource)[comboBox3.SelectedIndex]));
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (DictionaryEntry ob in sortedListPeople)
                    {
                        Console.WriteLine($"{ob.Key}: {ob.Value}");
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, "^[А-Яа-я]"))
            {
                sortedListPeople.Remove(textBox3.Text);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (DictionaryEntry ob in sortedListPeople)
                {
                    Console.WriteLine($"{ob.Key}: {ob.Value}");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, "^[А-Яа-я]"))
            {
                int index = sortedListPeople.IndexOfKey(textBox3.Text);
                if (index != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(index + ": " + sortedListPeople.GetKey(index).ToString());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
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
