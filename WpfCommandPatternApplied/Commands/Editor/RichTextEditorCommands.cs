// -- FILE ------------------------------------------------------------------
// name       : RichTextEditorCommands.cs
// created    : Jani Giannoudis - 2008.04.13
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class RichTextEditorCommands : CommandCollection
	{

		// ----------------------------------------------------------------------
		public static EditUndo EditUndo;
		public static EditRedo EditRedo;

		public static ChangeFontFamily ChangeFontFamily;

		public static ToggleBold ToggleBold;
		public static ToggleItalic ToggleItalic;
		public static ToggleUnderline ToggleUnderline;

		public static IncreaseFontSize IncreaseFontSize;
		public static DecreaseFontSize DecreaseFontSize;

		public static IncreaseIndentation IncreaseIndentation;
		public static DecreaseIndentation DecreaseIndentation;

		// ----------------------------------------------------------------------
		public RichTextEditorCommands()
		{
			Add( EditUndo );
			Add( EditRedo );

			Add( ChangeFontFamily );

			Add( ToggleBold );
			Add( ToggleItalic );
			Add( ToggleUnderline );

			Add( IncreaseFontSize );
			Add( DecreaseFontSize );

			Add( IncreaseIndentation );
			Add( DecreaseIndentation );
		} // RichTextEditorCommands

		// ----------------------------------------------------------------------
		static RichTextEditorCommands()
		{
			EditUndo =
				new EditUndo(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandEditUndoText,
						Properties.Resources.CommandEditUndoDescription,
						Properties.Resources.CommandEditUndoGestures ) );

			EditRedo =
				new EditRedo(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandEditRedoText,
						Properties.Resources.CommandEditRedoDescription,
						Properties.Resources.CommandEditRedoGestures ) );

			ChangeFontFamily =
				new ChangeFontFamily(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandChangeFontFamilyText,
						Properties.Resources.CommandChangeFontFamilyDescription,
						Properties.Resources.CommandChangeFontFamilyGestures ) );

			ToggleBold =
				new ToggleBold(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandToggleBoldText,
						Properties.Resources.CommandToggleBoldDescription,
						Properties.Resources.CommandToggleBoldGestures ) );

			ToggleItalic =
				new ToggleItalic(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandToggleItalicText,
						Properties.Resources.CommandToggleItalicDescription,
						Properties.Resources.CommandToggleItalicGestures ) );

			ToggleUnderline =
				new ToggleUnderline(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandToggleUnderlineText,
						Properties.Resources.CommandToggleUnderlineDescription,
						Properties.Resources.CommandToggleUnderlineGestures ) );

			IncreaseFontSize =
				new IncreaseFontSize(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandIncreaseFontSizeText,
						Properties.Resources.CommandIncreaseFontSizeDescription ) );

			DecreaseFontSize =
				new DecreaseFontSize(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandDecreaseFontSizeText,
						Properties.Resources.CommandDecreaseFontSizeDescription ) );

			IncreaseIndentation =
				new IncreaseIndentation(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandIncreaseIndentationText,
						Properties.Resources.CommandIncreaseIndentationDescription ) );

			DecreaseIndentation =
				new DecreaseIndentation(
					typeof( RichTextEditorCommands ),
					new CommandDescription(
						Properties.Resources.CommandDecreaseIndentationText,
						Properties.Resources.CommandDecreaseIndentationDescription ) );

		} // RichTextEditorCommands

	} // class RichTextEditorCommands

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
