   M S B A M L   `   `   `  ����J  FWPF_TestWinDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_TestWinDemoWPF_TestWinDemo  5   	   !    WPF_TestWinDemo.Command_Win   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_TestWinDemo     5   	     � Title$  Command_Win��5   	   $	��600��6   $	��300��6*    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$	 New��5
      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      %   WPF_TestWinDemo.MyCommandSource  -   5          Name$ 	ctrlClear��5   $   $��10q�67   .��5      �� $��清除��6   $��16(�6&    �� TextAlignment$ Center=�64   
������$��80��6c   5         WPF_TestWinDemo.MiniView  5      -   5          Name$ miniView��5      $	��200��6/   $	��140��6;   5      �� 5   
   -   5         ��Name$	 tb1��5      $��1��5       $��30��5!      $��5q�5"      �� 5#   
   -   5         ��Name$	 sp1��5#      $��2��6"   $��40��6/   .+�5$      �� -   5        	 ��Name$	 button1��5$      $��30��6&   $�� Send Clear Command��5%      $��	10,5,10,5q�5&      5'      �� 5(   
   -   5        $	 Bt_NewStudent��5)      $��3��5(      $��New Student File��5*      $��30��5+      $	��New��5,      $��Student��6   $��	10,5,10,5q�5-      6&   �� 5.   
   -   5        $	 Bt_NewTeacher��5.      $��4��6(   $��New Teacher File��5/      $	��New��50      $��Teacher��51      $��30��52      $��	10,5,10,5q�53      6&   �� 54   
   -	   5        
 ��Name$
 
lb_Newinfo��54      $��5��6&   56      57      58      