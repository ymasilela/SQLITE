﻿

#pragma checksum "C:\Users\Mod\Desktop\usb\Project\SQLITE\TPCWare.SQLiteTest\TPCWare.SQLiteTest.Windows\SearchPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6324EA04EDACA94539309126A7320B1C"
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
    partial class SearchPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\..\SearchPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.back_se_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 13 "..\..\..\SearchPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.UserList_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


