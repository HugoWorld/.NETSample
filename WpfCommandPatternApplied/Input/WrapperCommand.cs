// -- FILE ------------------------------------------------------------------
// name       : WrapperCommand.cs
// created    : Jani Giannoudis - 2008.04.22
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Input;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public abstract class WrapperCommand : Command
	{

		// ----------------------------------------------------------------------
		protected WrapperCommand( RoutedCommand coreCommand, Type ownerType, CommandDescription description ) :
			base( coreCommand.Name, ownerType, description )
		{
			if ( coreCommand == null )
			{
				throw new ArgumentNullException( "coreCommand" );
			}

			this.coreCommand = coreCommand;
		} // WrapperCommand

		// ----------------------------------------------------------------------
		protected WrapperCommand( RoutedUICommand coreCommand, Type ownerType, CommandDescription description ) :
			base( coreCommand.Text, coreCommand.Name, ownerType, description )
		{
			if ( coreCommand == null )
			{
				throw new ArgumentNullException( "coreCommand" );
			}

			this.coreCommand = coreCommand;
		} // WrapperCommand

		// ----------------------------------------------------------------------
		public RoutedCommand CoreCommand
		{
			get { return coreCommand; }
		} // CoreCommand

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( CommandContext commandContext )
		{
			IInputElement inputElement = commandContext.CommandSource as IInputElement;
			if ( inputElement == null )
			{
				return false;
			}

			return coreCommand.CanExecute( commandContext.CommandParameter, inputElement );
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( CommandContext commandContext )
		{
			IInputElement inputElement = commandContext.CommandSource as IInputElement;
			if ( inputElement == null )
			{
				return;
			}

			coreCommand.Execute( commandContext.CommandParameter, inputElement );
		} // OnExecute

		// ----------------------------------------------------------------------
		// members
		private readonly RoutedCommand coreCommand;

	} // class WrapperCommand

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
