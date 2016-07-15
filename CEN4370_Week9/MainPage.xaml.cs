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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CEN4370_Week9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double height;
            double weight;
            double bmi;

            try
            {
                // Convert numbers to doubles
                height = Convert.ToDouble(heightTextBox.Text);
                weight = Convert.ToDouble(weightTextBox.Text);

                // determine which formula to use to calculate bmi
                if ((bool)englishRadioButton.IsChecked)
                {
                    bmi = (weight * 703) / (height * height);
                }
                else if ((bool)metricRadioButton.IsChecked)
                {
                    bmi = weight / (height * height);
                }
                else
                {
                    throw new Exception();
                }

                // format to two decimal places
                //String.Format("{0:0.00}", 123.4567);      // "123.46"

                bmiTextBlock.Text = "Your BMI is: " + String.Format("{0:0.00}", bmi);
            }
            catch (FormatException)
            {
                bmiTextBlock.Text = "You can only enter numbers for height/weight.";
            }
            catch (Exception)
            {
                bmiTextBlock.Text = "You have to select English or Metric units.";
            }
        }
    }
}
