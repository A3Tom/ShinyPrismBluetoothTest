using Shiny.BluetoothLE.Central;

namespace ShinyPrismBLE_Trial.Models
{
    public class FoundPeripheralVM
    {
        public string Name { get; set; }

        public IPeripheral Hing { get; set; }
    }
}
