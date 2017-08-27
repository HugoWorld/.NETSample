// -- FILE ------------------------------------------------------------------
// name       : ToggleBold.cs
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
	public class ToggleBold : EditorSelectionFormatCommand
	{

		// ----------------------------------------------------------------------
		public ToggleBold( Type ownerType, CommandDescription description ) :
			base( "ToggleBold", ownerType, description )
		{
		} // ToggleBold

		// ----------------------------------------------------------------------
		public FontWeight BoldFontWeight
		{
			get { return boldFontWeight; }
			set { boldFontWeight = value; }
		} // BoldFontWeight

		// ----------------------------------------------------------------------
		protected override DependencyProperty FormatProperty
		{
			get { return FlowDocument.FontWeightProperty; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object FormatValue
		{
			get { return boldFontWeight; }
		} // FormatProperty

		// ----------------------------------------------------------------------
		protected override object DefaultValue
		{
			get { return FontWeights.Normal; }
		} // DefaultValue

		// ----------------------------------------------------------------------
		// members
		private FontWeight boldFontWeight = FontWeights.Bold;

	} // class ToggleBold

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
