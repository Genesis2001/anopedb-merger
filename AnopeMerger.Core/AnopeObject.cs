namespace AnopeMerge.Core
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

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
	}
}