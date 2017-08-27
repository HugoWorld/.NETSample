// -- FILE ------------------------------------------------------------------
// name       : IncreaseIndentation.cs
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
	public class IncreaseIndentation : WrapperCommand
	{

		// ----------------------------------------------------------------------
		public IncreaseIndentation( Type ownerType, CommandDescription description ) :
			base( EditingCommands.IncreaseIndentation, ownerType, description )
		{
		} // IncreaseIndentation

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( CommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}

			// add some additional enabling conditions

			return true;
		} // OnCanExecute

	} // class IncreaseIndentation

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
