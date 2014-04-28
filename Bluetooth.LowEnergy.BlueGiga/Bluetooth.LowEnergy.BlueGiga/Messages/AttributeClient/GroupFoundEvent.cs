namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	sealed class GroupFoundEvent : AttributeClientEvent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GroupFoundEvent"/> class.
		/// </summary>
		public GroupFoundEvent() 
			: base(0x02)
		{
		}

		/// <summary>
		/// Gets the starting handle.
		/// </summary>
		/// <value>The starting handle.</value>
		public ushort StartingHandle { get { return GetUnsignedShortFromPayload(1); } }

		/// <summary>
		/// Gets the ending handle.
		/// </summary>
		/// <value>The ending handle.</value>
		public ushort EndingHandle { get { return GetUnsignedShortFromPayload(3); } }

		/// <summary>
		/// Gets the UUID of service.
		/// </summary>
		/// <value>The UUID of service.</value>
		public Uuid UuidOfService { get { return GetUuidFromPayload(5); } }

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get
			{
				return string.Format("{0} StartingHandle={1:X4} EndingHandle={2:X4} UuidOfService={3}",
					base.LogText,
					StartingHandle,
					EndingHandle,
					UuidOfService);
			}
		}
	}
}
