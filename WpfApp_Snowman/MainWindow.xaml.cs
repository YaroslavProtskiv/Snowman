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

namespace HW_WpfApp_Snowman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int howCircles, maxRadius, minRadius;
        double heightLocation;
        double radiusHand, _storyRadiusHand;
        List<Ellipse> bodySnowman;
        List<Ellipse> faceSnowman;

        public MainWindow()
        {
            InitializeComponent();
            bodySnowman = new List<Ellipse>();
            faceSnowman = new List<Ellipse>();
            ChangeColorLine.IsEnabled = false;
            ChangeColor.IsEnabled = false;
        }

        private void ChangeColorLine_Click(object sender, RoutedEventArgs e)
        {
            NeWColor(true);
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            NeWColor(false);
        }

        private void CreateSnowman_Click(object sender, RoutedEventArgs e)
        {
            bodySnowman.Clear();
            faceSnowman.Clear();
            windowShow.Children.Clear();
            heightLocation = windowShow.ActualHeight;
            if (MaxRadius.Text == "" || MinRadius.Text == "" || numberCircles.Text == "")
            {
                MessageBox.Show("You should enter all parameters: number circles, max and min radius!!");
                return;
            }
            try
            {
                howCircles = int.Parse(numberCircles.Text);
                minRadius = int.Parse(MinRadius.Text);
                maxRadius = int.Parse(MaxRadius.Text);
                //MessageBox.Show("Parameters accepted!");
            }
            catch (Exception)
            {
                MessageBox.Show("Some parameters are not correct!! Try again!!");
                return;
            }
            CreateBodySnowman();
            CreateFaceSnowman();
            ChangeColorLine.IsEnabled = true;
            ChangeColor.IsEnabled = true;
        }

        

        private void CreateBodySnowman()
        {
            for (int i = 0; i < howCircles; i++)
            {
                bodySnowman.Add(new Ellipse());
                radiusHand = random.Next(Math.Min(minRadius, maxRadius), Math.Max(minRadius, maxRadius));
                bodySnowman[i].Height = radiusHand;
                bodySnowman[i].Width = bodySnowman[i].Height;
                bodySnowman[i].Stroke = ColorsSnowman.GetColor(random.Next(0, 20));
                bodySnowman[i].StrokeThickness = 4;

                heightLocation = heightLocation - bodySnowman[i].Height;

                if (heightLocation < 0)
                {
                    bodySnowman.Remove(bodySnowman[i]);
                    MessageBox.Show($"Snowman is not fit in the window!! I create smaller snowman. Number circles are {i}!");
                    return;
                }
                windowShow.Children.Add(bodySnowman[i]);
                bodySnowman[i].Margin = new Thickness((windowShow.ActualWidth - bodySnowman[i].Height) / 2, heightLocation, 0, 0);
                _storyRadiusHand = radiusHand;
            }
        }

        private void CreateFaceSnowman()
        {
            double _leftToHead = bodySnowman[bodySnowman.Count - 1].Margin.Left;
            double _topToHead = bodySnowman[bodySnowman.Count - 1].Margin.Top;

            for (int i = 0; i < 3; i++)
            {
                double _koefHeightNose = (i == 1) ? 0.5 : 1-1/Math.Sqrt(2);
                double _radius = random.Next((int)_storyRadiusHand / 8, (int)_storyRadiusHand / 4);
                double _leftMargin = _leftToHead - _radius / 2 + _storyRadiusHand * (1+i) / 4;
                double _topMargin = _topToHead - _radius / 2 + _storyRadiusHand * _koefHeightNose;

                faceSnowman.Add(new Ellipse());
                faceSnowman[i].Height = _radius;
                faceSnowman[i].Width = faceSnowman[i].Height;
                faceSnowman[i].Stroke = ColorsSnowman.GetColor(random.Next(0,20));

                windowShow.Children.Add(faceSnowman[i]);
                faceSnowman[i].Margin = new Thickness(_leftMargin, _topMargin, 0, 0);
            }
        }

        private void NeWColor (bool toLine = true)
        {
            if (toLine == true)
            {
                for (int i = 0; i < bodySnowman.Count; i++)
                {
                    bodySnowman[i].Stroke = ColorsSnowman.GetColor(random.Next(0, 20));
                }
                for (int i = 0; i < 3; i++)
                {
                    faceSnowman[i].Stroke = ColorsSnowman.GetColor(random.Next(0, 20));
                }
            }
            else
            {
                for (int i = 0; i < bodySnowman.Count; i++)
                {
                    bodySnowman[i].Fill = ColorsSnowman.GetColor(random.Next(0, 20));
                }
                for (int i = 0; i < 3; i++)
                {
                    faceSnowman[i].Fill = ColorsSnowman.GetColor(random.Next(0, 20));
                }
            }
            
        }
    }
}
