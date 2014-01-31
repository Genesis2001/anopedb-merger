// -----------------------------------------------------------------------------
//  <copyright file="ItemLoadedEventArgs.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.Core
{
	using System;

	public class ItemLoadedEventArgs : EventArgs
	{
		public ItemLoadedEventArgs(AnopeObject item)
		{
			Item = item;
		}

		public AnopeObject Item { get; private set; }
	}
}
