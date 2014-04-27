using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.SecurityManager
{
	abstract class SecurityManagerCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityManagerCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SecurityManagerCommand(byte commandId)
			: base(ClassId.SecurityManager, commandId)
		{
		}
	}

	abstract class SecurityManagerResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityManagerResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SecurityManagerResponse(byte commandId)
			: base(ClassId.SecurityManager, commandId)
		{
		}
	}

	abstract class SecurityManagerCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : SecurityManagerResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityManagerCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SecurityManagerCommandWithResponse(byte commandId)
			: base(ClassId.SecurityManager, commandId)
		{
		}
	}

	abstract class SecurityManagerEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityManagerEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SecurityManagerEvent(byte commandId)
			: base(ClassId.SecurityManager, commandId)
		{
		}
	}
}
