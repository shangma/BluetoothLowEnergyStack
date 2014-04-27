using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.Hardware
{
	abstract class HardwareCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HardwareCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected HardwareCommand(byte commandId)
			: base(ClassId.Hardware, commandId)
		{
		}
	}

	abstract class HardwareResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HardwareResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected HardwareResponse(byte commandId)
			: base(ClassId.Hardware, commandId)
		{
		}
	}

	abstract class HardwareCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : HardwareResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HardwareCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected HardwareCommandWithResponse(byte commandId)
			: base(ClassId.Hardware, commandId)
		{
		}
	}

	abstract class HardwareEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HardwareEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected HardwareEvent(byte commandId)
			: base(ClassId.Hardware, commandId)
		{
		}
	}
}
