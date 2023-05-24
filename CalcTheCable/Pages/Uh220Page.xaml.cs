using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CalcTheCable.Pages
{
    /// <summary>
    /// Логика взаимодействия для Uh220Page.xaml
    /// </summary>
    public partial class Uh220Page : Page
    {
        ScottPlot.Plottable.Crosshair crosshair;
        Core core = new Core();
        Dictionary<double, double> FirstLine;
        Dictionary<double, double> SecondLine;
        Dictionary<double, double> ThirdLine;
        Dictionary<double, double> FourthLine;
        public Uh220Page()
        {
            InitializeComponent();
            WpfPlot1.Plot.SetAxisLimitsX(0, 8000);
            WpfPlot1.Plot.SetAxisLimitsY(0, 1500);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            WpfPlot1.Plot.Clear();
            core.AC240 = Int32.Parse(tbAC240.Text);
            core.AC300 = Int32.Parse(tbAC300.Text);
            core.AC400 = Int32.Parse(tbAC400.Text);
            core.AC500 = Int32.Parse(tbAC500.Text);
            core.AC600 = Int32.Parse(tbAC600.Text);
            core.TNB = Int32.Parse(tbTnb.Text);
            core.NB = Int32.Parse(tbТb.Text);
            core.GetT();
            FirstLine = core.GetFirstLineForUh220();
            SecondLine = core.GetSecondLineForUh220();
            ThirdLine = core.GetThirdLineForUh220();
            FourthLine = core.GetFourthLineForUh220();
            WpfPlot1.Plot.AddScatterLines(FirstLine.Keys.ToArray(), FirstLine.Values.ToArray(), System.Drawing.Color.Black, 3);
            WpfPlot1.Plot.AddScatterLines(SecondLine.Keys.ToArray(), SecondLine.Values.ToArray(), System.Drawing.Color.Green, 3);
            WpfPlot1.Plot.AddScatterLines(ThirdLine.Keys.ToArray(), ThirdLine.Values.ToArray(), System.Drawing.Color.Red, 3);
            WpfPlot1.Plot.AddScatterLines(FourthLine.Keys.ToArray(), FourthLine.Values.ToArray(), System.Drawing.Color.Blue, 3);

            double coordinateX = Double.Parse(tbTnb.Text);
            double coordinateY = Double.Parse(tbТb.Text);
            crosshair = WpfPlot1.Plot.AddCrosshair(core.T, coordinateY);
            tbSelected.Content = core.SelectedCable;
            WpfPlot1.Refresh();
        }

        private void WpfPlot1_LeftClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
