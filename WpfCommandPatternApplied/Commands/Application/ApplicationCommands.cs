// -- FILE ------------------------------------------------------------------
// name       : ApplicationCommands.cs
// created    : Jani Giannoudis - 2008.04.16
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Application
{

	// ------------------------------------------------------------------------
	public class ApplicationCommands : CommandCollection
	{

		// ----------------------------------------------------------------------
		public static ApplicationShutdown ApplicationShutdown;
		public static CommandStatistics CommandStatistics;
		public static ApplicationAbout ApplicationAbout;

		// ----------------------------------------------------------------------
		public ApplicationCommands()
		{
			Add( ApplicationShutdown );
			Add( CommandStatistics );
			Add( ApplicationAbout );
		} // ApplicationCommands

		// ----------------------------------------------------------------------
		static ApplicationCommands()
		{
			ApplicationShutdown =
				new ApplicationShutdown(
					typeof( ApplicationCommands ),
					new CommandDescription(
						Properties.Resources.CommandApplicationShutdownText,
						Properties.Resources.CommandApplicationShutdownDescription ) );

			CommandStatistics =
				new CommandStatistics(
					typeof( ApplicationCommands ),
					new CommandDescription(
						Properties.Resources.CommandCommandStatisticsText,
						Properties.Resources.CommandCommandStatisticsDescription ) );

			ApplicationAbout =
				new ApplicationAbout(
					typeof( ApplicationCommands ),
					new CommandDescription(
						Properties.Resources.CommandApplicationAboutText,
						Properties.Resources.CommandApplicationAboutDescription ) );

		} // ApplicationCommands

	} // class ApplicationCommands

} // namespace Itenso.Solutions.Community.Commands.Application
// -- EOF -------------------------------------------------------------------
