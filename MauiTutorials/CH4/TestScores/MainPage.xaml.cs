namespace TestScores
{
    public partial class MainPage : ContentPage
    {
        int totalScore = 0;
        int testScoreCount = 0;
        double averageScore = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddScoreClicked(object sender, EventArgs e)
        {
           
            if (int.TryParse(TestScoreEntry.Text, out int testScore) && testScore >= 0 && testScore <= 100)
            {
                totalScore += testScore;
                testScoreCount++;
                averageScore = (double)totalScore / testScoreCount; //Show Int Division
                
                lblTotalScore.Text = $"{totalScore}";
                lblScoreCount.Text = $"  {testScoreCount}";
                lblAverage.Text = $"  {averageScore}";
                
                TestScoreEntry.Text = string.Empty; 
            }
            else
            {
                DisplayAlert("Invalid Input", "Please enter a valid score.", "OK");
            }
           
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            totalScore = 0;
            testScoreCount = 0;
            averageScore = 0;
            lblTotalScore.Text = "0";
            lblScoreCount.Text = "0";
            lblAverage.Text = "0";
            TestScoreEntry.Text = string.Empty;
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current.Quit(); // Close the application
        }


    }
}
