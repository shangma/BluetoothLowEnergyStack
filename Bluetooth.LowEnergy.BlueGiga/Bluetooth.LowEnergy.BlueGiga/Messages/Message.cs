using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class Message : IMessage
	{
		private readonly Header _header = new Header();
		private readonly IKey<Identifier, byte[]> _key;

		/// <summary>
		/// Initializes a new instance of the <see cref="Message" /> class.
		/// </summary>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The message identifier.</param>
		protected Message(MessageType messageType, ClassId classId, byte commandId)
		{
			_key = new Key(new Identifier(messageType, TechnologyType.Bluetooth_4_0_Single_Mode, classId, commandId));

			_header.MessageType = messageType;
			_header.TechnologyType = TechnologyType.Bluetooth_4_0_Single_Mode;
			_header.ClassId = classId;
			_header.CommandId = commandId;
		}

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>The key.</value>
		public IKey<Identifier, byte[]> Key { get { return _key; } }

		/// <summary>
		/// Gets the type of the message.
		/// </summary>
		/// <value>The type of the message.</value>
		public MessageType MessageType
		{
			get { return _header.MessageType; }
			set { _header.MessageType = value; }
		}

		/// <summary>
		/// Gets the type of the technology.
		/// </summary>
		/// <value>The type of the technology.</value>
		public TechnologyType TechnologyType
		{
			get { return _header.TechnologyType; }
			set { _header.TechnologyType = value; }
		}

		/// <summary>
		/// Gets the length of the payload.
		/// </summary>
		/// <value>The length of the payload.</value>
		public ushort PayloadLength
		{
			get { return _header.PayloadLength; }
			set { _header.PayloadLength = value; }
		}

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		public ClassId ClassId
		{
			get { return _header.ClassId; }
			set { _header.ClassId = value; }
		}

		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		/// <value>The command identifier.</value>
		public byte CommandId
		{
			get { return _header.CommandId; }
			set { _header.CommandId = value; }
		}

		/// <summary>
		/// Gets the payload.
		/// </summary>
		/// <value>The payload.</value>
		/// <exception cref="System.ArgumentNullException">value</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">value</exception>
		public byte[] Payload
		{
			get
			{
				var payload = new byte[PayloadLength];
				Buffer.BlockCopy(_header.Store, Header.HeaderSize, payload, 0, PayloadLength);

				return payload;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				if (value.Length < Header.HeaderSize)
					throw new ArgumentOutOfRangeException("value");

				var store = new byte[Header.HeaderSize + value.Length];
				_header.PayloadLength = (ushort) value.Length;
				Buffer.BlockCopy(_header.Store, 0, store, 0, Header.HeaderSize);
				Buffer.BlockCopy(value, 0, store, Header.HeaderSize, value.Length);

				_header.Store = store;
			}
		}

		/// <summary>
		/// Gets the store.
		/// </summary>
		/// <value>The store.</value>
		public byte[] Store { get { return _header.Store; } protected set { _header.Store = value; } }

		/// <summary>
		/// Reallocates the store.
		/// </summary>
		/// <param name="payloadLength">Length of the payload.</param>
		private void ReallocateStore(int payloadLength)
		{
			if (payloadLength != PayloadLength)
			{
				var storeLength = Header.HeaderSize + payloadLength;

				var store = new byte[storeLength];
				Buffer.BlockCopy(Store, 0, store, 0, Math.Min(PayloadLength, storeLength));

				_header.Store = store;
				_header.PayloadLength = (ushort) payloadLength;
			}
		}

		/// <summary>
		/// Gets the byte from payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <returns>System.Byte.</returns>
		protected byte GetByteFromPayload(int payloadIndex)
		{
			return Store[Header.HeaderSize + payloadIndex];
		}

		/// <summary>
		/// Sets the byte from payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <param name="value">The value.</param>
		protected void SetByteFromPayload(int payloadIndex, byte value)
		{
			Store[Header.HeaderSize + payloadIndex] = value;
		}

		/// <summary>
		/// Gets the unsigned short from payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <returns>System.UInt16.</returns>
		protected ushort GetUnsignedShortFromPayload(int payloadIndex)
		{
			return (ushort) (Store[Header.HeaderSize + payloadIndex] << 8 | Store[Header.HeaderSize + payloadIndex + 1]);
		}

		/// <summary>
		/// Sets the unsigned short in payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <param name="value">The value.</param>
		protected void SetUnsignedShortInPayload(int payloadIndex, ushort value)
		{
			Store[Header.HeaderSize + payloadIndex] = (byte) (value >> 8);
			Store[Header.HeaderSize + payloadIndex + 1] = (byte) (0xff & value);
		}

		/// <summary>
		/// Gets the tail byte array from payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <returns>System.Byte[].</returns>
		protected byte[] GetTailByteArrayFromPayload(int payloadIndex)
		{
			var arrayLength = PayloadLength - payloadIndex;
			var array = new byte[arrayLength];
			Buffer.BlockCopy(Store, Header.HeaderSize + payloadIndex, array, 0, arrayLength);

			return array;
		}

		/// <summary>
		/// Sets the tail byte array in payload.
		/// </summary>
		/// <param name="payloadIndex">Index of the payload.</param>
		/// <param name="value">The value.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The length. If 0 use the length of the value.</param>
		protected void SetTailByteArrayInPayload(int payloadIndex, byte[] value, int offset = 0, int length = 0)
		{
			length = length == 0 ? value.Length : length;

			ReallocateStore(payloadIndex + length);
			Buffer.BlockCopy(value, offset, Store, Header.HeaderSize + payloadIndex, length);
		}

		/// <summary>
		/// Gets the string from byte array.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>System.String.</returns>
		protected static string GetStringFromByteArray(IEnumerable<byte> value)
		{
			var sb = new StringBuilder();
			var e = value.GetEnumerator();

			if (e.MoveNext())
				sb.AppendFormat("{0:X2}", e.Current);

			while (e.MoveNext())
				sb.AppendFormat(",{0:X2}", e.Current);

			return sb.ToString();
		}

		/// <summary>
		/// Gets the log text.
		/// </summary>
		/// <value>The log text.</value>
		public virtual string LogText
		{
			get
			{
				return string.Format("{0} MessageType={1}, TechnologyType={2} ClassID={3} CommandID={4:X2}",
					GetType().Name,
					MessageType,
					TechnologyType,
					ClassId,
					CommandId);
			}
		}
	}
}
