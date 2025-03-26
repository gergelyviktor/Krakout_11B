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
        double alapSeb = 5;
        int pontszam = 0;
        public MainWindow() {
            InitializeComponent();

            Cursor = Cursors.None;


            var tegla = new Image();
            tegla.Source = new BitmapImage(new Uri("tegla.jpg", UriKind.Relative));
            tegla.Width = 90;
            tegla.Height = 20;
            tegla.Stretch = Stretch.Fill;
            jatekter.Children.Add(tegla);


            labda.CacheMode = new BitmapCache();
            //// Sync rendering with frame refresh rate
            CompositionTarget.Rendering += mozgatas;
            //// Lock the animation frame rate to 60 FPS
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 60 });

            //var ido = new DispatcherTimer();
            //ido.Interval = TimeSpan.FromMilliseconds(1);
            //ido.Tick += mozgatas;
            //ido.Start();
        }

        private void mozgatas(object sender, EventArgs e) {
            // a játékos mozgatása
            Canvas.SetLeft(jatekos, Mouse.GetPosition(jatekter).X);
            var labdaX = Canvas.GetLeft(labda);
            var labdaY = Canvas.GetTop(labda);
            // nézzük a képernyő határait
            if (labdaX < 0 || labdaX > 950) xSeb *= -1;
            if (labdaY > 550) {
                // ha a labda eléri a képernyő alját, vonjon le egy pontot
                pontszam = 0;
                lbPontszam.Content = 0;
                Canvas.SetTop(labda, 0);
                labdaY = 0;
                ySeb = alapSeb;
            }
            if (labdaY < 0) ySeb *= -1;

            // ütközésvizsgálat a labda és a játékos között
            var jatekosX = Canvas.GetLeft(jatekos);
            var jatekosY = Canvas.GetTop(jatekos);
            if (labdaX + labda.Width > jatekosX
                && labdaX < jatekosX + jatekos.Width
                && labdaY + labda.Height > jatekosY
                && labdaY < jatekosY + jatekos.Height
                ) {
                ySeb *= -1.3;
                lbPontszam.Content = ++pontszam;
            }
            // a labda mozgatása
            Canvas.SetLeft(labda, labdaX + xSeb);
            Canvas.SetTop(labda, labdaY + ySeb);
        }
    }
}
