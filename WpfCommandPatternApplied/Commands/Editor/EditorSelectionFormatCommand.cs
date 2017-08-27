// -- FILE ------------------------------------------------------------------
// name       : EditorSelectionFormatCommand.cs
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
	public abstract class EditorSelectionFormatCommand : EditorSelectionCommand
	{

		// ----------------------------------------------------------------------
		protected EditorSelectionFormatCommand( string name, Type ownerType, CommandDescription description ) :
			base( name, ownerType, description )
		{
		} // EditorSelectionFormatCommand

		// ----------------------------------------------------------------------
		protected abstract DependencyProperty FormatProperty { get; }

		// ----------------------------------------------------------------------
		protected abstract object FormatValue { get; }

		// ----------------------------------------------------------------------
		protected abstract object DefaultValue { get; }

		// ----------------------------------------------------------------------
		protected virtual void OnSelectionChange( TextSelection selection, object formatValue, object defaultValue )
		{
			DependencyProperty formatProperty = FormatProperty;
			object selectionValue = selection.GetPropertyValue( formatProperty );
			selection.ApplyPropertyValue( formatProperty, !selectionValue.Equals( formatValue ) ? formatValue : defaultValue );
		} // OnSelectionChange

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			OnSelectionChange( commandContext.Selection, FormatValue, DefaultValue );
		} // OnExecute

	} // class EditorSelectionFormatCommand

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
