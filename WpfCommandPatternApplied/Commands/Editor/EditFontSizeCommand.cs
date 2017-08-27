// -- FILE ------------------------------------------------------------------
// name       : EditFontSizeCommand.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Documents;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public abstract class EditFontSizeCommand : EditorSelectionCommand
	{

		// ----------------------------------------------------------------------
		protected EditFontSizeCommand( string name, Type ownerType, CommandDescription description ) :
			base( name, ownerType, description )
		{
		} // EditFontSizeCommand

		// ----------------------------------------------------------------------
		protected override bool SelectionRequired
		{
			get { return false; }
		} // SelectionRequired

		// ----------------------------------------------------------------------
		protected double? GetFontSize( TextSelection textSelection )
		{
			object fontSize = textSelection.GetPropertyValue( FlowDocument.FontSizeProperty );
			if ( fontSize == null || fontSize.GetType() != typeof( double ) )
			{
				return null; // in case when font size is 'UnsetValue' (multiple selection)
			}
			return (double)fontSize;
		} // GetFontSize

		// ----------------------------------------------------------------------
		protected void SetFontSize( TextSelection textSelection, double fontSize )
		{
			textSelection.ApplyPropertyValue( FlowDocument.FontSizeProperty, fontSize );
		} // GetFontSize

	} // class EditFontSizeCommand

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
