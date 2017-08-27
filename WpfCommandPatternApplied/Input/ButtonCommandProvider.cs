// -- FILE ------------------------------------------------------------------
// name       : ButtonCommandProvider.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public static class ButtonCommandProvider
	{

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.RegisterAttached(
				"Command",
				typeof( ICommand ),
				typeof( ButtonCommandProvider ),
				new FrameworkPropertyMetadata( OnCommandInvalidated ) );

		// ----------------------------------------------------------------------
		public static bool UseCommandImage
		{
			get { return useCommandImage; }
			set { useCommandImage = value; }
		} // UseCommandImage

		// ----------------------------------------------------------------------
		public static bool ShowDisabledState
		{
			get { return showDisabledState; }
			set { showDisabledState = value; }
		} // ShowDisabledState

		// ----------------------------------------------------------------------
		public static CommandToolTipStyle ToolTipStyle
		{
			get { return toolTipStyle; }
			set { toolTipStyle = value; }
		} // ToolTipStyle

		// ----------------------------------------------------------------------
		public static double DisabledOpacity
		{
			get { return disabledOpacity; }
			set { disabledOpacity = value; }
		} // DisabledOpacity

		// ----------------------------------------------------------------------
		public static ICommand GetCommand( DependencyObject sender )
		{
			return sender.GetValue( CommandProperty ) as ICommand;
		} // GetCommand

		// ----------------------------------------------------------------------
		public static void SetCommand( DependencyObject sender, ICommand command )
		{
			sender.SetValue( CommandProperty, command );
		} // SetCommand

		// ----------------------------------------------------------------------
		private static void UpdateButton( Button button )
		{
			UIElement uiElement = button.Content as UIElement;
			if ( uiElement != null )
			{
				uiElement.Opacity = button.IsEnabled ? 1.0 : disabledOpacity;
			}
		} // UpdateButton

		// ----------------------------------------------------------------------
		private static void OnCommandInvalidated( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			Button button = dependencyObject as Button;
			if ( button == null )
			{
				throw new InvalidOperationException( "button required" );
			}

			ICommand newCommand = e.NewValue as ICommand;
			if ( newCommand == null )
			{
				throw new InvalidOperationException( "command required" );
			}
			button.Command = newCommand;

			RoutedCommand routedCommand = newCommand as RoutedCommand;
			Command command = newCommand as Command;

			// image
			if ( useCommandImage && button.Content == null && command != null )
			{
				Uri imageUri = CommandImageService.GetCommandImageUri( command );
				if ( imageUri != null )
				{
					ButtonImage image = new ButtonImage();
					image.Source = new BitmapImage( imageUri );
					button.Content = image;
				}
			}

			// tooltip
			if ( button.ToolTip == null && command != null )
			{
				button.ToolTip = CommandToolTipService.GetCommandToolTip( command, toolTipStyle );
			}
			if ( button.ToolTip is string && routedCommand != null )
			{
				button.ToolTip = CommandToolTipService.FormatToolTip( routedCommand, button.ToolTip as string, toolTipStyle );
			}
			CommandToolTipService.SetShowOnDisabled( button, toolTipStyle );

			if ( showDisabledState )
			{
				UpdateButton( button );
				DependencyPropertyDescriptor.FromProperty(
					UIElement.IsEnabledProperty,
					typeof( Button ) ).AddValueChanged( button, ButtonIsEnabledChanged );
			}
		} // OnCommandInvalidated

		// ----------------------------------------------------------------------
		private static void ButtonIsEnabledChanged( object sender, EventArgs e )
		{
			Button button = sender as Button;
			if ( button == null )
			{
				return;
			}
			UpdateButton( button );
		} // ButtonIsEnabledChanged

		// ----------------------------------------------------------------------
		// members
		private static bool useCommandImage = true;
		private static bool showDisabledState = true;
		private static CommandToolTipStyle toolTipStyle = CommandToolTipStyle.None;
		private static double disabledOpacity = 0.25;

	} // class ButtonCommandProvider

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
