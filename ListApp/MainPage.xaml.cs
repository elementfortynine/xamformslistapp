using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;
using Autofac;

namespace ListApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var model = App.Container.Resolve<INewsRoomModel>();

			NewsListView.ItemsSource = model.NewsList;
		}
	}
}

