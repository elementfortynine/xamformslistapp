using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ListApp
{
	public interface INewsRoomModel
	{
		ObservableCollection<NewsModel> NewsList
		{
			get;
			set;
		}
		void RemoveItem(NewsModel model);
	}


	public class NewsRoomModel : INewsRoomModel, INotifyPropertyChanged
	{
		public NewsRoomModel()
		{
			NewsList.Add(new NewsModel(){ Title = "Casper"});
			NewsList.Add(new NewsModel(){ Title = "Slimer"});
			NewsList.Add(new NewsModel(){ Title = "Gozer"});
		}
			
		private ObservableCollection<NewsModel> _newsList = new ObservableCollection<NewsModel>();
		public ObservableCollection<NewsModel> NewsList //Binds with the listbox
		{
			get { return _newsList; }
			set 
			{ 
				_newsList = value; 
				RaisePropertyChanged("_newsList"); 
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string propertyName)
		{
			var handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void RemoveItem(NewsModel model)
		{
			model.ShowItem = false;
			_newsList.Remove(model);
		}
	}
}

