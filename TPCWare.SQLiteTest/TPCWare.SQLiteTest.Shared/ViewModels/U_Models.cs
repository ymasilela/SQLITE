using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TPCWare.SQLiteTest.Model;

namespace TPCWare.SQLiteTest.ViewModels
{
    class U_Models 
    {
        private ObservableCollection<U_Models> projects;
        public ObservableCollection<U_Models> Projects
        {
            get
            {
                return projects;
            }

            set
            {
                projects = value;
                RaisePropertyChanged("Universities");
            }
        }

        private void RaisePropertyChanged(string p)
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<U_Models> groupedProjects;
        public ObservableCollection<U_Models> GroupedProjects
        {
            get
            {
                return groupedProjects;
            }

            set
            {
                groupedProjects = value;
             
            }
        }

        private TPCWare.SQLiteTest.App app = (App.Current as App);

       
    }
}
