using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MyGame
{

    static class Game
    {
        public static EventMes messages = new EventMes();
        private static Timer timer = new Timer();
        public static Random Rnd = new Random();
        public static List<BaseObject> _objs;
        public static List<BaseObject> _asteroids;
        public static List<BaseObject> _bullet = new List<BaseObject>();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Bitmap img;
        static int score = 0;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(0, 10), new Size(50, 50));
        private static Energy _energy = new Energy(new Point(800, 400), new Point(30, 0), new Size(50, 50));
        static int countAsteroid;
        static int speedAsterod;
        /// <summary>
        /// Метод инициализации объектов
        /// </summary>
        public static void Load()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            //набор объектов для фона
            _objs = new List<BaseObject>();
            try
            {
                int countStar = 60;
                for (int i = 0; i < countStar; i++)
                    _objs.Add(new Star(new Point(r.Next(20, Width), i * (Height / countStar) + r.Next(10)),
                                         new Point(r.Next(10, 25), 0),
                                         new Size(12, 12)));
                _objs.Add(new Сamet(new Point(400, 0), new Point(50, 50), new Size(50, 50)));
                _objs.Add(new Satellite(new Point(400, 0), new Point(15, 15), new Size(70, 70)));

            }
            catch (GameObjectException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Метод инициализации объектов
        /// </summary>
        public static void LoadAsteroid(int countAsteroid, int speed)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            _asteroids = new List<BaseObject>();
            //набор астероидов
            for (int i = 0; i < countAsteroid; i++)
                _asteroids.Add(new Asteroid(new Point(r.Next(20, Width), i * (Height / countAsteroid) + r.Next(10)),
                                     new Point(r.Next(10 + speed, 25 + speed), 0),
                                     new Size(30, 30)));
        }

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// Конструктор игры
        /// </summary>
        static Game()
        {
            img = new Bitmap("Planet.png");
            countAsteroid = 10;
            speedAsterod = 0;
        }
        /// <summary>
        /// Метод для отрисовки графики в игре
        /// </summary>
        /// <param name="form">Форма игры</param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            try
            {
                Width = form.ClientSize.Width;
                if (Width > 1000 || Width < 0) throw new GameFormException();//генерация исключения ширины
            }
            catch (GameFormException)
            {
                form.Width = 1000;
                Width = 1000;
            }
            try
            {
                Height = form.ClientSize.Height;
                if (Height > 1000 || Height < 0) throw new GameFormException();//генерация исключения высоты
            }
            catch (GameFormException)
            {
                form.Height = 1000;
                Height = 1000;
            }
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            LoadAsteroid(10, 0);
            form.KeyDown += Form_KeyDown;
            //Timer timer = new Timer { Interval = 50 };
            timer.Interval = 50;
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;
        }
        /// <summary>
        /// Обработка нажатия клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet.Add(new Bullet(  new Point(_ship.Rect.X + _ship.Rect.Height/2, _ship.Rect.Y + _ship.Rect.Width/5), 
                                                            new Point(10, 0), 
                                                            new Size(30, 30)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
        /// <summary>
        /// Метод отрисовки объектов(основной для запуска игры)
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black); //задание фона
            foreach (BaseObject obj in _objs) obj.Draw(); //отрисовка всех объектов
            Game.Buffer.Graphics.DrawImage(img, Width - 250, 20, 200, 200); //отрисовка фоновой планеты
            foreach (Asteroid a in _asteroids) a?.Draw();//отрисовка всех астероидов
            foreach (Bullet b in _bullet) b?.Draw();//отрисовка всех пуль
            _ship?.Draw();//отрисовка корабля
            _energy?.Draw();//отрисовка энергии
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);// Енерия корабля
            Buffer.Graphics.DrawString("Scores:" + score, SystemFonts.DefaultFont, Brushes.White, 100, 0);//Количество очков
            Buffer.Render();
        }

        /// <summary>
        /// Метода движения всех объектов
        /// </summary>
        public static void Update()
        {
            _energy?.Update();
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet bull in _bullet) bull?.Update();
            for (var i = 0; i < _asteroids.Count; i++)
            {
                if (_asteroids[i] == null)  continue;
                _asteroids[i].Update();
                for (var j = 0; j < _bullet.Count; j++)
                {   
                        //проверка попадания пули в астероид
                    if (_bullet[j] != null && _asteroids[i] != null && _bullet[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        //_asteroids[i].UpdateCollision();
                        _asteroids[i] = null;
                        _bullet[j] = null;
                        score++;
                        messages.AsteroidDie(Message);
                        continue;
                    }
                }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;

                //Столкновенние с астероидом
                _asteroids[i].UpdateCollision();
                var rnd = new Random();
                int damage = rnd.Next(10, 30);
                _ship?.EnergyLow(damage);
                System.Media.SystemSounds.Asterisk.Play();
                messages.ShipDamage(damage, Message);

                //проверка на кол-во енергии у корабля, если меньше 0, то корабль уничтожен.
                if (_ship.Energy <= 0) 
                { 
                    _ship?.Die();
                    messages.ShipDie(Message);
                }
                
            }
            //Лечение корабля с соответствующим сообщением
            if (_ship.Collision(_energy))
            {
                var rnd = new Random();
                int energy = rnd.Next(5, 15);
                _ship?.EnergyUp(energy);
                messages.ShipHealth(energy, Message);
                _energy.UpdateCollision();
                System.Media.SystemSounds.Hand.Play();
            }

            if(_asteroids.Check()) LoadAsteroid(++countAsteroid, ++speedAsterod);
        }

        /// <summary>
        /// Таймер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        /// <summary>
        /// Метод для делегата
        /// </summary>
        /// <param name="message"></param>
        private static void Message(string message)
        {
            Console.WriteLine(message);
            StreamWriter sw = new StreamWriter("Message.txt", true);
            sw.WriteLine(message);
            sw.Close();
        }
    }
}
