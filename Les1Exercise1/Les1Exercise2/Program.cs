using System;
using System.Windows.Forms;

namespace Les1Exercise2
{
    //Ронжин Л.

    //2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках. - готово
    //3. Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана. - готово
    //4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или
    //принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException(). - готово
    //5. * Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект с неправильными
    //характеристиками(например, отрицательные размеры, слишком большая скорость или неверная позиция). - готово

    //Сергей, вопрос по исключениям. Добавил условие генерации исключения в конструктор в базовом классе для скорсти и размера,
    //и для объекта Star в конструкторе задал условие для позиции. При запуске программы сообщение выскакивает дважды, как это исправить?
    //В методе Load есть два объекта для проверки исключения.


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
