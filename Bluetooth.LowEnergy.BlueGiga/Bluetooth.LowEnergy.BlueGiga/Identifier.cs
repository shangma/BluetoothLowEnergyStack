using System;
using Bluetooth.LowEnergy.BlueGiga.Messages;

namespace Bluetooth.LowEnergy.BlueGiga
{
	public struct Identifier : IConvertible, IComparable<byte[]>
	{
		private readonly Header _header;

		/// <summary>
		/// Initializes a new instance of the <see cref="Identifier"/> struct.
		/// </summary>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="technologyType">Type of the technology.</param>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The command identifier.</param>
		public Identifier(MessageType messageType, TechnologyType technologyType, ClassId classId, byte commandId)
			: this()
		{
			_header = new Header
			{
				MessageType = messageType,
				TechnologyType = technologyType,
				ClassId = classId,
				CommandId = commandId
			};
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Identifier"/> struct.
		/// </summary>
		/// <param name="store">The store.</param>
		/// <exception cref="System.ArgumentNullException">store</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">store</exception>
		public Identifier(byte[] store)
		{
			if (store == null)
				throw new ArgumentNullException("store");

			if (store.Length != Header.HeaderSize)
				throw new ArgumentOutOfRangeException("store");

			_header = new Header(store);
		}

		/// <summary>
		/// Gets the type of the message.
		/// </summary>
		/// <value>The type of the message.</value>
		public MessageType MessageType { get { return _header.MessageType; } }

		/// <summary>
		/// Gets the type of the technology.
		/// </summary>
		/// <value>The type of the technology.</value>
		public TechnologyType TechnologyType { get { return _header.TechnologyType; } }

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		public ClassId ClassId { get { return _header.ClassId; } }

		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		/// <value>The command identifier.</value>
		public byte CommandId { get { return _header.CommandId; } }

		/// <summary>
		/// Performs an explicit conversion from <see cref="System.Byte[][]"/> to <see cref="Identifier"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		/// <exception cref="System.ArgumentNullException">value</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">value</exception>
		public static explicit operator Identifier(byte[] value)
		{
			if (value == null)
				throw new ArgumentNullException("value");

			if (value.Length < Header.HeaderSize)
				throw new ArgumentOutOfRangeException("value");

			var bytes = BitConverter.ToUInt32(value, 0);

			return (Identifier)bytes;
		}

		/// <summary>
		/// Performs an explicit conversion from <see cref="Identifier"/> to <see cref="System.Byte[]"/>.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator byte[](Identifier identifier)
		{
			return BitConverter.GetBytes((uint)identifier);
		}

		/// <summary>
		/// Performs an explicit conversion from <see cref="System.UInt32"/> to <see cref="Identifier"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator Identifier(uint value)
		{
			return new Identifier(BitConverter.GetBytes(value));
		}

		/// <summary>
		/// Performs an explicit conversion from <see cref="Identifier"/> to <see cref="System.UInt32"/>.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator uint(Identifier identifier)
		{
			return Convert.ToUInt32(identifier);
		}

		/// <summary>
		/// Returns the <see cref="T:System.TypeCode" /> for this instance.
		/// </summary>
		/// <returns>The enumerated constant that is the <see cref="T:System.TypeCode" /> of the class or value type that implements this interface.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public TypeCode GetTypeCode()
		{
			return TypeCode.UInt32;
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A Boolean value equivalent to the value of this instance.</returns>
		public bool ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent Unicode character using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A Unicode character equivalent to the value of this instance.</returns>
		public char ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 8-bit signed integer equivalent to the value of this instance.</returns>
		public sbyte ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 8-bit unsigned integer equivalent to the value of this instance.</returns>
		public byte ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 16-bit signed integer equivalent to the value of this instance.</returns>
		public short ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 16-bit unsigned integer equivalent to the value of this instance.</returns>
		public ushort ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 32-bit signed integer equivalent to the value of this instance.</returns>
		public int ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 32-bit unsigned integer equivalent to the value of this instance.</returns>
		public uint ToUInt32(IFormatProvider provider)
		{
			return (uint)this;
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 64-bit signed integer equivalent to the value of this instance.</returns>
		public long ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An 64-bit unsigned integer equivalent to the value of this instance.</returns>
		public ulong ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent single-precision floating-point number using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A single-precision floating-point number equivalent to the value of this instance.</returns>
		public float ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent double-precision floating-point number using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A double-precision floating-point number equivalent to the value of this instance.</returns>
		public double ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent <see cref="T:System.Decimal" /> number using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A <see cref="T:System.Decimal" /> number equivalent to the value of this instance.</returns>
		public decimal ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an equivalent <see cref="T:System.DateTime" /> using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A <see cref="T:System.DateTime" /> instance equivalent to the value of this instance.</returns>
		public DateTime ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(ToUInt32(provider));
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public string ToString(IFormatProvider provider)
		{
			return Convert.ToString(ToUInt32(provider));
		}

		/// <summary>
		/// Converts the value of this instance to an <see cref="T:System.Object" /> of the specified <see cref="T:System.Type" /> that has an equivalent value, using the specified culture-specific formatting information.
		/// </summary>
		/// <param name="conversionType">The <see cref="T:System.Type" /> to which the value of this instance is converted.</param>
		/// <param name="provider">An <see cref="T:System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
		/// <returns>An <see cref="T:System.Object" /> instance of type <paramref name="conversionType" /> whose value is equivalent to the value of this instance.</returns>
		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)ToUInt32(provider)).ToType(conversionType, provider);
		}

		/// <summary>
		/// Compares to.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="System.ArgumentNullException">other</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">other</exception>
		public int CompareTo(byte[] other)
		{
			if (other == null)
				throw new ArgumentNullException("other");

			if (other.Length < Header.HeaderSize)
				throw new ArgumentOutOfRangeException("other");

			var otherValue = (uint) (new Identifier(other));
			var thisValue = (uint) this;

			return thisValue.CompareTo(otherValue);
		}
	}
}
