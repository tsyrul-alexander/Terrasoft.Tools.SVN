﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terrasoft.Core.SVN;
using Terrasoft.Tools.SvnUI.Model.Enums;
using Terrasoft.Tools.SvnUI.Model.EventArgs;
using Terrasoft.Tools.SvnUI.Model.File;
using Terrasoft.Tools.SvnUI.Model.Property;
using Terrasoft.Tools.SvnUI.Properties;

namespace Terrasoft.Tools.SvnUI.ViewModel.Svn
{
	public class CreateFeatureSvnViewModel : BaseSvnOperationViewModel {
		
		private StringProperty _branchReleaseUrl;
		private StringProperty _maintainer;
		private StringProperty _featureName;

		public StringProperty BranchReleaseUrl {
			get => _branchReleaseUrl;
			set {
				_branchReleaseUrl = value;
				RaisePropertyChanged();
			}
		}

		public StringProperty Maintainer {
			get => _maintainer;
			set {
				_maintainer = value;
				RaisePropertyChanged();
			}
		}

		public StringProperty FeatureName {
			get => _featureName;
			set {
				_featureName = value;
				RaisePropertyChanged();
			}
		}

		public CreateFeatureSvnViewModel(IBrowserDialog browserDialog) : base(browserDialog) {
			BranchFeatureUrl.Caption = Resources.BranchesFeatureUrl;
			BranchFeatureUrl.Description = Resources.BranchesFeatureUrlDescription;
			BranchReleaseUrl = new StringProperty(Resources.BranchReleaseUrl, true, SvnUtilsBase.BranchReleaseUrlOptionName) {
				Description = Resources.BranchReleaseUrlDescription, Value = AppSetting.DefBranchReleaseUrl
			};
			Maintainer = new StringProperty(Resources.Maintainer, true, SvnUtilsBase.MaintainerOptionName) {
				Description = Resources.MaintainerDescription, Value = AppSetting.DefMaintainer
			};
			FeatureName = new StringProperty(Resources.FeatureName, true, SvnUtilsBase.FeatureNameOptionName) {
				Description = Resources.FeatureNameDescription, Value = AppSetting.DefFeatureName
			};
			BranchFeatureUrl.Value = AppSetting.DefBranchFeatureUrl;
			FeatureName.PropertyValueChange += FeatureNameOnPropertyValueChange;
		}

		private void FeatureNameOnPropertyValueChange(PropertyValueChangeEventArgs<string> eventArgs) {
			SetFeatureFolder(eventArgs.OldValue, eventArgs.NewValue);
		}
		protected virtual void SetFeatureFolder(string featureOldValue, string featureNewValue) {
			var lastFolderIndex = WorkingCopyPath.Value.LastIndexOf("\\", StringComparison.Ordinal);
			var lastFolderName = WorkingCopyPath.Value.Substring(lastFolderIndex + 1);
			if (lastFolderName == featureOldValue) {
				WorkingCopyPath.Value = WorkingCopyPath.Value.Remove(lastFolderIndex);
			}
			WorkingCopyPath.Value = Path.Combine(WorkingCopyPath.Value, featureNewValue);
		}

		protected override IEnumerable<BaseProperty> GetProperties() {
			return base.GetProperties().Concat(new[] {
				BranchReleaseUrl, Maintainer, FeatureName
			});
		}

		public override SvnOperation GetSvnOperation() {
			return SvnOperation.CreateFeature;
		}
	}
}
