using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static Vilian_Clock.PointMatrix.PointsEnum;

namespace Vilian_Clock
{
    public partial class MainWindow : Window
    {
        int minutes;
        int seconds;
        PointMatrix matrix;
        DispatcherTimer dt;
        public MainWindow()
        {
            InitializeComponent();
            matrix = new PointMatrix();
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(Update);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
        }
        void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        void Update(object sender, EventArgs e)
        {
            seconds = DateTime.Now.Second;
            minutes = DateTime.Now.Minute + (DateTime.Now.Hour * 60);
            LineSet();
        }
        void LineSet()
        {
            //second logic
            secondFace.Children.Clear();
            SolidColorBrush redBrush = new SolidColorBrush
            {
                Color = Colors.Red
            };
            Line sec = new Line
            {
                Stroke = redBrush,
                StrokeThickness = 5
            };
            if (seconds <= 15)
            {
                sec.X1 = 85 + (seconds * 5) - 2;
                sec.Y1 = 10 + (seconds * 5) - 2;
                sec.X2 = 85 + (seconds * 5) + 2;
                sec.Y2 = 10 + (seconds * 5) + 2;
            }
            else if (seconds > 15 && seconds <= 30)
            {
                sec.X1 = 160 - ((seconds - 15) * 5) - 2;
                sec.Y1 = 85 + ((seconds - 15) * 5) - 2;
                sec.X2 = 160 - ((seconds - 15) * 5) + 2;
                sec.Y2 = 85 + ((seconds - 15) * 5) + 2;
            }
            else if (seconds > 30 && seconds <= 45)
            {
                sec.X1 = 85 - ((seconds - 30) * 5) - 2;
                sec.Y1 = 160 - ((seconds - 30) * 5) - 2;
                sec.X2 = 85 - ((seconds - 30) * 5) + 2;
                sec.Y2 = 160 - ((seconds - 30) * 5) + 2;
            }
            else if (seconds > 45 && seconds <= 60)
            {
                sec.X1 = 10 + ((seconds - 45) * 5) - 2;
                sec.Y1 = 85 - ((seconds - 45) * 5) - 2;
                sec.X2 = 10 + ((seconds - 45) * 5) + 2;
                sec.Y2 = 85 - ((seconds - 45) * 5) + 2;
            }
            secondFace.Children.Add(sec);

            //minute logic
            minuteFace.Children.Clear();
            if (minutes != 0)
            {
                int sub = minutes;
                if (sub >= 768)
                {
                    sub = sub - 768;
                    Draw(matrix.Points[(int)SevenSixtyEight]);
                    Draw(matrix.Points[(int)TwoFiftySix]);
                }
                if (sub >= 512)
                {
                    sub = sub - 512;
                    Draw(matrix.Points[(int)FiveTwelve]);
                }
                if (sub >= 256)
                {
                    sub = sub - 256;
                    Draw(matrix.Points[(int)TwoFiftySix]);
                }
                if (sub >= 192)
                {
                    sub = sub - 192;
                    Draw(matrix.Points[(int)OneNintyTwo]);
                    Draw(matrix.Points[(int)SixtyFour]);
                }
                if (sub >= 128)
                {
                    sub = sub - 128;
                    Draw(matrix.Points[(int)OneTwentyEight]);
                }
                if (sub >= 64)
                {
                    sub = sub - 64;
                    Draw(matrix.Points[(int)SixtyFour]);
                }
                if (sub >= 48)
                {
                    sub = sub - 48;
                    Draw(matrix.Points[(int)FortyEight]);
                    Draw(matrix.Points[(int)SixTeen]);
                }
                if (sub >= 32)
                {
                    sub = sub - 32;
                    Draw(matrix.Points[(int)ThirtyTwo]);
                }
                if (sub >= 16)
                {
                    sub = sub - 16;
                    Draw(matrix.Points[(int)SixTeen]);
                }
                if (sub >= 12)
                {
                    sub = sub - 12;
                    Draw(matrix.Points[(int)Twelve]);
                    Draw(matrix.Points[(int)Four]);
                }
                if (sub >= 8)
                {
                    sub = sub - 8;
                    Draw(matrix.Points[(int)Eight]);
                }
                if (sub >= 4)
                {
                    sub = sub - 4;
                    Draw(matrix.Points[(int)Four]);
                }
                if (sub >= 3)
                {
                    sub = sub - 3;
                    Draw(matrix.Points[(int)Three]);
                    Draw(matrix.Points[(int)One]);
                }
                if (sub >= 2)
                {
                    sub = sub - 2;
                    Draw(matrix.Points[(int)Two]);
                }
                if (sub >= 1)
                {
                    sub = sub - 1;
                    Draw(matrix.Points[(int)One]);
                }
            }
            else
                return;
        }
        //display
        void Draw(string Points)
        {
            SolidColorBrush blueBrush = new SolidColorBrush
            {
                Color = Colors.Blue
            };
            var line = new Polyline
            {
                Stroke = blueBrush,
                StrokeThickness = 5,
                Points = PointCollection.Parse(Points)
            };
            minuteFace.Children.Add(line);
        }

    }
}
