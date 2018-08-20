﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Terrasoft.Tools.SVN.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Terrasoft.Tools.SVN.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Использование:
        ///	Terrasoft.Tools.SVN.exe &lt;команда&gt; [аргументы]
        ///Команды:
        ///	-Operation:		В качестве операции выбрать одну из следующих операций: CreateFeature, UpdateFeature, FinishFeature, CloseFeature, ChangeLanguage
        ///		CreateFeature :	Выделение новой ветки для фитчи на основании родительской
        ///		UpdateFeature :	Обновить ветку фитчи изменениями из родительской ветки
        ///		FinishFeature :	Завершить разработку фитчи, путем реинтеграции ветки фитчи в родительску ветку
        ///		CloseFeature  :	Пометь фитчу как завершенн [rest of string was truncated]&quot;;.
        /// </summary>
        public static string Program_Usage {
            get {
                return ResourceManager.GetString("Program_Usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Реинтеграция базовой ветки в ветку фитчи.
        /// </summary>
        public static string SvnUtils_CommitChanges_Reintegrate_base_branch_to_feature {
            get {
                return ResourceManager.GetString("SvnUtils_CommitChanges_Reintegrate_base_branch_to_feature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Автоматическая фиксация невозможна, так присутсвуют не решенные конфликты..
        /// </summary>
        public static string SvnUtils_CommitChanges_Sources_not_resolved {
            get {
                return ResourceManager.GetString("SvnUtils_CommitChanges_Sources_not_resolved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #0
        ///Создание ветки для фитчи: {0}.
        /// </summary>
        public static string SvnUtils_CopyBaseBranch_Init_Feature {
            get {
                return ResourceManager.GetString("SvnUtils_CopyBaseBranch_Init_Feature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Зафиксировано в ревизии №{0}..
        /// </summary>
        public static string SvnUtils_SvnCommitArgsOnCommitted_Commited_revision {
            get {
                return ResourceManager.GetString("SvnUtils_SvnCommitArgsOnCommitted_Commited_revision", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Элементов для фиксации: {0}.
        /// </summary>
        public static string SvnUtils_SvnCommitArgsOnCommitting_Items_to_commit {
            get {
                return ResourceManager.GetString("SvnUtils_SvnCommitArgsOnCommitting_Items_to_commit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Действие не выбрано!.
        /// </summary>
        public static string SvnUtils_SvnReintegrationMergeArgsOnConflict_Action_Not_Selected {
            get {
                return ResourceManager.GetString("SvnUtils_SvnReintegrationMergeArgsOnConflict_Action_Not_Selected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Обнаружен конфликт в файле: {0}.
        /// </summary>
        public static string SvnUtils_SvnReintegrationMergeArgsOnConflict_Conflict_in_file {
            get {
                return ResourceManager.GetString("SvnUtils_SvnReintegrationMergeArgsOnConflict_Conflict_in_file", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Файл {0} обновлен до ревизии №{1}.
        /// </summary>
        public static string SvnUtils_SvnUpdateArgsOnNotify_Update_to_revision {
            get {
                return ResourceManager.GetString("SvnUtils_SvnUpdateArgsOnNotify_Update_to_revision", resourceCulture);
            }
        }
    }
}
