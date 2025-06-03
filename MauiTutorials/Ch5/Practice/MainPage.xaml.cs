namespace Practice
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateFactorial_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberEntry.Text, out int number))
            {
                if (number < 0)
                {
                    ResultLabel.Text = "Please enter a non-negative number.";
                }
                else if (number == 0)
                {
                    ResultLabel.Text = "The factorial of 0 is 1.";
                }
                else
                {
                    long factorial = 1; // Use long to accommodate larger factorials
                    for (int i = 1; i <= number; i++)
                    {
                        factorial *= i;
                    }
                    ResultLabel.Text = $"The factorial of {number} is {factorial}.";
                }
            }
            else
            {
                ResultLabel.Text = "Invalid input. Please enter a whole number.";
            }
        }

        private async void GoToIncomeTaxPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IncomeTaxPage());
        }
    }
}
