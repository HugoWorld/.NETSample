// -- FILE ------------------------------------------------------------------
// name       : UIElementInput.cs
// created    : Jani Giannoudis - 2008.04.16
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Input;

namespace Itenso.Solutions.Community.CommandDemo
{

	// ------------------------------------------------------------------------
	public class UIElementInput
	{

		// ----------------------------------------------------------------------
		public UIElementInput( UIElement uiElement )
		{
			if ( uiElement == null )
			{
				throw new ArgumentNullException( "uiElement" );
			}

			// keyboard
			uiElement.PreviewKeyDown += UIElelmentKeyDown;
			uiElement.KeyUp += UIElelmentKeyUp;

			// mouse
			uiElement.PreviewMouseDown += UIElelmentMouseDown;
			uiElement.MouseUp += UIElelmentMouseUp;

			//stylus
			uiElement.PreviewStylusDown += UIElelmentStylusDown;
			uiElement.StylusUp += UIElelmentStylusUp;
		} // UIElementInput

		// ----------------------------------------------------------------------
		public bool IsActiveEvent
		{
			get { return IsActiveKeyEvent || IsActiveMouseEvent || IsActiveStylusEvent; }
		} // IsActiveEvent

		// ----------------------------------------------------------------------
		public bool IsActiveKeyEvent
		{
			get { return activeKeyEvent != null; }
		} // IsActiveKeyEvent

		// ----------------------------------------------------------------------
		public KeyEventArgs ActiveKeyEvent
		{
			get { return activeKeyEvent; }
		} // ActiveKeyEvent

		// ----------------------------------------------------------------------
		public bool IsActiveMouseEvent
		{
			get { return activeMouseEvent != null; }
		} // IsActiveMouseEvent

		// ----------------------------------------------------------------------
		public MouseButtonEventArgs ActiveMouseEvent
		{
			get { return activeMouseEvent; }
		} // ActiveMouseEvent

		// ----------------------------------------------------------------------
		public bool IsActiveStylusEvent
		{
			get { return activeStylusEvent != null; }
		} // IsActiveStylusEvent

		// ----------------------------------------------------------------------
		public StylusDownEventArgs ActiveStylusEvent
		{
			get { return activeStylusEvent; }
		} // ActiveStylusEvent

		// ----------------------------------------------------------------------
		private void UIElelmentKeyDown( object sender, KeyEventArgs e )
		{
			activeKeyEvent = e;
		} // UIElelmentKeyDown

		// ----------------------------------------------------------------------
		private void UIElelmentKeyUp( object sender, KeyEventArgs e )
		{
			activeKeyEvent = null;
		} // UIElelmentKeyUp

		// ----------------------------------------------------------------------
		private void UIElelmentMouseDown( object sender, MouseButtonEventArgs e )
		{
			activeMouseEvent = e;
		} // UIElelmentMouseDown

		// ----------------------------------------------------------------------
		private void UIElelmentMouseUp( object sender, MouseButtonEventArgs e )
		{
			activeMouseEvent = null;
		} // UIElelmentMouseUp

		// ----------------------------------------------------------------------
		private void UIElelmentStylusDown( object sender, StylusDownEventArgs e )
		{
			activeStylusEvent = e;
		} // UIElelmentStylusDown

		// ----------------------------------------------------------------------
		private void UIElelmentStylusUp( object sender, StylusEventArgs e )
		{
			activeStylusEvent = null;
		} // UIElelmentStylusUp

		// ----------------------------------------------------------------------
		// members
		private KeyEventArgs activeKeyEvent;
		private MouseButtonEventArgs activeMouseEvent;
		private StylusDownEventArgs activeStylusEvent;

	} // class UIElementInput

} // namespace Itenso.Solutions.Community.CommandDemo
// -- EOF -------------------------------------------------------------------
