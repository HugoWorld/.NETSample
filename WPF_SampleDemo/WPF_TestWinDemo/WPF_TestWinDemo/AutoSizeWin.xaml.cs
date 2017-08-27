using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;


namespace WPF_TestWinDemo
{
    /// <summary>
    /// AutoSizeWin.xaml 的交互逻辑
    /// </summary>
    public partial class AutoSizeWin : Window
    {
        public AutoSizeWin()
        {
            InitializeComponent();
            
    
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string TextContent = "你好我是吴嘉杰，1很高兴认识你！！！！";
            tb1.Text = TextContent;
         
           
            FontInfo scaleInfo = CalFontSize.AutoFitFontSize(TextContent,10,tb1.Width,tb1);
            tb1.FontSize = scaleInfo.fontSize;
            tb1.Text = scaleInfo.Content;
        }
    }
    public class CalFontSize
    {
         /// <summary>
        /// Measures the size of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="fontWeight">The font weight.</param>
        /// <param name="fontStretch">The font stretch.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <returns></returns>
        public static Size MeasureTextSize( string text, FontFamily fontFamily,
                                                          FontStyle fontStyle,
                                                          FontWeight fontWeight,
                                                          FontStretch fontStretch,
                                                          double fontSize)
        {
            FormattedText ft = new FormattedText(text, CultureInfo.CurrentCulture,
                                                 System.Windows.FlowDirection.LeftToRight,
                                                 new Typeface(fontFamily, fontStyle, fontWeight, fontStretch),
                                                 fontSize,
                                                 Brushes.Black);
            return new Size(ft.Width, ft.Height);
        }
        /// <summary>
        /// Get the required height and width of the specified text. Uses Glyph's
        /// </summary>
        public static Size MeasureText(string text, FontFamily fontFamily,
                                                     FontStyle fontStyle, 
                                                     FontWeight fontWeight,
                                                     FontStretch fontStretch, 
                                                     double fontSize)
        {
            Typeface typeface = new Typeface(fontFamily, fontStyle, fontWeight, fontStretch);
            GlyphTypeface glyphTypeface;
            //根据当前的字体类获取字体的Size
            //若GlyphTypeface对象为非空时，直接使用Typeface的TryGetGlyphTypeface方法获取
            if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
            {
                return MeasureTextSize(text, fontFamily, fontStyle, fontWeight, fontStretch, fontSize);
            }
            //若glyphTypeface对象为空时
            double totalWidth = 0;
            double height = 0;
            for (int n = 0; n < text.Length; n++)
            {
                //对字符串中每个字符的Unicode码位映射到标志符索引
                ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];
                //获取GlyphTypeface对象代表的字符串中每个字符的宽度
                double width = glyphTypeface.AdvanceWidths[glyphIndex] * fontSize;
                //获取GlyphTypeface对象代表的字符串的高度
                double glyphHeight = glyphTypeface.AdvanceHeights[glyphIndex] * fontSize;
                if (glyphHeight > height)
                {
                    height = glyphHeight;
                }
                totalWidth += width;
            }
            return new Size(totalWidth, height);
        }
        public static FontInfo GetFontInfo(string text,UIElement uicontrol)
        {
      
            if (uicontrol is TextBlock)
            {
                TextBlock tb = (TextBlock)uicontrol;
                FontFamily ff=tb.FontFamily;
                FontStyle fstyle=tb.FontStyle;
                FontWeight fw=tb.FontWeight;
                FontStretch fstretch=tb.FontStretch;
                double fontsize = tb.FontSize;
                GlyphTypeface glyphTypeface;
                Typeface typeface = new Typeface(ff, fstyle, fw, fstretch);
                if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
                { throw new InvalidOperationException("No glyphtypeface found"); }
                else
                {
                    FontInfo curInfo = new FontInfo();
                    int index = 0;
                    //对字符串中每个字符的Unicode码位映射到标志符索引
                    ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[index]];
                    //获取GlyphTypeface对象代表的字符串中每个字符的宽度
                    double width = glyphTypeface.AdvanceWidths[glyphIndex] * fontsize;
                    curInfo.Width = (int)width;
                    //获取GlyphTypeface对象代表的字符串的高度
                    double height = glyphTypeface.AdvanceHeights[glyphIndex] * fontsize;
                    curInfo.Height = (int)height;
                    curInfo.Content = text;
                    curInfo.fontSize = (int)fontsize;
                    return curInfo;
                }
            }
            else
            {
                FontInfo fi = new FontInfo();
                return fi;
            }        
        }
        /// <summary>
        /// Limits the size of the control font.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="fontWeight">The font weight.</param>
        /// <param name="fontStretch">The font stretch.</param>
        /// <param name="fontSize">Size of the font.</param>
        public static FontInfo AutoFitFontSize(string text,int MinFontSize,double width, UIElement uicontrol)                                                             
        {
            if (uicontrol is TextBlock)
            {
                TextBlock tb = (TextBlock)uicontrol;
                FontFamily ff = tb.FontFamily;
                FontStyle fstyle = tb.FontStyle;
                FontWeight fw = tb.FontWeight;
                FontStretch fstretch = tb.FontStretch;
                double fontsize=tb.FontSize;
                //获取当前单个字体信息
                FontInfo autoFont = GetFontInfo(text,uicontrol);
                //缩小后的字体大小
                int lastFontSize = 0;

                #region 根据字符串长度调节字体大小
                ////缩小后的整体尺寸
                //Size size;
                ////获取字体大小与阈值作判断，缩小字体大小
                //for (int i = Convert.ToInt32(fontSize); i > MinFontSize; i--)
                //{
                //    //获取缩小后整体字符串的Size
                //    size = MeasureText(text, fontFamily, fontStyle, fontWeight, fontStretch, i);
                //    //若标签宽度大于当前字体宽度，字体大小再减一
                //    if (width >size.Width )
                //    {
                //        lastFontSize = i - 1;
                //        break;
                //    }
                //}
                #endregion

                //自动调节后整体的字体尺寸大小
                autoFont.fontSize = (int)fontsize;

                #region 获取缩小后的字符大小信息

                ////缩小后整体字符串宽度
                //Size Fitsize = MeasureText(text, fontFamily, fontStyle, fontWeight, fontStretch, lastFontSize);

                //////获取缩小后单个字体的信息
                ////FontInfo curFontInfo = GetFontInfo(text, lastFontSize, fontFamily, fontStyle, fontWeight, fontStretch);
                #endregion

                int perFontWidth = autoFont.Width;
                int SetFontWidth = 8 * perFontWidth;
                Size size = MeasureText(text, ff, fstyle, fw, fstretch, fontsize);
                int totalWidth = (int)size.Width;
                //如果字符串大于8个
                if (totalWidth > SetFontWidth)
                {
                    var textTemp = text.Substring(0, 8);
                    string lastControlContent = textTemp + "...";
                    autoFont.Content = lastControlContent;
                }

                return autoFont;
            } 
            else
            {
                FontInfo fi = new FontInfo();
                return fi;
            }
        }

    }
    public struct FontInfo
    {
        public string Content;
        public int fontSize;
        public int Width;
        public int Height;
        public FontFamily fontfamily;
        public FontStyle fontStyle;
        public FontWeight fontWeight;
        public FontStretch fontStretch;
    }

}
