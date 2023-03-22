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
using Game;

namespace Game.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class Window_GameScreen : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight, goUp, goDown, wasTouched = false;
        int playerSpeed = 5, score = 0;

        public Window_GameScreen()
        {
            InitializeComponent();

            Test.Focus();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Tick += TreasureChest;
            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(Player) > 5)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }

            if (goRight == true && Canvas.GetLeft(Player) + (Player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }

            if (goUp == true && Canvas.GetTop(Player) > 5)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - playerSpeed);
            }

            if (goDown == true && Canvas.GetTop(Player) + (Player.Height * 2) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + playerSpeed);
            }
        }


        private void TreasureChest(object sender, EventArgs e)
        {
            foreach (var x in Test.Children.OfType<Rectangle>())
            {
                Rect P = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
                Rect T_C = new Rect(Canvas.GetLeft(Treasure_Chest), Canvas.GetTop(Treasure_Chest), Treasure_Chest.Width, Treasure_Chest.Height);
                Rect C = new Rect(Canvas.GetLeft(Coin), Canvas.GetTop(Coin), Coin.Width, Coin.Height);
                Rect E = new Rect(Canvas.GetLeft(Emerald), Canvas.GetTop(Emerald), Emerald.Width, Emerald.Height);
                Rect R = new Rect(Canvas.GetLeft(Ruby), Canvas.GetTop(Ruby), Ruby.Width, Ruby.Height);
                Rect D = new Rect(Canvas.GetLeft(Diamond), Canvas.GetTop(Diamond), Diamond.Width, Diamond.Height);

                if ((string)x.Tag == "T_C")
                {

                    if (P.IntersectsWith(T_C))
                    {
                        x.Visibility = Visibility.Collapsed;

                        if (wasTouched == false)
                        {
                            foreach (var y in Test.Children.OfType<Rectangle>())
                            {
                                string money = (string)y.Tag;
                                var random = new Random();
                                int HowMuchMove, HowManyCoins, HowManyEmeralds, HowManyRubys, HowManyDiamonds;

                                if ((string)y.Tag != "T_C")
                                {
                                    HowManyCoins = random.Next(1, 8);
                                    HowManyEmeralds = random.Next(1, 6);
                                    HowManyRubys = random.Next(1, 4);
                                    HowManyDiamonds = random.Next(0, 2);

                                    for (var i = 0; i <= HowManyCoins; i++)
                                    {
                                        HowMuchMove = random.Next(-10, 11);
                                        Canvas.SetLeft(Coin, Canvas.GetLeft(Coin) + HowMuchMove);
                                        HowMuchMove = random.Next(-10, 11);
                                        Canvas.SetTop(Coin, Canvas.GetTop(Coin) + HowMuchMove);
                                    }

                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetLeft(Emerald, Canvas.GetLeft(Emerald) + HowMuchMove);
                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetTop(Emerald, Canvas.GetTop(Emerald) + HowMuchMove);

                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetLeft(Ruby, Canvas.GetLeft(Ruby) + HowMuchMove);
                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetTop(Ruby, Canvas.GetTop(Ruby) + HowMuchMove);

                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetLeft(Diamond, Canvas.GetLeft(Diamond) + HowMuchMove);
                                    HowMuchMove = random.Next(-10, 11);
                                    Canvas.SetTop(Diamond, Canvas.GetTop(Diamond) + HowMuchMove);

                                    y.Visibility = Visibility.Visible;
                                }
                            }
                        }
                        wasTouched = true;
                    }
                }

                string currency;
                currency = (string)x.Tag;

                switch (currency)
                {
                    case "C":
                        if (P.IntersectsWith(C))
                        { x.Visibility = Visibility.Collapsed; score += 3; }
                        break;
                    case "E":
                        if (P.IntersectsWith(E))
                        { x.Visibility = Visibility.Collapsed; score += 9; }
                        break;
                    case "R":
                        if (P.IntersectsWith(R))
                        { x.Visibility = Visibility.Collapsed; score += 27; }
                        break;
                    case "D":
                        if (P.IntersectsWith(D))
                        { x.Visibility = Visibility.Collapsed; score += 81; }
                        break;
                    default:
                        break;
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = true;
            }
            if (e.Key == Key.D)
            {
                goRight = true;
            }
            if (e.Key == Key.W)
            {
                goUp = true;
            }
            if (e.Key == Key.S)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                goLeft = false;
            }
            if (e.Key == Key.D)
            {
                goRight = false;
            }
            if (e.Key == Key.W)
            {
                goUp = false;
            }
            if (e.Key == Key.S)
            {
                goDown = false;
            }
        }
    }
}
