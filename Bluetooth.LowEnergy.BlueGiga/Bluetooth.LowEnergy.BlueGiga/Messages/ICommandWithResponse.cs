namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	public interface ICommandWithResponse<TResponse> : ICommand
		where TResponse : class, IResponse, IMessage, new()
	{
	}
}
