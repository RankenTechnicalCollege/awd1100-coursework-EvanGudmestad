using System.Threading.Tasks;

namespace FactorialAndIncomeTax
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateFactorial_Clicked(object sender,EventArgs e)
        {
            if(int.TryParse(txtNumberEntry.Text, out int number))
            {
                //Conversion of string to int worked!
                if(number < 0)
                {
                    lblResult.Text = "Please enter a non negative number";
                }else if(number == 0)
                {
                    lblResult.Text = "The factorial of 0 is 1";
                } else
                {
                    //Do the factorial calc
                    long factorial = 1;
                    for (int i = 1; i <= number; i++)
                    {
                        factorial = factorial * i; //factorial *= i;
                    }
                    
                    //Output the results to the end user!
                    lblResult.Text = $"The factorial of {number} is {factorial}.";
                }
            }else
            {
                lblResult.Text = "Invalid Input.  Please enter a whole number";
            }
        }

        private async void GoToIncomeTaxPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IncomeTaxPage());
        }
    }
}
