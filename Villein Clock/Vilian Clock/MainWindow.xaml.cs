using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Linq;

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
                foreach (var item in matrix.Points.Reverse())
                {
                    if (sub >= item.Key)
                    {
                        sub = sub - item.Key;
                        (string p1, string p2) = item.Value;

                        Draw(p1);
                        if (!string.IsNullOrEmpty(p2))
                        {
                            Draw(p2);
                        }
                    }
                }
            }
            else
            {
                return;
            }
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
