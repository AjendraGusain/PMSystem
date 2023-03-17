using BussinessObjectLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IProjectDataAccess
    {
        DataSet GetAllProject();
        DataSet GetProjectById(int ProjectId);
        DataSet GetProjectByName(string ProjectName);
        int InsertProject(ProjectBusinessObject Project);
        int DeleteProject(int ProjectId);
        int UpdateProject(ProjectBusinessObject Project, int ProjectId);
        DataSet ProjectSearch(ProjectBusinessObject Project);
        void Save();
    }
}
