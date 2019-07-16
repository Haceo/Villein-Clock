using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vilian_Clock
{
    public partial class MainWindow : Window
    {
        int minutes;
        int seconds;
        DispatcherTimer dt;
        public MainWindow()
        {
            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(Update);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
        }
        void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            Line sec = new Line();
            sec.Stroke = redBrush;
            sec.StrokeThickness = 5;
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
                    sevenSixtyEight();
                    twoFiftySix();
                }
                if (sub >= 512)
                {
                    sub = sub - 512;
                    fiveTwelve();
                }
                if (sub >= 256)
                {
                    sub = sub - 256;
                    twoFiftySix();
                }
                if (sub >= 192)
                {
                    sub = sub - 192;
                    oneNintyTwo();
                    sixtyFour();
                }
                if (sub >= 128)
                {
                    sub = sub - 128;
                    oneTwentyEight();
                }
                if (sub >= 64)
                {
                    sub = sub - 64;
                    sixtyFour();
                }
                if (sub >= 48)
                {
                    sub = sub - 48;
                    fourtyEight();
                    sixteen();
                }
                if (sub >= 32)
                {
                    sub = sub - 32;
                    thirtyTwo();
                }
                if (sub >= 16)
                {
                    sub = sub - 16;
                    sixteen();
                }
                if (sub >= 12)
                {
                    sub = sub - 12;
                    twelve();
                    four();
                }
                if (sub >= 8)
                {
                    sub = sub - 8;
                    eight();
                }
                if (sub >= 4)
                {
                    sub = sub - 4;
                    four();
                }
                if (sub >= 3)
                {
                    sub = sub - 3;
                    three();
                    one();
                }
                if (sub >= 2)
                {
                    sub = sub - 2;
                    two();
                }
                if (sub >= 1)
                {
                    sub = sub - 1;
                    one();
                }
            }
            else
                return;
        }
        //display
        void one()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("85,85 65,65");
            minuteFace.Children.Add(line);
        }
        void two()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,65 85,85 105,105");
            minuteFace.Children.Add(line);
        }
        void three()//plus one
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("65,105 105,65");
            minuteFace.Children.Add(line);
        }
        void four()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("85,45 65,25");
            minuteFace.Children.Add(line);
        }
        void eight()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,65 85,45 105,25");
            minuteFace.Children.Add(line);
        }
        void twelve()//plus four
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,65 85,45 105,25");
            minuteFace.Children.Add(line);
        }
        void sixteen()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,65 125,85");
            minuteFace.Children.Add(line);
        }
        void thirtyTwo()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("145,65 125,85 145,105");
            minuteFace.Children.Add(line);
        }
        void fourtyEight()//plus sixteen
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("145,65 105,105");
            minuteFace.Children.Add(line);
        }
        void sixtyFour()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("65,105 85,125");
            minuteFace.Children.Add(line);
        }
        void oneTwentyEight()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,105 85,125 105,145");
            minuteFace.Children.Add(line);
        }
        void oneNintyTwo()//plus sixtyFour
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("105,105 65,145");
            minuteFace.Children.Add(line);
        }
        void twoFiftySix()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("45,85 25,65");
            minuteFace.Children.Add(line);
        }
        void fiveTwelve()
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("65,65 45,85 65,105");
            minuteFace.Children.Add(line);
        }
        void sevenSixtyEight()//plus twoFiftySix
        {
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            Polyline line = new Polyline();
            line.Stroke = blueBrush;
            line.StrokeThickness = 5;
            //points
            line.Points = PointCollection.Parse("65,65 25,105");
            minuteFace.Children.Add(line);
        }
    }
}
