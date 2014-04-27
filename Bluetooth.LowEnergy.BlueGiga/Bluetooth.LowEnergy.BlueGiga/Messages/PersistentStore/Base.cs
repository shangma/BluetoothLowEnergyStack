using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.PersistentStore
{
	abstract class PersistentStoreCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PersistentStoreCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected PersistentStoreCommand(byte commandId)
			: base(ClassId.PersistentStore, commandId)
		{
		}
	}

	abstract class PersistentStoreResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PersistentStoreResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected PersistentStoreResponse(byte commandId)
			: base(ClassId.PersistentStore, commandId)
		{
		}
	}

	abstract class PersistentStoreCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : PersistentStoreResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PersistentStoreCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected PersistentStoreCommandWithResponse(byte commandId)
			: base(ClassId.PersistentStore, commandId)
		{
		}
	}

	abstract class PersistentStoreEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PersistentStoreEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected PersistentStoreEvent(byte commandId)
			: base(ClassId.PersistentStore, commandId)
		{
		}
	}
}
