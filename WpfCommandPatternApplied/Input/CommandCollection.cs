// -- FILE ------------------------------------------------------------------
// name       : CommandCollection.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Collections.Generic;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public class CommandCollection : List<Command>
	{

		// ----------------------------------------------------------------------
		public Command this[ string name ]
		{
			get
			{
				if ( string.IsNullOrEmpty( name ) )
				{
					return null;
				}

				foreach ( Command command in this )
				{
					if ( name.Equals( command.Name ) )
					{
						return command;
					}
				}
				return null;
			}
		} // this[ string ]

		// ----------------------------------------------------------------------
		public bool Contains( string name )
		{
			return this[ name ] != null;
		} // Contains

	} // class CommandCollection

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
