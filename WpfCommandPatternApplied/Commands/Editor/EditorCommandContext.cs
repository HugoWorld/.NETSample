// -- FILE ------------------------------------------------------------------
// name       : EditorCommandContext.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Windows.Controls;
using System.Windows.Documents;
using Itenso.Solutions.Community.Commands.Application;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class EditorCommandContext : ApplicationCommandContext
	{

		// ----------------------------------------------------------------------
		public EditorCommandContext( RichTextBox textBox ) :
			this( null, null, null, textBox )
		{
		} // EditorCommandContext

		// ----------------------------------------------------------------------
		public EditorCommandContext( object bindingSource, object commandSource, object commandParameter, RichTextBox textBox ) :
			base( bindingSource, commandSource, commandParameter )
		{
			if ( textBox == null )
			{
				throw new ArgumentNullException( "textBox" );
			}

			this.textBox = textBox;
		} // EditorCommandContext

		// ----------------------------------------------------------------------
		public RichTextBox TextBox
		{
			get { return textBox; }
		} // TextBox

		// ----------------------------------------------------------------------
		public FlowDocument Document
		{
			get { return textBox.Document; }
		} // Document

		// ----------------------------------------------------------------------
		public bool HasSelection
		{
			get { return !Selection.IsEmpty; }
		} // HasSelection

		// ----------------------------------------------------------------------
		public TextSelection Selection
		{
			get { return textBox.Selection; }
		} // Selection

		// ----------------------------------------------------------------------
		// members
		private readonly RichTextBox textBox;

	} // class EditorCommandContext

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
