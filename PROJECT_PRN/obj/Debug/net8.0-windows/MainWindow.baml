   M S B A M L   `   `   `  ����  PROJECT_PRN    PROJECT_PRN.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  USER REPORTED��5   	   $	��650��6   $
��1800��6,   ���#F0F8FF � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6d    � WindowState$ 	Maximized=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5	      $��* �6   .+�5   
   �� ���#FFDAB9$��0��6&   ._�5      �� $	��Top=�6   $��10q�61   .+�5      �� -   5         ��Name$ HelloMsgLabel��5      $��Hello��6/   $
��Left=�6?   $��34��6Z   $	��300��6f   $
��10,0q�6r   �� 5      -   5        $ RoleMsgLabel��5      $
��Role��6.   $
��Left=�6=   $��34��6X   $	��174��6d   $
��10,0q�6p   �� 5      -   5         ��Name$ ManageAccountButton��5      $��13(�66   $��Manage Account��6D   $	��150��6]   $��40��6i   $��10q�6u   ���#FF8C00
�������5   A   �� 5      -   5        $ ManageVehicleButton��5      $��13(�66   $��Manage Vehicle��6D   $	��150��6]   $��40��6i   $��10q�6u   ���#FF8C00
�������5   A   �� 5      -   5        $ ProfileButton��5      $��13(�60   $��Profile��6>   $	��150��6P   $��40��6\   $��10q�6h   ���#FF8C00
�������5   A   �� 5      -   5        $ NotificationButton��5      $��13(�65   $��Notification��6C   $	��150��6Z   $��40��6f   $��10q�6r   ���#FF8C00
�������5   A   �� 5      -   5        $ UserViolation��5      $��13(�60   $��Your Violation��6>   $	��150��6W   $��40��6c   $��10q�6o   ���#FF8C00
�������5   B   �� 5      -	   5        $ Logout��5      $��13(�6)   $��Logout��67   $	��150��6H   $��40��6T   $��10q�6`   ���#FF4500
�������5   A   5      5      � 5"   
   $��1��6   .+�5#      �� $��YOUR REPORTED DASHBOARD��6   $
��Left=�66   $	��Top=�6Q      HeaderLabelStyle#��[  6i   $��	36,10,0,0q�6�   $��63��6�   $	��620��6�   &   System.Windows.Controls.DataGrid  5%      -
   5          Name$ ReportDataGrid��5%      $��Center=�6/   $	��376��6L   $	��Top=�6Y   $
��1580��6q   $��0,89,0,0q�6~      AutoGenerateColumns$ False��6�   ���#FF8C00$��1q�6�   	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ReportID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *
ReportId+  5(      $
 ViolationType��6)   $	 100 6@    6L   �� *ViolationType+  5)      $
 Description��6)   $ * 6>    6H   �� *Description+  5*      $
 PlateNumber��6)   $ 80 6>    6I   �� *PlateNumber+  5+      $
 Location��6)   $ 80 6;    6F   �� *
Location+  5,      $
 ImageURL��6)   $ * 6;    6E   �� *
ImageUrl+  5-      $
 VideoURL��6)   $ * 6;    6E   �� *
VideoUrl+  5.      $
 
ReportDate��6)   $	 130 6=    6I   �� *
ReportDate+  5/      $
 Status��6)   $ 80 69    6D   �� *Status+51      �� 53       �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��	0,498,0,0q�6g   .+�54      �� -   5        $ CreateButton��54      $��Create Report��6/   $	��183��6G   $��50��6S   ���#FF8C00
�������$��50,10q�6�   �� 55      -   5        $ UpdateButton��55      $��Update Report��6/   $	��183��6G   $��50��6S   ���#FF8C00
�������$��50,10q�6�   56      �� 58      $ 
Horizontal=�6   $��Right=�62   $	��Top=�6N   $��	0,10,10,0q�6f   $��50��6y   .+�59      �� -   5        $��X��59      $��40��6%   $��40��60   ���#FF4500
�������$��10,10q�6d   6s   5:      �� 5;      $ 
Horizontal=�6   $
��Left=�62   $	��Top=�6M   $��
694,25,0,0q�6e   .+�5<      �� $��Plate Number:��6   $	��100��60   $��Center=�6<   �� 5=      -   5         ��Name$ PlateNumberTextBox��5=      $	��120��66   $��Center=�6B   $��5q�6]   �� 5?      $��
From Date:��6   $��80��6-   $��Center=�68   (  "System.Windows.Controls.DatePicker  5@      -   5          Name$ FromDatePicker��5@      $	��120��65   $��Center=�6A   $��5q�6\   �� 5B      $��To Date:��6   $��80��6+   $��Center=�66     5C      -   5        $ ToDatePicker��5C      $	��120��63   $��Center=�6?   $��5q�6Z   �� 5E      -   5        $ SearchButton��5E      $��Search��6/   $��12(�6@   $��60��6N   $��25��6Y   ���#FF8C00
�������6�   �� 5F      -   5        $ ResetButton��5F      $��Reset��6.   $��12(�6>   $��60��6L   $��25��6W   
�������
�������$	��5,0q�6�   5H      5I      5J      5K      