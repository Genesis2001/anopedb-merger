namespace AnopeMerge.Core
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.Text;

	[DataContract(Name = "OBJECT")]
	public class AnopeObject : IEquatable<AnopeObject>
	{
		public static readonly IDictionary<String, String> NameMap = new Dictionary<string, string>
		                                                             {
			                                                             {"NickCore", "display"},
			                                                             {"BotInfo", "nick"},
																		 {"NickAlias", "nick"},
			                                                             {"ChanAccess", "ci"},
			                                                             {"SeenInfo", "nick"},
																		 {"ChannelInfo", "name"},
																		 {"ModeLock", "ci"},
		                                                             };

		public AnopeObject()
		{
			Meta = new Dictionary<string, string>();
		}

		[IgnoreDataMember]
		public string ObjectType { get; set; }

		[DataMember(Name = "ID")]
		public int Id { get; set; }

		[IgnoreDataMember]
		public string Name
		{
			get { return NameMap.ContainsKey(ObjectType) ? Meta[NameMap[ObjectType]] : string.Empty; }
		}

		[DataMember(Name = "DATA")]
		public IDictionary<string, string> Meta { get; private set; }

		#region Overrides of Object

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(AnopeObject other)
		{
			throw new NotImplementedException();
		}

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
