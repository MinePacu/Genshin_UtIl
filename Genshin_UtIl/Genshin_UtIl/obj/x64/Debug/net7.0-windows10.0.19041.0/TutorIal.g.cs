﻿#pragma checksum "H:\Visual_Studio__\Genshin_UtIl\Genshin_UtIl\Genshin_UtIl\TutorIal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "912ADEA0A058718EDA84BE5AFCD2FC29BFF8F660E5D95B6136743750E6EE705B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Genshin_UtIl
{
    partial class TutorIal : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // TutorIal.xaml line 1
                {
                    global::Microsoft.UI.Xaml.Window element1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Window>(target);
                    ((global::Microsoft.UI.Xaml.Window)element1).Closed += this.WIndow_Closed;
                }
                break;
            case 2: // TutorIal.xaml line 11
                {
                    this.n = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.n).SelectionChanged += this.N_SelectIonChanged;
                }
                break;
            case 3: // TutorIal.xaml line 23
                {
                    this.contentFra = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

