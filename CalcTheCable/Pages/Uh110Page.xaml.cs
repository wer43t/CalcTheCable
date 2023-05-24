using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CalcTheCable.Pages
{
    /// <summary>
    /// Логика взаимодействия для Uh110Page.xaml
    /// </summary>
    public partial class Uh110Page : Page
    {
        ScottPlot.Plottable.Crosshair crosshair;
        Core core = new Core();
        Dictionary<double, double> FirstLine;
        Dictionary<double, double> SecondLine;
        public Uh110Page()
        {
            InitializeComponent();
            WpfPlot1.Plot.SetAxisLimitsX(0, 8000);
            WpfPlot1.Plot.SetAxisLimitsY(0, 1500);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            WpfPlot1.Plot.Clear();
            core.AC120 = Int32.Parse(tbAC120.Text);
            core.AC150 = Int32.Parse(tbAC150.Text);
            core.AC240 = Int32.Parse(tbAC240.Text);
            core.TNB = Int32.Parse(tbTnb.Text);
            core.NB = Double.Parse(tbТb.Text);
            core.GetT();
            FirstLine = core.GetFirstLineForUh110();
            SecondLine = core.GetSecondLineForUh110();
            WpfPlot1.Plot.AddScatterLines(FirstLine.Keys.ToArray(), FirstLine.Values.ToArray(), System.Drawing.Color.Black, 3);
            WpfPlot1.Plot.AddScatterLines(SecondLine.Keys.ToArray(), SecondLine.Values.ToArray(), System.Drawing.Color.Green, 3);
            double coordinateX = Double.Parse(tbTnb.Text);
            double coordinateY = Double.Parse(tbТb.Text);
            crosshair = WpfPlot1.Plot.AddCrosshair(core.T, coordinateY);
            tbSelected.Content = core.SelectedCable;
            WpfPlot1.Refresh(); ;
        }


        private void WpfPlot1_LeftClicked(object sender, RoutedEventArgs e)
        {
            (double coordinateX, double coordinateY) = WpfPlot1.GetMouseCoordinates();
            if (crosshair is null)
            {
                crosshair = WpfPlot1.Plot.AddCrosshair(coordinateX, coordinateY);
            }
            else
            {
                crosshair.X = coordinateX; crosshair.Y = coordinateY;
                crosshair.Y = 400;

            }
            WpfPlot1.Refresh();

        }
    }
}
