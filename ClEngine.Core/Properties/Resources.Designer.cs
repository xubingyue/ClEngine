﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClEngine.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClEngine.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找类似 Could not find any 的本地化字符串。
        /// </summary>
        public static string CantFindAny {
            get {
                return ResourceManager.GetString("CantFindAny", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Files 的本地化字符串。
        /// </summary>
        public static string Files {
            get {
                return ResourceManager.GetString("Files", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 files, so GUIDs cannot be replaced 的本地化字符串。
        /// </summary>
        public static string GuidCantReplace {
            get {
                return ResourceManager.GetString("GuidCantReplace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 This location has multiple  的本地化字符串。
        /// </summary>
        public static string MultiLocation {
            get {
                return ResourceManager.GetString("MultiLocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Name 的本地化字符串。
        /// </summary>
        public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The file wasn&apos;t extracted correctly 的本地化字符串。
        /// </summary>
        public static string NotExtractedCorrectly {
            get {
                return ResourceManager.GetString("NotExtractedCorrectly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The local .zip file could not be unzipped.  Deleting this file.  Attempt to create the project again to re-download it 的本地化字符串。
        /// </summary>
        public static string NotUnzippedDeleteFileAndReDownload {
            get {
                return ResourceManager.GetString("NotUnzippedDeleteFileAndReDownload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Project name can&apos;t be blank 的本地化字符串。
        /// </summary>
        public static string ProjectNotBlank {
            get {
                return ResourceManager.GetString("ProjectNotBlank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Project name can&apos;t contain the character 的本地化字符串。
        /// </summary>
        public static string ProjectNotChar {
            get {
                return ResourceManager.GetString("ProjectNotChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Project names can&apos;t start with numbers 的本地化字符串。
        /// </summary>
        public static string ProjectNotNumber {
            get {
                return ResourceManager.GetString("ProjectNotNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Project name can&apos;t contain spaces. 的本地化字符串。
        /// </summary>
        public static string ProjectNotSpace {
            get {
                return ResourceManager.GetString("ProjectNotSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 is reserved.  Please pick another name 的本地化字符串。
        /// </summary>
        public static string ReserverdPickAnother {
            get {
                return ResourceManager.GetString("ReserverdPickAnother", resourceCulture);
            }
        }
    }
}
