using System;
using System.Windows.Forms;

namespace Les1Exercise1
{
    //Ронжин Л.

    //1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
    //2. * Заменить кружочки картинками, используя метод DrawImage.

    //Сергей, для реалистичности было бы неплохо сделать чтобы звезды двигались за планетой, но я не смог найти способа поместить ее на передний план,
    //подскажите как это можно реализовать?
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
