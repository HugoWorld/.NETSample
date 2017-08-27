// -- FILE ------------------------------------------------------------------
// name       : CommandStatistics.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Text;
using System.Windows;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Application
{

	// ------------------------------------------------------------------------
	public class CommandStatistics : ApplicationCommand
	{

		// ----------------------------------------------------------------------
		public CommandStatistics( Type ownerType, CommandDescription description ) :
			base( "CommandStatistics", ownerType, description )
		{
		} // CommandStatistics

		// ----------------------------------------------------------------------
		public override bool HasImage
		{
			get { return false; }
		} // HasImage

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( ApplicationCommandContext commandContext )
		{
			return Target is CommandCollection;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( ApplicationCommandContext commandContext )
		{
			CommandCollection commands = Target as CommandCollection;
			if ( commands == null )
			{
				return;
			}

			StringBuilder sb = new StringBuilder();

			foreach ( Command command in commands )
			{
				sb.Append( "- " );
				sb.Append( command.Name );
				sb.Append( " (" );
				sb.Append( command.OwnerType.Name );
				sb.Append( ")" );
				sb.Append( Environment.NewLine );
			}

			MessageBox.Show( sb.ToString(), Name );
		} // OnExecute

	} // class CommandStatistics

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
