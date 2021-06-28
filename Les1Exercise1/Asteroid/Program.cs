using System;
using System.Windows.Forms;
using System.IO;

namespace MyGame
{
    //Ронжин Л.

    //1. Добавить в программу коллекцию астероидов.Как только она заканчивается(все астероиды сбиты), формируется новая коллекция,
    //в которой на один астероид больше.
    //Помимо количество добавлено увеличение скорости.
    //Для этого создание астероидов вынесено в отдельный метоад LoadAsteroid(). и добавлен метод проверки списка астероидов на 
    //null всех элементов, если все null то содается новый список астероидов с новыми параметрами.
    //Правильно ли делать так по ресурсам? получается что проверка спика происходит каждый тик таймера.

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Очистка журнала игры
            StreamWriter sw = new StreamWriter("Message.txt", false);
            sw.WriteLine("Новая игра");
            sw.Close();

            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height-100
            };
            form.StartPosition = FormStartPosition.CenterScreen;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
