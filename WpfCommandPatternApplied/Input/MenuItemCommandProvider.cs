// -- FILE ------------------------------------------------------------------
// name       : MenuItemCommandProvider.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Controls;

namespace Itenso.Windows.Input
{

	// ------------------------------------------------------------------------
	public static class MenuItemCommandProvider
	{

		// ----------------------------------------------------------------------
		public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
			"Command",
			typeof( ICommand ),
			typeof( MenuItemCommandProvider ),
			new FrameworkPropertyMetadata( OnCommandInvalidated ) );

		// ----------------------------------------------------------------------
		public static bool UseCommandImage
		{
			get { return useCommandImage; }
			set { useCommandImage = value; }
		} // UseCommandImage

		// ----------------------------------------------------------------------
		public static CommandToolTipStyle ToolTipStyle
		{
			get { return toolTipStyle; }
			set { toolTipStyle = value; }
		} // ToolTipStyle

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
		private static void OnCommandInvalidated( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e )
		{
			MenuItem menuItem = dependencyObject as MenuItem;
			if ( menuItem == null )
			{
				throw new InvalidOperationException( "menu item required" );
			}

			ICommand newCommand = e.NewValue as ICommand;
			if ( newCommand == null )
			{
				throw new InvalidOperationException( "command required" );
			}
			menuItem.Command = newCommand;

			RoutedCommand routedCommand = newCommand as RoutedCommand;
			Command command = newCommand as Command;

			// image
			if ( useCommandImage && menuItem.Icon == null && command != null )
			{
				Uri imageUri = CommandImageService.GetCommandImageUri( command );
				if ( imageUri != null )
				{
					MenuItemImage image = new MenuItemImage();
					image.Source = new BitmapImage( imageUri );
					menuItem.Icon = image;
				}
			}

			// tooltip
			if ( menuItem.ToolTip == null && command != null )
			{
				menuItem.ToolTip = CommandToolTipService.GetCommandToolTip( command, toolTipStyle );
			}
			if ( menuItem.ToolTip is string && routedCommand != null )
			{
				menuItem.ToolTip = CommandToolTipService.FormatToolTip( routedCommand, menuItem.ToolTip as string, toolTipStyle );
			}
			CommandToolTipService.SetShowOnDisabled( menuItem, toolTipStyle );
		} // OnCommandInvalidated

		// ----------------------------------------------------------------------
		// members
		private static bool useCommandImage = true;
		private static CommandToolTipStyle toolTipStyle = CommandToolTipStyle.None;

	} // class MenuItemCommandProvider

} // namespace Itenso.Windows.Input
// -- EOF -------------------------------------------------------------------
