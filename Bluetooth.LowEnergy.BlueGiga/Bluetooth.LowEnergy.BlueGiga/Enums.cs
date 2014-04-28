namespace Bluetooth.LowEnergy.BlueGiga
{
	/// <summary>
	/// Enum ClassId
	/// </summary>
	public enum ClassId : byte
	{
		/// <summary>
		/// Provides access to system functions
		/// </summary>
		System = 0x00,
		/// <summary>
		/// Provides access the persistence store (parameters)
		/// </summary>
		PersistentStore = 0x01,
		/// <summary>
		/// Provides access to local GATT database
		/// </summary>
		AttributeDatabase = 0x02,
		/// <summary>
		/// Provides access to connection management functions
		/// </summary>
		Connection = 0x03,
		/// <summary>
		/// Functions to access remote devices GATT database
		/// </summary>
		AttributeClient = 0x04,
		/// <summary>
		/// Bluetooth low energy security functions
		/// </summary>
		SecurityManager = 0x05,
		/// <summary>
		/// GAP functions
		/// </summary>
		GenericAccessProfile = 0x06,
		/// <summary>
		/// Provides access to hardware such as timers and ADC
		/// </summary>
		Hardware = 0x07
	}

	public enum MessageType : byte
	{
		/// <summary>
		/// Command from host to the stack
		/// </summary>
		Command = 0x00,
		/// <summary>
		/// Response from stack to the host
		/// </summary>
		Response = 0x00,
		/// <summary>
		/// Event from stack to the host
		/// </summary>
		Event = 0x80
	}

	public enum TechnologyType : byte
	{
		/// <summary>
		/// Bluetooth 4.0 low energy single mode
		/// </summary>
		Bluetooth_4_0_Single_Mode  = 0x00,
		/// <summary>
		/// 802.11
		/// </summary>
		Wifi = 0x01
	}

	public enum Result : ushort
	{
		/// <summary>
		/// No error, success.
		/// </summary>
		Success = 0x00,
		/// <summary>
		/// Command contained invalid parameter.
		/// </summary>
		InvalidParameter = 0x0180,
		/// <summary>
		/// Device is in wrong state to receive command.
		/// </summary>
		DeviceInWrongState = 0x0181,
		/// <summary>
		/// Device has run out of memory.
		/// </summary>
		OutOfMemory = 0x0182,
		/// <summary>
		/// Feature is not implemented.
		/// </summary>
		FeatureNotImplemented = 0x0183,
		/// <summary>
		/// Command was not recognized.
		/// </summary>
		CommandNotRecognized = 0x0184,
		/// <summary>
		/// Command or Procedure failed due to timeout.
		/// </summary>
		Timeout = 0x0185,
		/// <summary>
		/// Connection handle passed is to command is not a valid handle.
		/// </summary>
		NotConnected = 0x0186,
		/// <summary>
		/// Command would cause either underflow or overflow error.
		/// </summary>
		UndreflowOverflow = 0x0187,
		/// <summary>
		/// User attribute was accessed through API which is not supported.
		/// </summary>
		UserAttribute = 0x0188,
		/// <summary>
		/// Pairing or authentication failed due to incorrect results in the pairing or authentication procedure. 
		/// This could be due to an incorrect PIN or Link KeyToErase.
		/// </summary>
		AuthenticationFailure = 0x0205,
		/// <summary>
		/// Pairing failed because of missing PIN, or authentication failed because of missing KeyToErase.
		/// </summary>
		PinOrKeyMissing = 0x0206,
		/// <summary>
		/// Controller is out of memory.
		/// </summary>
		MemoryCapacityExceeded = 0x0207,
		/// <summary>
		/// Link supervision timeout has expired.
		/// </summary>
		ConnectionTimeout = 0x0208,
		/// <summary>
		/// Controller is at limit of connections it can support.
		/// </summary>
		ConnectionLimitExceeded = 0x0209,
		/// <summary>
		/// Command requested cannot be executed because the Controller is in a state where 
		/// it cannot process this command at this time.
		/// </summary>
		CommandDisallowed = 0x020C,
		/// <summary>
		/// Command contained invalid parameters.
		/// </summary>
		InvalidCommandParameters = 0x0212,
		/// <summary>
		/// User on the remote device terminated the connection.
		/// </summary>
		RemoteUserTerminatedConnection = 0x0213,
		/// <summary>
		/// Local device terminated the connection.
		/// </summary>
		ConnectionTerminatedByLocalHost = 0x0216,
		/// <summary>
		/// Connection terminated due to link-layer procedure timeout.
		/// </summary>
		LlResponseTimeout = 0x0222,
		/// <summary>
		/// Received link-layer control packet where instant was in the past.
		/// </summary>
		LlInstantPassed = 0x0228,
		/// <summary>
		/// Operation was rejected because the controller is busy and unable to process the request.
		/// </summary>
		ControllerBusy = 0x023A,
		/// <summary>
		/// Directed advertising completed without a connection being created.
		/// </summary>
		DirectAdvertisingTimeout = 0x023C,
		/// <summary>
		/// Connection was terminated because the Message Integrity Check (MIC) failed on a received packet.
		/// </summary>
		MicFailure = 0x023D,
		/// <summary>
		/// LL initiated a connection but the connection has failed to be established. 
		/// Controller did not receive any packets from remote end.
		/// </summary>
		ConnectionFailedToBeEstablished = 0x023E,
		/// <summary>
		/// The user input of passkey failed, for example, the user cancelled the operation.
		/// </summary>
		PasskeyEntryFailed = 0x0301,
		/// <summary>
		/// Out of Band data is not available for authentication.
		/// </summary>
		OobDataIsNOtAvailable = 0x0302,
		/// <summary>
		/// The pairing procedure cannot be performed as authentication requirements cannot be met due to 
		/// IO capabilities of one or both devices.
		/// </summary>
		AuthenticationRequirements = 0x0303,
		/// <summary>
		/// The confirm value does not match the calculated compare value.
		/// </summary>
		ConfirmValueFailed = 0x0304,
		/// <summary>
		/// Pairing is not supported by the device.
		/// </summary>
		PairingNotSupported = 0x0305,
		/// <summary>
		/// The resultant encryption key size is insufficient for the security requirements of this device.
		/// </summary>
		EncryptionKeySize = 0x0306,
		/// <summary>
		/// The SMP command received is not supported on this device.
		/// </summary>
		CommandNotSupported = 0x0307,
		/// <summary>
		/// Pairing failed due to an unspecified reason.
		/// </summary>
		UnspecifiedReason = 0x0308,
		/// <summary>
		/// Pairing or authentication procedure is disallowed because too little time has elapsed since last pairing 
		/// request or security request.
		/// </summary>
		RepeatedAttempts = 0x0309,
		/// <summary>
		/// The Invalid Parameters error code indicates: the command length is invalid or a parameter is outside of 
		/// the specified range.
		/// </summary>
		InvalidParameters = 0x030A,
		/// <summary>
		/// The attribute handle given was not valid on this server.
		/// </summary>
		InvalidHandle = 0x0401,
		/// <summary>
		/// The attribute cannot be read.
		/// </summary>
		ReadNotPermitted = 0x0402,
		/// <summary>
		/// The attribute cannot be written.
		/// </summary>
		WriteNotPermitted = 0x0403,
		/// <summary>
		/// The attribute PDU was invalid.
		/// </summary>
		InvalidPdu = 0x0404,
		/// <summary>
		/// The attribute requires authentication before it can be read or written.
		/// </summary>
		InsufficientAuthentication = 0x0405,
		/// <summary>
		/// Attribute Server does not support the request received from the client.
		/// </summary>
		RequestNotSupported = 0x0406,
		/// <summary>
		/// Offset specified was past the end of the attribute.
		/// </summary>
		InvalidOffset = 0x0407,
		/// <summary>
		/// The attribute requires authorization before it can be read or written.
		/// </summary>
		InsufficientAuthorization = 0x0408,
		/// <summary>
		/// Too many prepare writes have been queued.
		/// </summary>
		PrepareQueueFull = 0x0409,
		/// <summary>
		/// No attribute found within the given attribute handle range.
		/// </summary>
		AttributeNotFound = 0x040A,
		/// <summary>
		/// The attribute cannot be read or written using the Read Blob Request.
		/// </summary>
		AttributeNotLong = 0x040B,
		/// <summary>
		/// The Encryption KeyToErase Size used for encrypting this link is insufficient.
		/// </summary>
		InsufficientEncryptionKeySize = 0x040C,
		/// <summary>
		/// The attribute value length is invalid for the operation.
		/// </summary>
		InvalidAttributeValueLength = 0x040D,
		/// <summary>
		/// The attribute request that was requested has encountered an error that was unlikely, and therefore 
		/// could not be completed as requested.
		/// </summary>
		UnlikelyError = 0x040E,
		/// <summary>
		/// The attribute requires encryption before it can be read or written.
		/// </summary>
		InsufficientEncryption = 0x040F,
		/// <summary>
		/// The attribute type is not a supported grouping attribute as defined by a higher layer specification.
		/// </summary>
		UnsupportedGroupType = 0x0410,
		/// <summary>
		/// Insufficient Resources to complete the request.
		/// </summary>
		InsufficientResources = 0x0411,
		/// <summary>
		/// Application error code defined by a higher layer specification.
		/// </summary>
		ApplicationErrorCodes = 0x0480,
	}
}
