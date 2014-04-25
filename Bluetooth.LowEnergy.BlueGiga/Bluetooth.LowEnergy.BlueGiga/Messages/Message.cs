using System.Security.Cryptography.X509Certificates;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class Message : IMessage
	{
		private readonly Header _header = new Header();

		/// <summary>
		/// Initializes a new instance of the <see cref="Message" /> class.
		/// </summary>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The message identifier.</param>
		protected Message(MessageType messageType, ClassId classId, byte commandId)
		{
			_header.MessageType = messageType;
			_header.TechnologyType = TechnologyType.Bluetooth_4_0_Single_Mode;
			_header.ClassId = classId;
			_header.CommandId = commandId;
		}

		/// <summary>
		/// Gets the type of the message.
		/// </summary>
		/// <value>The type of the message.</value>
		public MessageType MessageType
		{
			get { return _header.MessageType; }
			set { _header.MessageType = value; }
		}

		/// <summary>
		/// Gets the type of the technology.
		/// </summary>
		/// <value>The type of the technology.</value>
		public TechnologyType TechnologyType
		{
			get { return _header.TechnologyType; }
			set { _header.TechnologyType = value; }
		}

		/// <summary>
		/// Gets the length of the payload.
		/// </summary>
		/// <value>The length of the payload.</value>
		public ushort PayloadLength
		{
			get { return _header.PayloadLength; }
			set { _header.PayloadLength = value; }
		}

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		public ClassId ClassId
		{
			get { return _header.ClassId; }
			set { _header.ClassId = value; }
		}

		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		/// <value>The command identifier.</value>
		public byte CommandId
		{
			get { return _header.CommandId; }
			set { _header.CommandId = value; }
		}

		public byte[] Payload { get; private set; }

	}
}
