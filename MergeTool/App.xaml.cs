// -----------------------------------------------------------------------------
//  <copyright file="App.xaml.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace MergeTool
{
	using System.Windows;
	using ViewModels;

	public partial class App
	{
		private MergerViewModel viewModel;

		#region Overrides of Application

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
		protected override void OnStartup(StartupEventArgs e)
		{
			viewModel = new MergerViewModel();
			// viewModel.ParseArgs(e.Args);

			if (MainWindow == null)
			{
				MainWindow = new MainWindow();
			}

			MainWindow.DataContext = viewModel;
			MainWindow.Show();
		}

		#endregion
	}
}
