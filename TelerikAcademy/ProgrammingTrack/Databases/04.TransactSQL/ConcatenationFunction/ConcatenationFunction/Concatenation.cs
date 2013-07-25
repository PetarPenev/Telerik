using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;

namespace ConcatenationFunction
{
    [Serializable]
    [SqlUserDefinedAggregate(
        Format.UserDefined,
        IsInvariantToNulls=true,
        IsInvariantToDuplicates=false,
        IsInvariantToOrder=false,
        MaxByteSize = -1
        )]
    public class Concatenation : IBinarySerialize
    {
        private StringBuilder result;

        public StringBuilder Result { get; private set; }

        private bool isNull;

        private string separator;

        public void Init()
        {
            this.Result = new StringBuilder();
            this.isNull = true;
            this.separator = ", ";
        }

        public void Accumulate(SqlString value)
        {
            if (!value.IsNull)
            {
                this.isNull = false;
            }

            this.Result.Append(value.Value);
            this.Result.Append(this.separator);
        }

        public void Merge(Concatenation group)
        {
            this.Result.Append(group.Result);
        }

        public SqlString Terminate()
        {
            if (this.isNull)
            {
                return new SqlString("No strings in the sequence");
            }

            return new SqlString(this.Result.ToString());
        }

        public void Read(BinaryReader reader)
        {
            this.Result = new StringBuilder(reader.ReadString());
            if (this.Result.Length > 0)
            {
                this.isNull = false;
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.Result.ToString());
        }
    }
}