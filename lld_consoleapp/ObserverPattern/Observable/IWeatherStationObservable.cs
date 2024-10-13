using lld_console_app.ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.ObserverPattern.Observable
{
    public interface IWeatherStationObservable
    {
        public void Add(IDisplayObserver displayObserver);
        public void Remove(IDisplayObserver displayObserver);
        public void Notify();
        public void setTemperature(int temperature);
        public int GetTemperature();
    }
}
