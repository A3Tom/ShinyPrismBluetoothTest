using System;
using System.Collections.Generic;
using Shiny.BluetoothLE.Central;

namespace ShinyPrismBLE_Trial.Trackers
{
    public class PeripheralTracker : IObservable<IPeripheral>
    {
        public PeripheralTracker()
        {
            observers = new List<IObserver<IPeripheral>>();
        }

        private List<IObserver<IPeripheral>> observers;

        public IDisposable Subscribe(IObserver<IPeripheral> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IPeripheral>> _observers;
            private IObserver<IPeripheral> _observer;

            public Unsubscriber(List<IObserver<IPeripheral>> observers, IObserver<IPeripheral> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}
