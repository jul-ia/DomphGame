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
using System.Windows.Shapes;

namespace DomphGame_v1
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        Classes.Screensaver ss; 
        public TestWindow()
        {
            InitializeComponent();
            ss = new Classes.Screensaver(1);
            imageForMW.Source = ss.GetImage(101);
        }
    }
}
