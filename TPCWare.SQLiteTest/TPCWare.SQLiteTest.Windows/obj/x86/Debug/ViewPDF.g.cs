﻿

#pragma checksum "C:\Users\Mod\Desktop\usb\Project\SQLITE\TPCWare.SQLiteTest\TPCWare.SQLiteTest.Windows\ViewPDF.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "88501076F1E42B5A98F9EB1D436539A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPCWare.SQLiteTest
{
    partial class ViewPDF : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\..\ViewPDF.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).LoadCompleted += this.webView1_LoadCompleted;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\..\ViewPDF.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.back_web_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


