using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    public delegate void Message();
    abstract class BaseObject: ICollision
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected Point dir
        {
            get { return Dir; }
            set
            {
                if (value.X > 100 || value.Y > 100)
                    throw new GameObjectException("Скорость слишком велика");
                else if (value.X <= 0 || value.Y <= 0)
                    throw new GameObjectException("Скорость не может быть меньше 0");
                else
                    Dir = value;
            }
        }
        /// <summary>
        /// Конструктор базового класса
        /// </summary>
        /// <param name="pos">Положение</param>
        /// <param name="dir">Скорость перемещения</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            
            if (dir.X > 100 || dir.Y > 100)
                throw new GameObjectException("Скорость слишком велика");
            else if (dir.X < 0 || dir.Y < 0)
                throw new GameObjectException("Скорость не может быть меньше 0");
            else
                Dir = dir;

            if (size.Height > 100 || size.Width > 100)
                throw new GameObjectException("Размер объекта слишком велик");
            else if (size.Height < 0 || size.Width < 0)
                throw new GameObjectException("Размер объекта не может быть меньше 0");
            else
                Size = size;
        }

        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)
        public Rectangle Rect => new Rectangle(Pos, Size);
        /// <summary>
        /// Проверка на колизию 2х объектов
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        /// <summary>
        /// Абстрактный метод отрисовки
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Абстрактный метод движения
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Метод генерации базового объекта после столкновения
        /// </summary>
        public virtual void UpdateCollision() 
        {
            Pos.Y = r.Next(Game.Height - Size.Height);
        }
    }
}
