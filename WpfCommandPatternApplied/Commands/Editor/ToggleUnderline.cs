// -- FILE ------------------------------------------------------------------
// name       : ToggleUnderline.cs
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
	public class ToggleUnderline : EditorSelectionFormatCommand
	{

		// ----------------------------------------------------------------------
		public ToggleUnderline( Type ownerType, CommandDescription description ) :
			base( "ToggleUnderline", ownerType, description )
		{
		} // ToggleUnderline

		// ----------------------------------------------------------------------
		public TextDecorationCollection UnderlineTextDecoration
		{
			get { return underlineTextDecoration; }
			set { underlineTextDecoration = value; }
		} // UnderlineTextDecoration

		// ----------------------------------------------------------------------
		protected override DependencyProperty FormatProperty
		{
			get { return Inline.TextDecorationsProperty; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object FormatValue
		{
			get { return underlineTextDecoration; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object DefaultValue
		{
			get { return null; }
		} // DefaultValue

		// ----------------------------------------------------------------------
		// members
		private TextDecorationCollection underlineTextDecoration = TextDecorations.Baseline;

	} // class ToggleUnderline

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
