namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class Command : Message, ICommand
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The command identifier.</param>
		protected Command(ClassId classId, byte commandId) 
			: base(MessageType.Command, classId, commandId)
		{
		}
	}
}
