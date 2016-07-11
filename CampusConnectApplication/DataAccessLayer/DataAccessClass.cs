using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CampusConnectApplication.DataAccessLayer
{
    public class DataAccessClass
    {
        #region Scope of work


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appraisalid"></param>
        /// <param name="areaofwork"></param>
        /// <param name="detailofwork"></param>
        /// <param name="qualification"></param>
        /// <param name="startdate"></param>
        /// <param name="employerid"></param>
        /// <returns></returns>
        /// 
        public bool InsertWorkDetail(string appraisalid, int areaofwork, string detailofwork, string qualification, DateTime startdate, int employerid, string empdescription)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
            using (var connection = new SqlConnection(connString.ConnectionString))
            {
                connection.Open();
                var cmd = new SqlCommand
                {
                    CommandText = "spInsertWorkDetail",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
                DAOUtility.AddInParameter(ref cmd, "Area_Of_WorkID", DbType.Int32, areaofwork);
                DAOUtility.AddInParameter(ref cmd, "DetailOfWork", DbType.String, detailofwork);
                DAOUtility.AddInParameter(ref cmd, "Qualification", DbType.String, qualification);
                DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
                DAOUtility.AddInParameter(ref cmd, "EmployerID", DbType.String, employerid);
                DAOUtility.AddInParameter(ref cmd, "EmpDescription", DbType.String, empdescription);

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appraisalid"></param>
        /// <param name="areaofwork"></param>
        /// <param name="detailofwork"></param>
        /// <param name="qualification"></param>
        /// <param name="startdate"></param>
        /// <param name="employerid"></param>
        /// <returns></returns>
        public bool UpdateWorkDetail(int id, string appraisalid, int areaofwork, string detailofwork, string qualification, DateTime startdate, int employerid, string empdescription)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
            using (var connection = new SqlConnection(connString.ConnectionString))
            {
                connection.Open();
                var cmd = new SqlCommand
                {
                    CommandText = "spUpdateWorkDetail",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
                DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
                DAOUtility.AddInParameter(ref cmd, "Area_Of_WorkID", DbType.Int32, areaofwork);
                DAOUtility.AddInParameter(ref cmd, "DetailOfWork", DbType.String, detailofwork);
                DAOUtility.AddInParameter(ref cmd, "Qualification", DbType.String, qualification);
                DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
                DAOUtility.AddInParameter(ref cmd, "EmployerID", DbType.String, employerid);
                DAOUtility.AddInParameter(ref cmd, "EmpDescription", DbType.String, empdescription);
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteWorkDetail(int id)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
            using (var connection = new SqlConnection(connString.ConnectionString))
            {
                connection.Open();
                var cmd = new SqlCommand
                {
                    CommandText = "spDeleteWorkDetailByID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appraisalId"></param>
        /// <returns></returns>
        public DataTable SelectWorkDetailByAppraisalID(Guid appraisalId)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
            using (var connection = new SqlConnection(connString.ConnectionString))
            {
                // try
                // {
                connection.Open();
                var cmd = new SqlCommand
                {
                    CommandText = "spGetWorkDetailByAppraisalID",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };

                DAOUtility.AddInParameter(ref cmd, "@AppraisalID", DbType.Guid, appraisalId);

                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }

                return null;
            }
        }

        #endregion

        //    #region Last Year PDP

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectLastYearPDPDetailByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetLastYearPDPByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "@AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="devneed"></param>
        //    /// <param name="agreedaction"></param>
        //    /// <param name="outcome"></param>
        //    /// <param name="startdate"></param>
        //    /// <param name="targetdate"></param>
        //    /// <param name="statusid"></param>
        //    /// <returns></returns>
        //    public bool InsertLastYearPDP(string appraisalid, string devneed, string agreedaction, string outcome, DateTime startdate, DateTime targetdate, int statusid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertLastYearPDP",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Development_Need", DbType.String, devneed);
        //            DAOUtility.AddInParameter(ref cmd, "Agreed_Action", DbType.String, agreedaction);
        //            DAOUtility.AddInParameter(ref cmd, "Outcomes", DbType.String, outcome);
        //            DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
        //            DAOUtility.AddInParameter(ref cmd, "TargetDate", DbType.DateTime, targetdate);
        //            DAOUtility.AddInParameter(ref cmd, "StatusID", DbType.Int32, statusid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="devneed"></param>
        //    /// <param name="agreedaction"></param>
        //    /// <param name="outcome"></param>
        //    /// <param name="startdate"></param>
        //    /// <param name="targetdate"></param>
        //    /// <param name="statusid"></param>
        //    /// <returns></returns>
        //    public bool UpdateLastYearPDP(int id, string appraisalid, string devneed, string agreedaction, string outcome, DateTime startdate, DateTime targetdate, int statusid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateLastYearPDP",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int16, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Development_Need", DbType.String, devneed);
        //            DAOUtility.AddInParameter(ref cmd, "Agreed_Action", DbType.String, agreedaction);
        //            DAOUtility.AddInParameter(ref cmd, "Outcomes", DbType.String, outcome);
        //            DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
        //            DAOUtility.AddInParameter(ref cmd, "TargetDate", DbType.DateTime, targetdate);
        //            DAOUtility.AddInParameter(ref cmd, "StatusID", DbType.Int32, statusid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="approved"></param>
        //    /// <param name="approvalcomment"></param>
        //    /// <returns></returns>
        //    public bool UpdateLastYearPDPApproval(int id, bool approved, string approvalcomment)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateLastYearPDPApproval",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "Appraiser_Approval", DbType.Boolean, approved ? 1 : 0);
        //            DAOUtility.AddInParameter(ref cmd, "Appraiser_Comment", DbType.String, approvalcomment);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeleteLastYearPDP(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeleteLastYearPDP",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    #endregion

        //    #region professional development

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectProfessionDevelopmentByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetProfessionDevelopmentByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="purpose"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="suppinfotype"></param>
        //    /// <param name="pointsachieved"></param>
        //    /// <returns></returns>
        //    public bool InsertProfessionDevelopment(string appraisalid, string purpose, string desc, int suppinfotype, int pointsachieved)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertProfessionDevelopment",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Purpose", DbType.String, purpose);
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            //// DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Provided", DbType.Int16, supportinginfoprovided ? 1 : 0);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_TypeID", DbType.Int32, suppinfotype);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Filename", DbType.String, string.Empty);
        //            DAOUtility.AddInParameter(ref cmd, "Points_Achieved", DbType.Int32, pointsachieved);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="purpose"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="suppinfotype"></param>
        //    /// <param name="pointsachieved"></param>
        //    /// <returns></returns>
        //    public bool UpdateProfessionDevelopment(int id, string appraisalid, string purpose, string desc, int suppinfotype, int pointsachieved)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateProfessionDevelopment",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Purpose", DbType.String, purpose);
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            //// DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Provided", DbType.Int16, supportinginfoprovided ? 1 : 0);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_TypeID", DbType.Int32, suppinfotype);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Filename", DbType.String, string.Empty);
        //            DAOUtility.AddInParameter(ref cmd, "Points_Achieved", DbType.Int32, pointsachieved);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="supportinginfoprovided"></param>
        //    /// <returns></returns>
        //    public bool UpdateProfessionDevelopmentApproval(int id, bool supportinginfoprovided)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateProfessionDevelopmentApproval",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Provided", DbType.Int16, supportinginfoprovided ? 1 : 0);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeleteProfessionDevelopment(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeleteProfessionDevelopment",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    #endregion

        //    #region Quality improvement

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectQualityImprovementByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetQIActivityByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="qiInfTypeId"></param>
        //    /// <returns></returns>
        //    public bool InsertQualityImprovement(string appraisalid, string desc, int qiInfTypeId)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertQIActivity",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            DAOUtility.AddInParameter(ref cmd, "QI_Information_TypeID", DbType.Int32, qiInfTypeId);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="qiinfotype"></param>
        //    /// <returns></returns>
        //    public bool UpdateQualityImprovement(int id, string appraisalid, string desc, int qiinfotype)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateQIActivity",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            DAOUtility.AddInParameter(ref cmd, "QI_Information_TypeID", DbType.Int32, qiinfotype);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeleteQualityImprovement(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeleteQIActivity",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="supportinginfoprovided"></param>
        //    /// <returns></returns>
        //    public bool UpdateQualityImprovementApproval(int id, bool supportinginfoprovided)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateQIActivityApproved",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "Information_Provided", DbType.Int16, supportinginfoprovided ? 1 : 0);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    #endregion

        //    #region Signficant Events

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectEventBriefByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetEventBriefByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="personalinvolvement"></param>
        //    /// <param name="overcome"></param>
        //    /// <param name="typeid"></param>
        //    /// <returns></returns>
        //    public bool InsertEventBrief(string appraisalid, string desc, string personalinvolvement, string overcome, int typeid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertEventBrief",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            DAOUtility.AddInParameter(ref cmd, "Personal_Involvement", DbType.String, personalinvolvement);
        //            DAOUtility.AddInParameter(ref cmd, "Overcome", DbType.String, overcome);
        //            DAOUtility.AddInParameter(ref cmd, "BriefTypeID", DbType.Int32, typeid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeleteEventBrief(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeleteEventBrief",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="desc"></param>
        //    /// <param name="personalinvolvement"></param>
        //    /// <param name="overcome"></param>
        //    /// <param name="typeid"></param>
        //    /// <returns></returns>
        //    public bool UpdateEventBrief(int id, string appraisalid, string desc, string personalinvolvement, string overcome, int typeid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateEventBrief",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Description", DbType.String, desc);
        //            DAOUtility.AddInParameter(ref cmd, "Personal_Involvement", DbType.String, personalinvolvement);
        //            DAOUtility.AddInParameter(ref cmd, "Overcome", DbType.String, overcome);
        //            DAOUtility.AddInParameter(ref cmd, "BriefTypeID", DbType.Int32, typeid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    #endregion

        //    #region Colleague and patient feedback

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectFeedbackByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetFeedbackByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="feedbackdate"></param>
        //    /// <param name="activitycompleted"></param>
        //    /// <param name="activityoutcome"></param>
        //    /// <param name="infotype"></param>
        //    /// <param name="feedbacktypeid"></param>
        //    /// <returns></returns>
        //    public bool InsertFeedback(string appraisalid, DateTime feedbackdate, string activitycompleted, string activityoutcome, int infotype, int feedbacktypeid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertFeedback",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Feedback_Date", DbType.DateTime, feedbackdate);
        //            DAOUtility.AddInParameter(ref cmd, "Activity_Completed", DbType.String, activitycompleted);
        //            DAOUtility.AddInParameter(ref cmd, "Activity_Outcome", DbType.String, activityoutcome);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_TypeID", DbType.Int32, infotype);
        //            DAOUtility.AddInParameter(ref cmd, "Feedback_TypeID", DbType.Int32, feedbacktypeid);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Filename", DbType.String, string.Empty);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="feedbackdate"></param>
        //    /// <param name="activitycompleted"></param>
        //    /// <param name="activityoutcome"></param>
        //    /// <param name="infotype"></param>
        //    /// <param name="feedbacktypeid"></param>
        //    /// <returns></returns>
        //    public bool UpdateFeedback(int id, string appraisalid, DateTime feedbackdate, string activitycompleted, string activityoutcome, int infotype, int feedbacktypeid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateFeedback",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Feedback_Date", DbType.DateTime, feedbackdate);
        //            DAOUtility.AddInParameter(ref cmd, "Activity_Completed", DbType.String, activitycompleted);
        //            DAOUtility.AddInParameter(ref cmd, "Activity_Outcome", DbType.String, activityoutcome);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_TypeID", DbType.Int32, infotype);
        //            DAOUtility.AddInParameter(ref cmd, "Feedback_TypeID", DbType.Int32, feedbacktypeid);
        //            DAOUtility.AddInParameter(ref cmd, "Supporting_Info_Filename", DbType.String, string.Empty);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeleteFeedback(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeleteFeedback",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    public bool UpdateFeedbackApproval(int id, bool reportprovided, string reportcomment)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdateFeedbackApproved",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };
        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "Report_Provided", DbType.Int16, reportprovided ? 1 : 0);
        //            DAOUtility.AddInParameter(ref cmd, "Report_Comment", DbType.String, reportcomment);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    #endregion

        //    #region PDP Objectives

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <returns></returns>
        //    public DataTable SelectPDPObjectiveByAppraisalID(string appraisalid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            // try
        //            // {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetPDPObjectiveByAppraisalID",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="devneeded"></param>
        //    /// <param name="agreedaction"></param>
        //    /// <param name="outcomes"></param>
        //    /// <param name="startdate"></param>
        //    /// <param name="targetdate"></param>
        //    /// <param name="pdpobjstatusid"></param>
        //    /// <returns></returns>
        //    public bool InsertPDPObjective(string appraisalid, string devneeded, string agreedaction, string outcomes, DateTime startdate, DateTime targetdate, int pdpobjstatusid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spInsertPDPObjective",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Development_Needed", DbType.String, devneeded);
        //            DAOUtility.AddInParameter(ref cmd, "Agreed_Action", DbType.String, agreedaction);
        //            DAOUtility.AddInParameter(ref cmd, "Outcomes", DbType.String, outcomes);
        //            DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
        //            DAOUtility.AddInParameter(ref cmd, "TargetDate", DbType.DateTime, targetdate);
        //            DAOUtility.AddInParameter(ref cmd, "PDP_Obejective_StatusID", DbType.Int32, pdpobjstatusid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <param name="appraisalid"></param>
        //    /// <param name="devneeded"></param>
        //    /// <param name="agreedaction"></param>
        //    /// <param name="outcomes"></param>
        //    /// <param name="startdate"></param>
        //    /// <param name="targetdate"></param>
        //    /// <param name="pdpobjstatusid"></param>
        //    /// <returns></returns>
        //    public bool UpdatePDPObjective(int id, string appraisalid, string devneeded, string agreedaction, string outcomes, DateTime startdate, DateTime targetdate, int pdpobjstatusid)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spUpdatePDPObjective",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);
        //            DAOUtility.AddInParameter(ref cmd, "AppraisalID", DbType.Guid, new Guid(appraisalid));
        //            DAOUtility.AddInParameter(ref cmd, "Development_Needed", DbType.String, devneeded);
        //            DAOUtility.AddInParameter(ref cmd, "Agreed_Action", DbType.String, agreedaction);
        //            DAOUtility.AddInParameter(ref cmd, "Outcomes", DbType.String, outcomes);
        //            DAOUtility.AddInParameter(ref cmd, "StartDate", DbType.DateTime, startdate);
        //            DAOUtility.AddInParameter(ref cmd, "TargetDate", DbType.DateTime, targetdate);
        //            DAOUtility.AddInParameter(ref cmd, "PDP_Obejective_StatusID", DbType.Int32, pdpobjstatusid);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="id"></param>
        //    /// <returns></returns>
        //    public bool DeletePDPObjective(int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spDeletePDPObjective",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "ID", DbType.Int32, id);

        //            return cmd.ExecuteNonQuery() == 1;
        //        }
        //    }

        //    /// <summary>
        //    /// Select Appraiser and Appraisee Name
        //    /// </summary>
        //    /// <param name="personalid">the personal id</param>
        //    /// <param name="id">the appraiser id</param>
        //    /// <returns>the datatable</returns>
        //    public DataTable SelectAppraiserAppraiseeName(string personalid, int id)
        //    {
        //        ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["AppraisalConnectionString"];
        //        using (var connection = new SqlConnection(connString.ConnectionString))
        //        {
        //            connection.Open();
        //            var cmd = new SqlCommand
        //            {
        //                CommandText = "spGetAppraiserAppraiseeName",
        //                CommandType = CommandType.StoredProcedure,
        //                Connection = connection
        //            };

        //            DAOUtility.AddInParameter(ref cmd, "personalid", DbType.Guid, new Guid(personalid));
        //            DAOUtility.AddInParameter(ref cmd, "appraiserid", DbType.Int16, id);

        //            var da = new SqlDataAdapter(cmd);
        //            var ds = new DataSet();
        //            da.Fill(ds);

        //            if (ds.Tables.Count > 0)
        //            {
        //                return ds.Tables[0];
        //            }

        //            return null;
        //        }
        //    }

        //    #endregion
    }
}