namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	sealed class ProcedureCompletedEvent : AttributeClientEvent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProcedureCompletedEvent"/> class.
		/// </summary>
		public ProcedureCompletedEvent() 
			: base(0x01)
		{
		}

		/// <summary>
		/// Gets the result.
		/// </summary>
		/// <value>The result.</value>
		public Result Result { get { return (Result) GetUnsignedShortFromPayload(1); } }

		/// <summary>
		/// Gets the characteristic handle.
		/// </summary>
		/// <value>The characteristic handle.</value>
		public ushort CharacteristicHandle { get { return GetUnsignedShortFromPayload(3); } }

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get
			{
				return string.Format("{0} Result={1} CharacteristicHandle={2:X4}", base.LogText, Result, CharacteristicHandle);
			}
		}
	}
}
