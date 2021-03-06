#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qqqqqqqq
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CAFE.net")]
	public partial class MyDbContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTHUCDON(THUCDON instance);
    partial void UpdateTHUCDON(THUCDON instance);
    partial void DeleteTHUCDON(THUCDON instance);
    partial void InsertNHANVIEN(NHANVIEN instance);
    partial void UpdateNHANVIEN(NHANVIEN instance);
    partial void DeleteNHANVIEN(NHANVIEN instance);
    #endregion
		
		public MyDbContextDataContext() : 
				base(global::qqqqqqqq.Properties.Settings.Default.CAFE_netConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public MyDbContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDbContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDbContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDbContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<THUCDON> THUCDONs
		{
			get
			{
				return this.GetTable<THUCDON>();
			}
		}
		
		public System.Data.Linq.Table<NHANVIEN> NHANVIENs
		{
			get
			{
				return this.GetTable<NHANVIEN>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.THUCDON")]
	public partial class THUCDON : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MATD;
		
		private int _MALOAITD;
		
		private string _TENTD;
		
		private System.Nullable<int> _GIA;
		
		private System.Data.Linq.Binary _anh;
		
		private System.Nullable<bool> _TRANG_THAI;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMATDChanging(int value);
    partial void OnMATDChanged();
    partial void OnMALOAITDChanging(int value);
    partial void OnMALOAITDChanged();
    partial void OnTENTDChanging(string value);
    partial void OnTENTDChanged();
    partial void OnGIAChanging(System.Nullable<int> value);
    partial void OnGIAChanged();
    partial void OnanhChanging(System.Data.Linq.Binary value);
    partial void OnanhChanged();
    partial void OnTRANG_THAIChanging(System.Nullable<bool> value);
    partial void OnTRANG_THAIChanged();
    #endregion
		
		public THUCDON()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MATD", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MATD
		{
			get
			{
				return this._MATD;
			}
			set
			{
				if ((this._MATD != value))
				{
					this.OnMATDChanging(value);
					this.SendPropertyChanging();
					this._MATD = value;
					this.SendPropertyChanged("MATD");
					this.OnMATDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MALOAITD", DbType="Int NOT NULL")]
		public int MALOAITD
		{
			get
			{
				return this._MALOAITD;
			}
			set
			{
				if ((this._MALOAITD != value))
				{
					this.OnMALOAITDChanging(value);
					this.SendPropertyChanging();
					this._MALOAITD = value;
					this.SendPropertyChanged("MALOAITD");
					this.OnMALOAITDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENTD", DbType="NVarChar(50)")]
		public string TENTD
		{
			get
			{
				return this._TENTD;
			}
			set
			{
				if ((this._TENTD != value))
				{
					this.OnTENTDChanging(value);
					this.SendPropertyChanging();
					this._TENTD = value;
					this.SendPropertyChanged("TENTD");
					this.OnTENTDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIA", DbType="Int")]
		public System.Nullable<int> GIA
		{
			get
			{
				return this._GIA;
			}
			set
			{
				if ((this._GIA != value))
				{
					this.OnGIAChanging(value);
					this.SendPropertyChanging();
					this._GIA = value;
					this.SendPropertyChanged("GIA");
					this.OnGIAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_anh", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary anh
		{
			get
			{
				return this._anh;
			}
			set
			{
				if ((this._anh != value))
				{
					this.OnanhChanging(value);
					this.SendPropertyChanging();
					this._anh = value;
					this.SendPropertyChanged("anh");
					this.OnanhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRANG_THAI", DbType="Bit")]
		public System.Nullable<bool> TRANG_THAI
		{
			get
			{
				return this._TRANG_THAI;
			}
			set
			{
				if ((this._TRANG_THAI != value))
				{
					this.OnTRANG_THAIChanging(value);
					this.SendPropertyChanging();
					this._TRANG_THAI = value;
					this.SendPropertyChanged("TRANG_THAI");
					this.OnTRANG_THAIChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NHANVIEN")]
	public partial class NHANVIEN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CMND;
		
		private string _TENNV;
		
		private string _DIACHI;
		
		private System.Nullable<bool> _GIOITINH;
		
		private string _SDT;
		
		private string _GMAIL;
		
		private int _MACHUCVU;
		
		private System.Nullable<bool> _TRANGTHAI;
		
		private System.Data.Linq.Binary _ANH;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCMNDChanging(string value);
    partial void OnCMNDChanged();
    partial void OnTENNVChanging(string value);
    partial void OnTENNVChanged();
    partial void OnDIACHIChanging(string value);
    partial void OnDIACHIChanged();
    partial void OnGIOITINHChanging(System.Nullable<bool> value);
    partial void OnGIOITINHChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    partial void OnGMAILChanging(string value);
    partial void OnGMAILChanged();
    partial void OnMACHUCVUChanging(int value);
    partial void OnMACHUCVUChanged();
    partial void OnTRANGTHAIChanging(System.Nullable<bool> value);
    partial void OnTRANGTHAIChanged();
    partial void OnANHChanging(System.Data.Linq.Binary value);
    partial void OnANHChanged();
    #endregion
		
		public NHANVIEN()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CMND", DbType="NVarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CMND
		{
			get
			{
				return this._CMND;
			}
			set
			{
				if ((this._CMND != value))
				{
					this.OnCMNDChanging(value);
					this.SendPropertyChanging();
					this._CMND = value;
					this.SendPropertyChanged("CMND");
					this.OnCMNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENNV", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TENNV
		{
			get
			{
				return this._TENNV;
			}
			set
			{
				if ((this._TENNV != value))
				{
					this.OnTENNVChanging(value);
					this.SendPropertyChanging();
					this._TENNV = value;
					this.SendPropertyChanged("TENNV");
					this.OnTENNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIACHI", DbType="NVarChar(50)")]
		public string DIACHI
		{
			get
			{
				return this._DIACHI;
			}
			set
			{
				if ((this._DIACHI != value))
				{
					this.OnDIACHIChanging(value);
					this.SendPropertyChanging();
					this._DIACHI = value;
					this.SendPropertyChanged("DIACHI");
					this.OnDIACHIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIOITINH", DbType="Bit")]
		public System.Nullable<bool> GIOITINH
		{
			get
			{
				return this._GIOITINH;
			}
			set
			{
				if ((this._GIOITINH != value))
				{
					this.OnGIOITINHChanging(value);
					this.SendPropertyChanging();
					this._GIOITINH = value;
					this.SendPropertyChanged("GIOITINH");
					this.OnGIOITINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="NVarChar(50)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GMAIL", DbType="NVarChar(100)")]
		public string GMAIL
		{
			get
			{
				return this._GMAIL;
			}
			set
			{
				if ((this._GMAIL != value))
				{
					this.OnGMAILChanging(value);
					this.SendPropertyChanging();
					this._GMAIL = value;
					this.SendPropertyChanged("GMAIL");
					this.OnGMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MACHUCVU", DbType="Int NOT NULL")]
		public int MACHUCVU
		{
			get
			{
				return this._MACHUCVU;
			}
			set
			{
				if ((this._MACHUCVU != value))
				{
					this.OnMACHUCVUChanging(value);
					this.SendPropertyChanging();
					this._MACHUCVU = value;
					this.SendPropertyChanged("MACHUCVU");
					this.OnMACHUCVUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRANGTHAI", DbType="Bit")]
		public System.Nullable<bool> TRANGTHAI
		{
			get
			{
				return this._TRANGTHAI;
			}
			set
			{
				if ((this._TRANGTHAI != value))
				{
					this.OnTRANGTHAIChanging(value);
					this.SendPropertyChanging();
					this._TRANGTHAI = value;
					this.SendPropertyChanged("TRANGTHAI");
					this.OnTRANGTHAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANH", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary ANH
		{
			get
			{
				return this._ANH;
			}
			set
			{
				if ((this._ANH != value))
				{
					this.OnANHChanging(value);
					this.SendPropertyChanging();
					this._ANH = value;
					this.SendPropertyChanged("ANH");
					this.OnANHChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
