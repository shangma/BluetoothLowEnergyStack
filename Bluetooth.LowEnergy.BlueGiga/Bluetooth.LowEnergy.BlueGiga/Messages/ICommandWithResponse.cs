using Veldy.Net.CommandProcessor;

namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface ICommandWithResponse<TResponse> : ICommand, ICommandWithResponse<Identifier, byte[]> 
		where TResponse : class, IResponse, IResponse<Identifier, byte[]>, IMessage, IMessage<Identifier, byte[]>, new()
	{
	}
}
