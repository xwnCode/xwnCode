using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Vline.DAL
{
	/// <summary>
	/// 数据访问类:BUSI_applyDetail
	/// </summary>
	public partial class BUSI_applyDetail
	{
		public BUSI_applyDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "BUSI_applyDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUSI_applyDetail");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Vline.Model.BUSI_applyDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUSI_applyDetail(");
			strSql.Append("id,sqrid,sqDate,timeId,state,startTime,endTime,Describle,sqrName,sqrsm,by1)");
			strSql.Append(" values (");
			strSql.Append("@id,@sqrid,@sqDate,@timeId,@state,@startTime,@endTime,@Describle,@sqrName,@sqrsm,@by1)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sqrid", SqlDbType.Int,4),
					new SqlParameter("@sqDate", SqlDbType.DateTime),
					new SqlParameter("@timeId", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.VarChar,20),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@Describle", SqlDbType.VarChar,50),
					new SqlParameter("@sqrName", SqlDbType.VarChar,50),
					new SqlParameter("@sqrsm", SqlDbType.VarChar,-1),
					new SqlParameter("@by1", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.sqrid;
			parameters[2].Value = model.sqDate;
			parameters[3].Value = model.timeId;
			parameters[4].Value = model.state;
			parameters[5].Value = model.startTime;
			parameters[6].Value = model.endTime;
			parameters[7].Value = model.Describle;
			parameters[8].Value = model.sqrName;
			parameters[9].Value = model.sqrsm;
			parameters[10].Value = model.by1;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Vline.Model.BUSI_applyDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUSI_applyDetail set ");
			strSql.Append("sqrid=@sqrid,");
			strSql.Append("sqDate=@sqDate,");
			strSql.Append("timeId=@timeId,");
			strSql.Append("state=@state,");
			strSql.Append("startTime=@startTime,");
			strSql.Append("endTime=@endTime,");
			strSql.Append("Describle=@Describle,");
			strSql.Append("sqrName=@sqrName,");
			strSql.Append("sqrsm=@sqrsm,");
			strSql.Append("by1=@by1");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@sqrid", SqlDbType.Int,4),
					new SqlParameter("@sqDate", SqlDbType.DateTime),
					new SqlParameter("@timeId", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.VarChar,20),
					new SqlParameter("@startTime", SqlDbType.DateTime),
					new SqlParameter("@endTime", SqlDbType.DateTime),
					new SqlParameter("@Describle", SqlDbType.VarChar,50),
					new SqlParameter("@sqrName", SqlDbType.VarChar,50),
					new SqlParameter("@sqrsm", SqlDbType.VarChar,-1),
					new SqlParameter("@by1", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sqrid;
			parameters[1].Value = model.sqDate;
			parameters[2].Value = model.timeId;
			parameters[3].Value = model.state;
			parameters[4].Value = model.startTime;
			parameters[5].Value = model.endTime;
			parameters[6].Value = model.Describle;
			parameters[7].Value = model.sqrName;
			parameters[8].Value = model.sqrsm;
			parameters[9].Value = model.by1;
			parameters[10].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUSI_applyDetail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUSI_applyDetail ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Vline.Model.BUSI_applyDetail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sqrid,sqDate,timeId,state,startTime,endTime,Describle,sqrName,sqrsm,by1 from BUSI_applyDetail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			Vline.Model.BUSI_applyDetail model=new Vline.Model.BUSI_applyDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Vline.Model.BUSI_applyDetail DataRowToModel(DataRow row)
		{
			Vline.Model.BUSI_applyDetail model=new Vline.Model.BUSI_applyDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sqrid"]!=null && row["sqrid"].ToString()!="")
				{
					model.sqrid=int.Parse(row["sqrid"].ToString());
				}
				if(row["sqDate"]!=null && row["sqDate"].ToString()!="")
				{
					model.sqDate=DateTime.Parse(row["sqDate"].ToString());
				}
				if(row["timeId"]!=null && row["timeId"].ToString()!="")
				{
					model.timeId=int.Parse(row["timeId"].ToString());
				}
				if(row["state"]!=null)
				{
					model.state=row["state"].ToString();
				}
				if(row["startTime"]!=null && row["startTime"].ToString()!="")
				{
					model.startTime=DateTime.Parse(row["startTime"].ToString());
				}
				if(row["endTime"]!=null && row["endTime"].ToString()!="")
				{
					model.endTime=DateTime.Parse(row["endTime"].ToString());
				}
				if(row["Describle"]!=null)
				{
					model.Describle=row["Describle"].ToString();
				}
				if(row["sqrName"]!=null)
				{
					model.sqrName=row["sqrName"].ToString();
				}
				if(row["sqrsm"]!=null)
				{
					model.sqrsm=row["sqrsm"].ToString();
				}
				if(row["by1"]!=null)
				{
					model.by1=row["by1"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sqrid,sqDate,timeId,state,startTime,endTime,Describle,sqrName,sqrsm,by1 ");
			strSql.Append(" FROM BUSI_applyDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,sqrid,sqDate,timeId,state,startTime,endTime,Describle,sqrName,sqrsm,by1 ");
			strSql.Append(" FROM BUSI_applyDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BUSI_applyDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from BUSI_applyDetail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BUSI_applyDetail";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

