using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.System
{
	abstract class SystemCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SystemCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SystemCommand(byte commandId)
			: base(ClassId.System, commandId)
		{
		}
	}

	abstract class SystemResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SystemResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SystemResponse(byte commandId)
			: base(ClassId.System, commandId)
		{
		}
	}

	abstract class SystemCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : SystemResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SystemCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SystemCommandWithResponse(byte commandId)
			: base(ClassId.System, commandId)
		{
		}
	}

	abstract class SystemEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SystemEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected SystemEvent(byte commandId)
			: base(ClassId.System, commandId)
		{
		}
	}
}
