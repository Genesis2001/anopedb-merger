﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnopeMerge.UnitTests.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AnopeMerge.UnitTests.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OBJECT BotInfo
        ///ID 1
        ///DATA nick BotServ
        ///DATA user services
        ///DATA host services.nite-serv.com
        ///DATA realname Bot Service
        ///DATA created 1361509363
        ///DATA oper_only 0
        ///END.
        /// </summary>
        internal static string BotInfoSingularTextStream {
            get {
                return ResourceManager.GetString("BotInfoSingularTextStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OBJECT BotInfo
        ///ID 1
        ///DATA nick BotServ
        ///DATA user services
        ///DATA host services.nite-serv.com
        ///DATA realname Bot Service
        ///DATA created 1361509363
        ///DATA oper_only 0
        ///END
        ///OBJECT BotInfo
        ///ID 2
        ///DATA nick ChanServ
        ///DATA user services
        ///DATA host services.nite-serv.com
        ///DATA realname Channel Registration Service
        ///DATA created 1361509363
        ///DATA oper_only 0
        ///END
        ///OBJECT BotInfo
        ///ID 3
        ///DATA nick Global
        ///DATA user services
        ///DATA host services.nite-serv.com
        ///DATA realname Global Noticer
        ///DATA created 1361509363
        ///DATA oper_only 0
        ///END.
        /// </summary>
        internal static string BotInfoTextStream {
            get {
                return ResourceManager.GetString("BotInfoTextStream", resourceCulture);
            }
        }
    }
}
