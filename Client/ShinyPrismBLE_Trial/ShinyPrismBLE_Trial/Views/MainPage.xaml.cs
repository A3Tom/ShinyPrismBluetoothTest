
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Shiny.BluetoothLE.Central;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShinyPrismBLE_Trial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private ICentralManager _central;
        public MainPage(ICentralManager central)
        {
            _central = central;


            InitializeComponent();
            lblOutput.Text = "";
            btnSend.Clicked += BtnSend_Clicked;

        }

        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            var resultSet = new List<IPeripheral>();    

            await OutputScan();

            btnSend.Text = "Anotha one ?";
            lblOutput.Text += txtMessage.Text;
        }

        private async Task OutputScan()
        {
            await _central.RequestAccess();

            lblOutput.Text += $"using ble adapter : {_central.AdapterName}, Can control: {_central.CanControlAdapterState()}";

            var test2 = await _central.ScanForUniquePeripherals()
                .Select(x => lblOutput.Text += $"{Environment.NewLine}Just foon : {GetPeripheralVisibleAlias(x.Name, x.Uuid.ToString())}")
                //.FirstAsync(x => x.Name == "Tams IR Sensor")
            ;

            //test2.Connect();

            //var whitthefuck = await test2.Notify(Guid.NewGuid(), Guid.NewGuid());
                    //new Guid("af0cdaa1-f061-41f5-a9a5-25784b8de258"),
                    //new Guid("7f5e6c0d-4bd6-463c-9f0d-38f429b1b657"));

            swToggle.IsToggled = true;
        }

        private string GetPeripheralVisibleAlias(string peripheralName, string uuid) => !string.IsNullOrEmpty(peripheralName) ? peripheralName : uuid;
    }
}