   M S B A M L   `   `   `  ����  WPF三维图形     WPF三维图形.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          �Name$  Window��5       � Title$ 
MainWindow��5      $	��800��5      $	��600��6    � WindowStartupLocation$ CenterScreen=�6   .��5
      � -   5         �Name$ 
LayoutRoot��5
         DrawingBrush1#���   6   .+�5      '� -   5         '�Name$ 
viewport3d��5      $��8,8,8,0q�6#    '� Camera 5      =� 5      -   5        ppc�� =� FieldOfView$ 45Q�5   %    � FarPlaneDistance$	 120Q�66    � LookDirection$ 0,0,-105�6M   	 � NearPlaneDistance$		 0.1Q�6e   
 � Position$
 0,0,1001�6}    � UpDirection$ 0,1,05�6�   5      �� 5      -   5         ��Name$ reset��5      $��复 位��6   $
��Left=�6(   $��29��6C   $��
201,91,0,0q�6O   $	��Top=�6c   $��76��6{    � Cursor$
 Hand��6�   6�   �� 5      $��28��6   $��281,92,315,0q�6   $
��Wrap=�60   $ ��C#语言实现三维造型��6D   $	��Top=�6V   
�������$
��Bold"�6�   5      5      