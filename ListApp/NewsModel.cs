using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Autofac;

namespace ListApp
{
	public class NewsModel : INotifyPropertyChanged
	{ 
		public string Title { get; set; }
		bool _showBoo;
		bool _showItem; 

		public bool ShowBoo 
		{ 
			get
			{
				return _showBoo;
			}
			set
			{
				_showBoo = value;
				NotifyPropertyChanged();
			}
		}

		public bool ShowItem 
		{ 
			get
			{
				return _showItem;
			}
			set
			{
				_showItem = value;
				NotifyPropertyChanged();
			}
		}

		public NewsModel()
		{
			_hideBooCommand = new Command(() => ShowBoo = false );
			_removeCommand = new Command(() => ExecuteRemoveCommand());
			ShowBoo = true;
			ShowItem = true;
		}

		void ExecuteRemoveCommand()
		{
			var model = App.Container.Resolve<INewsRoomModel>();
			this.ShowItem = false;
			model.RemoveItem(this);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var propertyChanged = PropertyChanged;
			if (propertyChanged != null)
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		readonly Command _hideBooCommand;
		public Command HideBooCommand
		{
			get { return _hideBooCommand; }
		}

		readonly Command _removeCommand;
		public Command RemoveCommand
		{
			get { return _removeCommand; }
		}
	}
}

