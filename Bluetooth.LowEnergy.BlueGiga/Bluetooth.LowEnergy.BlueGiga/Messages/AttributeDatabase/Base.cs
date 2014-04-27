using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeDatabase
{
	abstract class AttributeDatabaseCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeDatabaseCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeDatabaseCommand(byte commandId)
			: base(ClassId.AttributeDatabase, commandId)
		{
		}
	}

	abstract class AttributeDatabaseResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeDatabaseResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeDatabaseResponse(byte commandId)
			: base(ClassId.AttributeDatabase, commandId)
		{
		}
	}

	abstract class AttributeDatabaseCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : AttributeDatabaseResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeDatabaseCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeDatabaseCommandWithResponse(byte commandId)
			: base(ClassId.AttributeDatabase, commandId)
		{
		}
	}

	abstract class AttributeDatabaseEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeDatabaseEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeDatabaseEvent(byte commandId)
			: base(ClassId.AttributeDatabase, commandId)
		{
		}
	}
}
