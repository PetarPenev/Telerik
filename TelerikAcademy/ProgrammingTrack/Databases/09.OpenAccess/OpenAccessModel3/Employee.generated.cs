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
	[Table("Employees")]
	[ConcurrencyControl(OptimisticConcurrencyControlStrategy.Changed)]
	[KeyGenerator(KeyGenerator.Autoinc)]
	[Serializable()]
	public partial class Employee : NotificationObject
	{
		private int _employeeID;
		[Column("EmployeeID", OpenAccessType = OpenAccessType.Int32, IsBackendCalculated = true, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "int")]
		[Storage("_employeeID")]
		public virtual int EmployeeID 
		{ 
		    get
		    {
		        return this._employeeID;
		    }
		    set
		    {
				if (this._employeeID == value)
				{
					return;
				}
		
		        this._employeeID = value;
				this.RaisePropertyChanged("_employeeID");
		    }
		}
		
		private string _lastName;
		[Column("LastName", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 20, Scale = 0, SqlType = "nvarchar")]
		[Storage("_lastName")]
		public virtual string LastName 
		{ 
		    get
		    {
		        return this._lastName;
		    }
		    set
		    {
				if (this._lastName == value)
				{
					return;
				}
		
		        this._lastName = value;
				this.RaisePropertyChanged("_lastName");
		    }
		}
		
		private string _firstName;
		[Column("FirstName", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, Length = 10, Scale = 0, SqlType = "nvarchar")]
		[Storage("_firstName")]
		public virtual string FirstName 
		{ 
		    get
		    {
		        return this._firstName;
		    }
		    set
		    {
				if (this._firstName == value)
				{
					return;
				}
		
		        this._firstName = value;
				this.RaisePropertyChanged("_firstName");
		    }
		}
		
		private string _title;
		[Column("Title", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 30, Scale = 0, SqlType = "nvarchar")]
		[Storage("_title")]
		public virtual string Title 
		{ 
		    get
		    {
		        return this._title;
		    }
		    set
		    {
				if (this._title == value)
				{
					return;
				}
		
		        this._title = value;
				this.RaisePropertyChanged("_title");
		    }
		}
		
		private string _titleOfCourtesy;
		[Column("TitleOfCourtesy", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 25, Scale = 0, SqlType = "nvarchar")]
		[Storage("_titleOfCourtesy")]
		public virtual string TitleOfCourtesy 
		{ 
		    get
		    {
		        return this._titleOfCourtesy;
		    }
		    set
		    {
				if (this._titleOfCourtesy == value)
				{
					return;
				}
		
		        this._titleOfCourtesy = value;
				this.RaisePropertyChanged("_titleOfCourtesy");
		    }
		}
		
		private DateTime? _birthDate;
		[Column("BirthDate", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_birthDate")]
		public virtual DateTime? BirthDate 
		{ 
		    get
		    {
		        return this._birthDate;
		    }
		    set
		    {
				if (this._birthDate == value)
				{
					return;
				}
		
		        this._birthDate = value;
				this.RaisePropertyChanged("_birthDate");
		    }
		}
		
		private DateTime? _hireDate;
		[Column("HireDate", OpenAccessType = OpenAccessType.DateTime, IsNullable = true, Length = 0, Scale = 0, SqlType = "datetime")]
		[Storage("_hireDate")]
		public virtual DateTime? HireDate 
		{ 
		    get
		    {
		        return this._hireDate;
		    }
		    set
		    {
				if (this._hireDate == value)
				{
					return;
				}
		
		        this._hireDate = value;
				this.RaisePropertyChanged("_hireDate");
		    }
		}
		
		private string _address;
		[Column("Address", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 60, Scale = 0, SqlType = "nvarchar")]
		[Storage("_address")]
		public virtual string Address 
		{ 
		    get
		    {
		        return this._address;
		    }
		    set
		    {
				if (this._address == value)
				{
					return;
				}
		
		        this._address = value;
				this.RaisePropertyChanged("_address");
		    }
		}
		
		private string _city;
		[Column("City", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 15, Scale = 0, SqlType = "nvarchar")]
		[Storage("_city")]
		public virtual string City 
		{ 
		    get
		    {
		        return this._city;
		    }
		    set
		    {
				if (this._city == value)
				{
					return;
				}
		
		        this._city = value;
				this.RaisePropertyChanged("_city");
		    }
		}
		
		private string _region;
		[Column("Region", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 15, Scale = 0, SqlType = "nvarchar")]
		[Storage("_region")]
		public virtual string Region 
		{ 
		    get
		    {
		        return this._region;
		    }
		    set
		    {
				if (this._region == value)
				{
					return;
				}
		
		        this._region = value;
				this.RaisePropertyChanged("_region");
		    }
		}
		
		private string _postalCode;
		[Column("PostalCode", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 10, Scale = 0, SqlType = "nvarchar")]
		[Storage("_postalCode")]
		public virtual string PostalCode 
		{ 
		    get
		    {
		        return this._postalCode;
		    }
		    set
		    {
				if (this._postalCode == value)
				{
					return;
				}
		
		        this._postalCode = value;
				this.RaisePropertyChanged("_postalCode");
		    }
		}
		
		private string _country;
		[Column("Country", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 15, Scale = 0, SqlType = "nvarchar")]
		[Storage("_country")]
		public virtual string Country 
		{ 
		    get
		    {
		        return this._country;
		    }
		    set
		    {
				if (this._country == value)
				{
					return;
				}
		
		        this._country = value;
				this.RaisePropertyChanged("_country");
		    }
		}
		
		private string _homePhone;
		[Column("HomePhone", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 24, Scale = 0, SqlType = "nvarchar")]
		[Storage("_homePhone")]
		public virtual string HomePhone 
		{ 
		    get
		    {
		        return this._homePhone;
		    }
		    set
		    {
				if (this._homePhone == value)
				{
					return;
				}
		
		        this._homePhone = value;
				this.RaisePropertyChanged("_homePhone");
		    }
		}
		
		private string _extension;
		[Column("Extension", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 4, Scale = 0, SqlType = "nvarchar")]
		[Storage("_extension")]
		public virtual string Extension 
		{ 
		    get
		    {
		        return this._extension;
		    }
		    set
		    {
				if (this._extension == value)
				{
					return;
				}
		
		        this._extension = value;
				this.RaisePropertyChanged("_extension");
		    }
		}
		
		private byte[] _photo;
		[Column("Photo", OpenAccessType = OpenAccessType.LongVarBinary, IsNullable = true, Length = 0, Scale = 0, SqlType = "image")]
		[Storage("_photo")]
		public virtual byte[] Photo 
		{ 
		    get
		    {
		        return this._photo;
		    }
		    set
		    {
				if (this._photo == value)
				{
					return;
				}
		
		        this._photo = value;
				this.RaisePropertyChanged("_photo");
		    }
		}
		
		private string _notes;
		[Column("Notes", OpenAccessType = OpenAccessType.UnicodeStringInfiniteLength, IsNullable = true, Length = 0, Scale = 0, SqlType = "ntext")]
		[Storage("_notes")]
		public virtual string Notes 
		{ 
		    get
		    {
		        return this._notes;
		    }
		    set
		    {
				if (this._notes == value)
				{
					return;
				}
		
		        this._notes = value;
				this.RaisePropertyChanged("_notes");
		    }
		}
		
		private int? _reportsTo;
		[Column("ReportsTo", OpenAccessType = OpenAccessType.Int32, IsNullable = true, Length = 0, Scale = 0, SqlType = "int")]
		[Storage("_reportsTo")]
		public virtual int? ReportsTo 
		{ 
		    get
		    {
		        return this._reportsTo;
		    }
		    set
		    {
				if (this._reportsTo == value)
				{
					return;
				}
		
		        this._reportsTo = value;
				this.RaisePropertyChanged("_reportsTo");
		    }
		}
		
		private string _photoPath;
		[Column("PhotoPath", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsNullable = true, Length = 255, Scale = 0, SqlType = "nvarchar")]
		[Storage("_photoPath")]
		public virtual string PhotoPath 
		{ 
		    get
		    {
		        return this._photoPath;
		    }
		    set
		    {
				if (this._photoPath == value)
				{
					return;
				}
		
		        this._photoPath = value;
				this.RaisePropertyChanged("_photoPath");
		    }
		}
		
		private Employee _employee1;
		[ForeignKeyAssociation(ConstraintName = "FK_Employees_Employees", SharedFields = "ReportsTo", TargetFields = "EmployeeID")]
		[Storage("_employee1")]
		public virtual Employee Employee1 
		{ 
		    get
		    {
		        return this._employee1;
		    }
		    set
		    {
				if (this._employee1 == value)
				{
					return;
				}
		
		        this._employee1 = value;
				this.RaisePropertyChanged("_employee1");
		    }
		}
		
		private IList<Territory> _territories = new List<Territory>();
		[JoinTableAssociation(TableName = "EmployeeTerritories", OwnerColumns = "EmployeeID", TargetColumns = "TerritoryID", SourceConstraint = "FK_EmployeeTerritories_Employees", TargetConstraint = "FK_EmployeeTerritories_Territories")]
		[Column("EmployeeID", OpenAccessType = OpenAccessType.Int32, IsPrimaryKey = true, Length = 0, Scale = 0, SqlType = "int")]
		[Column("TerritoryID", OpenAccessType = OpenAccessType.UnicodeStringVariableLength, IsPrimaryKey = true, Length = 20, Scale = 0, SqlType = "nvarchar")]
		[Storage("_territories")]
		public virtual IList<Territory> Territories 
		{ 
		    get
		    {
		        return this._territories;
		    }
		}
		
		private IList<Order> _orders = new List<Order>();
		[Collection(InverseProperty = "Employee")]
		[Storage("_orders")]
		public virtual IList<Order> Orders 
		{ 
		    get
		    {
		        return this._orders;
		    }
		}
		
		private IList<Employee> _employees = new List<Employee>();
		[Collection(InverseProperty = "Employee1")]
		[Storage("_employees")]
		public virtual IList<Employee> Employees 
		{ 
		    get
		    {
		        return this._employees;
		    }
		}
		
	}
}