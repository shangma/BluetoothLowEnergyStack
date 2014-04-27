using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	abstract class AttributeClientCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientCommand(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}
	}

	abstract class AttributeClientResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientResponse(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}
	}

	abstract class AttributeClientCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : AttributeClientResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientCommandWithResponse(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}
	}

	abstract class AttributeClientEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientEvent(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}
	}
}
