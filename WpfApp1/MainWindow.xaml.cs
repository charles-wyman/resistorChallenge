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
using System.Collections.Specialized;
//Code provided by Charles Wyman for Resistor challenge

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        interface IOhmValueCalculator
        {
            string bandAColor { get; set; }
            string bandBColor { get; set; }
            string bandCColor { get; set; }
            string bandDColor { get; set; }
            int CalculateOhmValue { get; }

            Double toleranceValue { get; }
            

        }

        public class calcObject : IOhmValueCalculator {

            string a;
            string b;
            string c;
            string d;
            
            private static readonly IDictionary<string, int> sigFigDict = new Dictionary<string, int>()
            {
                { "Black", 0 },
                { "Brown", 1 },
                { "Red", 2 },
                { "Orange", 3 },
                { "Yellow", 4 },
                { "Green", 5 },
                { "Blue", 6 },
                { "Violet", 7 },
                { "Gray", 8 },
                { "White", 9 }

            };

            private static readonly IDictionary<string, Double> multDict = new Dictionary<string, Double>()
            {
                { "Pink", .001 },
                { "Silver", .01 },
                { "Gold", .1 },
                { "Black", 1 },
                { "Brown", 10 },
                { "Red", 100 },
                { "Orange", 1000 },
                { "Yellow", 10000 },
                { "Green", 100000 },
                { "Blue", 1000000 },
                { "Violet", 10000000 },
                { "Gray", 100000000 },
                { "White", 1000000000 },

            };
            
            private static readonly IDictionary<string, Double> toleranceDict = new Dictionary<string, Double>() 
            {
                { "None", .2 },
                { "Silver", .1 },
                { "Gold", .05 },
                { "Black", 0 },
                { "Brown", .01 },
                { "Red", .02 },
                { "Yellow", .05 },
                { "Green", .005 },
                { "Blue", .0025 },
                { "Violet", .001 },
                { "Gray", .0005 },
                { "White", .0 }
            };
            
            public string bandAColor
            {
                get { return a; }
                set { a = value; }
            }

            public string bandBColor
            {
                get { return b; }
                set { b = value; }
            }

            public string bandCColor
            {
                get { return c; }
                set { c = value; }
            }

            public string bandDColor
            {
                get { return d; }
                set { d = value; }
            }

           
            public int CalculateOhmValue
            {
                get { return Convert.ToInt32(((sigFigDict[bandAColor] * 10) + sigFigDict[bandBColor]) * multDict[bandCColor]); }
            }

            public Double toleranceValue
            {
                get { return toleranceDict[bandDColor] * CalculateOhmValue; }
            }

            
        }

        public calcObject calcObj1 = new calcObject();

        public MainWindow()
        {
            InitializeComponent();
            calcObj1.bandAColor = "None";
            calcObj1.bandBColor = "None";
            calcObj1.bandCColor = "None";
            calcObj1.bandDColor = "None";
            resultsLbl.Content = "-- Ohms";
            

        }

        void calculateBtn_Click(object sender, RoutedEventArgs e)
        { 
            resultsLbl.Content = (calcObj1.CalculateOhmValue - calcObj1.toleranceValue).ToString() + " - " + (calcObj1.CalculateOhmValue + calcObj1.toleranceValue).ToString() + " Ohms";            
        }

        void cmbA_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            { 
            calcObj1.bandAColor = cmbA.SelectedValue.ToString();
            }

            catch
            {
                //I guess calcObj1 wasn't defined before compile!!!
            }
        }

        void cmbB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                calcObj1.bandBColor = cmbB.SelectedValue.ToString();
            }
            catch
            {
                //I guess calcObj1 wasn't defined before compile!!!
            }

        }

        void cmbC_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                calcObj1.bandCColor = cmbC.SelectedValue.ToString();
            }
            catch
            {
                //I guess calcObj1 wasn't defined before compile!!!
            }
        }

        void cmbD_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                calcObj1.bandDColor = cmbD.SelectedValue.ToString();
            }
            catch
            {
                //I guess calcObj1 wasn't defined before compile!!!
            }


        }
        
    }
}
