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
		GeneralAccessProfile = 0x06,
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
}
