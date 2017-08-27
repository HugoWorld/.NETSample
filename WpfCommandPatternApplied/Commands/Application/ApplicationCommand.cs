// -- FILE ------------------------------------------------------------------
// name       : ApplicationCommand.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Application
{

	// ------------------------------------------------------------------------
	public abstract class ApplicationCommand : Command
	{

		// ----------------------------------------------------------------------
		protected ApplicationCommand( string name, Type ownerType, CommandDescription description ) :
			base( name, ownerType, description )
		{
		} // ApplicationCommand

		// ----------------------------------------------------------------------
		protected override CommandContext OnCreateContext( object bindingSource, object commandSource, object commandParameter )
		{
			return new ApplicationCommandContext( bindingSource, commandSource, commandParameter );
		} // OnCreateContext

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( CommandContext commandContext )
		{
			bool canExecute = false;
			try
			{
				canExecute = OnCanExecute( commandContext as ApplicationCommandContext );
			}
			catch ( ApplicationException e )
			{
				// custom error handling
				MessageBox.Show( "Unhandled Exception: " + e.Message, Text );
			}

			return canExecute;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( CommandContext commandContext )
		{
			try
			{
				OnExecute( commandContext as ApplicationCommandContext );
			}
			catch ( ApplicationException e )
			{
				// custom error handling
				MessageBox.Show( "Unhandled Exception: " + e.Message, Text );
			}
		} // OnExecute

		// ----------------------------------------------------------------------
		protected virtual bool OnCanExecute( ApplicationCommandContext commandContext )
		{
			return true;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected abstract void OnExecute( ApplicationCommandContext commandContext );

	} // class ApplicationCommand

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
