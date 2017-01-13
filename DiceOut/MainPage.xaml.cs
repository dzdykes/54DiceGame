using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// Scoring Sum of Die with a times bonus for pairs(x2) and trips(x3)
    /// Ones 100pts... Sixes 1000pts
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int[] Die = new int[3];
        public Random RandomGenerator = new Random();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                Die[i] = RandomGenerator.Next(1, 7);
            }
            

            Die1.DisplayFace(Die[0]);
            Die2.DisplayFace(Die[1]);
            Die3.DisplayFace(Die[2]);

            GetScore();
        }

        private void GetScore()
        {
            int RollScore = Die.Sum() * GetBonus();

            RollScoreText.Text = RollScore.ToString();
        }

        private int GetBonus()
        {
            foreach (var grp in Die.GroupBy(i => i))
            {
                int bonus = grp.Count();
                if (bonus > 1) return bonus;
            }
            return 1;
        }
        
    }
}
