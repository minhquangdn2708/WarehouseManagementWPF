   M S B A M L   `   `   `  ����D  @QuanLiKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLiKho	QuanLiKho  5   	   ;"clr-namespace:QuanLiKho.ControlBarQuanLiKho.ControlBar  5   	       QuanLiKho.UserWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLiKho     5   	   1uc"clr-namespace:QuanLiKho.ControlBar     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterScreen=�5       � Title$ 
UserWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      '   !QuanLiKho.ControlBar.ControlBarUC  6    5      � 5    
   $��1��6    5!      �� 5"      $
��auto �6    60   �� 5#      $
��auto �6    60   �� 5$      6"   .+�5(      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5)      � -   5         �Name$ Input��5)      $��0 0 0 10q�6+   .+�5*      �� -   5         ��Name$ txtCustomerEmail��5*      $��5 5 15 5q�6t   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Email đăng nhập��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   $	��100��6�   ��68   �� *Email+
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   �� 5+      -   5        $ txtCustomerName��5+      $��5 5 15 5q�6z   $	 Tên khách hàng��6�   #��[ 6�   $	��100��6�   ��67   �� *CustomerName+$
 PropertyChanged=�6�   �� 5,      -   5        $ 
txtAddress��5,      $��5 5 15 5q�6p   $	 Địa chỉ��6�   #��[ 6�   $	��200��6�   ��62   �� *	Address+$
 PropertyChanged=�6�   �� 5-      -   5        $ txtPhone��5-      $��5 5 15 5q�6l   $	 Số điện thoại��6~   #��[ 6�   $	��100��6�   ��60   �� *Phone+$
 PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5.      -   5          Name$ dateContractDate��5.   !   $	��Top=�6;   $	��100��6�   $��	5 5 15 -7q�6�   $	 Ngày hợp tác��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6S   �� *ContractDate+ �� StringFormat$ 
dd/MM/yyyy��6�   5/      50        52      $��1��6"   $��5q�6/   .��53      � .+�54      �� -   5        $��Thêm��54   <   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6v   �� 55      -	   5        $��Sửa��55   =   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6z   �� 56      -
   5        $��Xóa��56   ?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6|   57      58        5:      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5;      �� $
��Auto=�6   .��5<      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomerDataGrid��5<         AutoGenerateColumns$ False��6�      HeadersVisibility$ Column=�6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      
IsReadOnly$
 True��6   �� SelectedItem 6d   �� *SelectedItem+ �� Mode$ OneWayToSource=�   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��61      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 6\   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6=   �� *
CustomerId+6\     5?      $ Tên khách hàng��61   $ *	 6l    6K   �� *CustomerName+6l     5@      $ Địa chỉ��61   $ *	 6`    6D   �� *	Address+6`     5A      $ Điện thoại��61   $ *	 6a    6G   �� *Phone+6a     5B      $ Email��61   $ *	 6Z    6@   �� *Email+6Z     5C      $ Ngày hợp tác��61   $
 Auto	 6�    6J   �� *ContractDate+$ 
dd/MM/yyyy��6�   5E      5G      5H      5I      5J      5K      