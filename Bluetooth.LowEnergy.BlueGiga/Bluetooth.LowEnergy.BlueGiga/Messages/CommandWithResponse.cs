namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class CommandWithResponse<TResponse> : Command, ICommandWithResponse<TResponse>
		where TResponse : class, IResponse, IMessage, new()
	{
	}
}
