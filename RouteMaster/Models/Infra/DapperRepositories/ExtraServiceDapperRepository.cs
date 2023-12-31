﻿using Dapper;
using RouteMaster.Models.Dto;
using RouteMaster.Models.EFModels;
using RouteMaster.Models.Interfaces;
using RouteMaster.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RouteMaster.Models.Infra.DapperRepositories
{
	public class ExtraServiceDapperRepository : IExtraServiceRepository
	{
		private string _connstr;

        public ExtraServiceDapperRepository()
        {
			_connstr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
        }



		public IEnumerable<ExtraServiceIndexDto> Search()
		{

			using(var conn=new SqlConnection(_connstr))
			{


				string sql = @"select E.[Id], E.[Name], A.[Name] as AttractionName, 
E.[Price], E.[Description] ,[Status] 
from ExtraServices AS E
JOIN Attractions AS A
ON E.AttractionId=A.Id
order by Price";

                return conn.Query<ExtraServiceIndexDto>(sql);	
			}
		}





		public void Create(ExtraServiceCreateDto dto)
		{

			//還沒測試
			using(var conn =new SqlConnection(_connstr))
			{

				string sql = @"INSERT INTO ExtraServices(
Name, AttractionId, Price, Description, Status
)VALUES(@Name, @AttractionId, @Price, @Description, @Status
)";

				conn.Execute(sql, dto);

			}	
		}

		public void Delete(int id)
		{
			using(var conn=new SqlConnection(_connstr))
			{
				string sql = @"DELETE FROM ExtraServices WHERE Id=@Id";
				conn.Execute(sql, new{id});
			}
		}



		public void Edit(ExtraServiceEditDto dto)
		{
			using(var conn =new SqlConnection(_connstr))
			{

				string sql = @"Update ExtraServices SET 
[Name]=@Name, 
AttractionId=@AttractionId, 
Price=@Price, 
[Description]=@Description, 
[Status]=@Status
WHERE Id=@Id" ;

				conn.Execute(sql,dto);
			}
		}

		public bool ExistExtraService(string name, int attractionId,int id)
		{
			using(var conn =new SqlConnection(_connstr))
			{
				string sql = " select count(*) as [count] from ExtraServices WHERE [Name]=@name and AttractionId=@attractionId and Id!=@id";
                var parameters = new { name, attractionId,id };
                var result = conn.QueryFirstOrDefault<int>(sql, parameters);
				bool exists = result > 0;
                return exists;
            }
            
		}


        public bool ExistExtraServiceCreate(string name, int attractionId)
		{
            using (var conn = new SqlConnection(_connstr))
            {
                string sql = " select count(*) as [count] from ExtraServices WHERE [Name]=@name and AttractionId=@attractionId ";
                var parameters = new { name, attractionId};
                var result = conn.QueryFirstOrDefault<int>(sql, parameters);
                bool exists = result > 0;
                return exists;
            }
        }



        public  ExtraServiceEditDto GetExtraServiceById(int id)
		{
			using (var conn = new SqlConnection(_connstr))
			{




				string sql = @"select E.[Id],E.[Name],E.[AttractionId],A.[Name] as AttractionName, 
E.[Price], E.[Description] ,[Status] 
from ExtraServices AS E
JOIN Attractions AS A
ON E.AttractionId=A.Id where E.[Id]=@id ";

                return conn.QuerySingleOrDefault<ExtraServiceEditDto>(sql,new { id });
			}
		}
	}
}