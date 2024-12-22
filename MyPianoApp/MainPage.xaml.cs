using Plugin.Maui.Audio;

namespace MyPianoApp
{
    public partial class MainPage : ContentPage
    {
        public static bool temp = false;
        IAudioManager _audioManager;
        string CurrentPlaying = null;
        public enum seciliEnstruman
        {
            ParlakPiano,
            ElektronikPiano,
            AkustikGitar
        }
        public static seciliEnstruman seciliEns = (seciliEnstruman)instruments.seciliEns;
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this._audioManager = audioManager;
        }
        private void onPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (sender is Button btn)
                switch (e.StatusType)
                {
                    case GestureStatus.Started:
                    case GestureStatus.Running:
                        if (CurrentPlaying == null)
                        {
                            if (btn.AutomationId != null)
                            {
                                playSound(btn.AutomationId);
                            }
                            CurrentPlaying = btn.AutomationId;
                        }
                        break;
                    case GestureStatus.Completed:
                        CurrentPlaying = null;
                        break;
                }

        }

        

        async void ayarlar_Clicked(object sender,EventArgs e)
        { 
            await Navigation.PushModalAsync(new instruments(seciliEns));
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.AutomationId != null)
            {
                playSound(btn.AutomationId);
            }
        }
        async void playSound(string fileName)
        {
            string totalName=null;
            double volume = 1;
            switch (instruments.seciliEns)
            {
                case instruments.seciliEnstruman.ParlakPiano:
                    totalName = fileName + ".wav";
                    volume = 1;
                    break;
                case instruments.seciliEnstruman.ElektronikPiano:
                    totalName = "e" + fileName + ".wav";
                    volume = 0.2;
                    break;
                case instruments.seciliEnstruman.AkustikGitar:
                    totalName = "g" + fileName + ".wav";
                    volume = 1;
                    break;
            }
            var player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(totalName));
            player.Volume = volume;
            player.Play();
            
        }

        void tema(object sender, EventArgs e)
        {
            foreach (var item in absoluteLayout.Children)
            {
                if (item is Button && item.AutomationId != null)
                {
                    var btn = item as Button;
                    if (btn.BackgroundColor == Colors.Black)
                    {
                        btn.BackgroundColor = Colors.White;
                    }
                    else
                    {
                        btn.BackgroundColor = Colors.Black;
                    }

                }
            }
            if (MainPage.temp)
            {
               absoluteLayout.BackgroundColor = Colors.Black;
                MainPage.temp = false;
                btnTema.Text = "Açık";
            }
            else
            {
                absoluteLayout.BackgroundColor = Colors.Turquoise;
                MainPage.temp = true;
                btnTema.Text = "Kapalı";
            }
        }


    }

}
