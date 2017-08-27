// -- FILE ------------------------------------------------------------------
// name       : ApplicationAbout.cs
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
	public class ApplicationAbout : ApplicationCommand
	{

		// ----------------------------------------------------------------------
		public ApplicationAbout( Type ownerType, CommandDescription description ) :
			base( "ApplicationAbout", ownerType, description )
		{
		} // ApplicationAbout

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
			MessageBox.Show(
				"Assembly: " + GetType().Assembly.GetName().FullName, "Command Demo" );
		} // OnExecute

	} // class ApplicationAbout

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
