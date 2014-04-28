using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface IMessage : IMessage<Identifier, byte[]>
	{
		/// <summary>
		/// Gets the type of the message.
		/// </summary>
		/// <value>The type of the message.</value>
		MessageType MessageType { get; }

		/// <summary>
		/// Gets the type of the technology.
		/// </summary>
		/// <value>The type of the technology.</value>
		TechnologyType TechnologyType { get; }

		/// <summary>
		/// Gets the length of the payload.
		/// </summary>
		/// <value>The length of the payload.</value>
		ushort PayloadLength { get; }

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		ClassId ClassId { get; }

		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		/// <value>The command identifier.</value>
		byte CommandId { get; }

		/// <summary>
		/// Gets the payload.
		/// </summary>
		/// <value>The payload.</value>
		byte[] Payload { get; }

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		string LogText { get; }
	}
}
