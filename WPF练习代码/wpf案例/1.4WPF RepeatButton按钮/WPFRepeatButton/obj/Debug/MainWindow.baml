   M S B A M L   `   `   `  ����  WPFRepeatButton     WPFRepeatButton.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ RepeatButton按钮��5      $	��640��5      $	��480��6    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6@    � 	Resources 5         RepeatButtonStyle1 �� 
TargetType �� Property �� Value �� 
TargetType	 � Cursor
 J� SnapsToDevicePixels  RepeatButtonStyle2 J� RenderTransformOrigin��%_  &	        &	     �� 5	      " ��6%   .�5
      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� $	 ScrollSW��6   $��images/imageLeft.png��6!   $
��Fill=�6?   �� 5   	   #��z��6   ��. #
 z
 6x   #��z��6�   5   	   5      5      5      �� 5      " ��6%   .�5      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� $	 ScrollSE��6   $ -0.088,0.257&�6!   $��images/imageRight.png��6F   $
��Fill=�6e   �� 5   	   #��z��6   ��. #
 z
 6x   #��z��6�   5   	   5      5      5       5!      .��5#      � -   5         �Name$ 
LayoutRoot��5#      ��5$      �� 5%       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6*   .��5&      �  � Color$
 Blue��6    � Offset$ 0.279Q�6    � 5'      $ White��6   $ 1Q�6!   5(      .+�5*      � $
��Left=�6	   $��57.333��6$   $��	99,45,0,0q�64   $	��Top=�6G   $��115.814��6_   .+�5+      �� -   5         ��Name$ 
textblock1��5+      $"��-1.353,5.824,-32.733,-21.108q�6#   $
��Wrap=�6I   $��000.0��6]   
���   �
��� � �$��64(�6�   $��Times New Roman)�6�   $
��Bold"�6�   �� 5,      $��9��6   $��-8.568,0,-38.218,-28.067q�6#   ��5-      �� 5.      $ 0.5,1&�6   $ 0.363,-0.017&�6,   .��5/      � $ White��6   � 50      $ 	#FF462F08��6   $ 0.253Q�6'   � 51      $ 	#FF281902��6   $ 1Q�6'   52      54      �� 55      $��3��6   $��-8.568,0,-37.218,-28.067q�6#   ��56      �� 57      $ 0.608,0.959&�6   $ 0.392,0.041&�62   .��58      � $ 	#FFF1EDDD��6   � 59      $ 	#FF4D421E��6   $ 0.598Q�6'   � 5:      $ 	#FF6A603E��6   $ 0.238Q�6'   � 5;      $ 	#FF392E05��6   $ 1Q�6'   � 5<      $ 	#FFB8AD85��6   $ 0.838Q�6'   5=      5?      5@      �� 5A      -   5         ��Name$	 rb1��5A      $��启动��6   $
��Left=�6+   $��31.904,74.169,0,0q�6F   $	��Top=�6a   $��52.524��6y   $��28.164��6�   $
	 Wait��6�    �� Interval$	 100��6�    �� Delay$ 0��6�    �� 	ClickMode$ Hover=�6�   �� 5B      -   5        $	 rb2��5B      $��复位��6   $
��Left=�6+   $��31.904,102.333,0,0q�6F   $	��Top=�6b   $��52.524��6z   $��28.164��6�   $
	 Hand��6�   $	 100��6�   $ 0��6�   6�   �� 5C      $
��Left=�6   $��19��6)   $��42,49.169,0,0q�65   $
��Wrap=�6L   $��秒表��6`   $	��Top=�6j   $��40.428��6�   
�������$
��Bold"�6�   $ 0.247,-3.321&�6�   � 5D      -   5        $ gridxngroup��5D   	   $��Right=�6   $��89��6:   $��0,49.169,56,0q�6F   $	��Top=�6]   $	��100��6u   .+�5E      �� $��images/image1.png��6   $
��Fill=�6&   � 5F      -   5        $ gridxn��5F   
   $��13,14.328,17,4.672q�6   $ 	0.52,0.52&�66   z�5G      V� 5H      .~�5I      �� �� 5J      �� 5K       �� Angle$ 10Q�6   -   5        xuanniu��5K   #   T� 5L      5M      .+�5O      �� -	   5        $ repeatbuttonLeft��5O      $�� ��6-   $��0,0,34,0q�68   #���   6J   $	 ScrollSW��6w   6�   �� 5P      -
   5        $ repeatbuttonRight��5P      $�� ��6.   $��Right=�69   #���  6U   $��34��6�   $	 ScrollSE��6�   6�   5Q      5R      �� 5S      -   5         ��Name$ canvas1��5S      $��303,28,159,0q�6   $��150.831��62   $	��Top=�6C   .+�5T      �� $��images/screen.jpg��6   $
��Fill=�6&   $��150.831��65   
 �� Top$ 1��6F   $	��172��6U   F� 5U      -   5         F�Name$ lineh��5U   
   ����@��@^]� �9 N	$��1��62    �� Stretch$
 Fill=�6=   
��� � �$��2��6Z   $	��132��6n    �� Left$ 21��6z   $ 76��6�   5V      �� 5W      $��Right=�6   $
��17.8��6*   $��
0,152,61,0q�68   $
��Wrap=�6L   $��垂直位置调整��6`   $	��Top=�6n   $��84��6�   
�������$��13.333(�6�   5X      5Y      