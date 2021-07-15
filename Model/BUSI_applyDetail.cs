using System;
namespace Vline.Model
{
	/// <summary>
	/// BUSI_applyDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BUSI_applyDetail
	{
		public BUSI_applyDetail()
		{}
		#region Model
		private int _id;
		private int? _sqrid;
		private DateTime? _sqdate;
		private int? _timeid;
		private string _state;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _describle;
		private string _sqrname;
		private string _sqrsm;
		private string _by1;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sqrid
		{
			set{ _sqrid=value;}
			get{return _sqrid;}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime? sqDate
		{
			set{ _sqdate=value;}
			get{return _sqdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? timeId
		{
			set{ _timeid=value;}
			get{return _timeid;}
		}
		/// <summary>
		/// 状态  待审核 审核通过 不通过
		/// </summary>
		public string state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? startTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? endTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Describle
		{
			set{ _describle=value;}
			get{return _describle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sqrName
		{
			set{ _sqrname=value;}
			get{return _sqrname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sqrsm
		{
			set{ _sqrsm=value;}
			get{return _sqrsm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string by1
		{
			set{ _by1=value;}
			get{return _by1;}
		}
		#endregion Model

	}
}

