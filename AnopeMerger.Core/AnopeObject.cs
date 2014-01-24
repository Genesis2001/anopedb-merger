namespace AnopeMerge.Core
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.Text;

	[DataContract(Name = "OBJECT")]
	public class AnopeObject
	{
		public AnopeObject()
		{
			Meta = new Dictionary<string, string>();
		}

		[IgnoreDataMember]
		public string ObjectType { get; set; }

		[DataMember(Name = "ID")]
		public int Id { get; set; }

		[DataMember(Name = "DATA")]
		public IDictionary<string, string> Meta { get; private set; }

		#region Overrides of Object

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			var builder = new StringBuilder();

			builder.AppendFormat("OBJECT {0}\n", ObjectType);
			builder.AppendFormat("ID {0}\n", Id);

			foreach (var item in Meta)
			{
				builder.AppendFormat("DATA {0} {1}\n", item.Key, item.Value);
			}

			builder.Append("END");

			return builder.ToString();
		}

		#endregion
	}
}