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

namespace Sierpinski_Triangles
{    
    public partial class MainWindow : Window
    {
        Rectangle[] cp = new Rectangle[6];
        int[] sizes = new int[6];
        int controlPoints = -1;
        Boolean shapeDraggable = false;
        Rectangle shapeDragged;
        Boolean drawn = false;
        public MainWindow()
        {            
            InitializeComponent();            
        }

        //Places control points, with some stipulations.
        private void ShapeCanvas_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            controlPoints++;
            //No more than 6 control points are allowed.
            if (controlPoints > 5) controlPoints--;
            else
            {
                Rectangle rect = new Rectangle();
                rect.Name = "CP_" + controlPoints.ToString(); //Control Point # assignment, starts at 0

                //New shape size
                if(ShapeSizeTwo.IsChecked == true)
                {
                    sizes[controlPoints] = 2;
                }
                else if(ShapeSizeFour.IsChecked == true)
                {
                    sizes[controlPoints] = 4;
                }
                else if (ShapeSizeSix.IsChecked == true)
                {
                    sizes[controlPoints] = 6;
                }

                //Control point size
                rect.Height = 10;
                rect.Width = 10;
                rect.Stroke = Brushes.Black;
				
                //Control point color
                if (ColorPreviewCanvas != null)
                {
                    SolidColorBrush shapeColor = (SolidColorBrush)ColorPreviewCanvas.Background;
                    rect.Fill = shapeColor;
                }
                else rect.Fill = Brushes.Black;				
				
                //Get the position from the event firing it, relative to the canvas
                Canvas.SetLeft(rect, e.GetPosition(ShapeCanvas).X);
                Canvas.SetTop(rect, e.GetPosition(ShapeCanvas).Y);
                ShapeCanvas.Children.Add(rect); //put it on the canvas
                cp[controlPoints] = rect; //add it to our list of controlpoints
                
                //if you added a shape after drawing the attractor already
                if (drawn)
                {
                    List<Rectangle> removed = new List<Rectangle>();
                    foreach (Rectangle rekt in ShapeCanvas.Children)
                    {
                        if (!cp.Contains(rekt))
                        {
                            removed.Add(rekt);
                        }
                    }

                    foreach (Rectangle rekt in removed)
                    {
                        ShapeCanvas.Children.Remove(rekt);
                    }
                    drawAttractor();
                }
            }

        }

        //Get rid of everything
        private void ClearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShapeCanvas.Children.Clear();
            drawn = false;
            controlPoints = -1;
        }

        private void drawAttractor(){
            drawn = true;
            if (controlPoints < 2)
            {
                if (controlPoints < 0)
                    MessageBox.Show("Add at least 3 control points.");
                else
                    MessageBox.Show("Add at least " + (2 - controlPoints).ToString() + " control points.");
            }
            else //We've got enough control points to work with.
            {
                Rectangle last, next;
                Random random = new Random();
                int rd = random.Next(controlPoints + 1);
                last = cp[rd];
                for (int i = 0; i < 2000; i++)
                {
                    int r = random.Next(controlPoints + 1);
                    next = cp[r];
                    Rectangle l = new Rectangle();
                    l.Fill = next.Fill;
                    l.Width = sizes[r];
                    l.Height = sizes[r];
                    double next_y = Canvas.GetTop(next);
                    double next_x = Canvas.GetLeft(next);
                    double last_y = Canvas.GetTop(last);
                    double last_x = Canvas.GetLeft(last);
                    Canvas.SetTop(l, (next_y + last_y) / (2));
                    Canvas.SetLeft(l, (next_x + last_x) / (2));
                    ShapeCanvas.Children.Add(l);
                    last = l;
                }
            }
        }
        //Render the attractor
        private void RunButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            drawAttractor();
        }

        //If mousedown is being held, drag the shape we're holding
        private void ShapeCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (shapeDraggable) {
                double x = e.GetPosition(ShapeCanvas).X;
                double y = e.GetPosition(ShapeCanvas).Y;
                Canvas.SetTop(shapeDragged, y);
                Canvas.SetLeft(shapeDragged, x);
            }
        }

        //Enables dragging
        private void ShapeCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double x = e.GetPosition(ShapeCanvas).X;
            double y = e.GetPosition(ShapeCanvas).Y;
            double smallestDist = 100;
            foreach(Rectangle rect in ShapeCanvas.Children){
                if (cp.Contains(rect)) //Only select the ones that are control points
                {
                    double rect_x = Canvas.GetLeft(rect);
                    double rect_y = Canvas.GetTop(rect);
                    double dist = Math.Sqrt((Math.Pow((y - rect_y), 2)) + (Math.Pow((x - rect_x), 2)));
                    if (dist > 20)
                    {
                        //do nothing because no shape is near enough
                    }
                    else
                    {
                        if (dist < smallestDist) //if we've got the closest shape
                        {
                            shapeDragged = rect; //latch on to it
                            smallestDist = dist;//update our smallest
                        }
                        shapeDraggable = true; //and allow dragging
                    }
                }
            }

        }

        //Disables dragging a shape
        private void ShapeCanvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            shapeDraggable = false;
            List<Rectangle> removed = new List<Rectangle>();
            if (drawn)
            {
                foreach (Rectangle rekt in ShapeCanvas.Children)
                {
                    if (!cp.Contains(rekt))
                    {
                        removed.Add(rekt);
                    }
                }

                foreach (Rectangle rekt in removed)
                {
                    ShapeCanvas.Children.Remove(rekt);
                }                
                drawAttractor();
            }            

        }

        //Dialog from pressing "About" menu item
        private void About_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Authors:\nRicky Sidhu (rajwinder.sidhu.842@my.csun.edu) \nKamron Javaherpour (kamron.javaherpour.623@my.csun.edu)");
        }

        //Dialog from pressing "Usage" menu item
        private void Usage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(" \nPress Run to run the simulation, and Clear to clear the canvas of all shapes."+
                " Right click to add a new control point. Hold left click and drag to move control points that are on the canvas." +
                "\n\nYou must make at least three control points, but no more than six." +
                " Shape size and color can be specified, per each control point, using the " +
                "controls at the bottom. There are presets as well as sliders that actuate those presets or the preference of the user."
                );
        }
		
		//All of these will set the RGB triplet to some preset.
        private void RedShapeItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {        	
            RedValueSlider.Value = 255;
            GreenValueSlider.Value = 0;
            BlueValueSlider.Value = 0;
        }

        private void BlueShapeItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            RedValueSlider.Value = 0;
            GreenValueSlider.Value = 0;
            BlueValueSlider.Value = 255;
        }

        private void GreenShapeItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            RedValueSlider.Value = 0;
            GreenValueSlider.Value = 255;
            BlueValueSlider.Value = 0;
        }

        private void OrangeShapeItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            RedValueSlider.Value = 255;
            GreenValueSlider.Value = 165;
            BlueValueSlider.Value = 0;
        }

        private void CyanShapeItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            RedValueSlider.Value = 0;
            GreenValueSlider.Value = 255;
            BlueValueSlider.Value = 255;
        }

        //For slider value changes
        private void ColorValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            double r = 0, g = 0, b = 0;
            if(RedValueSlider != null)
                r = RedValueSlider.Value;
            if(GreenValueSlider != null)
                g = GreenValueSlider.Value;
            if (BlueValueSlider != null)
                b = BlueValueSlider.Value;
            if(ColorPreviewCanvas != null)
                ColorPreviewCanvas.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
        }
    }
}
