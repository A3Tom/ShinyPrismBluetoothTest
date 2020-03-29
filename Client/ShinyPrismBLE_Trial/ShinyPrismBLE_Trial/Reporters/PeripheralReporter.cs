using System;
using Shiny.BluetoothLE.Central;

namespace ShinyPrismBLE_Trial.Reporters
{
    public class PeripheralReporter : IObserver<IPeripheral>
    {
        private IDisposable unsubscriber;
        private string instName;

        public PeripheralReporter(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<IPeripheral> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine($"{this.Name} : Am done.");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"{this.Name} : Shits fucked.");
            Console.WriteLine(e);
        }

        public virtual void OnNext(IPeripheral value)
        {
            Console.WriteLine($"Next bitch: {value.Name}");
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
