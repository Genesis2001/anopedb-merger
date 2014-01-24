// -----------------------------------------------------------------------------
//  <copyright file="AnopeObjectModel.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.Models
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using Core;

	public class AnopeObjectModel : AnopeObject, IObservableClass
	{
		private bool isChecked;
		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				NotifyPropertyChanging();
				name = value;
				NotifyPropertyChanged();
			}
		}

		public bool IsChecked
		{
			get { return isChecked; }
			set
			{
				NotifyPropertyChanging();
				isChecked = value;
				NotifyPropertyChanged();
			}
		}

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Implementation of INotifyPropertyChanging

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion

		public virtual void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyname));
		}

		public virtual void NotifyPropertyChanging([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanging;
			if (handler != null) handler(this, new PropertyChangingEventArgs(propertyName));
		}
	}
}
