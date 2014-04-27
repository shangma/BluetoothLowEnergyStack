namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class Response : Message, IResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Response"/> class.
		/// </summary>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The command identifier.</param>
		protected Response(ClassId classId, byte commandId) 
			: base(MessageType.Response, classId, commandId)
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
