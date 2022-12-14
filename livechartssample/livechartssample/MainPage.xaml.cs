using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace livechartssample
{
    public partial class MainPage : ContentPage
    {
        private readonly int _textSize = 12;
        private double _textSizeScaled;

        public MainPage()
        {
            InitializeComponent();
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            _textSizeScaled = _textSize * mainDisplayInfo.Density * 2;
            chart.Series = new ISeries[]
        {
                new ColumnSeries<double>
                {
                    Values = new[]{ 0.0,0.1,0.2},
                    Fill = new SolidColorPaint(SKColor.Parse("ff5b00")),
                    Stroke = null,
                    Rx = 0,
                    Ry = 0,
                    Name = "heating",
                    MaxBarWidth = 15
                    },
                new ColumnSeries<double>
                {
                    Values = new[]{ 0.0,0.1,0.2},
                    Fill = new SolidColorPaint(SKColor.Parse("2675c3")),
                    Rx = 0,
                    Ry = 0,
                    Stroke = null,
                    MaxBarWidth = 15,
                    Name = "cooling"
                }
        };
            chart.XAxes = new List<Axis>
            {
                new Axis
                {
                    MinStep = 1,
                    TextSize = _textSizeScaled,
                    ForceStepToMin = true,
                    LabelsRotation = -45,
                    Labels = new[]{"a","b","c" }
                }
            };
            chart.YAxes = new List<Axis>
            {
                new Axis
                {
                    MinStep = 0,
                    MinLimit = 0,
                    Padding = new Padding(10,10),
                    TextSize = _textSizeScaled,
                    SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 4 }
                }
            };

            //if (device is SnowmeltDevice snowmeltDevice)
            //{
            //    chart.Series.Last().IsVisible = false;
            //}
            //else if (device is ThermostatDevice thermostatDevice)
            //{
            //    chart.Series.Last().IsVisible = Convert.ToBoolean(thermostatDevice?.Data?.Schedule?.CoolActive);
            //}

        }

        void Button_Pressed(System.Object sender, System.EventArgs e)
        {
            chart.Series.First().Values = new[] { 0.0, 0.0, 0.0 };
            chart.Series.Last().Values = new[] { 0.0, 0.0, 0.0 };
        }

        void Button_Pressed_1(System.Object sender, System.EventArgs e)
        {
            chart.Series.First().Values = new[] { 0.0, 1.1, 2.2 };
            chart.Series.Last().Values = new[] { 1.0, 2.1, 2.2 };
        }
    }
}

