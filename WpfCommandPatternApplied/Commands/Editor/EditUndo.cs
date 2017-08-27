// -- FILE ------------------------------------------------------------------
// name       : EditUndo.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class EditUndo : EditorCommand
	{

		// ----------------------------------------------------------------------
		public EditUndo( Type ownerType, CommandDescription description ) :
			base( "EditUndo", ownerType, description )
		{
		} // EditUndo

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( EditorCommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}
			return commandContext.TextBox.CanUndo;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			commandContext.TextBox.Undo();
		} // OnExecute

	} // class EditUndo

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
