using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TPCWare.SQLiteTest.Model;
using System.Linq;

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
       /* public async Task<Campuses> SearchUniversities(string name)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("institutionFinder.db");
            var result = await connection.QueryAsync<Campuses>("Select * FROM Campuses WHERE Name ='" + name + "'");
            return result.SingleOrDefault();
        }*/
       
    }
}
