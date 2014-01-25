// -----------------------------------------------------------------------------
//  <copyright file="ICheckedTreeViewItem.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.Models
{
	public interface ICheckedTreeViewItem : IObservableClass
	{
		string Name { get; set; }

		bool IsChecked { get; set; }
	}
}
