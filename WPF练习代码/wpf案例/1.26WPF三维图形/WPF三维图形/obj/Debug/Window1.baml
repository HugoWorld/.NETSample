   M S B A M L   `   `   `  ����  WPF三维图形    WPF三维图形.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ XAML语言造型��5      $	��800��5      $	��600��6    � WindowStartupLocation$ CenterScreen=�6   .��5	      � -   5         �Name$ 
LayoutRoot��5	      ��5
      �� 5       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6*   .��5      �  � Color$ Black��6    � Offset$ 1Q�6!   � 5      $
 Blue��6   5      .+�5      '� -   5         '�Name$ 
viewport3d��5      }�. $��	25,8,39,8q�67   	 � Cursor$
	 Hand��6�   
 '� Camera
 5      =� 5      -   5        ppc�� =� FieldOfView$ 45Q�5   %    � FarPlaneDistance$	 120Q�66    � LookDirection$ 0,0,-105�6M    � NearPlaneDistance$	 0.1Q�6e    � Position$ 0,0,1001�6}    � UpDirection$ 0,1,05�6�   .x�5      g� -   5        	World�� g� 	Transform 5      Y� 5      .�5      S�  S� OffsetZ$ 0Q�6    S� OffsetX$ 0Q�6)    S� OffsetY$ 0Q�65   �� 5       �� ScaleZ$ 1Q�6    �� ScaleY$ 1Q�6$    �� ScaleX$ 1Q�6/   �� 5       �� Rotation 5   	   �� 5   
    �� Axis$ -1,-1,-15�6    �� Angle$ 45Q�6.   5   	   5      .2�5       g� -   5        AmbientLightContainer�� g� Content 5!      �� 5"      -   5        AmbientLight�� �� Color$ 	#FF6E6E6E��5"   +   5$      g� 5%      -   5        DirectionalLightContainer�� 5&      t� 5'      -	   5        DirectionalLight�� t� 	Direction$ 0,0,-15�5'   3   5)      g� 5*      -
   5        	Box01�� 5+      � 5,      -   5        DefaultMaterial�� � Material 5-   	   u� 5.   
    u� Brush
 �  ��6     � Geometry  50   	   k� 51      ! k� 	Positions�! �   �ig��ig���� ��� �ig���� ��� ��� ��� �ig���� ��� �ig��ig��ig���� �ig��ig���� ��� �ig��ig���� �ig�" k� TriangleIndices." �$        52   
   54   	   56      57      58      �� 59      -   5        # ��Name$# reset��59      $��复 位��6   $
��Left=�6(   $��29��6C   $��
231,91,0,0q�6O   $	��Top=�6c   $��76��6{   $
	 Hand��6�   6�   �� 5:      $��28��6   $��316,91,280,0q�6   $
��Wrap=�60   $	��Top=�6D   
�������$
��Bold"�6o   �� 6�   $ � Language$$ zh-cn�6�   $
�XAML��6�   �� 6�   $�语言实现三维造型��6�   6�   5;      5<      