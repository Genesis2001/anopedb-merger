// -----------------------------------------------------------------------------
//  <copyright file="AnopeDbFixture.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace AnopeMerge.UnitTests
{
	using System;
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

		[Test]
		public void Load_FromStreamWithSingleBotInfo_ShouldContainSingleBotInfoObjectWithMetaDataAttached()
		{
			var stream = Resources.BotInfoSingularTextStream.ToStream();

			SUT.Load(stream);

			Assert.That(SUT.BotServ.Count, Is.EqualTo(1));

			var bot = SUT.BotServ[0];

			Assert.That(bot, Is.Not.Null);
			Assert.That(bot.Id, Is.EqualTo(1));
			Assert.That(bot.Meta, Is.Not.Empty);
		}

		[Test]
		public void AnopeObjectToString_LoadFromStreamWithSingleBot_ShouldOutputSameAsInput()
		{
			var expected = Resources.BotInfoSingularTextStream;
			var stream = expected.ToStream();
			SUT.Load(stream);
			
			Assert.That(SUT.BotServ.Count, Is.EqualTo(1));
			
			var bot = SUT.BotServ[0];
			Assert.That(bot, Is.Not.Null);

			var actual = bot.ToString();
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Load_FromStream_ShouldRecognizeNickCoreAsNickServEntries()
		{
			var stream = Resources.NickCoreMultiTextStream.ToStream();

			SUT.Load(stream);

			Assert.That(SUT.NickServ.Count, Is.EqualTo(3));
		}
	}

	// ReSharper enable InconsistentNaming
	// ReSharper enable PossibleNullReferenceException
}
