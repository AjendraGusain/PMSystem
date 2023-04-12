using BussinessObjectLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IProjectBusinessLogic
    {
        DataSet GetAllProject();
        DataSet GetProjectById(int ProjectId);
        DataSet GetCurrentEmployeeByProjectId(int ProjectId);
        DataSet GetPastEmployeeByProjectId(int ProjectId);
        DataSet GetProjectByName(string ProjectName);
        int InsertProject(ProjectBusinessObject Project);
        int DeleteProject(int Id);
        int UpdateProject(ProjectBusinessObject Project, int ProjectId);
        DataSet ProjectSearch(ProjectBusinessObject Project);
        void Save();
    }
}
