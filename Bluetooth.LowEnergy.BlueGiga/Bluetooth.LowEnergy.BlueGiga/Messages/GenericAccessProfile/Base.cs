using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.GenericAccessProfile
{
	abstract class GenericAccessProfileCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericAccessProfileCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected GenericAccessProfileCommand(byte commandId)
			: base(ClassId.GenericAccessProfile, commandId)
		{
		}
	}

	abstract class GenericAccessProfileResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericAccessProfileResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected GenericAccessProfileResponse(byte commandId)
			: base(ClassId.GenericAccessProfile, commandId)
		{
		}
	}

	abstract class GenericAccessProfileCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : GenericAccessProfileResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericAccessProfileCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected GenericAccessProfileCommandWithResponse(byte commandId)
			: base(ClassId.GenericAccessProfile, commandId)
		{
		}
	}

	abstract class GenericAccessProfileEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericAccessProfileEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected GenericAccessProfileEvent(byte commandId)
			: base(ClassId.GenericAccessProfile, commandId)
		{
		}
	}
}
