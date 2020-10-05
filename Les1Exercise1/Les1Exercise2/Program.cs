using System;
using System.Windows.Forms;
using System.IO;

namespace MyGame
{
    //Ронжин Л.

    //1. Добавить космический корабль, как описано в уроке. - готово
    //2. Доработать игру «Астероиды»:
    //  a. Добавить ведение журнала в консоль с помощью делегатов; - готово
    //  b. * добавить это и в файл. - готово
    //3. Разработать аптечки, которые добавляют энергию.  - готово
    //4. Добавить подсчет очков за сбитые астероиды. - готово

    // Сергей, чем отличается Keys.ControlKey от Keys.Control, в методичке был использован последний, он у меня отказывается работать.
    // Доработал класс Game так чтобы корабль мог стрелять не по одной пули как это чделано в методичке.

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
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
