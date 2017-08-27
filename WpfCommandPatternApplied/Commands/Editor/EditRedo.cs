// -- FILE ------------------------------------------------------------------
// name       : EditRedo.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class EditRedo : EditorCommand
	{

		// ----------------------------------------------------------------------
		public EditRedo( Type ownerType, CommandDescription description ) :
			base( "EditRedo", ownerType, description )
		{
		} // EditRedo

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( EditorCommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}
			return commandContext.TextBox.CanRedo;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			commandContext.TextBox.Redo();
		} // OnExecute

	} // class EditRedo

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
