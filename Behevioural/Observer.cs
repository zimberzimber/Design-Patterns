using System.Collections.Generic;

namespace Design_Patterns.Behevioural
{
    abstract class ObserverableBase
    {
        List<IObserver> _observers;

        public void AddObserver(IObserver observer)
            => _observers.Add(observer);

        public void RemoveObserver(IObserver observer)
            => _observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.OnNotified();
        }
    }

    class ObservableA : ObserverableBase
    {
        string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyObservers();
            }
        }
    }

    interface IObserver
    {
        void OnNotified();
    }

    class ObserverA : IObserver
    {
        ObservableA _observing;
        string _observedName;

        public ObserverA(ObservableA observing)
        {
            _observing = observing;
            _observedName = _observing.Name;
            _observing.AddObserver(this);
        }

        public void OnNotified()
            => _observedName = _observing.Name;
    }
}
