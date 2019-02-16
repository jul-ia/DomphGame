using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Classes.GameController controller;
        bool finish = false;

        public GameWindow()
        {
            InitializeComponent();

            controller = new Classes.GameController();
            controller.StartGame(canvas, continueButton);

        }

        //restart game
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            controller.StartGame(canvas, continueButton);
        }

        //return to main menu
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //if level was passed
            if (finish)
                controller.SaveCurrentGame();

            this.Close();
        }

        //game rules
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(controller.GetRules());
        }

        //next game
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            finish = !(controller.Continue(canvas, continueButton));
            if(finish)
            {
                MessageBox.Show("Congratulations! You have finished the game!");
            }
        }
    }
}
