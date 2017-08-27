// -- FILE ------------------------------------------------------------------
// name       : RichTextEditorSelectionCommand.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public abstract class EditorSelectionCommand : EditorCommand
	{

		// ----------------------------------------------------------------------
		protected EditorSelectionCommand( string name, Type ownerType, CommandDescription description ) :
			base( name, ownerType, description )
		{
		} // RichTextEditorSelectionCommand

		// ----------------------------------------------------------------------
		protected virtual bool SelectionRequired
		{
			get { return true; }
		} // SelectionRequired

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( EditorCommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}

			if ( !SelectionRequired )
			{
				return true;
			}

			return !commandContext.TextBox.Selection.IsEmpty;
		} // OnCanExecute

	} // class RichTextEditorSelectionCommand

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
