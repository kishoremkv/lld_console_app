﻿// See https://aka.ms/new-console-template for more information


using lld_console_app.DecoratorPattern;
using lld_console_app.Observable;
using lld_console_app.ObserverPattern.Observable;
using lld_console_app.ObserverPattern.Observer;

//Console.WriteLine("Hello, World!");
//HelloWorld helloWorld = new HelloWorld();
//helloWorld.display();

// Observer pattern -> Notifying all observers
//IWeatherStationObservable weatherStation = new WeatherStationObservable();
//IDisplayObserver observer1 = new MobileDisplayObserver(weatherStation);
//IDisplayObserver observer2 = new MobileDisplayObserver(weatherStation);
//IDisplayObserver observer3 = new MobileDisplayObserver(weatherStation);

//weatherStation.Add(observer1);
//weatherStation.Add(observer2);
//weatherStation.Add(observer3);

//weatherStation.setTemperature(new Random().Next());
//Console.WriteLine("Updated!");
//weatherStation.setTemperature(new Random().Next());
//Console.WriteLine("Updated!");
//weatherStation.setTemperature(new Random().Next());
//Console.WriteLine("Updated!");

// Decorator Pattern -> Adding Toppings to the base functionality

Magerita mPizza = new Magerita();

ToppingsDecorator pizzaExtraCheese = new ExtraCheese(mPizza);

Console.WriteLine(pizzaExtraCheese.Cost());

ToppingsDecorator pizzaECMushroom = new ExtraCheese(new Mushroom(mPizza));  
Console.WriteLine(pizzaECMushroom.Cost());

ToppingsDecorator pizzaMushroom = new Mushroom(mPizza);
Console.WriteLine(pizzaMushroom.Cost());

