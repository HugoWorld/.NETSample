   M S B A M L   `   `   `  ����  WPFStoryboard    WPFStoryboard.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      :d2http://schemas.microsoft.com/expression/blend/2008  6B   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6   -   5          �Name$  Window��5       � Title$' !WPF中的故事板控制(Window1)��5      $	��640��5      $	��480��6    � WindowStartupLocation$ CenterScreen=�6    � 	Resources 5	         Storyboard1 g� Duration T� Source �� TargetProperty �� 
TargetName T� PathGeometry��%�  &	        �� 5
      .��5      T� $ 0:0:5D�6   $ X=�6/   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6:   $ ellipse1��6�    5      B� 5      $����M489,-17.5 C489,12.599519 395.42751,37 280,37 C164.57249,37 71,12.599519 71,-17.5 C71,-47.599519 164.57249,-72 280,-72 C395.42751,-72 489,-47.599519 489,-17.5 zC�6   5      T� 5      $ 0:0:5D�6   $ Y=�6/   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6:   $ ellipse1��6�    5      B� 5      $����M489,-17.5 C489,12.599519 395.42751,37 280,37 C164.57249,37 71,12.599519 71,-17.5 C71,-47.599519 164.57249,-72 280,-72 C395.42751,-72 489,-47.599519 489,-17.5 zC�6   5      5      5      	 � Triggers	 5      :� 5      
 :� RoutedEvent$
 FrameworkElement.Loaded��6   .[�5      �� -   5         ��Name$! Storyboard1_BeginStoryboard��5      #��[  6:   5      :� 5      $
 FrameworkElement.Loaded��6   .[�5      ��  �� BeginStoryboardName$! Storyboard1_BeginStoryboard��6   5      .��5       � -   5         �Name$ 
LayoutRoot��5       ��5!      �� 5"       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6*   .��5#      �  � Color$ 	#FF0004FF��6    � Offset$ 0.305Q�6%   � 5$      $ White��6   $ 1Q�6!   5%      .+�5'      A� $��107,34,106,0q�6   
��� � �$	��110��60   $	��Top=�6=   A� 5(      -   5         A�Name$ ellipse1��5(      $
��Left=�6   $��25��69   $��	24,94,0,0q�6E   
��� � �$	��Top=�6f   $��25��6~   $��0��6�   
���  �� J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      T� 5.      5/      51      �� 52      -   5         ��Name$ button1��52      $��Begin��6   $
��Left=�6,   $��29��6G   $��
87,0,0,126q�6S   $��Bottom=�6g   $��88��6�    � Cursor$
 Hand��6�   $��14.667(�6�   6�   � 53      -   5        $
 grid��53   	   $
��Left=�6   $��101,187,0,0q�62   $	��113��6G   $ 0.5,0.5&�6S   $��26.411��6s   $	��Top=�6�   z�54      V� 55      .~�56      �� �� 57      �� 58      T� 59      5:      .+�5<      �� -   5         ��Name$ textbox1��5<      $��26,2,0,2.411q�6    �� TextWrapping$
 Wrap=�65   $ �� HorizontalScrollBarVisibility$
 Auto=�6I   " �� VerticalScrollBarVisibility$ Disabled=�6n   $��13.333(�6�   {�.  
�������
����  �$��Forever��6�    �� SelectionOpacity$ 0Q�6�    �� 	UndoLimit$ 0��6  $��60��6  $��24��6  $
��Left=�6'  �� 5=      -   5         ��Name$
 rpb1��5=      $
��Left=�6    $��0,0.411,0,0q�6;   $��26��6P   $��23��6n   .��5>      ,  &Microsoft.Expression.Shapes.BlockArrow  
����  �$��16��6       Orientation$
 Left=�6,   
���   �$��16��6N      ArrowBodySize$ 0Q�6Y      ArrowheadAngle$ 0Q�6k   $��0��6~   $
 Hand��6�   5?      �� 5@      -	   5        $
 rpb2��5@      $��Right=�6    $��0,1.911,2,1.5q�6<   $��26��6S   $��23��6q   .��5A        
����  �$��16��6    
���   �$��16��6;   $ 0Q�6F   $ 0Q�6X   $��0��6k   $
 Hand��6   5B      5C      �� 5D      -
   5          ��Name$  	textBlock��5D      $
��Left=�6!   $��
97,159,0,0q�6<   $
��Wrap=�6P   $��RepeatBehavior��6d   $	��127��6z   
�������$ 0.5,0.5&�6�   $��23��6�   $	��Top=�6�   z�5E      V� 5F      .~�5G      �� �� 5H      �� 5I      T� 5J      5K      5M      �� 5N      -   5        $ button2��5N      $��Pause��6   $
��Left=�6,   $��29��6G   $��175,0,0,126q�6S   $��Bottom=�6h   $��88��6�   $
 Hand��6�   $��14.667(�6�   6�   �� 5O      -   5        $ button3��5O      $��Resume��6   $��29��6-   $��264,0,280,126q�69   $��Bottom=�6P   $
 Hand��6k   $��14.667(�6y   $��88��6�   �� 5P      -   5        $ button4��5P      $
��Stop��6   $��29��6+   $��0,0,191,126q�67   $��Bottom=�6L   $
 Hand��6g   $��14.667(�6u   $��Right=�6�   $��88��6�   �� 5Q      -   5        ! ��Name$! 	checkbox1��5Q      $�� ��6    $��275,189,0,0q�6+   $
��Left=�6@   $��16.687��6[   $ 0.5,0.5&�6j   $	��Top=�6�   z�5R      V� 5S      .~�5T      �� �� 5U      �� 5V      T� 5W      5X      5Z      �� 5[      -   5        $  
textBlock1��5[      $��237,160,292,0q�6"   $
��Wrap=�69   $��AutoReverse��6M   
�������$ 0.5,0.5&�6s   $��23��6�   $	��Top=�6�   z�5\      V� 5]      .~�5^      �� �� 5_      �� 5`      T� 5a      5b      5d      �� 5e      -   5        $ button5��5e      $��
SkipToFill��6   $��29��61   $��0,0,103,126q�6=   $��Bottom=�6R   $
 Hand��6m   $��14.667(�6{   $��Right=�6�   $��88��6�   �� 5f      -   5        " ��Name$" slider1��5f      $��
91,0,0,163q�6   # � Value$	# 0.1Q�60   $ � Minimum$	$ 0.1Q�6<   % �� TickPlacement$% TopLeft=�6J   $ SizeWE��6�   & � Maximum$& 5Q�6�   
��� ���$��Bottom=�6�   $ 0.5,0.5&�6�   $
��Left=�6�   $	��215��6  z�5g      V� 5h      .~�5i      �� �� 5j      �� 5k      T� 5l      5m      5o      �� 5p      -   5        $  
textBlock2��5p      $��125.084,0,0,194q�6"   $
��Wrap=�6;   $��SetSpeedRatio ��6O   
�������$��23��6x   $��Bottom=�6�   $ 0.5,0.5&�6�   $
��Left=�6�   $	��121��6�   z�5q      V� 5r      .~�5s      �� �� 5t      �� 5u      T� 5v      5w      5y      �� 5z      -   5        $" slider2��5z      $��Right=�6   $��0,0,100,163q�68   $��Bottom=�6M   $	��215��6h   $% TopLeft=�6t   $ SizeWE��6�   
��� ���$ 0.5,0.5&�6�   $	# -10Q�6�   $& 5Q�6   z�5{      V� 5|      .~�5}      �� �� 5~      �� 5      T� 5�      5�      5�      �� 5�      -   5        $  
textblock3��5�      $��
0,160,86,0q�6"   $
��Wrap=�66   $��FillBehavior?HoldEnd��6J   
�������$ 0.5,0.5&�6y   $��23��6�   $	��Top=�6�   $��Right=�6�   $	��182��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�      -   5        $  
textBlock4��5�      $��0,0,109,195q�6"   $
��Wrap=�67   $��SeekAlignedToLastTick��6K   
�������$��23��6{   $��Bottom=�6�   $ 0.5,0.5&�6�   $��Right=�6�   $	��189��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�      -   5        $! 	checkbox2��5�      $�� ��6    $��0,189,188.313,0q�6+   $ 0.5,0.5&�6D   $	��Top=�6d   $��Right=�6|   $��16.687��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      