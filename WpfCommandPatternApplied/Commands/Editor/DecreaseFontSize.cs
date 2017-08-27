// -- FILE ------------------------------------------------------------------
// name       : DecreaseFontSize.cs
// created    : Jani Giannoudis - 2008.04.15
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using Itenso.Windows.Input;

namespace Itenso.Solutions.Community.Commands.Editor
{

	// ------------------------------------------------------------------------
	public class DecreaseFontSize : EditFontSizeCommand
	{

		// ----------------------------------------------------------------------
		public DecreaseFontSize( Type ownerType, CommandDescription description ) :
			base( "DecreaseFontSize", ownerType, description )
		{
		} // DecreaseFontSize

		// ----------------------------------------------------------------------
		public static double MinFontSize
		{
			get { return minFontSize; }
			set { minFontSize = value; }
		} // MinFontSize

		// ----------------------------------------------------------------------
		public static double DecreaseSize
		{
			get { return decreaseSize; }
			set { decreaseSize = value; }
		} // DecreaseSize

		// ----------------------------------------------------------------------
		protected override bool OnCanExecute( EditorCommandContext commandContext )
		{
			if ( !base.OnCanExecute( commandContext ) )
			{
				return false;
			}

			double? fontSize = GetFontSize( commandContext.Selection );
			return fontSize.HasValue && fontSize > minFontSize;
		} // OnCanExecute

		// ----------------------------------------------------------------------
		protected override void OnExecute( EditorCommandContext commandContext )
		{
			double? fontSize = GetFontSize( commandContext.Selection );
			if ( fontSize.HasValue )
			{
				SetFontSize( commandContext.Selection, fontSize.Value + decreaseSize );
			}
		} // OnExecute

		// ----------------------------------------------------------------------
		// members
		private static double minFontSize = 5;
		private static double decreaseSize = -1;

	} // class DecreaseFontSize

} // namespace Itenso.Solutions.Community.Commands.Editor
// -- EOF -------------------------------------------------------------------
