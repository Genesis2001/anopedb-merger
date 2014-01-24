// -----------------------------------------------------------------------------
//  <copyright file="IObservableClass.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.Models
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;

	public interface IObservableClass : INotifyPropertyChanged, INotifyPropertyChanging
	{
		void NotifyPropertyChanged([CallerMemberName] string propertyname = null);

		void NotifyPropertyChanging([CallerMemberName] string propertyName = null);
	}
}
