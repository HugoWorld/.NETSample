// -- FILE ------------------------------------------------------------------
// name       : CommandWindow.xaml.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;
using Itenso.Solutions.Community.Commands.Editor;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.CommandDemo
{

	// ------------------------------------------------------------------------
	public partial class CommandWindow : IRichTextEditor
	{

		// ----------------------------------------------------------------------
		public static DependencyProperty CurrentCommandInfoProperty;
		public static DependencyProperty CommandStatisticInfoProperty;

		// ----------------------------------------------------------------------
		public CommandWindow()
		{
			SetupProperties();
			SetupSystemCommands();
			InitializeComponent();
			SetupApplicationCommands();
			SetupFonts();
		} // CommandWindow

		// ----------------------------------------------------------------------
		public string CurrentCommandInfo
		{
			get { return (string)GetValue( CurrentCommandInfoProperty ); }
			set { SetValue( CurrentCommandInfoProperty, value ); }
		} // CurrentCommandInfo

		// ----------------------------------------------------------------------
		public string CommandStatisticInfo
		{
			get { return (string)GetValue( CommandStatisticInfoProperty ); }
			set { SetValue( CommandStatisticInfoProperty, value ); }
		} // CommandStatisticInfo

		// ----------------------------------------------------------------------
		RichTextBox IRichTextEditor.TextBox
		{
			get { return Editor; }
		} // IEditor.TextBox

		// ----------------------------------------------------------------------
		private void SetupProperties()
		{
			CurrentCommandInfoProperty = DependencyProperty.Register(
				"CurrentCommandInfo", typeof( string ), typeof( CommandWindow ),
				new FrameworkPropertyMetadata( string.Empty, FrameworkPropertyMetadataOptions.AffectsRender ) );

			CommandStatisticInfoProperty = DependencyProperty.Register(
				"CommandStatisticInfo", typeof( string ), typeof( CommandWindow ),
				new FrameworkPropertyMetadata( string.Empty, FrameworkPropertyMetadataOptions.AffectsRender ) );
		} // SetupProperties

		// ----------------------------------------------------------------------
		private void SetupSystemCommands()
		{
			// setup system commands: adde gesture to demonstrate tooltip-gestures
			EditingCommands.ToggleBullets.InputGestures.Add( new KeyGesture( Key.T, ModifierKeys.Control, "Ctrl+T" ) );
			EditingCommands.ToggleNumbering.InputGestures.Add( new KeyGesture( Key.M, ModifierKeys.Control, "Ctrl+M" ) );
		} // SetupSystemCommands

		// ----------------------------------------------------------------------
		private void SetupFonts()
		{
			foreach ( FontFamily fontFamily in Fonts.SystemFontFamilies )
			{
				FontsComboBox.Items.Add( fontFamily.Source );
			}
			if ( FontsComboBox.Items.Count > 0 )
			{
				FontsComboBox.SelectedIndex = 0;
			}
		} // SetupFonts

		// ----------------------------------------------------------------------
		private void SetupApplicationCommands()
		{
			CommandBindings.AddRange( CommandRepository.Bindings );

			// command tracking
			CommandRepository.CommandExecuting += CommandRepositoryCommandExecuted;
			CommandRepository.CommandExecuted += CommandRepositoryCommandExecuting;

			// add undo-command from code behind
			Button undoButton = new Button();
			ButtonCommandProvider.SetCommand( undoButton, RichTextEditorCommands.EditUndo );
			MainToolBar.Items.Insert( 0, undoButton );

			// add redo-command from code behind
			Button redoButton = new Button();
			ButtonCommandProvider.SetCommand( redoButton, RichTextEditorCommands.EditRedo );
			MainToolBar.Items.Insert( 1, redoButton );
		} // SetupApplicationCommands

		// ----------------------------------------------------------------------
		private void UpdateStatusBarInfo( object source = null )
		{
			if ( source == null )
			{
				CurrentCommandInfo = string.Empty;
				return;
			}

			// menu item
			ICommandSource commandSource = source as ICommandSource;
			if ( commandSource != null )
			{
				Command command = ( commandSource ).Command as Command;
				if ( command != null )
				{
					CurrentCommandInfo = command.Description.Description;
				}
			}
		} // UpdateStatusBarInfo

		// ----------------------------------------------------------------------
		public void OnStatusUpdate( object sender, RoutedEventArgs e )
		{
			UpdateStatusBarInfo( sender );
		} // OnStatusUpdate

		// ----------------------------------------------------------------------
		public void OnStatusReset( object sender, RoutedEventArgs e )
		{
			UpdateStatusBarInfo();
		} // OnStatusReset

		// ----------------------------------------------------------------------
		private void CommandRepositoryCommandExecuted( object sender, CommandContextEventArgs e )
		{
			CurrentCommandInfo = "Current Command: " + e.Command.Name;
		} // CommandRepositoryCommandExecuted

		// ----------------------------------------------------------------------
		private void CommandRepositoryCommandExecuting( object sender, CommandContextEventArgs e )
		{
			commandExecuteCount++;

			CurrentCommandInfo = string.Empty;
			CommandStatisticInfo = "Execution Count: " + commandExecuteCount.ToString( CultureInfo.InvariantCulture );
		} // CommandRepositoryCommandExecuting

		// ----------------------------------------------------------------------
		// members
		private int commandExecuteCount;

	} // class CommandWindow

} // namespace Itenso.Solutions.Community.CommandDemo
// -- EOF -------------------------------------------------------------------
