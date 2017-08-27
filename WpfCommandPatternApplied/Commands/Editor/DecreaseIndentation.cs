// -- FILE ------------------------------------------------------------------
// name       : DecreaseIndentation.cs
// created    : Jani Giannoudis - 2008.04.22
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Documents;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class DecreaseIndentation : WrapperCommand
	{

		// ----------------------------------------------------------------------
		public DecreaseIndentation( Type ownerType, CommandDescription description ) :
			base( EditingCommands.DecreaseIndentation, ownerType, description )
		{
		} // DecreaseIndentation

	} // class DecreaseIndentation

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
