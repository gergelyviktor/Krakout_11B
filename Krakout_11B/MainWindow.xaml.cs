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
using System.Windows.Threading;

namespace Krakout_11B {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        double xSeb = 5;
        double ySeb = 5;
        public MainWindow() {
            InitializeComponent();
            var ido = new DispatcherTimer();
            ido.Interval = TimeSpan.FromMilliseconds(1);
            ido.Tick += mozgatas;
            ido.Start();
        }

        private void mozgatas(object sender, EventArgs e) {

            var labdaX = Canvas.GetLeft(labda);
            var labdaY = Canvas.GetTop(labda);
            // nézzük a képernyő határait
            if (labdaX > 950) xSeb = -5;
            if (labdaX < 0) xSeb = 5;
            if (labdaY > 550) ySeb = -5;
            if (labdaY < 0) ySeb = 5;
            // a labda mozgatása
            Canvas.SetLeft(labda, labdaX + xSeb);
            Canvas.SetTop(labda, labdaY + ySeb);
        }
    }
}
