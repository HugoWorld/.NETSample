// -- FILE ------------------------------------------------------------------
// name       : ApplicationShutdown.cs
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
	public class ApplicationShutdown : ApplicationCommand
	{

		// ----------------------------------------------------------------------
		public ApplicationShutdown( Type ownerType, CommandDescription description ) :
			base( "ApplicationShutdown", ownerType, description )
		{
		} // ApplicationShutdown

		// ----------------------------------------------------------------------
		public override bool HasRequirements
		{
			get { return false; }
		} // HasRequirements

		// ----------------------------------------------------------------------
		public override bool HasImage
		{
			get { return false; }
		} // HasImage

		// ----------------------------------------------------------------------
		protected override void OnExecute( ApplicationCommandContext commandContext )
		{
			Window mainWindow = System.Windows.Application.Current.MainWindow;
			if ( mainWindow != null )
			{
				mainWindow.Close();
				return;
			}

			System.Windows.Application.Current.Shutdown();
		} // OnExecute

	} // class ApplicationShutdown

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
