// -- FILE ------------------------------------------------------------------
// name       : ChangeFontFamily.cs
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
	public class ChangeFontFamily : EditorSelectionCommand
	{

		// ----------------------------------------------------------------------
		public ChangeFontFamily( Type ownerType, CommandDescription description ) :
			base( "ChangeFontFamily", ownerType, description )
		{
		} // ChangeFontFamily

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			TextSelection selection = commandContext.Selection;
			selection.ApplyPropertyValue( TextElement.FontFamilyProperty, commandContext.CommandParameter );
		} // OnExecute

	} // class ChangeFontFamily

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
