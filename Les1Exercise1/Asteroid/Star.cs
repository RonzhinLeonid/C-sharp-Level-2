using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Star: BaseObject
    {
        Bitmap img;
        /// <summary>
        /// Конструктор Star
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            if (pos.X > Game.Width || pos.Y > Game.Height || pos.X < 0 || pos.Y < 0)
                throw new GameObjectException("Координаты объекта неверны");
            else
                Pos = pos;

            img = new Bitmap("Star.png");
        }
        /// <summary>
        /// Метод отрисовки звезды
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Метод описания движения звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
