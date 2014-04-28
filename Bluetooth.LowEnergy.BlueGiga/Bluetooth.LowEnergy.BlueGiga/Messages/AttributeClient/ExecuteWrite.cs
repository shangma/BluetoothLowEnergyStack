namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	sealed class ExecuteWriteCommandWithResponse : AttributeClientCommandWithResponse<ExecuteWriteResponse>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteWriteCommandWithResponse"/> class.
		/// </summary>
		public ExecuteWriteCommandWithResponse() 
			: base(0x0a)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ExecuteWriteResponse"/> is commit.
		/// </summary>
		/// <value><c>true</c> if commit; otherwise, <c>false</c>.</value>
		public bool Commit
		{
			get { return GetBooleanFromPayload(1); }
			set { SetBooleanInPayload(1, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get { return string.Format("{0} Commit={1}", base.LogText, Commit); }
		}
	}

	sealed class ExecuteWriteResponse : AttributeClientResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExecuteWriteResponse"/> class.
		/// </summary>
		public ExecuteWriteResponse() 
			: base(0x0a)
		{
		}
	}
}
