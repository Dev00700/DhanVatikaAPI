using Azure;
using Dapper;
using DevApi.Models.Common;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
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

        public static async Task<List<T>> GetResponseModelList<T>(string spName, DynamicParameters p)
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
        public static T GetResponseModel<T>(string spName, DynamicParameters p)
        {
            try
            {
                var paramLog = GetDynamicParametersLog(p);
                Console.WriteLine($"SP: {spName}\nParameters:\n{paramLog}\nError: ");
                using (SqlConnection objConnection = new SqlConnection(connection()))
                {
                    objConnection.Open();
                    var record = SqlMapper.QueryFirst<T>(
                        objConnection,
                        spName,
                        p,
                        commandType: CommandType.StoredProcedure
                    );
                    return record;
                }
            }
            catch (Exception ex)
            {
                var paramLog = GetDynamicParametersLog(p);
                Console.WriteLine($"SP: {spName}\nParameters:\n{paramLog}\nError: {ex.Message}");

                // Exception को caller तक पहुंचाना ज़रूरी है
                throw;
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
        //        public static List<T> GetListWithJsonColumn<T, TItem>(
        //    string spName,
        //    DynamicParameters p,
        //    string jsonColumnName = "JsonData"
        //)
        //    where T : new()
        //        {
        //            using (SqlConnection con = new SqlConnection(connection()))
        //            {
        //                con.Open();

        //                // Read all rows as dynamic
        //                var rows = con.Query(
        //                    spName,
        //                    p,
        //                    commandType: CommandType.StoredProcedure
        //                ).ToList();




        //                List<T> result = new List<T>();


        //                foreach (var row in rows)
        //                {
        //                    // Convert row to dictionary
        //                    var dict = (IDictionary<string, object>)row;

        //                    // Create parent object
        //                    T parent = new T();

        //                    // Fill normal columns
        //                    foreach (var prop in typeof(T).GetProperties())
        //                    {
        //                        if (dict.ContainsKey(prop.Name) && dict[prop.Name] != null)
        //                        {
        //                            var convertedValue = SafeConvert(dict[prop.Name], prop.PropertyType);
        //                            prop.SetValue(parent, convertedValue);
        //                        }
        //                    }


        //                    // Handle JSON column
        //                    if (dict.ContainsKey(jsonColumnName) && dict[jsonColumnName] != null)
        //                    {
        //                        var json = dict[jsonColumnName].ToString();

        //                        if (!string.IsNullOrEmpty(json))
        //                        {
        //                            var listData =
        //                                JsonConvert.DeserializeObject<List<TItem>>(json);

        //                            var listProp = typeof(T).GetProperties()
        //                                .FirstOrDefault(x => x.PropertyType == typeof(List<TItem>));

        //                            if (listProp != null)
        //                                listProp.SetValue(parent, listData);
        //                        }
        //                    }



        //                    result.Add(parent);
        //                }

        //                return result;
        //            }
        //        }


        public static CommonResponseDto<List<T>> GetListWithJsonColumn<T, TItem>(
    string spName,
    DynamicParameters p,
    string jsonColumnName = "JsonData"
)
    where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                con.Open();

                var result = new CommonResponseDto<List<T>>
                {
                    Data = new List<T>(),
                    Flag = 1,
                    Message = "Success"
                };

                using (var multi = con.QueryMultiple(
                    spName,
                    p,
                    commandType: CommandType.StoredProcedure
                ))
                {
                    // 🔹 Result set 1
                    var rows = multi.Read().ToList();

                    foreach (var row in rows)
                    {
                        var dict = (IDictionary<string, object>)row;
                        T parent = new T();

                        // 🔹 Normal columns
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            if (dict.ContainsKey(prop.Name) && dict[prop.Name] != null)
                            {
                                var convertedValue = SafeConvert(dict[prop.Name], prop.PropertyType);
                                prop.SetValue(parent, convertedValue);
                            }
                        }

                        // 🔹 JSON column
                        if (dict.ContainsKey(jsonColumnName) && dict[jsonColumnName] != null)
                        {
                            var json = dict[jsonColumnName].ToString();

                            if (!string.IsNullOrEmpty(json))
                            {
                                var listData = JsonConvert.DeserializeObject<List<TItem>>(json);

                                var listProp = typeof(T).GetProperties()
                                    .FirstOrDefault(x => x.PropertyType == typeof(List<TItem>));

                                if (listProp != null)
                                    listProp.SetValue(parent, listData);
                            }
                        }

                        // ✅ FIXED
                        result.Data.Add(parent);
                    }

                    // 🔹 Result set 2: paging
                    if (!multi.IsConsumed)
                    {
                        var pageInfo = multi.ReadFirstOrDefault<PageInfoDto>();
                        result.PageSize = pageInfo?.PageSize ?? 1;
                        result.PageRecordCount = pageInfo?.PageRecordCount ?? result.Data.Count;
                        result.TotalRecordCount = pageInfo?.TotalRecordCount ?? result.Data.Count;
                    }
                }

                return result;
            }
        }



        public static async Task<CommonResponseDto<List<T>>> GetPagedModelList<T>(
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

        public static string GetDynamicParametersLog(DynamicParameters p)
        {
            var sb = new StringBuilder();
            foreach (var name in p.ParameterNames)
            {
                var value = p.Get<dynamic>(name);
                sb.AppendLine($"{name} = {value ?? "NULL"}");
            }
            return sb.ToString();
        }

        private static object SafeConvert(object value, Type targetType)
        {
            if (value == null || value == DBNull.Value)
                return null;

            // Nullable<T> handle
            var underlyingType = Nullable.GetUnderlyingType(targetType);
            if (underlyingType != null)
                targetType = underlyingType;

            // Guid handle
            if (targetType == typeof(Guid))
                return Guid.Parse(value.ToString());

            // Enum handle
            if (targetType.IsEnum)
                return Enum.Parse(targetType, value.ToString());

            // Same type
            if (targetType == value.GetType())
                return value;

            return Convert.ChangeType(value, targetType);
        }

    }

} 