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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace AutoRecognize.MVVM.Client.Views.Windows
{
    /// <summary>
    /// FlipLogin.xaml 的交互逻辑
    /// </summary>
    public partial class FlipLogin : Window
    {
        public FlipLogin()
        {
            InitializeComponent();
        }
        public void OnChangePage(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            if (((UserControl)sender).Tag.ToString().Equals("login"))
            {
                da.To = 180d;
            }
            else
            {
                da.To = 0d;
            }
            this.axr.BeginAnimation(AxisAngleRotation3D.AngleProperty, da);
        }
    }

}
