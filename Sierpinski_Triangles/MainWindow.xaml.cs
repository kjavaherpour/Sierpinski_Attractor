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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SAShape[] shape = new SAShape[2000];
        int controlPoints = -1;
        public MainWindow()
        {            
            InitializeComponent();            
        }

        /// <summary>
        /// Places control points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeCanvas_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            controlPoints++;
            //No more than 6 control points are allowed.
            if (controlPoints > 6) controlPoints--;
            else
            {
                Rectangle rect = new Rectangle();
                rect.Name = "CP_" + controlPoints.ToString(); //Control Point # assignment, starts at 0
                rect.Height = 10;
                rect.Width = 10;
                rect.Stroke = Brushes.Black;

                //Get the selected ComboBox item for shape color
                if (ComboBox.GetIsSelected(RedShapeItem))
                {
                    rect.Fill = Brushes.Red;
                }
                if (ComboBox.GetIsSelected(GreenShapeItem))
                {
                    rect.Fill = Brushes.Green;
                }
                if (ComboBox.GetIsSelected(BlueShapeItem))
                {
                    rect.Fill = Brushes.Blue;
                }
                if (ComboBox.GetIsSelected(YellowShapeItem))
                {
                    rect.Fill = Brushes.Yellow;
                }

                //Get the position from the event firing it, relative to (on) the canvas
                Canvas.SetLeft(rect, e.GetPosition(ShapeCanvas).X);
                Canvas.SetTop(rect, e.GetPosition(ShapeCanvas).Y);
                ShapeCanvas.Children.Add(rect);
                MessageBox.Show("Added Shape " + rect.Name, "Shape Added");
            }

        }

        /// <summary>
        /// Drag the control points around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        /// <summary>
        /// Clear all the shapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShapeCanvas.Children.Clear();
            controlPoints = -1;
        	// TODO: Add event handler implementation here.
        }

        /// <summary>
        /// Create the attractor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            // TODO: Add event handler implementation here.
        }
    }
}
