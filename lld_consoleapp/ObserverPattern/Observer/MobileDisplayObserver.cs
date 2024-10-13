using lld_console_app.ObserverPattern.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.ObserverPattern.Observer
{
    internal class MobileDisplayObserver : IDisplayObserver
    {
        public IWeatherStationObservable weatherStationObservable;

        public MobileDisplayObserver(IWeatherStationObservable weatherStationObservable)
        {
            this.weatherStationObservable = weatherStationObservable;
        }
        public void Update()
        {
            int updatedTemperature = this.weatherStationObservable.GetTemperature();
            Console.WriteLine("Updated Temperature for "+GetHashCode()+" is "+updatedTemperature);
        }
    }
}
