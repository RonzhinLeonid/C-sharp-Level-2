using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Les1Exercise1
{

    static class Game
    {
        public static List<BaseObject> _objs;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Bitmap img;
        /// <summary>
        /// Метод инициализации объектов
        /// </summary>
        public static void Load()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            _objs = new List<BaseObject>();
            int countStar = 40;
            for (int i = 0; i < countStar; i++)
               _objs.Add(new Star(new Point(r.Next(20, Width), i * (Height / countStar) + r.Next(10)),
                                    new Point(r.Next(10, 25), 0),
                                    new Size(12, 12)));
            _objs.Add(new Сamet(new Point(400,0), new Point(50, 50), new Size(50, 50)));
            _objs.Add(new Satellite(new Point(400, 0), new Point(15, 15), new Size(70, 70)));
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
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
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
            Game.Buffer.Graphics.DrawImage(img, 550, 20, 200, 200); //отрисовка фоновой планеты
            Buffer.Render();
        }
        /// <summary>
        /// Метода движения всех объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
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
