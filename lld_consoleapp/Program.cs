// See https://aka.ms/new-console-template for more information


using lld_console_app.Observable;
using lld_console_app.ObserverPattern.Observable;
using lld_console_app.ObserverPattern.Observer;

Console.WriteLine("Hello, World!");
HelloWorld helloWorld = new HelloWorld();
helloWorld.display();

IWeatherStationObservable weatherStation = new WeatherStationObservable();
IDisplayObserver observer1 = new MobileDisplayObserver(weatherStation);
IDisplayObserver observer2 = new MobileDisplayObserver(weatherStation);
IDisplayObserver observer3 = new MobileDisplayObserver(weatherStation);

weatherStation.Add(observer1);
weatherStation.Add(observer2);
weatherStation.Add(observer3);

weatherStation.setTemperature(new Random().Next());
Console.WriteLine("Updated!");
weatherStation.setTemperature(new Random().Next());
Console.WriteLine("Updated!");
weatherStation.setTemperature(new Random().Next());
Console.WriteLine("Updated!");
