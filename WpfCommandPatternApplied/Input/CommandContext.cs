// -- FILE ------------------------------------------------------------------
// name       : CommandContext.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public class CommandContext : IDisposable
	{

		// ----------------------------------------------------------------------
		public CommandContext()
		{
		} // CommandContext

		// ----------------------------------------------------------------------
		public CommandContext( object bindingSource, object commandSource, object commandParameter )
		{
			CommandSource = commandSource;
			BindingSource = bindingSource;
			CommandParameter = commandParameter;
		} // CommandContext

		// ----------------------------------------------------------------------
		~CommandContext()
		{
			Dispose( false );
		} // ~CommandContext

		// ----------------------------------------------------------------------
		public object BindingSource { get; set; }

		// ----------------------------------------------------------------------
		public object CommandSource { get; set; }

		// ----------------------------------------------------------------------
		public object CommandParameter { get; set; }

		// ----------------------------------------------------------------------
		public void Dispose()
		{
			Dispose( true );
		} // Dispose

		// ----------------------------------------------------------------------
		protected virtual void Dispose( bool disposing )
		{
			if ( !disposed )
			{
				disposed = true;
			}
		} // Dispose

		// ----------------------------------------------------------------------
		// members
		private bool disposed;

	} // class CommandContext

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
