using System;
namespace Vline.Model
{
	/// <summary>
	/// DIC_TIME:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DIC_TIME
	{
		public DIC_TIME()
		{}
		#region Model
		private int _id;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _describle;
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
		public string by1
		{
			set{ _by1=value;}
			get{return _by1;}
		}
		#endregion Model

	}
}

