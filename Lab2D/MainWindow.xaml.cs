using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;

        Line myLine = new Line();
        Rectangle Dance = new Rectangle();
        Ellipse myEllipse = new Ellipse();
        Rectangle myRect = new Rectangle();
        Polygon myPolygon = new Polygon();
        Path path = new Path();

        int currentFrame = 1, currentRow = 0, cr = 6;
        int frameW = 100, frameH = 100;


        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 120);
            Scene.Focusable = true;

            //Point pos = Mouse.GetPosition(Scene);
            //Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
            //if (rect.Contains(pos) == true) { MessageBox.Show("Точка входит в прямоугольник!"); }
            //Rect ellipse = myEllipse.RenderTransform.TransformBounds(myEllipse.RenderedGeometry.Bounds);
            //if (rect.IntersectsWith(ellipse) == true) { MessageBox.Show("Фигуры пересекаются!"); }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var frameLeft = currentFrame * frameW;
            var frameTop = currentRow * frameH;
            (Dance.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft+frameW, frameTop+frameH);
            if (currentFrame % cr == 0)
            {
                currentRow++;
                currentFrame = 0;
            }
            currentFrame++;
        }

        private void LMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(myLine);
        }

        private void EMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(myEllipse);
        }

        private void RMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(myRect);
        }

        private void PMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(myPolygon);
        }

        private void PaMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(path);
        }

        private void DMouseEnter(object sender, MouseEventArgs e)
        {
            Scene.Children.Remove(Dance);
            Timer.Stop();
            currentFrame = 1;
            currentRow = 0;
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.X1 = 1;
            myLine.Y2 = 50;
            myLine.X2 = 50;
            myLine.Y2 = 50;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myLine.Margin = new Thickness(100, 100, 0, 0);
            myLine.MouseEnter += LMouseEnter;
            Scene.Children.Add(myLine);
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;
            myEllipse.Width = 100;
            myEllipse.Height = 100;
            myEllipse.Margin = new Thickness(200, 200, 0, 0);
            //myEllipse.MouseEnter += EMouseEnter;
            Scene.Children.Add(myEllipse);
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            myRect.Stroke = Brushes.Black;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.Height = 100;
            myRect.Width = 100;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\Lab2D\\Bogo.jpg", UriKind.Absolute));
            myRect.Fill = ib;
            ib.Transform = new ScaleTransform(1.1, 1);

            //myRect.Margin = new Thickness(250, 250, 0, 0);
            myRect.RenderTransform = new TranslateTransform(250, 250);

//            myRect.RenderTransform = new TranslateTransform(50, 50);
//            myRect.RenderTransform = new ScaleTransform(2, 0.5);
//            myRect.RenderTransform = new SkewTransform(-45, 0);
            //myRect.MouseEnter += RMouseEnter;
            Scene.Children.Add(myRect);

            Point pos = Mouse.GetPosition(Scene);
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if (rect.Contains(pos) == true) { MessageBox.Show("Точка входит в прямоугольник!"); }


            Rect ellipse = myEllipse.RenderTransform.TransformBounds(myEllipse.RenderedGeometry.Bounds);
            if (rect.IntersectsWith(ellipse) == true) { MessageBox.Show("Фигуры пересекаются!"); }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = Mouse.GetPosition(Scene);
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if (rect.Contains(pos) == true) { MessageBox.Show("Точка входит в прямоугольник!"); }
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\Lab2D\\Bogo.jpg", UriKind.Absolute));
            myPolygon.Stroke = Brushes.Black;
            myPolygon.Fill = ib;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point Point1 = new Point(0, 0);
            Point Point2 = new Point(150, 0);
            Point Point3 = new Point(150, 100);
            Point Point4 = new Point(100, 150);
            Point Point5 = new Point(0, 100);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPolygon.Points = myPointCollection;
            TransformGroup tg = new TransformGroup();
            TranslateTransform tt = new TranslateTransform(350, 350);
            //myPolygon.Margin = new Thickness(350, 350, 0, 0);
            RotateTransform rt = new RotateTransform(45, 50, 50);
            tg.Children.Add(rt);
            tg.Children.Add(tt);
            myPolygon.RenderTransform = tg;
            myPolygon.MouseEnter += PMouseEnter;
            Scene.Children.Add(myPolygon);
        }

        private void Path_Click(object sender, RoutedEventArgs e)
        {
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 1;
            BezierSegment bezierCurve1 = new BezierSegment(new Point(0, 0), new Point(0, 50), new Point(50, 90), true);
            BezierSegment bezierCurve2 = new BezierSegment(new Point(200, -70), new Point(100, 0), new Point(50, 30), true);
            PathSegmentCollection psc = new PathSegmentCollection();
            psc.Add(bezierCurve1);
            psc.Add(bezierCurve2);
            PathFigure pf = new PathFigure();
            pf.Segments = psc;
            pf.StartPoint = new Point(50, 30);
            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);
            PathGeometry pg = new PathGeometry();
            pg.Figures = pfc;
            GeometryGroup pathGeometryGroup = new GeometryGroup();
            pathGeometryGroup.Children.Add(pg);
            path.Data = pathGeometryGroup;
            path.Margin = new Thickness(480, 450, 0, 0);
            Path.MouseEnter += PaMouseEnter;
            Scene.Children.Add(path);
        }

        private void DanceB_Click(object sender, RoutedEventArgs e)
        {
            Dance.Height = 100;
            Dance.Width = 100;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 100, 100);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\Lab2D\\VictoriaSprites.gif", UriKind.Absolute));
            Dance.Fill = ib;
            Dance.Margin = new Thickness(0, 0, 0, 0);
            myLine.MouseEnter += DMouseEnter;
            Scene.Children.Add(Dance);
            Timer.Start();
        }
    }
}
