using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Les1Exercise2
{

    static class Game
    {
        public static List<BaseObject> _objs;
        public static List<BaseObject> _asteroids;
        public static BaseObject _bullet;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Bitmap img;
        
        /// <summary>
        /// Метод инициализации объектов
        /// </summary>
        public static void Load()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            //набор объектов для фона
            _objs = new List<BaseObject>();
            _asteroids = new List<BaseObject>();

            try
            {
                int countStar = 60;
                for (int i = 0; i < countStar; i++)
                    _objs.Add(new Star(new Point(r.Next(20, Width), i * (Height / countStar) + r.Next(10)),
                                         new Point(r.Next(10, 25), 0),
                                         new Size(12, 12)));
                _objs.Add(new Сamet(new Point(400, 0), new Point(50, 50), new Size(50, 50)));
                _objs.Add(new Satellite(new Point(400, 0), new Point(15, 15), new Size(70, 70)));

                //Два объекта для проверки исключения. 
                _objs.Add(new Satellite(new Point(400, 0), new Point(150, 15), new Size(70, 70)));
                //_objs.Add(new Star(new Point(4000, 0), new Point(10, 15), new Size(70, 70)));
            }
            catch (GameObjectException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //набор астероидов
            int countAsteroid = 10;
                for (int i = 0; i < countAsteroid; i++)
                    _asteroids.Add(new Asteroid(new Point(r.Next(20, Width), i * (Height / countAsteroid) + r.Next(10)),
                                         new Point(r.Next(10, 25), 0),
                                         new Size(30, 30)));

            //пуля
            _bullet = new Bullet(new Point(50, 0), new Point(10, 10), new Size(50, 50));
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
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Метод отрисовки объектов(основной для запуска игры)
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black); //задание фона
            foreach (BaseObject obj in _objs) obj.Draw(); //отрисовка всех объектов
            Game.Buffer.Graphics.DrawImage(img, Width - 250, 20, 200, 200); //отрисовка фоновой планеты
            foreach (Asteroid obj in _asteroids) obj.Draw(); //отрисовка всех астероидов
            _bullet.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Метода движения всех объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) //проверка на столкновение
                { 
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.UpdateCollision();
                    a.UpdateCollision();
                }
            }
            _bullet.Update();

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
    }
}
