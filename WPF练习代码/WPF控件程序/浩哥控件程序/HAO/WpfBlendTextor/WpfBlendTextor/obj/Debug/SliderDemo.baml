   M S B A M L   `   `   `  ����  WpfBlendTextor    WpfBlendTextor.SliderDemo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
SliderDemo��5   	   $	��300��6   $	��500��6)    � 	Resources 5         SliderBackground �� 
StartPoint �� EndPoint � Offset � Color  SliderThumb  
SliderText  slider_light % !HorizontalSliderTrackNormalBorder ) %HorizontalSliderTrackNormalBackground �� Color  Horizontalslider_backround �� ImageSource j� Stretch	 j� 
AlignmentX
 j� 
AlignmentY  Horizontalslider_Thumb  Verticalslider_Thumb 	 Verticalslider_backround 
 Slider_RepeatButton �� 
TargetType �� Property �� Value �� 
TargetType  Slider_RepeatButton1  Horizontal_SliderThumbStyle � ColumnDefinitions �� CornerRadius  Slider_Thumb  Slider_CustomStyle J� SnapsToDevicePixels � RowDefinitions m�Name m� Fill m� 	Placement ��Name ]�Name ]� DecreaseRepeatButton ��Name �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge ]� Thumb n�Name J� RenderTransformOrigin��%d  &	        &	 �     &	 ,    &	 �    &	 O    &	 �    &	 	    &	 �    &	 )    &		 �    &	
 I    &	      7  &	 �    7  &	 �    7   7  &	 �	    7  7 
 7  7  �� 5   
   $	 0,0&�68   $	 0,1&�6I   .��5      � $ 0Q�6   $ #59ccfc��6&   � 5	      $	 0.5Q�6   $ #00b3fe��6(   � 5
      $ 1Q�6   $ #59ccfc��6&   5      �� 5   
   $	 0,0&�63   $	 0,1&�6D   .��5      � $ 0Q�6   $ 	#FFD9D3E8��6&   5      �� 5   
   $	 0,0&�62   $	 0,1&�6C   .��5      � $ 0Q�6   $ #7cce45��6&   � 5      $ 1Q�6   $ #4ea017��6&   5      �� 5   
   $ 0.5,1&�63   $ 0.5,0&�6D   .��5      � $ 	#FF02C6FF��6   $ 1Q�6-   � 5      $ 	#FF007CFF��6   5      �� 5   
   $	 0,1&�6H   $	 0,0&�6W   .��5      � $ 	#FFAEB1AF��6   $	 0.1Q�6-   � 5      $ White��6   $ .9Q�6)   5      �� 5   
   $ 	#FFE7EAEA��6H   �� 5   
   $E ?/Images/SpeedValueSlider/调节进度条_背景（水平）.png��68   $ Uniform=�6p   $	 Center=�6�   $
 Center=�6�   �� 5    
   $E ?/Images/SpeedValueSlider/调节进度条_按钮（水平）.png��64   $ Uniform=�6l   $	 Center=�6~   $
 Center=�6�   �� 5!   
   $E ?/Images/SpeedValueSlider/调节进度条_按钮（垂直）.png��62   $ Uniform=�6j   $	 Center=�6|   $
 Center=�6�   �� 5"   
   $E ?/Images/SpeedValueSlider/调节进度条_背景（垂直）.png��66   $ Uniform=�6n   $	 Center=�6�   $
 Center=�6�   �� 5%   
   " ��6,   .�5&      ��  � |� .  6*   �� 5'       � ��$ 8��6'   �� 5(       � �� 5)      �� 5*      " ��6&   .R�5+      �� 
������ 6!   5,      5.      5/      �� 50   
   " ��6-   .�51      ��  � ��$ 8��6'   �� 52       � |� .  6*   �� 53       � �� 54      �� 55      " ��6&   .R�56      �� 8��  6!   57      59      5:      �� 5<   
   " n�64   .�5=      ��  �@J�SnapsToDevicePixels . 64   �� 5>       �@�OverridesDefaultStyle . 66   �� 5?       � ��$ 38��6'   �� 5@       � ��$ 20��6&   �� 5A       � ��# �  6+   �� 5B       � �� 5C      �� 5D      " n�6&   .R�5E      �  5F      �� 5G   "   �� 5H   "   .+�5J      �� $��2��6%   $ 4��69   8��  5K      5L      5M      5O      5P      �� 5Q   
   " n�6%   .�5R      ��  � |� .  6*   �� 5S       � �� 5T      �� 5U      " n�6&   .R�5V      �  5W      �� 5X   "   �� 5Y   "   .+�5[      �� 8��  6%   �� 5\      $��2��6%   $ 4��69   8�� $��10��6u   5^      5_      5`      5b      5c      �� 5e   
   " ��6+   .�5f      ��  �@��IsPressAndHoldEnabled .  6=   �� 5g       � ��# �  6+   �� 5h       �@��IsSnapToTickEnabled . 64   �� 5i       � �� 5j      �� 5k      " ��6&   .R�5l      �� #��z��6!    . ._�5o      � #��z��6$    5p   "   �� 5q   &   $��* �64   �� 5r   &   $	��28* �64   �� 5s   &   $��* �64   .+�5u   "   m� $ TopTick��6*   # z��6;   $��4��6_   $	 Top=�6j   $��0��6z   $y�	Collapsed=�6�   m� 5v   "   $ 
BottomTick��6*   # z��6>   $��4��6b   $ Bottom=�6m   $��2��6�   $y�	Collapsed=�6�   �� 5w   "   $ TrackBackground��6)   8��  #��z��5y      #��z��5z      #��z��5{      #��z��5|      $��1��5}      $��Center=�5~      $
��Left=�5      $��0,0,0,0q�6'   $��3��68   5�   #   ]� 5�   "   $ 
PART_Track��6(   $��1��6<   $��0,0,5,0q�6I    5�   &   �� 5�   *   $
 Down��67   #��Z 6E   8�� {�. 5�   9    5�   &   �� 5�   *   $ Up��67   #��Z 6C   8�� {�. 5�   :    5�   &   n� 5�   *   $ Thumb��60   8�� $
��Left=�6t   $ 	1.759,0.5&�6�   $��0,0,0,0q�6�   $��Center=�6�   5�   #   5�      5�      5�      5�      5�      5�      .��5�      � .+�5�   
   �� #��[ 6   $��30��6>   $	��200��6J   5�      5�      