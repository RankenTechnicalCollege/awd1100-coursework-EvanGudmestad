namespace Practice;

public partial class IncomeTaxPage : ContentPage
{
	public IncomeTaxPage()
	{
		InitializeComponent();
        StatusPicker.SelectedIndex = 0; // Default to Single
    }

    private void CalculateTax_Clicked(object sender, EventArgs e)
    {
        if (!decimal.TryParse(IncomeEntry.Text, out decimal income) || income < 0)
        {
            TaxResultLabel.Text = "Please enter a valid non-negative income.";
            return;
        }

        if (StatusPicker.SelectedIndex == -1)
        {
            TaxResultLabel.Text = "Please select a filing status.";
            return;
        }

        string status = StatusPicker.SelectedItem.ToString();
        decimal tax = 0;

        if (status == "Single")
        {
            if (income <= 11925)
                tax = income * 0.10m;
            else if (income <= 48475)
                tax = 1192.50m + (income - 11925) * 0.12m;
            else if (income <= 103350)
                tax = 5476.98m + (income - 48475) * 0.22m;
            else if (income <= 197300)
                tax = 17593.08m + (income - 103350) * 0.24m;
            else if (income <= 250525)
                tax = 39713.08m + (income - 197300) * 0.32m;
            else if (income <= 626350)
                tax = 57097.48m + (income - 250525) * 0.35m;
            else
                tax = 168264.73m + (income - 626350) * 0.37m;
        }
        else // Married Filing Jointly
        {
            if (income <= 23850)
                tax = income * 0.10m;
            else if (income <= 96950)
                tax = 2385.00m + (income - 23850) * 0.12m;
            else if (income <= 206700)
                tax = 11157.00m + (income - 96950) * 0.22m;
            else if (income <= 394600)
                tax = 36215.00m + (income - 206700) * 0.24m;
            else if (income <= 501050)
                tax = 81391.00m + (income - 394600) * 0.32m;
            else if (income <= 751600)
                tax = 117683.20m + (income - 501050) * 0.35m;
            else
                tax = 205858.45m + (income - 751600) * 0.37m;
        }

        TaxResultLabel.Text = $"Estimated tax: {tax:C}";
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}