using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.Connection
{
	abstract class ConnectionCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected ConnectionCommand(byte commandId)
			: base(ClassId.Connection, commandId)
		{
		}
	}

	abstract class ConnectionResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected ConnectionResponse(byte commandId)
			: base(ClassId.Connection, commandId)
		{
		}
	}

	abstract class ConnectionCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : ConnectionResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected ConnectionCommandWithResponse(byte commandId)
			: base(ClassId.Connection, commandId)
		{
		}
	}

	abstract class ConnectionEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected ConnectionEvent(byte commandId)
			: base(ClassId.Connection, commandId)
		{
		}
	}
}
