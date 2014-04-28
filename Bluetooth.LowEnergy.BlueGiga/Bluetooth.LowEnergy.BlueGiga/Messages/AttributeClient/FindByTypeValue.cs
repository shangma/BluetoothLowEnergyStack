namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	sealed class FindByTypeValueCommandWithResponse : AttributeClientCommandWithResponse<FindByTypeValueResponse>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FindByTypeValueCommandWithResponse"/> class.
		/// </summary>
		public FindByTypeValueCommandWithResponse() 
			: base(0x00)
		{
		}

		/// <summary>
		/// Gets or sets the first requested channel number.
		/// </summary>
		/// <value>The first requested channel number.</value>
		public ushort FirstRequestedChannelNumber
		{
			get { return GetUnsignedShortFromPayload(5); }
			set { SetUnsignedShortInPayload(5, value); }
		}

		/// <summary>
		/// Gets or sets the last requested channel number.
		/// </summary>
		/// <value>The last requested channel number.</value>
		public ushort LastRequestedChannelNumber
		{
			get { return GetUnsignedShortFromPayload(7); }
			set { SetUnsignedShortInPayload(7, value); }
		}

		/// <summary>
		/// Gets or sets the UUID to find.
		/// </summary>
		/// <value>The UUID to find.</value>
		public Uuid UuidToFind
		{
			get { return GetUuidFromPayload(9); }
			set {  SetUuidInPayload(9, value);}
		}

		/// <summary>
		/// Gets or sets the attribute value to find.
		/// </summary>
		/// <value>The attribute value to find.</value>
		public byte[] AttributeValueToFind
		{
			get { return GetTailByteArrayFromPayload(11); }
			set { SetTailByteArrayInPayload(11, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get
			{
				return
					string.Format(
						"{0} FirstRequestedChannelNumber={1:X4} LastRequestedChannelNumber={2:X4} UuidToFind={3} AttributeValueToFind={4}",
						base.LogText,
						FirstRequestedChannelNumber,
						LastRequestedChannelNumber,
						UuidToFind,
						AttributeValueToFind);
			}
		}
	}

	sealed class FindByTypeValueResponse : AttributeClientResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FindByTypeValueResponse"/> class.
		/// </summary>
		public FindByTypeValueResponse() 
			: base(0x00)
		{
		}
	}
}
