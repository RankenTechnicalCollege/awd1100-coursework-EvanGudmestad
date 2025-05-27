namespace TestScoresV2
{
    public partial class MainPage : ContentPage
    {
        int totalScore = 0; //Accumulated score
        int testScoreCount = 0; //Number of tests taken
        float averageScore = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddScoreClicked(object sender, EventArgs e)
        {
            //Get the input and validate the input
            if(int.TryParse(txtScoreEntry.Text, out int testScore) && testScore >= 0 && testScore <=100)
            {
                //Conversion Worked
                ++testScoreCount; //Increment the number of tests taken

                //Math 
                totalScore = totalScore + testScore;

                //Int division is a problem
                //To solve the problem, we convert one of the variables (temporarily) to a float
                averageScore = (float)totalScore / testScoreCount; //Calculate the average score


                //Output the results to the labels
                lblTotalScore.Text = $"  {totalScore}";
                lblScoreCount.Text = $"  {testScoreCount}";
                lblAverage.Text = $"  {averageScore}";
            }
            else
            {
                //Conversion Failed
                DisplayAlert("Invalid Input", "Please enter a valid score.", "OK");
            }

            txtScoreEntry.Text = string.Empty; //Clear the input field
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            lblTotalScore.Text = string.Empty;
            lblScoreCount.Text = string.Empty;
            lblAverage.Text = string.Empty;
            txtScoreEntry.Text = string.Empty; //Clear the input field
            totalScore = 0; //Reset the total score
            testScoreCount = 0; //Reset the number of tests taken
            averageScore = 0; //Reset the average score
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }


    }
}
