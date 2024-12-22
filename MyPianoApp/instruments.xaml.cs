namespace MyPianoApp;

public partial class instruments : ContentPage
{
	public enum seciliEnstruman
	{
		ParlakPiano,
		ElektronikPiano,
		AkustikGitar
	}
	public static seciliEnstruman seciliEns=seciliEnstruman.ParlakPiano;
	public instruments(MainPage.seciliEnstruman secili)
	{
		InitializeComponent();
		NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);
        if (secili!=null)
		{
			switch (secili)
			{
				case MainPage.seciliEnstruman.ParlakPiano:
					seciliEns = seciliEnstruman.ParlakPiano;
                    btnParlakPiano.BackgroundColor = Colors.Turquoise;
                    btnElektronikPiano.BackgroundColor = Colors.Black;
                    btnAkustikGitar.BackgroundColor = Colors.Black;
                    break;
				case MainPage.seciliEnstruman.ElektronikPiano:
					seciliEns = seciliEnstruman.ElektronikPiano;
                    btnParlakPiano.BackgroundColor = Colors.Black;
                    btnElektronikPiano.BackgroundColor = Colors.Turquoise;
                    btnAkustikGitar.BackgroundColor = Colors.Black;
                    break;
				case MainPage.seciliEnstruman.AkustikGitar:
					seciliEns = seciliEnstruman.AkustikGitar;
                    btnParlakPiano.BackgroundColor = Colors.Black;
                    btnElektronikPiano.BackgroundColor = Colors.Black;
                    btnAkustikGitar.BackgroundColor = Colors.Turquoise;
                    break;
				default:
					break;
			}
		}
	}

    async void btnGeri_Clicked(object sender,EventArgs e)
	{
		await Navigation.PopModalAsync();
        
	}

	void btnForInstruments(object sender, EventArgs e)
	{
		ImageButton btn = (ImageButton)sender;
		if (sender !=null)
		{
			switch (btn.AutomationId)
			{
				case "1":
					seciliEns=seciliEnstruman.ParlakPiano;
					MainPage.seciliEns = (MainPage.seciliEnstruman)seciliEns;
					btnParlakPiano.BackgroundColor = Colors.Turquoise;
                    btnElektronikPiano.BackgroundColor = Colors.Black;
                    btnAkustikGitar.BackgroundColor = Colors.Black;
                    break;
                case "2":
					seciliEns = seciliEnstruman.ElektronikPiano;
                    MainPage.seciliEns = (MainPage.seciliEnstruman)seciliEns;
                    btnParlakPiano.BackgroundColor = Colors.Black;
                    btnElektronikPiano.BackgroundColor = Colors.Turquoise;
                    btnAkustikGitar.BackgroundColor = Colors.Black;
                    break;
                case "3":
					seciliEns = seciliEnstruman.AkustikGitar;
                    MainPage.seciliEns = (MainPage.seciliEnstruman)seciliEns;
                    btnParlakPiano.BackgroundColor = Colors.Black;
                    btnElektronikPiano.BackgroundColor = Colors.Black;
                    btnAkustikGitar.BackgroundColor = Colors.Turquoise;
                    break;
            }
		}
	}
    
}