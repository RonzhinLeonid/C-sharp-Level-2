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
        public Сamet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap("Camet.png"), Pos.X, Pos.Y, Size.Width, Size.Height);

            //Game.Buffer.Graphics.FillEllipse(Brushes.Yellow, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.FillPolygon(Brushes.Yellow, new Point[] {new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2),
            //                                                              new Point(Pos.X + 6 * Size.Width, Pos.Y - 5 * Size.Height),
            //                                                              new Point(Pos.X + Size.Width / 2, Pos.Y)});
        }
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
