using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoSun.WPFTest
{
    /// <summary>
    /// ArrowLineDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ArrowLineDemo : Window
    {
        public ArrowLineDemo()
        {
            InitializeComponent();
            Geometry g = Create(0, 100, 100, 100);
            Path path = new Path();
            path.StrokeThickness = 1;
            path.Stroke = System.Windows.Media.Brushes.Blue;
            path.Data = g;
            grid.Children.Add(path);
        }

        private double mArrowAngle = 0.5;//0.17453292519943295;
        private double mArrowLengh = 8.0;


        public double ArrowAngle
        {
            get
            {
                return this.mArrowAngle;
            }
            set
            {
                this.mArrowAngle = value;
            }
        }
        public double ArrowLengh
        {
            get
            {
                return this.mArrowLengh;
            }
            set
            {
                this.mArrowLengh = value;
            }
        }

        public Geometry Create(double x1, double y1, double x2, double y2)
        {
            Point point = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            double num = Math.Atan((y2 - y1) / (x2 - x1));
            double d = num - this.ArrowAngle;
            double num3 = num + this.ArrowAngle;
            int num4 = (x2 > x1) ? -1 : 1;
            double x = x2 + ((num4 * this.ArrowLengh) * Math.Cos(d));
            double y = y2 + ((num4 * this.ArrowLengh) * Math.Sin(d));
            double num7 = x2 + ((num4 * this.ArrowLengh) * Math.Cos(num3));
            double num8 = y2 + ((num4 * this.ArrowLengh) * Math.Sin(num3));
            Point point3 = new Point(x, y);
            Point point4 = new Point(num7, num8);
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.IsFilled = true;
            figure.StartPoint = point2;
            Point[] points = new Point[] { point, point2, point3, point4, point2 };//从point2到point 然后在倒回来到point2，然后画箭头。及从point2到point3到point4到point2.....
            PolyLineSegment segment = new PolyLineSegment(points, true);
            figure.Segments.Add(segment);
            geometry.Figures.Add(figure);
            geometry.Freeze();
            return geometry;
        }



    }
}
