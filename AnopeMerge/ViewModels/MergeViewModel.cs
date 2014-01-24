// -----------------------------------------------------------------------------
//  <copyright file="MergeViewModel.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.ViewModels
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using Core;
	using Models;

	public class MergeViewModel : IObservableClass
	{
		private AnopeDb inputOne;

		public AnopeDb InputOne
		{
			get { return inputOne; }
			set
			{
				NotifyPropertyChanging();
				inputOne = value;
				NotifyPropertyChanged();
			}
		}

		private AnopeDb inputTwo;

		public AnopeDb InputTwo
		{
			get { return inputTwo; }
			set
			{
				NotifyPropertyChanging();
				inputTwo = value;
				NotifyPropertyChanged();
			}
		}

		private AnopeDb output;

		public AnopeDb Output
		{
			get { return output; }
			set
			{
				NotifyPropertyChanging();
				output = value;
				NotifyPropertyChanged();
			}
		}


		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Implementation of INotifyPropertyChanging

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion

		#region Implementation of IObservableClass

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
		
		#endregion
	}
}
