#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Framework;
using OpenAccessModel3;


namespace OpenAccessModel3	
{
	[Table("Shippers")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	[Serializable()]
	public partial class Shipper : NotificationObject
	{
		private int _shipperID;
		[Column("ShipperID", OpenAccessType = OpenAccessType.Int32, IsBackendCalculated = true, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "int")]
		[Storage("_shipperID")]
		public virtual int ShipperID 
		{ 
		    get
		    {
		        return this._shipperID;
		    }
		    set
		    {
				if (this._shipperID == value)
				{
					return;
				}
		
		        this._shipperID = value;
				this.RaisePropertyChanged("_shipperID");
		    }
		}
		
		private string _companyName;
		[Column("CompanyName", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 40, Scale = 0, SqlType = "nvarchar")]
		[Storage("_companyName")]
		public virtual string CompanyName 
		{ 
		    get
		    {
		        return this._companyName;
		    }
		    set
		    {
				if (this._companyName == value)
				{
					return;
				}
		
		        this._companyName = value;
				this.RaisePropertyChanged("_companyName");
		    }
		}
		
		private string _phone;
		[Column("Phone", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 24, Scale = 0, SqlType = "nvarchar")]
		[Storage("_phone")]
		public virtual string Phone 
		{ 
		    get
		    {
		        return this._phone;
		    }
		    set
		    {
				if (this._phone == value)
				{
					return;
				}
		
		        this._phone = value;
				this.RaisePropertyChanged("_phone");
		    }
		}
		
		private IList<Order> _orders = new List<Order>();
		[Collection(InverseProperty = "Shipper")]
		[Storage("_orders")]
		public virtual IList<Order> Orders 
		{ 
		    get
		    {
		        return this._orders;
		    }
		}
		
	}
}
