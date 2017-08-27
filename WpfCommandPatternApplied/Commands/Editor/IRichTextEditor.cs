// -- FILE ------------------------------------------------------------------
// name       : IRichTextEditor.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System.Windows.Controls;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public interface IRichTextEditor
	{

		// ----------------------------------------------------------------------
		RichTextBox TextBox { get; }

	} // interface IRichTextEditor

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
