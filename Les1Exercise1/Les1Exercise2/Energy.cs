using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Energy: BaseObject
    {
        Bitmap img;
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public Energy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap("Energy.png");
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = r.Next(Game.Height - Size.Height);
            }
        }
        public override void UpdateCollision()
        {
            Pos.X = Game.Width;
            Pos.Y = r.Next(Game.Height - Size.Height);
        }
    }
}
