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
		public MergeViewModel()
		{
			InputOne = new AnopeDb();
			InputTwo = new AnopeDb();
			Output   = new AnopeDb();
		}

		public AnopeDb InputOne { get; private set; }

		public AnopeDb InputTwo { get; private set; }

		public AnopeDb Output { get; private set; }

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
