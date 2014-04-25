using System;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	/// <summary>
	/// Class Header.
	/// </summary>
	class Header
	{
		private byte[] _store = new byte[HeaderSize];
		private readonly object _headerLock = new object();

		/// <summary>
		/// The header size
		/// </summary>
		public const int HeaderSize = 4;

		private const byte MessageTypeMask = 1 << 7;
		private const byte TechnologyTypeMask = ((1 << 6) - 1) & ~((1 << 3) - 1);
		private const ushort PayloadLengthMask = (1 << 11) - 1;

		/// <summary>
		/// Initializes a new instance of the <see cref="Header"/> class.
		/// </summary>
		public Header() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Header"/> class.
		/// </summary>
		/// <param name="store">The store.</param>
		public Header(byte[] store)
		{
			Store = store;
		}

		/// <summary>
		/// Gets or sets the type of the message.
		/// </summary>
		/// <value>The type of the message.</value>
		public MessageType MessageType
		{
			get
			{
				lock(_headerLock)
					return (MessageType) (_store[0] & MessageTypeMask);
			}
			set
			{
				lock (_headerLock)
					_store[0] = (byte) ((byte) value | (~MessageTypeMask & _store[0]));
			}
		}

		/// <summary>
		/// Gets or sets the type of the technology.
		/// </summary>
		/// <value>The type of the technology.</value>
		public TechnologyType TechnologyType
		{
			get
			{
				lock (_headerLock)
					return (TechnologyType) ((_store[0] & TechnologyTypeMask) >> 3);
			}
			set
			{
				lock (_headerLock)
					_store[0] = (byte) (((byte) value << 3) | (~TechnologyTypeMask & _store[0]));
			}
		}

		/// <summary>
		/// Gets or sets the length of the payload.
		/// </summary>
		/// <value>The length of the payload.</value>
		public ushort PayloadLength
		{
			get
			{
				lock (_headerLock)
					return (ushort) ((_store[0] << 8 | _store[1]) & PayloadLengthMask);
			}
			set
			{
				lock (_headerLock)
				{
					var pl = (ushort)(_store[0] << 8 | _store[1]);
					pl = (ushort)(value | (~PayloadLengthMask & pl));
					_store[0] = (byte) (pl >> 8);
					_store[1] = (byte) (pl & 0xff);
				}
			}
		}

		/// <summary>
		/// Gets or sets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		public ClassId ClassId
		{
			get
			{
				lock (_headerLock)
					return (ClassId) _store[2];
			}
			set
			{
				lock (_headerLock)
					_store[2] = (byte) value;
			}
		}

		/// <summary>
		/// Gets or sets the command identifier.
		/// </summary>
		/// <value>The command identifier.</value>
		public byte CommandId
		{
			get
			{
				lock (_headerLock)
					return _store[3];
			}
			set
			{
				lock (_headerLock)
					_store[3] = value;
			}
		}

		/// <summary>
		/// Gets or sets the payload.
		/// </summary>
		/// <value>The payload.</value>
		public byte[] Payload
		{
			get
			{
				lock (_headerLock)
				{
					return null;
				}
			}
			set
			{
				lock (_headerLock)
				{
					
				}
			}
		}

		/// <summary>
		/// Gets or sets the store.
		/// </summary>
		/// <value>The store.</value>
		public byte[] Store
		{
			get
			{
				lock (_headerLock)
					return _store;
			}
			set
			{
				lock (_headerLock)
				{
					var store = value ?? new byte[HeaderSize];
					if (store.Length < HeaderSize)
					{
						_store = new byte[HeaderSize];
						Buffer.BlockCopy(store, 0, _store, 0, store.Length);
					}
					else
					{
						_store = store;
					}
				}
			}
		}
	}
}
