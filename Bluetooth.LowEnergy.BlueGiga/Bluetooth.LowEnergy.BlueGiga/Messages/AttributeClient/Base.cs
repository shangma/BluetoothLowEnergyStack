namespace Bluetooth.LowEnergy.BlueGiga.Messages.AttributeClient
{
	abstract class AttributeClientCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AttributeClientCommand"/> class.
		/// </summary>
		/// <param name="commandId">The command identifier.</param>
		protected AttributeClientCommand(byte commandId) 
			: base(ClassId.AttributeClient, commandId)
		{
		}
	}

}
