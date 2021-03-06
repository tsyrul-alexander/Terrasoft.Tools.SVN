﻿using System;
using System.IO;
using SharpSvn;
using Terrasoft.Core.SVN.Properties;

namespace Terrasoft.Core.SVN
{
	public sealed partial class SvnUtils
    {
        /// <summary>
        ///     Копирование базового ветки в ветку фитчи
        /// </summary>
        /// <param name="featureName">Название фитчи</param>
        /// <param name="featureNewUrl">URL новой ветки фитчи</param>
        /// <param name="revision">Номер ревизии из которой выделяется копия</param>
        /// <returns>Результат</returns>
        private bool CopyBaseBranch(string featureName, string featureNewUrl, long revision) {
            var svnCopyArgs = new SvnCopyArgs {
                LogMessage = string.Format(Resources.SvnUtils_CopyBaseBranch_Init_Feature, featureName),
                Revision = new SvnRevision(revision)
            };
            svnCopyArgs.Notify += SvnCopyArgsOnNotify;
            try {
                return RemoteCopy(SvnTarget.FromString(BranchReleaseUrl), new Uri(featureNewUrl), svnCopyArgs);
            } catch (ArgumentNullException argumentNullException) {
                Logger.LogError(argumentNullException.Message,
                    $"Parameter {argumentNullException.ParamName} is empty.");
                return false;
            } finally {
                svnCopyArgs.Notify -= SvnCopyArgsOnNotify;
            }
        }

        /// <summary>
        ///     Создание нового ветки для фитчи из базовой
        /// </summary>
        /// <returns>Результат</returns>
        public bool CreateFeature() {
            long lastBranchRevision = GetBaseBranchHeadRevision(BranchReleaseUrl);
            string featureNewUrl = $"{BranchFeatureUrl}/{Maintainer}_{FeatureName}";
            return CopyBaseBranch(FeatureName, featureNewUrl, lastBranchRevision)
                   && ExtractWorkingCopy(WorkingCopyPath, featureNewUrl)
                   && FixBranch();
        }

        /// <summary>
        ///     Выгрузить рабочую копия в локальную папку
        /// </summary>
        /// <param name="workingCopyPath">Путь к папке</param>
        /// <param name="url"></param>
        /// <returns>Результат</returns>
        private bool ExtractWorkingCopy(string workingCopyPath, string url) {
            return Directory.Exists(workingCopyPath)
                ? UpdateWorkingCopy(workingCopyPath)
                : CheckoutWorkingCopy(workingCopyPath, url);
        }

        /// <summary>
        ///     Выгрузка бранча в рабочую копию
        /// </summary>
        /// <param name="workingCopyPath">Путь к рабочей копии</param>
        /// <param name="url"></param>
        /// <returns>Результат</returns>
		public bool CheckoutWorkingCopy(string workingCopyPath, string url) {
            var svnCheckOutArgs = new SvnCheckOutArgs {IgnoreExternals = false};
            svnCheckOutArgs.Notify += SvnCheckOutArgsOnNotify;
            try {
                return CheckOut(SvnUriTarget.FromString(url), workingCopyPath, svnCheckOutArgs);
            } catch (ArgumentNullException argumentNullException) {
                Logger.LogError(argumentNullException.Message,
                    $"Parameter {argumentNullException.ParamName} is empty.");
                return false;
            } finally {
                svnCheckOutArgs.Notify -= SvnCheckOutArgsOnNotify;
            }
        }

        /// <summary>
        ///     Обновить рабочую копию
        /// </summary>
        /// <param name="workingCopyPath">Путь к рабочей копии</param>
        /// <returns>Результат</returns>
		public bool UpdateWorkingCopy(string workingCopyPath) {
            Info(SvnTarget.FromString(workingCopyPath), (sender, args) => Logger.LogInfo(args.ToString()));
            var svnUpdateArgs = new SvnUpdateArgs {IgnoreExternals = false, UpdateParents = true};
            svnUpdateArgs.Notify += SvnUpdateArgsOnNotify;
            svnUpdateArgs.Conflict += SvnUpdateArgsOnConflict;
            svnUpdateArgs.SvnError += SvnUpdateArgsOnSvnError;
            try {
                return Update(workingCopyPath, svnUpdateArgs);
            } catch (ArgumentNullException argumentNullException) {
                Logger.LogError(argumentNullException.Message,
                    $"Parameter {argumentNullException.ParamName} is empty.");
                return false;
            } finally {
                svnUpdateArgs.Notify -= SvnUpdateArgsOnNotify;
                svnUpdateArgs.Conflict -= SvnUpdateArgsOnConflict;
                svnUpdateArgs.SvnError -= SvnUpdateArgsOnSvnError;
            }
        }
    }
}