// -----------------------------------------------------------------------------
//  <copyright file="AnopeDbFixture.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.UnitTests
{
	using Core;
	using Helpers;
	using NUnit.Framework;
	using Properties;

	// ReSharper disable InconsistentNaming
	// ReSharper disable PossibleNullReferenceException

	[TestFixture]
	public class AnopeDbFixture
	{
		[SetUp]
		public void AnopeDb_SetUp()
		{
			SUT = new AnopeDb();
		}

		private AnopeDb SUT;

		[Test]
		public void Load_FromStream_ShouldLoadListOfAnopeObjectsOfTypeBotInfo()
		{
			var stream = Resources.BotInfoTextStream.ToStream();

			SUT.Load(stream);

			Assert.That(SUT.BotServ.Count, Is.EqualTo(3));
		}
	}

	// ReSharper enable InconsistentNaming
	// ReSharper enable PossibleNullReferenceException
}
