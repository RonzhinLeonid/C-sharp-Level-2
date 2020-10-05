using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Asteroid: BaseObject
    {
        Bitmap img;
        Random r = new Random(Guid.NewGuid().GetHashCode());
        /// <summary>
        /// Конструктор Asteroid
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap("Asteroid.png");
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
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = r.Next(Game.Height - Size.Height);
            }
        }
        /// <summary>
        /// Метод генерации астероида после столкновения
        /// </summary>
        public override void UpdateCollision()
        {
            Pos.X = Game.Width;
            Pos.Y = r.Next(Game.Height - Size.Height);
        }
    }
}
