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

namespace network
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
             Canvas mainCanvas = background;

            InitializeComponent();
         


        }
        public Canvas returnProperCanvas() 
        {
            return background;

        }

 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Interraction.deleteAllElements(background);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            randomizerWindow r = new randomizerWindow();
            r.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* List<point> list = new List<point>();

             foreach (FrameworkElement t in background.Children) 
             {
                 point p = new point();
                 list.Add(p(Convert.ToInt32(background.getTop)));
                 list.Add(p(Convert.ToInt32(Canvas.GetTop(t))), Convert.ToInt32(Canvas.GetLeft(t)));


             }*/
            //Deleting every single line before graph update to prevent mass failures due to canvas overflow
            for (int i = background.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = background.Children[i];
                if (Child is Line)
                    background.Children.Remove(Child);
            }


            List<int> Ycoordinates = new List<int>();
            List<int> Xcoordinates = new List<int>();


            foreach (FrameworkElement t in background.Children)
            {
                double y = Canvas.GetTop(t);
                double x = Canvas.GetLeft(t);

                Ycoordinates.Add(Convert.ToInt32(y)+2);
                Xcoordinates.Add(Convert.ToInt32(x)+2);

            }

            for (int i = 0; i < Ycoordinates.Count(); i++)
            {
                int x = Xcoordinates[i];
                int y = Ycoordinates[i];
                for (int n = 0; n < Ycoordinates.Count(); n++) 
                {
                    Line ln = new Line();
                    ln.Stroke = System.Windows.Media.Brushes.Black;
                    ln.StrokeThickness = 1;
                    ln.SnapsToDevicePixels = true;
                    ln.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                    int x1 = Xcoordinates[n];
                    int y2 = Ycoordinates[n];
                    ln.X1 = x;
                    ln.X2 = x1;
                    ln.Y1 = y;
                    ln.Y2 = y2;
                    background.Children.Add(ln);

                }
            }
        }
    }


        

    public class point
    {
        //base point class
       public int x;
       public int y;
        private int v;

        public point(int v)
        {
            this.v = v;
        }

        public point() { }
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public void setX(int value) 
        {
            this.x = value;

        }
        public void setY(int value)
        {
            this.y = value;

        }
    }

    public class Interraction
    {


        public static List<point> randomizer(int pointsAmount) 
        {
            //TO DO
            /* done
             *color picker from drop down menu
             * choose amount of points to add
             */


            List<point> lst = new List<point>();
            Random r = new Random();

            for (int i = 0; i < pointsAmount; i++) 
            {
                lst.Insert(i, new point(r.Next(0,1000),r.Next(0,520)));

            }
            return lst;

        }

        public static void drawThemALl(List<point>coordinates,Canvas cs, string color) 
        {
            for (int i = 0; i < coordinates.Count(); i++) 
            {
                circle(coordinates[i].getX(), coordinates[i].getY(), cs,color);
            }
        }

        public static void circle(int x, int y, Canvas cv,string color )
        {
            //method for drawing 1 circle on console

            Ellipse circle = new Ellipse()
            {
                Width = 15,
                Height = 15,
                Stroke = Brushes.Red,
                
                Fill = (SolidColorBrush)(new BrushConverter().ConvertFromString(color))
                
        };

            cv.Children.Add(circle);

            circle.SetValue(Canvas.LeftProperty, (double)x);
            circle.SetValue(Canvas.TopProperty, (double)y);
        }

        public static void deleteAllElements(Canvas cs)
        {
            cs.Children.Clear();

        }



    }
}
