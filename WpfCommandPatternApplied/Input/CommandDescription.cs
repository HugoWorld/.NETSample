// -- FILE ------------------------------------------------------------------
// name       : CommandDescription.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Input;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public class CommandDescription
	{

		// ----------------------------------------------------------------------
		public CommandDescription( string text ) :
			this( text, string.Empty, string.Empty, string.Empty, string.Empty )
		{
		} // CommandDescription

		// ----------------------------------------------------------------------
		public CommandDescription( string text, string description ) :
			this( text, description, string.Empty, string.Empty, string.Empty )
		{
		} // CommandDescription

		// ----------------------------------------------------------------------
		public CommandDescription( string text, string description, string gestures ) :
			this( text, description, gestures, string.Empty, string.Empty )
		{
		} // CommandDescription

		// ----------------------------------------------------------------------
		public CommandDescription( string text, string description, string gestures, string toolTip ) :
			this( text, description, gestures, toolTip, string.Empty )
		{
		} // CommandDescription

		// ----------------------------------------------------------------------
		public CommandDescription( string text, string description, string gestures, string toolTip, string gesturesText )
		{
			Text = text;
			Description = description;
			ToolTip = toolTip;

			SetupGestures( gestures, gesturesText );
		} // CommandDescription

		// ----------------------------------------------------------------------
		public string Text { get; set; }

		// ----------------------------------------------------------------------
		public string Description { get; set; }

		// ----------------------------------------------------------------------
		public InputGestureCollection Gestures
		{
			get { return gestures; }
		} // Gestures

		// ----------------------------------------------------------------------
		public string ToolTip { get; set; }

		// ----------------------------------------------------------------------
		private void SetupGestures( string keyGestures, string displayStrings )
		{
			if ( string.IsNullOrEmpty( displayStrings ) )
			{
				displayStrings = keyGestures;
			}

			while ( !string.IsNullOrEmpty( keyGestures ) )
			{
				string currentDisplay;
				string currentGesture;
				int index = keyGestures.IndexOf( ";", StringComparison.Ordinal );
				if ( index >= 0 )
				{
					currentGesture = keyGestures.Substring( 0, index );
					keyGestures = keyGestures.Substring( index + 1 );
				}
				else
				{
					currentGesture = keyGestures;
					keyGestures = string.Empty;
				}

				index = displayStrings.IndexOf( ";", StringComparison.Ordinal );
				if ( index >= 0 )
				{
					currentDisplay = displayStrings.Substring( 0, index );
					displayStrings = displayStrings.Substring( index + 1 );
				}
				else
				{
					currentDisplay = displayStrings;
					displayStrings = string.Empty;
				}

				KeyGesture inputGesture = CreateFromResourceStrings( currentGesture, currentDisplay );
				if ( inputGesture != null )
				{
					if ( gestures == null )
					{
						gestures = new InputGestureCollection();
					}
					gestures.Add( inputGesture );
				}
			}
		} // SetupGestures

		// ----------------------------------------------------------------------
		private KeyGesture CreateFromResourceStrings( string keyGestureToken, string keyDisplayString )
		{
			if ( !string.IsNullOrEmpty( keyDisplayString ) )
			{
				keyGestureToken = keyGestureToken + ',' + keyDisplayString;
			}
			return ( keyGestureConverter.ConvertFromInvariantString( keyGestureToken ) as KeyGesture );
		} // CreateFromResourceStrings

		// ----------------------------------------------------------------------
		// members
		private InputGestureCollection gestures;

		private static readonly KeyGestureConverter keyGestureConverter = new KeyGestureConverter();

	} // class CommandDescription

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
