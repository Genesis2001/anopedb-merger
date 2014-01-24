// -----------------------------------------------------------------------------
//  <copyright file="StreamHelpers.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.UnitTests.Helpers
{
	using System.IO;
	using System.Text;

	public static class StreamHelpers
	{
		public static Stream ToStream(this string source, Encoding encoding = null)
		{
			var stream = new MemoryStream();
			var buf = encoding == null ? Encoding.Default.GetBytes(source) : encoding.GetBytes(source);

			stream.Write(buf, 0, buf.Length);
			stream.Position = 0;

			return stream;
		}
	}
}
