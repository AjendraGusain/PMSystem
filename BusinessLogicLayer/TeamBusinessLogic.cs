using BusinessLogicLayer.Interface;
using BussinessObjectLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TeamBusinessLogic:ITeamBusinessLogic
    {
        private DataSet dtResult;
        private int respone;
        private ITeamDataAccess _teamDataAccess;

        public TeamBusinessLogic(ITeamDataAccess teamDataAccess)
        {
            _teamDataAccess = teamDataAccess;
        }
        public DataSet GetManager(int Id, int projectId)
        {
            dtResult = _teamDataAccess.GetManager(Id, projectId);
            return dtResult;
        }

        public DataSet GetTeam()
        {
            dtResult = _teamDataAccess.GetTeam();
            return dtResult;
        }

        public DataSet GetTeamByID(int Id)
        {
            dtResult = _teamDataAccess.GetTeamByID(Id);
            return dtResult;
        }

        public DataSet GetTeamLeader(int Id)
        {
            dtResult = _teamDataAccess.GetTeamLeader(Id);
            return dtResult;
        }

        //public DataSet GetTeamMember(int ProjectId)
        //{
        //    dtResult = _teamDataAccess.GetTeamMembers(ProjectId);
        //    return dtResult;
        //}

        public DataSet GetUser()
        {
            dtResult = _teamDataAccess.GetUser();
            return dtResult;
        }

        public int InsertTeam(TeamBusinessObject createTeam)
        {
            respone = _teamDataAccess.InsertTeam(createTeam);
            return respone;
        }

        public int UpdateTeam(TeamBusinessObject createTeam, int Id)
        {
            respone = _teamDataAccess.UpdateTeam(createTeam, Id);
            return respone;
        }

        public DataSet GetProject()
        {
            dtResult = _teamDataAccess.GetProject();
            return dtResult;
        }

        public int EditTeam(TeamBusinessObject createTeam, int Id)
        {
            throw new NotImplementedException();
        }

        public int DeleteTeam(int Id)
        {
            respone = _teamDataAccess.DeleteTeam(Id);
            return respone;
        }

        public DataSet GetTeamName()
        {
            dtResult = _teamDataAccess.GetTeamName();
            return dtResult;
        }

        public DataSet GetTeamNameById(int Id)
        {
            dtResult = _teamDataAccess.GetTeamNameById(Id);
            return dtResult;
        }

        public DataSet GetTeamMemberMangerTLUser(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamMemberMangerTLUser(createTeam);
            string TeamName = "";
            string ProjectName = "";
            for (int i = 0; i < dtResult.Tables[0].Rows.Count; i++)
            {
               if (dtResult.Tables[0].Rows[i]["TeamName"].ToString() == TeamName && dtResult.Tables[0].Rows[i]["ProjectName"].ToString() == ProjectName)
                {
                        dtResult.Tables[0].Rows[i]["TeamName"] = "";
                        dtResult.Tables[0].Rows[i]["ProjectName"] = "";
                    
                    if (TeamName == "" && ProjectName == "" )
                    {
                        TeamName = dtResult.Tables[0].Rows[i - 1]["TeamName"].ToString();
                        ProjectName = dtResult.Tables[0].Rows[i - 1]["ProjectName"].ToString();
                        
                    }
                }
              
                else
                {
                    TeamName = dtResult.Tables[0].Rows[i]["TeamName"].ToString();
                    ProjectName = dtResult.Tables[0].Rows[i]["ProjectName"].ToString();
                }
            }
            return dtResult;
        }



        public DataSet GetTeamMember(int ProjectId, int TeamId, TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamMember(ProjectId, TeamId, createTeam);
            return dtResult;
        }

        public int InsertTeamMember(TeamBusinessObject createTeam)
        {
            respone = _teamDataAccess.InsertTeamMember(createTeam);
            return respone;
        }

        public int DeleteTeamMember(int Id, TeamBusinessObject createTeam)
        {
            respone = _teamDataAccess.DeleteTeamMember(Id, createTeam);
            return respone;
        }

        public int UpdateTeamMember(TeamBusinessObject createTeam)
        {
            respone = _teamDataAccess.UpdateTeamMember(createTeam);
            return respone;
        }


        public DataSet GetViewTeam(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetViewTeam(createTeam);
            return dtResult;
        }
        public DataSet GetTeamLeaderTeam(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamLeaderTeam(createTeam);
            return dtResult;
        }

        public DataSet GetTeamLeaderTeam(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamLeaderTeam(createTeam);
            return dtResult;
        }

        public DataSet GetTeamMemberTeamLeader(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamMemberMangerTLUser(createTeam); ;
            string TeamName = "";
            string ProjectName = "";
            string ManagerName = "";
            for (int i = 0; i < dtResult.Tables[1].Rows.Count; i++)
            {
                if (dtResult.Tables[1].Rows[i]["TeamName"].ToString() == TeamName && dtResult.Tables[1].Rows[i]["ProjectName"].ToString() == ProjectName  
                    && dtResult.Tables[1].Rows[i]["ManagerName"].ToString() == ManagerName)
                {
                    dtResult.Tables[1].Rows[i]["TeamName"] = "";
                    dtResult.Tables[1].Rows[i]["ProjectName"] = "";
                    dtResult.Tables[1].Rows[i]["ManagerName"] = "";

                    if (TeamName == "" && ProjectName == "")
                    {
                        TeamName = dtResult.Tables[1].Rows[i - 1]["TeamName"].ToString();
                        ProjectName = dtResult.Tables[1].Rows[i - 1]["ProjectName"].ToString();
                        ManagerName = dtResult.Tables[1].Rows[i - 1]["ManagerName"].ToString();
                    }
                }

                else
                {
                    TeamName = dtResult.Tables[1].Rows[i]["TeamName"].ToString();
                    ProjectName = dtResult.Tables[1].Rows[i]["ProjectName"].ToString();
                    ManagerName = dtResult.Tables[1].Rows[i]["ManagerName"].ToString();
                }
            }

            //for (int i = dtResult.Tables[1].Rows.Count - 1; i >= 0; i--)
            //{
            //    DataRow dr = dtResult.Tables[1].Rows[i];
            //    if (dr["TeamName"] == "" && dr["ProjectName"] == "" && dr["ManagerName"]=="" && dr["TLName"]=="")
            //    {
            //        dr.Delete();
            //    }
            //}
            return dtResult;
        }

        public DataSet GetTeamMemberEmployee(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamMemberMangerTLUser(createTeam);
            string TeamName = "";
            string ProjectName = "";
            string ManagerName = "";
            string TeamLeaderName = "";
            for (int i = 0; i < dtResult.Tables[2].Rows.Count; i++)
            {
                if (dtResult.Tables[2].Rows[i]["RoleId"].ToString() == "2")
                   dtResult.Tables[2].Rows[i]["UserName"] = dtResult.Tables[2].Rows[i]["UserName"].ToString() + " (Developer)";
                else if (dtResult.Tables[2].Rows[i]["RoleId"].ToString() == "5")
                    dtResult.Tables[2].Rows[i]["UserName"] = dtResult.Tables[2].Rows[i]["UserName"].ToString() + " (Tester)";
            }

            for (int i = 0; i < dtResult.Tables[2].Rows.Count; i++)
            {
                if (dtResult.Tables[2].Rows[i]["TeamName"].ToString() == TeamName && dtResult.Tables[2].Rows[i]["ProjectName"].ToString() == ProjectName
                    && dtResult.Tables[2].Rows[i]["ManagerName"].ToString() == ManagerName && dtResult.Tables[2].Rows[i]["TeamLeaderName"].ToString() == TeamLeaderName)
                {
                    dtResult.Tables[2].Rows[i]["TeamName"] = "";
                    dtResult.Tables[2].Rows[i]["ProjectName"] = "";
                    dtResult.Tables[2].Rows[i]["TeamLeaderName"] = "";
                    dtResult.Tables[2].Rows[i]["ManagerName"] = "";
                    if (TeamName == "" && ProjectName == "")
                    {
                        TeamName = dtResult.Tables[2].Rows[i - 1]["TeamName"].ToString();
                        ProjectName = dtResult.Tables[2].Rows[i - 1]["ProjectName"].ToString();
                        ManagerName = dtResult.Tables[2].Rows[i - 1]["ManagerName"].ToString();
                        TeamLeaderName = dtResult.Tables[2].Rows[i - 1]["TeamLeaderName"].ToString();
                    }
                }
                else
                {
                    TeamName = dtResult.Tables[2].Rows[i]["TeamName"].ToString();
                    ProjectName = dtResult.Tables[2].Rows[i]["ProjectName"].ToString();
                    ManagerName = dtResult.Tables[2].Rows[i]["ManagerName"].ToString();
                    TeamLeaderName = dtResult.Tables[2].Rows[i]["TeamLeaderName"].ToString();
                }
            }

            //for (int i = dtResult.Tables[2].Rows.Count - 1; i >= 0; i--)
            //{
            //    DataRow dr = dtResult.Tables[2].Rows[i];
            //    if (dr["TeamName"] == "" && dr["ProjectName"] == "" && dr["ManagerName"]=="" && dr["TeamLeaderName"] =="")
            //    {
            //        dr.Delete();
            //    }
            //}
            return dtResult;
        }

        public DataSet GetTeamDetails(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetTeamDetails(createTeam);
            string TeamName = "";
            string ProjectName = "";
            string ManagerName = "";
            string TeamLeaderName = "";
            for (int i = 0; i < dtResult.Tables[2].Rows.Count; i++)
            {
                if (dtResult.Tables[2].Rows[i]["TeamName"].ToString() == TeamName && dtResult.Tables[2].Rows[i]["ProjectName"].ToString() == ProjectName)
                {
                    dtResult.Tables[2].Rows[i]["TeamName"] = "";
                    dtResult.Tables[2].Rows[i]["ProjectName"] = "";
                    if (dtResult.Tables[2].Rows[i]["TeamLeaderName"].ToString() == TeamLeaderName
                    && dtResult.Tables[2].Rows[i]["ManagerName"].ToString() == ManagerName)
                    {
                        dtResult.Tables[2].Rows[i]["TeamLeaderName"] = "";
                        dtResult.Tables[2].Rows[i]["ManagerName"] = "";
                    }
                    if (TeamName == "" && ProjectName == "")
                    {
                        TeamName = dtResult.Tables[2].Rows[i - 1]["TeamName"].ToString();
                        ProjectName = dtResult.Tables[2].Rows[i - 1]["ProjectName"].ToString();
                        if (dtResult.Tables[2].Rows[i]["TeamLeaderName"].ToString() == TeamLeaderName
                    && dtResult.Tables[2].Rows[i]["ManagerName"].ToString() == ManagerName)
                        {
                            ManagerName = dtResult.Tables[2].Rows[i - 1]["ManagerName"].ToString();
                            TeamLeaderName = dtResult.Tables[2].Rows[i - 1]["TeamLeaderName"].ToString();
                        }
                    }
                }

                else
                {
                    TeamName = dtResult.Tables[2].Rows[i]["TeamName"].ToString();
                    ProjectName = dtResult.Tables[2].Rows[i]["ProjectName"].ToString();
                    ManagerName = dtResult.Tables[2].Rows[i]["ManagerName"].ToString();
                    TeamLeaderName = dtResult.Tables[2].Rows[i]["TeamLeaderName"].ToString();
                }
            }
            return dtResult;
        }

        public DataSet GetAllEmployeTeamMemberId(TeamBusinessObject createTeam)
        {
            dtResult = _teamDataAccess.GetAllEmployeTeamMemberId(createTeam);
            return dtResult;
        }
    }
}
