namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	sealed class AttributeWriteCommandWithResponse : AttributeClientCommandWithResponse<AttributeWriteResponse>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeWriteCommandWithResponse"/> class.
		/// </summary>
		public AttributeWriteCommandWithResponse() 
			: base(0x05)
		{
		}

		/// <summary>
		/// Gets or sets the attribute handle.
		/// </summary>
		/// <value>The attribute handle.</value>
		public ushort AttributeHandle
		{
			get { return GetUnsignedShortFromPayload(5); }
			set { SetUnsignedShortInPayload(5, value); }
		}

		/// <summary>
		/// Gets or sets the attribute value.
		/// </summary>
		/// <value>The attribute value.</value>
		public byte[] AttributeValue
		{
			get { return GetTailByteArrayFromPayload(7); }
			set { SetTailByteArrayInPayload(7, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get
			{
				return string.Format("{0} AttributeHandle={1:X4} AttributeValue={2}", base.LogText, AttributeHandle, GetStringFromByteArray(AttributeValue));
			}
		}
	}

	sealed class AttributeWriteResponse : AttributeClientResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeWriteResponse"/> class.
		/// </summary>
		public AttributeWriteResponse() 
			: base(0x05)
		{
		}
	}
}
