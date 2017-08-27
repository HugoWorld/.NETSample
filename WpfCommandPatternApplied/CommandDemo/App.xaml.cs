// -- FILE ------------------------------------------------------------------
// name       : App.xaml.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Windows;
using Itenso.Solutions.Community.Commands.Application;
using Itenso.Solutions.Community.Commands.Editor;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.CommandDemo
{

	// ------------------------------------------------------------------------
	public partial class App
	{

		// ----------------------------------------------------------------------
		protected override void OnStartup( StartupEventArgs e )
		{
			base.OnStartup( e );

			// command styling
			ButtonCommandProvider.ToolTipStyle = CommandToolTipStyle.AlwaysWithKeyGesture;
			MenuItemCommandProvider.ToolTipStyle = CommandToolTipStyle.Always;

			// setup command repository
			CommandRepository.AddRange( new ApplicationCommands() );
			CommandRepository.AddRange( new RichTextEditorCommands() );

			// individual command setup
			ApplicationCommands.CommandStatistics.Target = CommandRepository.Commands;
		} // OnStartup

	} // class App

} // namespace Itenso.Solutions.Community.CommandDemo
// -- EOF -------------------------------------------------------------------
