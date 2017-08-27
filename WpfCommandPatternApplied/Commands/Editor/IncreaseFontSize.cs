// -- FILE ------------------------------------------------------------------
// name       : IncreaseFontSize.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class IncreaseFontSize : EditFontSizeCommand
	{

		// ----------------------------------------------------------------------
		public IncreaseFontSize( Type ownerType, CommandDescription description ) :
			base( "IncreaseFontSize", ownerType, description )
		{
		} // IncreaseFontSize

		// ----------------------------------------------------------------------
		public static double MaxFontSize
		{
			get { return maxFontSize; }
			set { maxFontSize = value; }
		} // MaxFontSize

		// ----------------------------------------------------------------------
		public static double IncreaseSize
		{
			get { return increaseSize; }
			set { increaseSize = value; }
		} // IncreaseSize

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( EditorCommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}

			double? fontSize = GetFontSize( commandContext.Selection );
			return fontSize.HasValue && fontSize < maxFontSize;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			double? fontSize = GetFontSize( commandContext.Selection );
			if ( fontSize.HasValue )
			{
				SetFontSize( commandContext.Selection, fontSize.Value + increaseSize );
			}
		} // OnExecute

		// ----------------------------------------------------------------------
		// members
		private static double maxFontSize = 25;
		private static double increaseSize = 1;

	} // class IncreaseFontSize

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
