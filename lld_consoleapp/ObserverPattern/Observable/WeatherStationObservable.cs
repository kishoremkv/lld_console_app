using lld_console_app.ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.ObserverPattern.Observable
{
    public class WeatherStationObservable : IWeatherStationObservable
    {
        List<IDisplayObserver> _observers;
        int temperature = 0;

        public WeatherStationObservable()
        {
            this._observers = new List<IDisplayObserver>();
        }
        public void Add(IDisplayObserver displayObserver)
        {
            this._observers.Add(displayObserver);
        }

        public int GetTemperature()
        {
            return this.temperature;
        }

        public void Notify()
        {
            foreach (var observer in this._observers)
            {
                observer.Update();
            }
        }

        public void Remove(IDisplayObserver displayObserver)
        {
            this._observers.Remove(displayObserver);
        }

        public void setTemperature(int temperature)
        {
            this.temperature = temperature;
            Notify();
        }
    }
}
