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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace calculateRoots
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void squareClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double squareThis = double.Parse(squareTextBox.Text);  //Turn user input into a double
                
                if (squareThis < 0)  //Test to see if input is a negative number, show error message otherwise
                {
                    answerLabel.Text = ""; //Make answerlabel blank to avoid confusion and redundancy
                    MessageDialog msg = new MessageDialog("Please enter a positive number");
                    msg.ShowAsync();
                }

                else
                {
                    double guess = 1;  //Randomized first guess
                    int counter = 100; //Number of guesses (increase for higher accuracy)
                    do
                    {
                            //Baylonian square method from http://pballew.net/oldsqrt.htm
                            double quotient = squareThis / guess;
                            double average = (quotient + guess) / 2;
                            guess = average;
                            counter--;
                        
                    } while (counter != 0);
                    answerLabel.Text = guess.ToString(); //Set the algorithm answer to the answerLabel to show user the square root
                }
            }
            catch(Exception h) //Shows error message if string is typed into textbox and button pushed.
            {
                answerLabel.Text = "";  //Make answerlabel blank to avoid confusion and redundancy
                MessageDialog msg = new MessageDialog("Please enter a double");
                msg.ShowAsync();

            }
        }
        private double firstGuess(double guess) //Randomized first guess to narrow guesses a bit
        {
            Random rnd = new Random();
            double narrowGuess = guess / 2;
            return rnd.NextDouble() * (narrowGuess - 0) + 0;
        }

    }
}
