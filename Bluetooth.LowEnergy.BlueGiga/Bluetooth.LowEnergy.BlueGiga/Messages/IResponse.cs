using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface IResponse : IMessage, IResponse<Identifier, byte[]>
	{
	}
}
