using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Les1Exercise2
{
    class Bullet: BaseObject
    {
        Bitmap img;
        Random r = new Random(Guid.NewGuid().GetHashCode());
        /// <summary>
        /// Конструктор Bullet
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
             img = new Bitmap("Bullet.png");
        }
        /// <summary>
        /// Метод отрисовки звезды
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
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height) Dir.Y = -Dir.Y;
        }
    }
}
