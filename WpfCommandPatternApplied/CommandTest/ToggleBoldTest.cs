// -- FILE ------------------------------------------------------------------
// name       : ToggleBoldTest.cs
// created    : Jani Giannoudis - 2008.04.18
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------

using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Itenso.Solutions.Community.Commands.Editor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Itenso.Solutions.Community.CommandTest
{

	// ------------------------------------------------------------------------
	[TestClass]
	public class ToggleBoldTest
	{

		// ----------------------------------------------------------------------
		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		// ----------------------------------------------------------------------
		[TestMethod]
		public void TestToggleCanExecute()
		{
			EditorCommandContext commandContext = CreateCommandContext();

			// disabled
			commandContext.Selection.Select( commandContext.Document.ContentStart, commandContext.Document.ContentStart );
			Assert.AreEqual( true, commandContext.Selection.IsEmpty );
			bool canExecute = RichTextEditorCommands.ToggleBold.CanExecute( commandContext );
			Assert.AreEqual( false, canExecute );

			// tests
			TextRange textContent = new TextRange( commandContext.Document.ContentStart, commandContext.Document.ContentEnd );
			commandContext.Selection.Select( textContent.Start, textContent.End );
			Assert.AreEqual( false, commandContext.Selection.IsEmpty );

			canExecute = RichTextEditorCommands.ToggleBold.CanExecute( commandContext );
			Assert.AreEqual( true, canExecute );
		} // TestToggleCanExecute

		// ----------------------------------------------------------------------
		[TestMethod]
		public void TestToggleBoldDefault()
		{
			EditorCommandContext commandContext = CreateCommandContext();

			// setup selection
			TextRange startContent = new TextRange( commandContext.Document.ContentStart, commandContext.Document.ContentEnd );
			commandContext.Selection.Select( startContent.Start, startContent.End );
			commandContext.Selection.ApplyPropertyValue( FlowDocument.FontWeightProperty, FontWeights.Normal );
			string startText = startContent.Text;

			// run the command
			FontWeight defaultFontWeigth = RichTextEditorCommands.ToggleBold.BoldFontWeight;
			RichTextEditorCommands.ToggleBold.Execute( commandContext );

			// tests
			TextRange endContent = new TextRange( commandContext.Document.ContentStart, commandContext.Document.ContentEnd );
			string endText = endContent.Text;
			Assert.AreEqual( startText, endText );

			object selectionFontWeight = commandContext.Selection.GetPropertyValue( FlowDocument.FontWeightProperty );
			Assert.AreEqual( defaultFontWeigth, selectionFontWeight );
		} // TestToggleBoldDefault

		// ----------------------------------------------------------------------
		[TestMethod]
		public void TestToggleBoldCustom()
		{
			EditorCommandContext commandContext = CreateCommandContext();

			// setup selection
			TextRange startContent = new TextRange( commandContext.Document.ContentStart, commandContext.Document.ContentEnd );
			commandContext.Selection.Select( startContent.Start, startContent.End );
			commandContext.Selection.ApplyPropertyValue( FlowDocument.FontWeightProperty, FontWeights.Normal );
			string startText = startContent.Text;

			// run the command
			RichTextEditorCommands.ToggleBold.BoldFontWeight = FontWeights.ExtraBold;
			RichTextEditorCommands.ToggleBold.Execute( commandContext );

			// tests
			TextRange endContent = new TextRange( commandContext.Document.ContentStart, commandContext.Document.ContentEnd );
			string endText = endContent.Text;
			Assert.AreEqual( startText, endText );

			object selectionFontWeight = commandContext.Selection.GetPropertyValue( FlowDocument.FontWeightProperty );
			Assert.AreEqual( FontWeights.ExtraBold, selectionFontWeight );
		} // TestToggleBoldDefault

		// ----------------------------------------------------------------------
		private EditorCommandContext CreateCommandContext()
		{
			// document
			FlowDocument flowDocument = new FlowDocument();

			for ( int i = 0; i < 10; i++ )
			{
				Paragraph paragraph = new Paragraph();
				for ( int n = 0; n < 5; n++ )
				{
					paragraph.Inlines.Add( new Run( "Paragraph Text " + n.ToString( CultureInfo.InvariantCulture ) + " " ) );
				}
				flowDocument.Blocks.Add( paragraph );
			}

			// editor
			RichTextBox richTextBox = new RichTextBox();
			richTextBox.Document = flowDocument;

			// command context
			return new EditorCommandContext( richTextBox );
		} // CreateCommandContext

		// ----------------------------------------------------------------------
		// members
	} // class ToggleBoldTest

} // namespace Itenso.Solutions.Community.CommandTest
// -- EOF -------------------------------------------------------------------
