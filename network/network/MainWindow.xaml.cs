using System;
using System.Collections;
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
            toggleForDrawing.IsChecked = false;



        }
        public Canvas returnProperCanvas() 
        {
            return background;

        }

 
        //delete all elelements  lined type button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Interraction.printAlllines(background);
        }


        // elements inserting button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            randomizerWindow randomizerWndowInstance = new randomizerWindow();
            randomizerWndowInstance.Show();


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

          //  foreach (Ellipse circle in cs.Children.OfType<Ellipse>())
         //   {
                foreach (FrameworkElement t in background.Children.OfType<Ellipse>())
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Interraction.getCoordinatesOFALlElmenentsCanavs(background);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("asdfas");
        }

        
        // method for drawing the lines 
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (background.Children.OfType<Ellipse>().Count() == 0)
            {
                MessageBox.Show("Nowhere to draw the lines at the moment");
                toggleForDrawing.IsChecked = false;
                return;
            }
            if (toggleForDrawing.IsChecked == true)
            {
                Interraction.deleteAllLinesForToggleButton(background);

            }
            else
            {
                Interraction.printAlllines(background); 
            }
          
        }

        private void TreeView_Representtaion(object sender, RoutedEventArgs e)
        {
            TreeViewRepresent tr = new TreeViewRepresent();
            tr.Show();

        }
    }




    public class point
    {
        //base point class
        public enum TypeEnum 
        {
            ROUTER,
            SWITCH,
            HUB
        }
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
        ArrayList xCoordinates = new ArrayList();
        ArrayList yCoordinates = new ArrayList();
        ArrayList verticesColor = new ArrayList();
        ArrayList typeofNode = new ArrayList();


        public static void deleteAllLinesForToggleButton(Canvas cs) 
        {

            for (int i = cs.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = cs.Children[i];
                if (Child is Line)
                    cs.Children.Remove(Child);
            }


            List<int> Ycoordinates = new List<int>();
            List<int> Xcoordinates = new List<int>();

            //  foreach (Ellipse circle in cs.Children.OfType<Ellipse>())
            //   {
            foreach (FrameworkElement t in cs.Children.OfType<Ellipse>())
            {
                double y = Canvas.GetTop(t);
                double x = Canvas.GetLeft(t);

                Ycoordinates.Add(Convert.ToInt32(y) + 2);
                Xcoordinates.Add(Convert.ToInt32(x) + 2);

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
                    cs.Children.Add(ln);

                }
            }
        }

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

        public  void drawThemALl(List<point>coordinates,Canvas cs, string color, string type) 
        {
            for (int i = 0; i < coordinates.Count(); i++) 
            {
                circle(coordinates[i].getX(), coordinates[i].getY(), cs,color,type);
            }
        }

        public  void circle(int x, int y, Canvas cv,string color,string type )// we have to pass type as enum type
        {
            //method for drawing 1 circle on console
            char realType = type[0];

            Ellipse circle = new Ellipse()
            {
                Width = 15,
                Height = 15,
                Stroke = Brushes.Red,
                
                Fill = (SolidColorBrush)(new BrushConverter().ConvertFromString(color))
                
        };
            TextBlock textbl = new TextBlock()
            {
                Text = realType.ToString(),
                Width = 40,
                Height = 40,
                FontSize = 9,
               
                FontWeight = FontWeights.Bold



            };

            // adding those elements in collections to represent in listview afterall

            cv.Children.Add(circle);
            cv.Children.Add(textbl);

            xCoordinates.Add(x);
            yCoordinates.Add(y);
            verticesColor.Add(color);
            typeofNode.Add(type);


            circle.SetValue(Canvas.LeftProperty, (double)x-5);
            circle.SetValue(Canvas.TopProperty, (double)y-2);
            textbl.SetValue(Canvas.LeftProperty, (double)x);
            textbl.SetValue(Canvas.TopProperty, (double)y);
        }


        //deleting all line types 
        public static void printAlllines(Canvas cs)
        {
 /*           foreach (FrameworkElement t in cs.Children.OfType<Line>())
            {
                cs.Children.Remove(t);
            }*/
            for (int i = cs.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = cs.Children[i];
                if (Child is Line)
                    cs.Children.Remove(Child);
            }

        }
        public static void getCoordinatesOFALlElmenentsCanavs(Canvas cs)
        {
            if (cs.Children.OfType<Ellipse>().Count() == 0)
            {
                MessageBox.Show("No elements at the moment");
            }
            else
            {
                ArrayList xAxes = new ArrayList();
                ArrayList yAxed = new ArrayList();

                foreach (Ellipse circle in cs.Children.OfType<Ellipse>())
                {
                    double x = Canvas.GetLeft(circle);
                    double y = Canvas.GetTop(circle);
                    xAxes.Add(x);
                    yAxed.Add(y);

                   // MessageBox.Show(x.ToString());
                   // MessageBox.Show(y.ToString());


                }
            }
        }



    }
}
