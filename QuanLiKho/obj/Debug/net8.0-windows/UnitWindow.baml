   M S B A M L   `   `   `  ����D  @QuanLiKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLiKho	QuanLiKho  5   	   ;"clr-namespace:QuanLiKho.ControlBarQuanLiKho.ControlBar  5   
       QuanLiKho.UnitWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLiKho     5   	   1uc"clr-namespace:QuanLiKho.ControlBar     5   
   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � 
ResizeMode$ NoResize=�5   
    � WindowStyle$
 None=�5   
    � WindowStartupLocation$ CenterScreen=�5   
    � Title$ 
UnitWindow��5   	   $	��450��6   $	��352��6)   .��5      � $��0,10,0,0q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      '   !QuanLiKho.ControlBar.ControlBarUC  6    5      � 5    
   $��1��6    5!      �� 5"      $
��auto �6    60   �� 5#      $
��auto �6    60   �� 5$      6"   .+�5(      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5)      � .+�5*      �� -   5         ��Name$ txtUnitName��5*      $��5q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đơn vị đo��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��63   �� *
UnitName+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�6�   5+      5,        5.      $��1��6"   $��5q�6/   .��5/      � .+�50      �� -   5        $��Thêm��50   <   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6y   �� 51      -   5        $��Sửa��51   =   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6|   �� 52      -   5        $��Xóa��52   ?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6~   53      54        56      $��2��6"   $��5q�6/   $��Stretch=�6:   .��57      �� $
��Auto=�6   .��58      &   System.Windows.Controls.DataGrid  -   5          Name$ dgUnit��58         AutoGenerateColumns$ False��6�      HeadersVisibility$ Column=�6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      
IsReadOnly$
 True��6�    �� SelectedItem 6Z   �� *SelectedItem+$
 OneWayToSource=�   Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6X   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6=   �� *UnitId+6X     5;      $ Tên đơn vị đo��61   $
 Auto 6e    6H   �� *
UnitName+6e   5=      5>      5?      5@      5B      5C      