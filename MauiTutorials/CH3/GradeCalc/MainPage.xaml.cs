namespace GradeCalc
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            //count+=2;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            //Get input from the user
            string enteredGrade = txtNumberGrade.Text;

            int numberGrade;

            int.TryParse(enteredGrade, out numberGrade);

            //First 2 conditions check for Invalid Data
            if (numberGrade == 0)
            {
                lblLetterGrade.Text = "Please enter a valid number 1-100";
            }
            else if (numberGrade < 0 || numberGrade > 100)
            {
                lblLetterGrade.Text = "Please enter a valid number 1-100";
            }
            else if (numberGrade >= 90)
            {
                lblLetterGrade.Text = "A";
            }else if(numberGrade >= 80)
            {
                lblLetterGrade.Text = "B";
            }else if(numberGrade >= 70)
            {
                lblLetterGrade.Text = "C";
            }else if(numberGrade >= 60)
            {
                lblLetterGrade.Text = "D";
            }
            else
            {
                lblLetterGrade.Text = "F";

            }

            //Determine the grade using if/else-if block

            //Ouput the letter 
        }
    }
}
