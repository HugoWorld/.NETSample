   M S B A M L   `   `   `  ����J  FWPF_TestWinDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_TestWinDemoWPF_TestWinDemo  5   	   E'clr-namespace:WPF_TestWinDemo.ConverterWPF_TestWinDemo.Converter  5   	        WPF_TestWinDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_TestWinDemo     5   	   'adohttp://Yingbao.Com/WPFExample   5   	   7	converter'clr-namespace:WPF_TestWinDemo.Converter   5   	     � Title$  
MainWindow��5
   	   $��670.852��6   $��507.735��6-    � 	Resources 5      6   0WPF_TestWinDemo.Converter.PlaneToStringConVerter   pcv5   /WPF_TestWinDemo.Converter.StateOfPlaneConverter  sop9   3WPF_TestWinDemo.Converter.CategoryToSourceConverter  ctc<   6WPF_TestWinDemo.Converter.StateToNullableBoolConverter 	 stnbc��%t   &	        &	      &	 &     &	 9       5   
   6+     5   
   6*     5   
   6.     5   
   61   5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5        $
��txt1��5   +   $��0��6   $	��160��6   $��5q�67   �� 5   
   -   5        $
��txt2��5   +   $��1��6   $	��160��6   $��5q�67   �� 5   
   -   5        $��2��5      $	��200��6   $��40��6*   $��点我啊！��66   $��24(�6Z   �� 5   
   -   5        $��3��5      $	��200��6   $��40��6*   $��给Student类赋值��66   $��24(�6b   �� 5   
   $��4��6    �� Orientation$ Vertical=�6"   $	��160��69   .+�5      �� -   5         ��Name$ LB��5      $	��180��6"   $��5q�6/   ��5       �� 5!      .R�5"      �� $ 
Horizontal=�6%   .+�5#      �� $��20��6$   $��20��6/   $��5q�6{   ��6;   ��  �� Path$ Category� �� 	Converter# [ 6{   �� 5$      $��40��6C   $��20��6N   $��5q�6Z   ��6(   �� $
 Name�6Z   �� 5%       d� IsThreeState . $��5q�6}    d� 	IsChecked 6;   �� $ State�# [ 6}   5&      5'      5)      5*      �� 5+   
   $��5��6   $ 
Horizontal=�6"   $��60��6;   $��Center=�6G   $��Bottom=�6d   .+�5,      �� -   5        $	��200��5,      $��40��6!   $��数据转换器��6-   $��24(�6[   5-      5.      5/      