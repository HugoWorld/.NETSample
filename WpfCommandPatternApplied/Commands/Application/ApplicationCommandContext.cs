// -- FILE ------------------------------------------------------------------
// name       : ApplicationCommandContext.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Application
{

	// ------------------------------------------------------------------------
	public class ApplicationCommandContext : CommandContext
	{

		// ----------------------------------------------------------------------
		public ApplicationCommandContext()
		{
		} // ApplicationCommandContext

		// ----------------------------------------------------------------------
		public ApplicationCommandContext( object bindingSource, object commandSource, object commandParameter ) :
			base( bindingSource, commandSource, commandParameter )
		{
		} // ApplicationCommandContext

	} // class ApplicationCommandContext

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
