   M S B A M L   `   `   `  ����  WpfExercises    WpfExercises.Page4   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          N�Name$
  Page��5       N� WindowTitle$
 Page��5      $��LeftToRight=�5      $	��792��5      $	��400��6    N� WindowWidth$	 640Q�5	       N� WindowHeight$	 480Q�6   .��5      � -   5         �Name$ 
LayoutRoot��5      ���	#FFDCDCFF � DataContext 63   ��    ExercisesDataSource �� Source# [  .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	datagrid1��5      $��0,2.195,0,50.132q�6       AutoGenerateColumns .  $��13.333(�6�   ��6V   �� 	 �� XPath$	 /exercises/exercise�� 6�   �� $	 
/exercises��
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 存储日期时间��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� $	 @date��6I     5      $ 单选题分��6>   $ 70 6L    6   �� $	 
@danxuanti��6L     5      $ 选题��68   $ 50 6D    6   �� $
	 @xz1��6D     5      $ 正确��68   $ 50 6D    6   �� $
	 @rt1��6D     5      $ 多选题分��6>   $ 70 6L    6   �� $	 
@duoxuanti��6L     5      $ 选题��68   $ 50 6D    6   �� $
	 @xz2��6D     5      $ 正确��68   $ 50 6D    6   �� $
	 @rt2��6D     5      $ 判断题分��6>   $ 70 6L    6   �� $	 
@panduanti��6L     5      $ 选题��68   $ 50 6D    6   �� $
	 @xz3��6D     5      $ 正确��68   $ 50 6D    6   �� $
	 @rt3��6D     5      $ 总分��6<   $ 60 6H    6   �� $	 @zongfen��6H     5      $ 用时��69   $ 70 6E    6   �� $	 @time��6E   5      �� 5      -   5         ��Name$ deletecurrent��5      $��删除当前选择行��6"   $��25��64   $��241.123,0,0,22.132q�6@   $��Bottom=�6\    � Cursor$
 Hand��6w   $
��Left=�6�   $	��120��6�   {�.  $��13.333(�6�   �� 5      -   5        $
 save��5      $��保存目前答题情况��6   $
��Left=�6,   $��25��6G   $��119.864,0,0,22.132q�6S   $��Bottom=�6o   $	��120��6�   $
 Hand��6�   $��13.333(�6�    � ToolTip$0 *将做题的最后得分保存到xml文件��6�   �� 5      -   5        $ 	deleteall��5      $��删除全部数据��6   $��25��6/   $��365.123,0,306.877,21.132q�6;   $��Bottom=�6]   $
 Hand��6x   $��13.333(�6�   5      5       