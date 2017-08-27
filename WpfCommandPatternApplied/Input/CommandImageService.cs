// -- FILE ------------------------------------------------------------------
// name       : CommandImageService.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public static class CommandImageService
	{

		// ----------------------------------------------------------------------
		public static string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; }
		} // ImagePath

		// ----------------------------------------------------------------------
		public static string ImageExtension
		{
			get { return imageExtension; }
			set { imageExtension = value; }
		} // ImageExtension

		// ----------------------------------------------------------------------
		public static Uri GetCommandImageUri( Command command )
		{
			if ( command == null )
			{
				throw new ArgumentNullException( "command" );
			}

			if ( !command.HasImage )
			{
				return null;
			}

			Uri imageUri = command.ImageUri;
			if ( imageUri != null )
			{
				return imageUri;
			}

			string imageSource = command.GetType().Assembly.GetName().Name;
			imageUri = new Uri( string.Concat(
				"pack://application:,,,/",
				imageSource,
				";Component/",
				imagePath,
				command.Name,
				imageExtension ) );

			return imageUri;
		} // GetCommandImageUri

		// ----------------------------------------------------------------------
		// members
		private static string imagePath = "Images/";
		private static string imageExtension = ".png";

	} // class CommandImageService

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
