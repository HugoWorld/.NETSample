using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfBlendTextor
{
	public partial class CButton:Button
	{
        /// <summary>
        /// PressedBackgroundProperty属性注册
        /// </summary>
		 public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.DarkBlue));

         /// <summary>
         /// 鼠标按下背景样式
         /// </summary>
         public Brush PressedBackground
         {
             get { return (Brush)GetValue(PressedBackgroundProperty); }
             set { SetValue(PressedBackgroundProperty, value); }
         }


         public static readonly DependencyProperty PressedForegroundProperty =
             DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.White));
         /// <summary>
         /// 鼠标按下前景样式（图标、文字）
         /// </summary>
         public Brush PressedForeground
         {
             get { return (Brush)GetValue(PressedForegroundProperty); }
             set { SetValue(PressedForegroundProperty, value); }
         }

         public static readonly DependencyProperty MouseOverBackgroundProperty =
           DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.RoyalBlue));
         /// <summary>
         /// 鼠标进入背景样式
         /// </summary>
         public Brush MouseOverBackground
         {
             get { return (Brush)GetValue(MouseOverBackgroundProperty); }
             set { SetValue(MouseOverBackgroundProperty, value); }
         }

         public static readonly DependencyProperty MouseOverForegroundProperty =
             DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(CButton), new PropertyMetadata(Brushes.White));
         /// <summary>
         /// 鼠标进入前景样式
         /// </summary>
         public Brush MouseOverForeground
         {
             get { return (Brush)GetValue(MouseOverForegroundProperty); }
             set { SetValue(MouseOverForegroundProperty, value); }
         }
       
        
        public static readonly DependencyProperty FIconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(CButton), new PropertyMetadata("\ue604"));
         /// <summary>
         /// 按钮字体图标编码
         /// </summary>
         public string Icon
         {
             get { return (string)GetValue(FIconProperty); }
             set { SetValue(FIconProperty, value); }
         }

         public static readonly DependencyProperty FIconSizeProperty =
             DependencyProperty.Register("IconSize", typeof(int), typeof(CButton), new PropertyMetadata(20));
         /// <summary>
         /// 按钮字体图标大小
         /// </summary>
         public int IconSize
         {
             get { return (int)GetValue(FIconSizeProperty); }
             set { SetValue(FIconSizeProperty, value); }
         }

         public static readonly DependencyProperty FIconMarginProperty =
             DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(CButton), new PropertyMetadata(new Thickness(0, 1, 3, 1)));
         /// <summary>
         /// 字体图标间距
         /// </summary>
         public Thickness IconMargin
         {
             get { return (Thickness)GetValue(FIconMarginProperty); }
             set { SetValue(FIconMarginProperty, value); }
         }

         public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.Register(
           "AllowsAnimation", typeof(bool), typeof(CButton), new PropertyMetadata(true));
         
        /// <summary>
         /// 是否启用Ficon动画
         /// </summary>
         public bool AllowsAnimation
         {
             get { return (bool)GetValue(AllowsAnimationProperty); }
             set { SetValue(AllowsAnimationProperty, value); }
         }

         public static readonly DependencyProperty CornerRadiusProperty =
             DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CButton), new PropertyMetadata(new CornerRadius(2)));
        
        /// <summary>
         /// 按钮圆角大小,左上，右上，右下，左下
         /// </summary>
         public CornerRadius CornerRadius
         {
             get { return (CornerRadius)GetValue(CornerRadiusProperty); }
             set { SetValue(CornerRadiusProperty, value); }
         }

         public static readonly DependencyProperty ContentDecorationsProperty = 
             DependencyProperty.Register("ContentDecorations", typeof(TextDecorationCollection), typeof(CButton), new PropertyMetadata(null));
        
         /// <summary>
         /// TextDecorationCollection 类指定应用于文本的文本修饰的类型。 
         /// 文本修饰的四种类型︰ 下划线、 基线、 删除线和上划线。
         /// 这些被称为 TextDecorationLocation 中每一项设置的值
         /// </summary>
        public TextDecorationCollection ContentDecorations
         {
             get { return (TextDecorationCollection)GetValue(ContentDecorationsProperty); }
             set { SetValue(ContentDecorationsProperty, value); }
         }

        static CButton()
        {
            //DefaultStyleKeyProperty
            //当此依赖项属性位于指定类型的实例上时为其提供替换元数据，
            //而不是在最初注册依赖项属性时提供的元数据。重载此成员。
            //作用：可以先把wpf 控件的类先定义好,然后用DefaultStyleKeyProperty把类与xaml数据关联起来
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CButton), new FrameworkPropertyMetadata(typeof(CButton)));
        }
	}
}