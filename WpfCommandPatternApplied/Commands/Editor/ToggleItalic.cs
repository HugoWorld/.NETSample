// -- FILE ------------------------------------------------------------------
// name       : ToggleItalic.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Documents;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class ToggleItalic : EditorSelectionFormatCommand
	{

		// ----------------------------------------------------------------------
		public ToggleItalic( Type ownerType, CommandDescription description ) :
			base( "ToggleItalic", ownerType, description )
		{
		} // ToggleItalic

		// ----------------------------------------------------------------------
		public FontStyle ItalicFontStyle
		{
			get { return italicFontStyle; }
			set { italicFontStyle = value; }
		} // ItalicFontStyle

		// ----------------------------------------------------------------------
		protected override DependencyProperty FormatProperty
		{
			get { return FlowDocument.FontStyleProperty; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object FormatValue
		{
			get { return italicFontStyle; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object DefaultValue
		{
			get { return FontStyles.Normal; }
		} // DefaultValue

		// ----------------------------------------------------------------------
		// members
		private FontStyle italicFontStyle = FontStyles.Italic;

	} // class ToggleItalic

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
