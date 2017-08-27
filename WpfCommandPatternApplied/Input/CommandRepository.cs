// -- FILE ------------------------------------------------------------------
// name       : CommandRepository.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public sealed class CommandRepository
	{

		// ----------------------------------------------------------------------
		public static event CommandContextEventHandler CommandExecuting;
		public static event CommandContextEventHandler CommandExecuted;

		// ----------------------------------------------------------------------
		private CommandRepository()
		{
		} // CommandRepository

		// ----------------------------------------------------------------------
		public static CommandCollection Commands
		{
			get { return Instance.commands; }
		} // Commands

		// ----------------------------------------------------------------------
		public static CommandBindingCollection Bindings
		{
			get { return Instance.bindings; }
		} // Bindings

		// ----------------------------------------------------------------------
		private static CommandRepository Instance
		{
			get
			{
				if ( instance == null )
				{
					lock ( mutex )
					{
						if ( instance == null )
						{
							// ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
							instance = new CommandRepository();
							// ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
						}
					}
				}
				return instance;
			}
		} // Instance

		// ----------------------------------------------------------------------
		public static void AddRange( CommandCollection commands )
		{
			Instance.AddCommands( commands );
		} // AddRange

		// ----------------------------------------------------------------------
		public static void Add( Command command )
		{
			Instance.AddCommand( command );
		} // Add

		// ----------------------------------------------------------------------
		private void AddCommands( IEnumerable<Command> addCommands )
		{
			if ( addCommands == null )
			{
				throw new ArgumentNullException( "addCommands" );
			}

			foreach ( Command addCommand in addCommands )
			{
				AddCommand( addCommand );
			}
		} // AddCommands

		// ----------------------------------------------------------------------
		private void AddCommand( Command command )
		{
			if ( command == null )
			{
				throw new ArgumentNullException( "command" );
			}

			// command registration
			commands.Add( command );

			// command binding registration
			CommandBinding commandBinding = new CommandBinding(
				command,
				CommandBindingExecuted,
				CommandBindingCanExecute );
			bindings.Add( commandBinding );
		} // AddCommand

		// ----------------------------------------------------------------------
		private void CommandBindingCanExecute( object sender, CanExecuteRoutedEventArgs e )
		{
			Command command = e.Command as Command;
			if ( command == null )
			{
				return;
			}

			if ( !commands.Contains( command ) )
			{
				return;
			}

			// command can executed without CanExecute check
			if ( !command.HasRequirements )
			{
				e.CanExecute = true;
				e.Handled = true;
				return;
			}

			// command context
			using ( CommandContext commandContext =
				command.CreateCanExecuteContext( sender, e.OriginalSource, e.Parameter ) )
			{
				if ( commandContext == null )
				{
					return;
				}

				// command can execute check
				e.CanExecute = command.CanExecute( commandContext );
				e.Handled = true;
			}
		} // CommandBindingCanExecute

		// ----------------------------------------------------------------------
		private void CommandBindingExecuted( object sender, ExecutedRoutedEventArgs e )
		{
			Command command = e.Command as Command;
			if ( command == null )
			{
				return;
			}

			if ( !commands.Contains( command ) )
			{
				return;
			}

			// command context
			using ( CommandContext commandContext =
				command.CreateCanExecuteContext( sender, e.OriginalSource, e.Parameter ) )
			{
				if ( CommandExecuting != null )
				{
					CommandExecuting( this, new CommandContextEventArgs( command, commandContext ) );
				}

				// command execute
				command.Execute( commandContext );

				if ( CommandExecuted != null )
				{
					CommandExecuted( this, new CommandContextEventArgs( command, commandContext ) );
				}
				e.Handled = true;
			}
		} // CommandBindingExecuted

		// ----------------------------------------------------------------------
		// members
		private readonly CommandCollection commands = new CommandCollection();
		private readonly CommandBindingCollection bindings = new CommandBindingCollection();

		private static readonly object mutex = new object();
		private static CommandRepository instance; // singleton

	} // class CommandRepository

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
