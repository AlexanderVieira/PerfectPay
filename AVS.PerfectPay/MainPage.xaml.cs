namespace AVS.PerfectPay;

public partial class MainPage : ContentPage
{
    private decimal _bill;
    private int _tip;
    private int _noPersons = 1;
    public MainPage()
	{
		InitializeComponent();
	}

    private void TxtBill_Completed(object sender, EventArgs e)
    {
        _bill = decimal.Parse(TxtBill.Text);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        var totalTip = (_bill * _tip) / 100;
        
        var tipByPerson = (totalTip / _noPersons);
        LblTipByPerson.Text = $"{tipByPerson:C}";
        
        var subtotal = (_bill / _noPersons);
        LblSubtotal.Text = $"{subtotal:C}";
        
        var totalByPerson = (_bill + totalTip) / _noPersons;
        LblTotal.Text = $"{totalByPerson:C}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            SldTip.Value = percentage;
        }
    }

    private void SldTip_ValueChanded(object sender, ValueChangedEventArgs e)
    {
        _tip = (int)SldTip.Value;
        LblTip.Text = $"{_tip}%";
        CalculateTotal();
    }

    private void BtnMinus_Clicked(object sender, EventArgs e)
    {
        if (_noPersons > 1)
        {
            _noPersons--;
        }

        LblNoPerons.Text = _noPersons.ToString();
        CalculateTotal();
    }

    private void BtnPlus_OnClicked(object sender, EventArgs e)
    {
        _noPersons++;
        LblNoPerons.Text = _noPersons.ToString();
        CalculateTotal();
    }
}

