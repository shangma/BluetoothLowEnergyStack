using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	abstract class AttributeClientCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientCommand(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}

		/// <summary>
		/// Gets or sets the connection handle.
		/// </summary>
		/// <value>The connection handle.</value>
		public byte ConnectionHandle
		{
			get { return GetByteFromPayload(0); }
			set { SetByteFromPayload(0, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get { return string.Format("{0} ConnectionHandle={1:X2}", base.LogText, ConnectionHandle); }
		}
	}

	abstract class AttributeClientResponse : Response
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientResponse"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientResponse(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}

		/// <summary>
		/// Gets the connection handle.
		/// </summary>
		/// <value>The connection handle.</value>
		public byte ConnectionHandle
		{
			get { return GetByteFromPayload(0); }
		}

		/// <summary>
		/// Gets the result.
		/// </summary>
		/// <value>The result.</value>
		public Result Result
		{
			get { return (Result) GetUnsignedShortFromPayload(1); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get { return string.Format("{0} ConnectionHandle={1:X2} Result={2}", base.LogText, ConnectionHandle, Result); }
		}
	}

	abstract class AttributeClientCommandWithResponse<TResponse> : CommandWithResponse<TResponse>
		where TResponse : AttributeClientResponse, IResponse, IResponse<Identifier, byte[]>, IMessage,
			IMessage<Identifier, byte[]>, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientCommandWithResponse{TResponse}"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientCommandWithResponse(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}

		/// <summary>
		/// Gets or sets the connection handle.
		/// </summary>
		/// <value>The connection handle.</value>
		public byte ConnectionHandle
		{
			get { return GetByteFromPayload(0); }
			set { SetByteFromPayload(0, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get { return string.Format("{0} ConnectionHandle={1:X2}", base.LogText, ConnectionHandle); }
		}
	}

	abstract class AttributeClientEvent : Event
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientEvent"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientEvent(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}

		/// <summary>
		/// Gets or sets the connection handle.
		/// </summary>
		/// <value>The connection handle.</value>
		public byte ConnectionHandle
		{
			get { return GetByteFromPayload(0); }
			set { SetByteFromPayload(0, value); }
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public override string LogText
		{
			get { return string.Format("{0} ConnectionHandle={1:X2}", base.LogText, ConnectionHandle); }
		}
	}
}
