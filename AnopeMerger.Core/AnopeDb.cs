// -----------------------------------------------------------------------------
//  <copyright file="AnopeDb.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.Core
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;

	[Serializable]
	public class AnopeDb : IEnumerable<AnopeObject>
	{
		private IList<AnopeObject> list;

		private AnopeObject obj;

		public AnopeDb()
		{
			list = new List<AnopeObject>();
		}

		// TODO: NickAlias, ChannelInfo, ModeLock, ChanAccess, Memo, BadWord, SeenInfo, NSMiscData, DNSServer, ForbidData, AJoinEntry, Exception,
		
		public void Load(string path)
		{
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				Load(stream);
			}
		}

		public void Load(Stream stream)
		{
			using (stream)
			{
				using (var reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine().Trim();
						if (!string.IsNullOrEmpty(line))
						{
							OnDataRead(line);
						}
					}
				}
			}
		}

		public void Save(string path)
		{
		}

		/// <summary>
		/// Writes the DB out to the specified <see cref="T:System.IO.Stream" />.
		/// </summary>
		/// <param name="stream"></param>
		public void Save(Stream stream)
		{
			using (var writer = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
			{
				var max = list.Count - 1;
				for (var i = 0; i <= max; ++i)
				{
					var o = list[i];
					writer.Write(o);

					if (i != max)
					{
						writer.Write("\n");
					}
				}
			}
		}

		protected void OnDataRead(string line)
		{
			var tokens = line.Split(' ');
			
			if (line.StartsWith("OBJECT") && obj == null)
			{
				obj	= new AnopeObject();
				obj.ObjectType = tokens[1];
			}

			if (line.StartsWith("ID") && obj != null)
			{
				int id;
				if (Int32.TryParse(tokens[1], out id))
				{
					obj.Id = id;
				}
			}

			if (line.StartsWith("DATA") && obj != null)
			{
				if (tokens.Length > 2)
				{
					var value = line.Substring(line.IndexOf(tokens[1], StringComparison.Ordinal) + tokens[1].Length + 1);

					obj.Meta.Add(tokens[1], value);
				}
			}

			if (line.StartsWith("END") && obj != null)
			{
				list.Add(obj);
				obj = null;
			}
		}

		#region Implementation of IEnumerable

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<AnopeObject> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}
