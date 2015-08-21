﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace TPCWare.SQLiteTest.ViewModels
{
    class CampusModels
    {
        private string Name = string.Empty;
        public string NAME
        {
            get { return Name; }

            set
            {
                if (Name == value)
                { return; }

                Name = value;

            }
        }
        private TPCWare.SQLiteTest.App app = (Application.Current as App);
        private string id = string.Empty;
        public string ID
        {
            get { return id; }

            set
            {
                if (id == value)
                { return; }
                id = value;
            }
        }
    }
}
