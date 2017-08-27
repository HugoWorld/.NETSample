// -- FILE ------------------------------------------------------------------
// name       : EditorCommand.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Solutions.Community.Commands.Application;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public abstract class EditorCommand : ApplicationCommand
	{

		// ----------------------------------------------------------------------
		protected EditorCommand( string name, Type ownerType, CommandDescription description ) :
			base( name, ownerType, description )
		{
		} // EditorCommand

		// ----------------------------------------------------------------------
		protected override CommandContext OnCreateContext( object bindingSource, object commandSource, object commandParameter )
		{
			IRichTextEditor richTextEditor = bindingSource as IRichTextEditor;
			if ( richTextEditor == null )
			{
				return null;
			}

			return new EditorCommandContext( bindingSource, commandSource, commandParameter, richTextEditor.TextBox );
		} // OnCreateContext

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( ApplicationCommandContext commandContext )
		{
			return OnCanExecute( commandContext as EditorCommandContext );
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( ApplicationCommandContext commandContext )
		{
			OnExecute( commandContext as EditorCommandContext );
		} // OnExecute

		// ----------------------------------------------------------------------
		protected virtual bool OnCanExecute( EditorCommandContext commandContext )
		{
			return true;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected abstract void OnExecute( EditorCommandContext commandContext );

	} // class EditorCommand

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
