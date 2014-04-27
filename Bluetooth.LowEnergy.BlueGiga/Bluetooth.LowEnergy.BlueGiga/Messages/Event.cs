namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class Event : Message, IEvent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Event"/> class.
		/// </summary>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The command identifier.</param>
		protected Event(ClassId classId, byte commandId) 
			: base(MessageType.Event, classId, commandId)
		{
		}

		/// <summary>
		/// Sets the store.
		/// </summary>
		/// <param name="store">The store.</param>
		public void SetStore(byte[] store)
		{
			Store = store;
		}
	}
}
