using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer.Interface;
using System;
using System.Data;


namespace BusinessLogicLayer
{
    public class ProjectBusinessLogic : IProjectBusinessLogic
    {
        private readonly IProjectDataAccess _projectRepo;

        public ProjectBusinessLogic(IProjectDataAccess projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public int DeleteProject(int ProjectId)
        {

            int deletProject = _projectRepo.DeleteProject(ProjectId);
            return deletProject;
        }

        public DataSet GetAllProject()
        {
            DataSet allProject = _projectRepo.GetAllProject();
            return allProject;
        }

        public DataSet GetProjectById(int ProjectId)
        {
            DataSet allProject = _projectRepo.GetProjectById(ProjectId);
            return allProject;
        }
        public DataSet GetProjectByName(string ProjectName)
        {
            DataSet allProject = _projectRepo.GetProjectByName(ProjectName);
            return allProject;
        }

        public int InsertProject(ProjectBusinessObject Project)
        {
            int insertProject = _projectRepo.InsertProject(Project);
            return insertProject;
        }

        public int UpdateProject(ProjectBusinessObject Project, int ProjectId)
        {
            int updateProject = _projectRepo.UpdateProject(Project, ProjectId);
            return updateProject;
        }

        public DataSet ProjectSearch(ProjectBusinessObject Project)
        {
            DataSet searchProject = _projectRepo.ProjectSearch(Project);
            return searchProject;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
