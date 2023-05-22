using ScottPlot;
using ScottPlot.Plottable;
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

namespace CalcTheCable.Pages
{
    /// <summary>
    /// Логика взаимодействия для Uh110Page.xaml
    /// </summary>
    public partial class Uh110Page : Page
    {
        ScottPlot.Plottable.Crosshair crosshair;
        Core core = new Core();
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
            core.GetT();
            WpfPlot1.Plot.AddScatterLines(core.GetFirstLineForUh110().Keys.ToArray(), core.GetFirstLineForUh110().Values.ToArray(), System.Drawing.Color.Black, 3);
            WpfPlot1.Plot.AddScatterLines(core.GetSecondLineForUh110().Keys.ToArray(), core.GetSecondLineForUh110().Values.ToArray(), System.Drawing.Color.Green, 3);

            WpfPlot1.Refresh();
        }


        private void WpfPlot1_LeftClicked(object sender, RoutedEventArgs e)
        {
           (double coordinateX, double coordinateY) = WpfPlot1.GetMouseCoordinates();
            if(crosshair is null)
            {
                crosshair = WpfPlot1.Plot.AddCrosshair(coordinateX, coordinateY);
            }
            else
            {
                crosshair.X = coordinateX; crosshair.Y = coordinateY;
                //crosshair.Y = 400;
                
            }
            WpfPlot1.Refresh();

        }
    }
}
