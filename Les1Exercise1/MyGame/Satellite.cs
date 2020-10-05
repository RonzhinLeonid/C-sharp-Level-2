using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Satellite: BaseObject
    {
        Bitmap img;
        /// <summary>
        /// Конструктор Satellite
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Satellite(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap("Satellite.png");
        }
        
        /// <summary>
        /// Метод отрисовки спутника
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Метод описания движения спутника
        /// </summary>
        public override void Update()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            Pos.X = Pos.X - Dir.X * 2;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X < 0) { Pos.X = r.Next(Game.Width) * 2; Pos.Y = Game.Height; }
            if (Pos.Y < 0) { Pos.X = r.Next(Game.Width) * 2; Pos.Y = Game.Height; }
        }
    }
}
