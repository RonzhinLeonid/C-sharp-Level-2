using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyGame
{
    class EventMes
    {
        public delegate void Message(string message);
        private event Message _message;

        public EventMes() {}
        /// <summary>
        /// Повреждение корабля
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="message"></param>
        public void ShipDamage(int damage, Message message)
        {
            _message = message;
            _message?.Invoke($"Корабль стулкнулся с астероидом. {damage} единиц урона.");
        }
        /// <summary>
        /// Восстановление корабля
        /// </summary>
        /// <param name="energy"></param>
        /// <param name="message"></param>
        public void ShipHealth(int energy, Message message)
        {
            _message = message;
            _message?.Invoke($"Корабль восстановил енергию. {energy} единиц енергии.");
        }
        /// <summary>
        /// Сообщение: "Астероид уничтожен"
        /// </summary>
        /// <param name="message"></param>
        public void AsteroidDie(Message message)
        {
            _message = message;
            _message?.Invoke($"Корабль уничтожил автероид.");
        }
        /// <summary>
        /// Сообщение: "Корабль уничтожен"
        /// </summary>
        /// <param name="message"></param>
        public void ShipDie(Message message)
        {
            _message = message;
            _message?.Invoke($"Корабль уничтожен.");
        }
    }
}
