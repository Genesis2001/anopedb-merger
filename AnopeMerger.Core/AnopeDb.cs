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

	[Serializable]
	public class AnopeDb
	{
		public static readonly string[] BotInfo = {"nick", "user", "host", "realname", "created", "oper_only"};
		public static readonly string[] NickCore = {"display", "pass", "email", "language", "access"};
		public static readonly string[] Stats = {"maxusercnt", "maxusertime"};

		private Stream stream;
		private StreamReader reader;

		private AnopeObject obj;

		public AnopeDb()
		{
			BotServ = new List<AnopeObject>();
		}

		public IList<AnopeObject> BotServ { get; private set; }
		
		public void Load(string path)
		{
			using (stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				using (reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine().Trim();
						if (!string.IsNullOrEmpty(line))
						{
							OnDataRead(reader.ReadLine());
						}
					}
				}
			}
		}

		public void Load(Stream pStream)
		{
			using (stream = pStream)
			{
				using (reader = new StreamReader(stream))
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
					obj.Meta.Add(tokens[1], tokens[2]);
				}
			}

			if (line.StartsWith("END") && obj != null)
			{
				switch (obj.ObjectType)
				{
					case "BotInfo":
					{
						BotServ.Add(obj);
						obj = null;
					}
						break;
				}
			}
		}
	}
}
