﻿namespace Bluetooth.LowEnergy.BlueGiga.Messages
{
	abstract class CommandWithResponse<TResponse> : Command, ICommandWithResponse<TResponse>
		where TResponse : class, IResponse, IMessage, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Command" /> class.
		/// </summary>
		/// <param name="classId">The class identifier.</param>
		/// <param name="commandId">The command identifier.</param>
		protected CommandWithResponse(ClassId classId, byte commandId) 
			: base(classId, commandId)
		{
		}

		/// <summary>
		/// Gets the length of the response.
		/// </summary>
		/// <value>The length of the response.</value>
		public virtual int ResponseLength { get { return 1; } }
	}
}
