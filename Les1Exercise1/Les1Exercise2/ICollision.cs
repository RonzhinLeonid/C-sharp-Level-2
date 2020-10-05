using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Интерфейс закладывает поведение, по которому два объекта, поддерживающие его, могут определить, столкнулись ли они.
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
