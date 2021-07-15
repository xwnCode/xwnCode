using System;
namespace Vline.Model
{
	/// <summary>
	/// BUSI_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BUSI_User
	{
		public BUSI_User()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userzh;
		private string _password;
		private string _userno;
		private string _detail;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 登录账号
		/// </summary>
		public string UserZH
		{
			set{ _userzh=value;}
			get{return _userzh;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 用户编号或者说明
		/// </summary>
		public string UserNo
		{
			set{ _userno=value;}
			get{return _userno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		#endregion Model

	}
}

