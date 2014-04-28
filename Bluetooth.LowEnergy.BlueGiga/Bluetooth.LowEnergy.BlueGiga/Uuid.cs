using System;
using System.Linq;
using System.Text;

namespace Bluetooth.LowEnergy.BlueGiga
{
	public class Uuid : IComparable<Uuid>, IEquatable<Uuid>
	{
		private readonly byte[] _store;

		/// <summary>
		/// Initializes a new instance of the <see cref="Uuid"/> class.
		/// </summary>
		/// <param name="store">The store.</param>
		public Uuid(byte[] store)
		{
			_store = store;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			var sb = new StringBuilder();

			foreach (var b in _store.Reverse())
				sb.AppendFormat(@"{0:X2}", b);

			return sb.ToString();
		}

		/// <summary>
		/// Gets the store.  This contains a length byte preceding the UUID store.
		/// </summary>
		/// <value>
		/// The message buffer.
		/// </value>
		public byte[] Store
		{
			get
			{
				var store = new byte[_store.Length == 0 ? 0 : _store.Length + 1];
				if (_store.Length > 0)
				{
					store[0] = (byte) _store.Length;
					Buffer.BlockCopy(_store, 0, store, 1, _store.Length);
				}

				return store;
			}
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(Uuid other)
		{
			return String.Compare(this.ToString(), other.ToString(), StringComparison.Ordinal);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Uuid other)
		{
			return _store.Length == other._store.Length && !_store.Where((t, i) => t != other._store[i]).Any();
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) 
				return false;

			if (ReferenceEquals(this, obj)) 
				return true;

			return obj.GetType() == this.GetType() && Equals((Uuid)obj);
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return (_store != null ? _store.GetHashCode() : 0);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="lhs">The LHS.</param>
		/// <param name="rhs">The RHS.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(Uuid lhs, Uuid rhs)
		{
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;

			return lhs.Equals(rhs);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="lhs">The LHS.</param>
		/// <param name="rhs">The RHS.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(Uuid lhs, Uuid rhs)
		{
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;

			return !lhs.Equals(rhs);
		}

		/// <summary>
		/// Performs an explicit conversion from <see cref="Uuid"/> to <see cref="System.UInt16"/>.
		/// </summary>
		/// <param name="uuid">The UUID.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator ushort(Uuid uuid)
		{
			return (ushort)(uuid._store[1] << 8 | uuid._store[0]);
		}

		/// <summary>
		/// Performs an explicit conversion from <see cref="System.UInt16"/> to <see cref="Uuid"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator Uuid(ushort value)
		{
			var store = new[] {(byte) (value >> 8), (byte) (value & 0xff)};
			return new Uuid(store);
		}
	}
}
