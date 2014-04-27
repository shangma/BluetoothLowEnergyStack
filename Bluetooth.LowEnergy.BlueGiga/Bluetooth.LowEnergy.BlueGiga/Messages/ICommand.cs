using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface ICommand : IMessage, ICommand<Identifier, byte[]>
	{
	}
}
