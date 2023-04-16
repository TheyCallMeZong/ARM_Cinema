using ARMCinema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ARMCinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Список показов
        private List<Show> shows = new List<Show>();
        private List<Session> sessionsList = new List<Session>();

        public MainWindow()
        {
            InitializeComponent();
            MyBorder.IsEnabled = false;
            sessionCountText.Text = sessionsList.Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (filmBtn.IsChecked == true)
            {
                var text1 = stackPanel.Children[5] as TextBox;
                var text2 = stackPanel.Children[7] as TextBox;
                var text3 = stackPanel.Children[9] as TextBox;
                if (!Int32.TryParse(text1.Text, out _) || !Int32.TryParse(text2.Text, out _)
                    || !Int32.TryParse(text3.Text, out _))
                {
                    MessageBox.Show("Вы ввели неправильные данные! Проверьте правильность ввода!");
                    return;
                }
            }
            if (serialBtn.IsChecked == true)
            {
                var text1 = stackPanel.Children[5] as TextBox;
                var text2 = stackPanel.Children[7] as TextBox;
                var text3 = stackPanel.Children[9] as TextBox;
                var text4 = stackPanel.Children[11] as TextBox;
                if (!Int32.TryParse(text1.Text, out _) || !Int32.TryParse(text2.Text, out _)
                    || !Int32.TryParse(text3.Text, out _) || !Int32.TryParse(text4.Text, out _))
                {
                    MessageBox.Show("Вы ввели неправильные данные! Проверьте правильность ввода!");
                    return;
                }
            }

            if (serialBtn.IsChecked == false && filmBtn.IsChecked == false)
            {
                MessageBox.Show("Выберите тип показа!");
                return;
            }
            MyBorder.IsEnabled = true;
            Bor.IsEnabled = false;
            MyBor.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var grid = sessionPanel.Children.OfType<Grid>().FirstOrDefault();
            foreach (var element in grid.Children)
                if (element is TextBox text)
                    if (text.Text.Equals(String.Empty))
                    {
                        MessageBox.Show("Заполните все поля!");
                        foreach (var element2 in sessionPanel.Children)
                            if (element2 is TextBox text2)
                                text2.Text = null;
                        return;
                    }


            foreach (var element in grid.Children)
                if (element is TextBox text)
                    if (!int.TryParse(text.Text, out _))
                    {
                        MessageBox.Show("Введите корректные данные!");
                        foreach (var element2 in sessionPanel.Children)
                            if (element2 is TextBox text2)
                                text2.Text = null;
                        return;
                    }

            if (int.Parse(mounthTextBox.Text) > 12 | int.Parse(mounthTextBox.Text) < 1)
            {
                MessageBox.Show("Введите корректную дату!");
                return;
            }

            if (int.Parse(dayTextBox.Text) > 31 | int.Parse(dayTextBox.Text) < 1)
            {
                MessageBox.Show("Введите корректную дату!");
                return;
            }

            if (int.Parse(hourTextBox.Text) > 24 | int.Parse(hourTextBox.Text) < 0)
            {
                MessageBox.Show("Введите корректное время!");
                return;
            }

            if (int.Parse(minutesTextBox.Text) > 60 | int.Parse(minutesTextBox.Text) < 0)
            {
                MessageBox.Show("Введите корректное время!");
                return;
            }

            sessionsList.Add(new Session(int.Parse(costTextBox.Text), new DateTime(int.Parse(yearTextBox.Text), int.Parse(mounthTextBox.Text),
                                                                                   int.Parse(dayTextBox.Text), int.Parse(hourTextBox.Text),
                                                                                   int.Parse(minutesTextBox.Text), 0)));
            foreach (var element in grid.Children)
                if (element is TextBox text)
                    text.Text = null;

            sessionCountText.Text = sessionsList.Count.ToString();
        }

        private void SetData(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Clear();
            RadioButton seanseType = (RadioButton)sender;
            var border = (Border)this.FindName("Bor");
            border.Child = null;
            if (seanseType.Content.ToString().Equals("Фильм"))
            {
                var label1 = new Label();
                label1.Content = "Введите название фильма: ";
                label1.Margin = new Thickness(15, 5, 0, 0);

                var label2 = new Label();
                label2.Content = "Введите жанр фильма: ";
                label2.Margin = new Thickness(15, 5, 0, 0);

                var label3 = new Label();
                label3.Content = "Введите возрастное ограничение: ";
                label3.Margin = new Thickness(15, 5, 0, 0);

                var label4 = new Label();
                label4.Content = "Введите зал: ";
                label4.Margin = new Thickness(15, 5, 0, 0);

                var label5 = new Label();
                label5.Content = "Введите длительность фильма: ";
                label5.Margin = new Thickness(15, 5, 0, 0);

                TextBox textBox1 = new TextBox();
                textBox1.Width = 230;
                textBox1.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox2 = new TextBox();
                textBox2.Width = 230;
                textBox2.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox3 = new TextBox();
                textBox3.Width = 230;
                textBox3.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox4 = new TextBox();
                textBox4.Width = 230;
                textBox4.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox5 = new TextBox();
                textBox5.Width = 230;
                textBox5.Margin = new Thickness(15, 0, 50, 0);

                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(textBox1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(textBox2);
                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(textBox3);
                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(textBox4);
                stackPanel.Children.Add(label5);
                stackPanel.Children.Add(textBox5);
                border.Child = stackPanel;
            }
            else if (seanseType.Content.ToString().Equals("Сериал"))
            {
                var label1 = new Label();
                label1.Content = "Введите название сериала: ";
                label1.Margin = new Thickness(15, 5, 0, 0);

                var label2 = new Label();
                label2.Content = "Введите жанр сериала: ";
                label2.Margin = new Thickness(15, 5, 0, 0);

                var label3 = new Label();
                label3.Content = "Введите возрастное ограничение: ";
                label3.Margin = new Thickness(15, 5, 0, 0);

                var label4 = new Label();
                label4.Content = "Введите зал: ";
                label4.Margin = new Thickness(15, 5, 0, 0);

                var label5 = new Label();
                label5.Content = "Введите количество серий: ";
                label5.Margin = new Thickness(15, 5, 0, 0);

                var label6 = new Label();
                label6.Content = "Введите длительность сериала: ";
                label6.Margin = new Thickness(15, 5, 0, 0);

                TextBox textBox1 = new TextBox();
                textBox1.Width = 230;
                textBox1.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox2 = new TextBox();
                textBox2.Width = 230;
                textBox2.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox3 = new TextBox();
                textBox3.Width = 230;
                textBox3.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox4 = new TextBox();
                textBox4.Width = 230;
                textBox4.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox5 = new TextBox();
                textBox5.Width = 230;
                textBox5.Margin = new Thickness(15, 0, 50, 0);

                TextBox textBox6 = new TextBox();
                textBox6.Width = 230;
                textBox6.Margin = new Thickness(15, 0, 50, 0);

                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(textBox1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(textBox2);
                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(textBox3);
                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(textBox4);
                stackPanel.Children.Add(label5);
                stackPanel.Children.Add(textBox5);
                stackPanel.Children.Add(label6);
                stackPanel.Children.Add(textBox6);
                border.Child = stackPanel;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Проверяем заполнены ли все поля
            foreach (Control c in stackPanel.Children)
                if (c is TextBox text)
                    if (text.Text == "")
                    {
                        MessageBox.Show("Вы не заполнили все поля!");
                        return;
                    }

            if (sessionCountText.Text == "0")
            {
                MessageBox.Show("Вы не добавили сеансы!");
                return;
            }

            if (filmBtn.IsChecked == true)
            {
                var text1 = stackPanel.Children[1] as TextBox;
                var text2 = stackPanel.Children[3] as TextBox;
                var text3 = stackPanel.Children[5] as TextBox;
                var text4 = stackPanel.Children[7] as TextBox;
                var text5 = stackPanel.Children[9] as TextBox;
                shows.Add(new Film(text1.Text,text2.Text,
                    int.Parse(text3.Text), int.Parse(text4.Text),
                    int.Parse(text5.Text), fill_in_session(sessionsList)));
            }

            //Если выбран сериал, проверяем правильно ли заполнены все поля. Если да - добавляем в список показов.
            if (serialBtn.IsChecked == true)
            {
                var text1 = stackPanel.Children[1] as TextBox;
                var text2 = stackPanel.Children[3] as TextBox;
                var text3 = stackPanel.Children[5] as TextBox;
                var text4 = stackPanel.Children[7] as TextBox;
                var text5 = stackPanel.Children[9] as TextBox;
                var text6 = stackPanel.Children[11] as TextBox;
                shows.Add(new Serial(text1.Text, text2.Text,
                    int.Parse(text3.Text), int.Parse(text4.Text),
                    int.Parse(text5.Text), int.Parse(text6.Text), fill_in_session(sessionsList)));
            }

            countTextBox.Text = shows.Count.ToString();
            sessionCountText.Text = "0";
            MyBorder.IsEnabled = false;
            Bor.IsEnabled = true;
            clearAll();
            sessionsList.Clear();
        }

        private void clearAll()
        {
            MyBor.IsEnabled = true;
            stackPanel.Children.Clear();
            var grid = sessionPanel.Children.OfType<Grid>().FirstOrDefault();
            foreach (Control ic in grid.Children)
                if (ic is TextBox text)
                    text.Text = null;
            sessionsList.Clear();
            sessionCountText.Text = "0";
            filmBtn.IsChecked = false;
            serialBtn.IsChecked = false;
            Bor.IsEnabled = true;
        }

        private List<Session> fill_in_session(List<Session> list)
        {
            List<Session> temp = new List<Session>();
            for (int i = 0; i < list.Count; i++)
                temp.Add(list[i]);
            return temp;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MyBorder.IsEnabled = false;
            clearAll();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("TestWrite.json", string.Empty);
            MessageBox.Show("Данные прошлого запуска удалены!");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // При переходе в основную форму десериализуем объекты прошлого запуска
            StreamReader sw = File.OpenText("TestWrite.json");
            string line;

            while ((line = sw.ReadLine()) != null)
            {
                if (line.Contains("Count_of_series"))
                    shows.Add(JsonSerializer.Deserialize<Serial>(line));
                else
                    shows.Add(JsonSerializer.Deserialize<Film>(line));
            }
            sw.Close();

            Hide();
            MainForm f = new MainForm(shows);
            f.ShowDialog();
            this.Close();
        }
    }
}
