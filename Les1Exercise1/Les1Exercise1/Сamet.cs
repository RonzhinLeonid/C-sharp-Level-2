using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Les1Exercise1
{
    class Сamet: BaseObject
    {
        Bitmap img;
        /// <summary>
        /// Конструктор Camet
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Сamet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap("Camet.png");
        }
        /// <summary>
        /// Метод отрисовки каметы
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Метод описания движения каметы
        /// </summary>
        public override void Update()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < -Game.Height) { Pos.X = r.Next(Game.Width)*2; Pos.Y = 0; }
            if (Pos.Y > Game.Height*2) { Pos.X = r.Next(Game.Width)*2; Pos.Y = 0; }
        }
    }
}
