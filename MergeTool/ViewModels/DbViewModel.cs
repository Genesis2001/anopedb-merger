// -----------------------------------------------------------------------------
//  <copyright file="DbViewModel.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace MergeTool.ViewModels
{
	using System.Windows.Forms;
	using System.Windows.Forms.VisualStyles;
	using System.Windows.Input;
	using AnopeMerge.Core;
	using Commands;

	public class DbViewModel : ObservableObject
	{
		private bool canLoad;
		private bool canSave;
		private string fileName;
		private AnopeDb db;

		public DbViewModel()
		{
			db = new AnopeDb();

			BrowseCommand = new RelayCommand(x => FileName = Browse(), x => true);
			LoadCommand   = new RelayCommand(x => db.Load(FileName), x => CanLoad && !string.IsNullOrEmpty(FileName));
			SaveCommand   = new RelayCommand(x => db.Save(FileName), x => CanSave);
		}

		#region Properties

		#region Commands

		public ICommand BrowseCommand { get; private set; }

		public ICommand LoadCommand { get; private set; }

		public ICommand SaveCommand { get; private set; }

		#endregion

		public bool CanLoad
		{
			get { return canLoad; }
			set
			{
				NotifyPropertyChanging();
				canLoad = value;
				NotifyPropertyChanged();
			}
		}

		public bool CanSave
		{
			get { return canSave; }
			set
			{
				NotifyPropertyChanging();
				canSave = value;
				NotifyPropertyChanged();
			}
		}

		public AnopeDb Db
		{
			get { return db; }
			private set
			{
				NotifyPropertyChanging();
				db = value;
				NotifyPropertyChanged();
			}
		}
		
		public string FileName
		{
			get { return fileName; }
			set
			{
				NotifyPropertyChanging();
				fileName = value;
				NotifyPropertyChanged();
			}
		}
		
		#endregion

		#region Methods

		public string Browse()
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

		#endregion
	}
}
