﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Discobulb.Resources.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Discobulb.Resources.Localization.AppResources", typeof(AppResources).Assembly);
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
        ///   Looks up a localized string similar to Available bulbs for this bridge.
        /// </summary>
        internal static string Available_Bulbs {
            get {
                return ResourceManager.GetString("Available_Bulbs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Brightness.
        /// </summary>
        internal static string Brightness {
            get {
                return ResourceManager.GetString("Brightness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hue.
        /// </summary>
        internal static string Hue {
            get {
                return ResourceManager.GetString("Hue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not alter bulb {0}, likely due to connectivity problems..
        /// </summary>
        internal static string Req_Failed_Msg {
            get {
                return ResourceManager.GetString("Req_Failed_Msg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not process request, likely due to connectivity problems or the Hue API..
        /// </summary>
        internal static string Req_Failed_Msg_Generic {
            get {
                return ResourceManager.GetString("Req_Failed_Msg_Generic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request failed.
        /// </summary>
        internal static string Req_Failed_Title {
            get {
                return ResourceManager.GetString("Req_Failed_Title", resourceCulture);
            }
        }
    }
}