
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Shiny.BluetoothLE.Central;
using ShinyPrismBLE_Trial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShinyPrismBLE_Trial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ICentralManager _central;
        private ObservableCollection<FoundPeripheralVM> uniquePeripherals = new ObservableCollection<FoundPeripheralVM>();
        private FoundPeripheralVM selectedPeripheral;

        public MainPage(ICentralManager central)
        {
            _central = central;


            InitializeComponent();
            btnSend.Clicked += BtnSend_Clicked;
            btnConnect.Clicked += BtnConnect_Clicked;
            lvDeviceView.ItemsSource = uniquePeripherals;
            lvDeviceView.ItemSelected += NewItemSelected;
        }

        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            await OutputScan();

            btnSend.Text = "Anotha one ?";
        }

        private async void BtnConnect_Clicked(object sender, EventArgs e)
        {
            btnConnect.IsEnabled = false;

            if (selectedPeripheral.Hing.IsConnected())
            {
                selectedPeripheral.Hing.CancelConnection();
                await DisplayAlert("Disconnected device", $"You have disconnected from {selectedPeripheral.HingName}", "Sound");
            }
            else
            {
                selectedPeripheral.Hing.Connect();
                await DisplayAlert("New connected device", $"You are now connected to {selectedPeripheral.HingName}", "Cheers");
            }


            btnConnect.IsEnabled = true;
        }

        private async Task OutputScan()
        {
            await _central.RequestAccess();

            _central.ScanForUniquePeripherals()
                .Subscribe(onNext: x => {
                    uniquePeripherals.Add(new FoundPeripheralVM(x));
                })
            ;

            //var whitthefuck = await test2.Notify(Guid.NewGuid(), Guid.NewGuid());
                    //new Guid("af0cdaa1-f061-41f5-a9a5-25784b8de258"),
                    //new Guid("7f5e6c0d-4bd6-463c-9f0d-38f429b1b657"));
        }

        void NewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedPeripheral = e.SelectedItem as FoundPeripheralVM;

            btnConnect.Text = selectedPeripheral.Hing.IsConnected() ?
                "Disconnect" :
                "Connect" ;
        }
    }
}