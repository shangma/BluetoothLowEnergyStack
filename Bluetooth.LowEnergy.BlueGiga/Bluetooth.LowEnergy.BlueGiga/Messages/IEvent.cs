using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface IEvent : IMessage, IEvent<Identifier, byte[]>
	{
	}
}
