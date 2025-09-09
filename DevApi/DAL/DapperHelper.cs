using Dapper;
using DevApi.Models.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class DBHelperDapper
    {
        private static string connectionString = string.Empty;
        public static string connection()
        {
            try
            {
                return connectionString = "Server=68.178.164.44,1437\\DIVIKA;Database=Dhanvatika;User Id=sa;Password=M@tpuchbha!@213$;TrustServerCertificate=true;";
            }
            catch (Exception)
            {
                throw;
            }
        }








        public static async Task<TClass> GetAddResponseModel<TClass>(string procName, DynamicParameters param)
        {
            try
            {
                using (SqlConnection objConnection = new SqlConnection(connection()))
                {
                    await objConnection.OpenAsync();
                    var result = await objConnection.QueryFirstOrDefaultAsync<TClass>(
                        procName,
                        param,
                        commandType: System.Data.CommandType.StoredProcedure
                    );
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task< List<T>> GetResponseModelList<T>(string spName, DynamicParameters p)
        {
            List<T> recordList = new List<T>();
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                recordList = SqlMapper.Query<T>(objConnection, spName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                objConnection.Close();
            }
            return recordList;
        }
        public  static async Task<  T> GetResponseModel<T>(string spName, DynamicParameters p)
        {
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                var record = SqlMapper.QueryFirstOrDefault<T>(
                    objConnection,
                    spName,
                    p,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return record;
            }
        }

        public static TResponse GetAllModelNew<TRequest, TResponse>(string procName, DynamicParameters param)
        {
            TResponse result;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    result = SqlMapper.Query<TResponse>(con, procName, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static T GetModelFromJson<T>(string spName, DynamicParameters p)
        {
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                var json = objConnection.QueryFirstOrDefault<string>(spName, p, commandType: System.Data.CommandType.StoredProcedure);
                objConnection.Close();
                if (!string.IsNullOrEmpty(json))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                }
                return default;
            }
        }

        public static async Task< CommonResponseDto<List<T>>> GetPagedModelList<T>(
            string spName,
            DynamicParameters parameters)
        {
            var response = new CommonResponseDto<List<T>>();

            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                using (var multi = objConnection.QueryMultiple(spName, parameters, commandType: CommandType.StoredProcedure))
                {
                    var dataList = multi.Read<T>().ToList();
                    var pageInfo = multi.ReadFirstOrDefault<PageInfoDto>();

                    response.Data = dataList;
                    response.PageSize = pageInfo?.PageSize ?? 1;
                    response.PageRecordCount = pageInfo?.PageRecordCount ?? 10;
                    response.TotalRecordCount = pageInfo?.TotalRecordCount ?? dataList.Count;
                    response.Flag = 1;
                    response.Message = "Success";
                }
            }

            return response;
        }
    }
} 