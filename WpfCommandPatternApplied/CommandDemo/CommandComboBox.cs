// -- FILE ------------------------------------------------------------------
// name       : CommandComboBox.cs
// created    : Jani Giannoudis - 2008.04.16
// language   : c#
// environment: .NET 3.0
// resources  : http://msdn.microsoft.com/en-us/library/system.windows.input.icommandsource.aspx
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Itenso.Solutions.Community.CommandDemo
{

	// ------------------------------------------------------------------------
	public class CommandComboBox : ComboBox, ICommandSource
	{

		public static readonly DependencyProperty CommandProperty =
				DependencyProperty.Register(
						"Command",
						typeof( ICommand ),
						typeof( CommandComboBox ),
						new PropertyMetadata( null,
						CommandChanged ) );

		public static readonly DependencyProperty CommandTargetProperty =
				DependencyProperty.Register(
						"CommandTarget",
						typeof( IInputElement ),
						typeof( CommandComboBox ),
						new PropertyMetadata( (IInputElement)null ) );

		public static readonly DependencyProperty CommandParameterProperty =
				DependencyProperty.Register(
						"CommandParameter",
						typeof( object ),
						typeof( CommandComboBox ),
						new PropertyMetadata( (object)null ) );

		// ----------------------------------------------------------------------
		public CommandComboBox()
		{
			uiElementInput = new UIElementInput( this );
		} // CommandComboBox

		// ----------------------------------------------------------------------
		public bool UseSelectedValueAsCommandParameter
		{
			get { return useSelectedValueAsCommandParameter; }
			set { useSelectedValueAsCommandParameter = value; }
		} // UseSelectedValueAsCommandParameter

		// ----------------------------------------------------------------------
		public ICommand Command
		{
			get { return GetValue( CommandProperty ) as ICommand; }
			set { SetValue( CommandProperty, value ); }
		} // Command

		// ----------------------------------------------------------------------
		public object CommandParameter
		{
			get { return GetValue( CommandParameterProperty ); }
			set { SetValue( CommandParameterProperty, value ); }
		} // CommandParameter

		// ----------------------------------------------------------------------
		public IInputElement CommandTarget
		{
			get { return GetValue( CommandTargetProperty ) as IInputElement; }
			set { SetValue( CommandTargetProperty, value ); }
		} // CommandTarget

		// ----------------------------------------------------------------------
		protected virtual void OnCommandExecute()
		{
			ICommand command = Command;
			if ( command == null )
			{
				return;
			}

			if ( UseSelectedValueAsCommandParameter )
			{
				CommandParameter = SelectedValue;
			}

			if ( command is RoutedCommand )
			{
				( (RoutedCommand)command ).Execute( CommandParameter, CommandTarget );
			}
			else
			{
				command.Execute( CommandParameter );
			}
		} // OnCommandExecute

		// ----------------------------------------------------------------------
		protected override void OnSelectionChanged( SelectionChangedEventArgs e )
		{
			base.OnSelectionChanged( e );

			if ( !uiElementInput.IsActiveEvent )
			{
				return;
			}

			OnCommandExecute();
		} // OnSelectionChanged

		// ----------------------------------------------------------------------
		private void HookUpCommand( ICommand oldCommand, ICommand newCommand )
		{
			EventHandler handler;

			// if oldCommand is not null, then we need to remove the handlers.
			if ( oldCommand != null )
			{
				handler = CanExecuteChanged;
				oldCommand.CanExecuteChanged -= handler;
			}

			handler = CanExecuteChanged;
			canExecuteChangedHandler = handler;
			if ( newCommand != null )
			{
				newCommand.CanExecuteChanged += canExecuteChangedHandler;
			}
		} // HookUpCommand

		// ----------------------------------------------------------------------
		private void CanExecuteChanged( object sender, EventArgs e )
		{
			if ( Command == null )
			{
				return;
			}

			RoutedCommand routedCommand = Command as RoutedCommand;
			IsEnabled = routedCommand != null ?
				routedCommand.CanExecute( CommandParameter, CommandTarget ) :
				Command.CanExecute( CommandParameter );
		} // CanExecuteChanged

		// ----------------------------------------------------------------------
		private static void CommandChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			CommandComboBox comboBox = d as CommandComboBox;
			if ( comboBox == null )
			{
				return;
			}
			comboBox.HookUpCommand( e.OldValue as ICommand, e.NewValue as ICommand );
		} // CommandChanged

		// ----------------------------------------------------------------------
		// members
		private readonly UIElementInput uiElementInput;
		private bool useSelectedValueAsCommandParameter = true;

		private static EventHandler canExecuteChangedHandler;

	} // class CommandComboBox

} // namespace Itenso.Solutions.Community.CommandDemo
// -- EOF -------------------------------------------------------------------
