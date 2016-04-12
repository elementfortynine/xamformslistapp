using System;
using Xamarin.Forms;
using Autofac;
using Microsoft.Practices.ServiceLocation;

namespace ListApp
{
	public class App : Application
	{
		public static IContainer Container { get; set; }

		public App()
		{
			var builder = new ContainerBuilder();

			builder.RegisterInstance(new NewsRoomModel()).As<INewsRoomModel>();
			Container = builder.Build();
			// The root page of your application
			MainPage = new ListApp.MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

