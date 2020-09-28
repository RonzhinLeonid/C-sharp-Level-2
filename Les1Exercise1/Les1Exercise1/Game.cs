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
        public static BaseObject[] _objs;
        public static void Load()
        {
            //_objs = new BaseObject[50];
            //for (int i = 0; i < _objs.Length; i++)
            //    _objs[i] = new BaseObject(new Point(100, i * 5), new Point(20 - i, 20 - i), new Size(10, 10));
            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length; i++)
            //    _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(20, 20));
            Random r = new Random(Guid.NewGuid().GetHashCode());
            _objs = new BaseObject[40];
            for (int i = 0; i < _objs.Length-2; i++)
                //    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
                //for (int i = _objs.Length / 2; i < _objs.Length; i++)  Game.Height
                _objs[i] = new Star(new Point(r.Next(20, Width), i * (Height / _objs.Length) + r.Next(10)),
                                    new Point(r.Next(10, 25), 0),
                                    new Size(12, 12));
            _objs[_objs.Length - 2] = new Сamet(new Point(400,0), new Point(50, 50), new Size(50, 50));
            _objs[_objs.Length - 1] = new Satellite(new Point(400, 0), new Point(15, 15), new Size(70, 70));
        }

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
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
        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
           // Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.LightGray, new Rectangle(550, 20, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Gray, new Rectangle(570, 100, 20, 30));
            //Buffer.Graphics.FillEllipse(Brushes.Gray, new Rectangle(560, 105, 30, 20));
            //Buffer.Graphics.FillEllipse(Brushes.Gray, new Rectangle(600, 150, 40, 30));
            //Buffer.Graphics.FillEllipse(Brushes.Gray, new Rectangle(670, 60, 25, 30));
            Game.Buffer.Graphics.DrawImage(new Bitmap("Planet.png"), 550, 20, 200, 200);
           // Game.Buffer.Graphics.DrawImage(new Bitmap("Star.png"), 300, 200, 200, 200);
            // Buffer.Render();

            // Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
