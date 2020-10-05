using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Ship : BaseObject
    {
        Bitmap img;

        private int _energy = 100;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public void EnergyUp(int n)
        {
            _energy += n;
        }
        public int Energy => _energy;

        /// <summary>
        /// Конструктор Ship
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = new Bitmap("Ship.png");
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public static event Message MessageDie;
    }    
}
