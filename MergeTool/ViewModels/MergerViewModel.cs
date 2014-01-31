// -----------------------------------------------------------------------------
//  <copyright file="MergerViewModel.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace MergeTool.ViewModels
{
	using System;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Windows.Forms;
	using System.Windows.Input;
	using AnopeMerge.Core;

	public class MergerViewModel : INotifyPropertyChanged
	{
		private string leftFileInput;
		private string outputFilePath;
		private string rightFileInput;
		private string state;

		private AnopeDb leftInputDb;
		private AnopeDb rightInputDb;
		private AnopeDb mergedDb;

		public MergerViewModel()
		{
			leftInputDb  = new AnopeDb();
			rightInputDb = new AnopeDb();
			mergedDb     = new AnopeDb();

			leftInputDb.ItemLoaded  += OnItemLoad;
			rightInputDb.ItemLoaded += OnItemLoad;

			BrowseLeftInputCommand  = new RelayCommand(x => LeftFileInput = BrowseFile(), x => true);
			BrowseRightInputCommand = new RelayCommand(x => RightFileInput = BrowseFile(), x => true);
			BrowseOutputFileCommand = new RelayCommand(x => OutputFilePath = BrowseFolder(), x => true);

			LoadLeftCommand   = new RelayCommand(x => LeftInputDb.Load(LeftFileInput), x => !string.IsNullOrEmpty(LeftFileInput));
			LoadRightCommand  = new RelayCommand(x => RightInputDb.Load(RightFileInput), x => !string.IsNullOrEmpty(RightFileInput));
			SaveOutputCommand = new RelayCommand(x => mergedDb.Save(OutputFilePath), x => !string.IsNullOrEmpty(OutputFilePath));
		}

		#region Properties

		#region Commands

		public ICommand BrowseLeftInputCommand { get; private set; }

		public ICommand BrowseRightInputCommand { get; private set; }

		public ICommand BrowseOutputFileCommand { get; private set; }

		public ICommand LoadLeftCommand { get; private set; }

		public ICommand LoadRightCommand { get; private set; }

		public ICommand SaveOutputCommand { get; private set; }

		#endregion

		public AnopeDb LeftInputDb
		{
			get { return leftInputDb; }
			private set
			{
				leftInputDb = value;
				NotifyPropertyChanged();
			}
		}

		public AnopeDb RightInputDb
		{
			get { return rightInputDb; }
			private set
			{
				rightInputDb = value;
				NotifyPropertyChanged();
			}
		}

		public string LeftFileInput
		{
			get { return leftFileInput; }
			set
			{
				leftFileInput = value;
				NotifyPropertyChanged();
			}
		}

		public string OutputFilePath
		{
			get { return outputFilePath; }
			set
			{
				outputFilePath = value;
				NotifyPropertyChanged();
			}
		}

		public string RightFileInput
		{
			get { return rightFileInput; }
			set
			{
				rightFileInput = value;
				NotifyPropertyChanged();
			}
		}

		public string State
		{
			get { return state; }
			set
			{
				state = value;
				NotifyPropertyChanged();
			}
		}


		#endregion

		#region Methods

		private void OnItemLoad(object sender, ItemLoadedEventArgs args)
		{
			State = string.Format("Loading {0} (ID: {1})", args.Item.ObjectType, args.Item.Id);
		}

		public string BrowseFile()
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Multiselect     = false;
				dialog.ReadOnlyChecked = true;
				dialog.DefaultExt      = ".db";
				dialog.Filter          = @"AnopeDB Files (*.db)|*.db";

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.FileName;
				}
			}

			return string.Empty;
		}

		public string BrowseFolder()
		{
			using (var dialog = new OpenFileDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					return dialog.FileName;
				}
			}

			return string.Empty;
		}

		#endregion

		#region Implementation of INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}
