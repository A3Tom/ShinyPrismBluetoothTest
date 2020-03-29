using Shiny.BluetoothLE.Central;

namespace ShinyPrismBLE_Trial.Models
{
    public class FoundPeripheralVM
    {

        public FoundPeripheralVM(IPeripheral newPeripheral)
        {
            Hing = newPeripheral;
        }

        public IPeripheral Hing { get; }

        public string HingName => !string.IsNullOrEmpty(Hing.Name) ? Hing.Name : Hing.Uuid.ToString();
    }
}
