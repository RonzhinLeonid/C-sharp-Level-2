using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Les1Exercise1
{
    class Satellite: BaseObject
    {
        public Satellite(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.White, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            Game.Buffer.Graphics.FillRectangle(Brushes.LightBlue, new Rectangle(Pos.X + Size.Width + 5, Pos.Y + Size.Height / 4, Size.Width, Size.Height / 2));
            Game.Buffer.Graphics.FillRectangle(Brushes.LightBlue, new Rectangle(Pos.X - Size.Width - 5, Pos.Y + Size.Height / 4, Size.Width, Size.Height / 2));
            Game.Buffer.Graphics.FillPolygon(Brushes.LightBlue, new Point[] {new Point(Pos.X, Pos.Y + Size.Height / 2),
                                                                             new Point(Pos.X - 5, Pos.Y + Size.Height / 4),
                                                                             new Point(Pos.X - 5, Pos.Y + Size.Height / 4 + Size.Height / 2)});
            Game.Buffer.Graphics.FillPolygon(Brushes.LightBlue, new Point[] {new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2),
                                                                             new Point(Pos.X + Size.Width + 5, Pos.Y + Size.Height / 4),
                                                                             new Point(Pos.X + Size.Width + 5, Pos.Y + Size.Height / 4 + Size.Height / 2)});
        }
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
