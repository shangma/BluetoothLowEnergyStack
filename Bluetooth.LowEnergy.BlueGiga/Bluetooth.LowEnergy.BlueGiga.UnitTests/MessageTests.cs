using System;
using Bluetooth.LowEnergy.BlueGiga.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bluetooth.LowEnergy.BlueGiga.UnitTests
{
	[TestClass]
	public class MessageTests
	{
		[TestMethod]
		public void HeaderTest()
		{
			var header = new Header();
			var random = new Random();

			header.MessageType = MessageType.Command;
			Assert.IsTrue(header.MessageType == MessageType.Command);

			header.MessageType = MessageType.Event;
			Assert.IsTrue(header.MessageType == MessageType.Event);

			header.TechnologyType = TechnologyType.Wifi;
			Assert.IsTrue(header.TechnologyType == TechnologyType.Wifi);
			Assert.IsTrue(header.MessageType == MessageType.Event);

			header.TechnologyType = TechnologyType.Bluetooth_4_0_Single_Mode;
			Assert.IsTrue(header.TechnologyType == TechnologyType.Bluetooth_4_0_Single_Mode);
			Assert.IsTrue(header.MessageType == MessageType.Event);

			var payloadLength = (ushort)random.Next((1 << 11) - 1);
			header.PayloadLength = payloadLength;
			Assert.IsTrue(header.PayloadLength == payloadLength);
			Assert.IsTrue(header.TechnologyType == TechnologyType.Bluetooth_4_0_Single_Mode);
			Assert.IsTrue(header.MessageType == MessageType.Event);

			header.ClassId = ClassId.GeneralAccessProfile;
			Assert.IsTrue(header.ClassId == ClassId.GeneralAccessProfile);
			Assert.IsTrue(header.PayloadLength == payloadLength);
			Assert.IsTrue(header.TechnologyType == TechnologyType.Bluetooth_4_0_Single_Mode);
			Assert.IsTrue(header.MessageType == MessageType.Event);

			header.ClassId = ClassId.Connection;
			Assert.IsTrue(header.ClassId == ClassId.Connection);
			Assert.IsTrue(header.PayloadLength == payloadLength);
			Assert.IsTrue(header.TechnologyType == TechnologyType.Bluetooth_4_0_Single_Mode);
			Assert.IsTrue(header.MessageType == MessageType.Event);

			var commandId = (byte) random.Next(255);
			header.CommandId = commandId;
			Assert.IsTrue(header.CommandId == commandId);
			Assert.IsTrue(header.ClassId == ClassId.Connection);
			Assert.IsTrue(header.PayloadLength == payloadLength);
			Assert.IsTrue(header.TechnologyType == TechnologyType.Bluetooth_4_0_Single_Mode);
			Assert.IsTrue(header.MessageType == MessageType.Event);
		}
	}
}
