   M S B A M L   `   `   `  ����   PROJECT_PRN    PROJECT_PRN.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  USER REPORTED��$	��650��$
��1800�����#F0F8FF � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���  � ColumnDefinitions �� $	��200 ��� $��* �.+��� ���#FFDAB9$��0��._��� $	��Top=�$��10q�.+��� -    ��Name$ HelloMsgLabel��$��Hello��$
��Left=�$��34��$	��300��$
��10,0q��� -   $ RoleMsgLabel��$
��Role��$
��Left=�$��34��$	��174��$
��10,0q��� -    ��Name$ ManageAccountButton��$��13(�$��Manage Account��$	��150��$��40��$��10q����#FF8C00
��������� -   $ ManageVehicleButton��$��13(�$��Manage Vehicle��$	��150��$��40��$��10q����#FF8C00
��������� -   $ ProfileButton��$��13(�$��Profile��$	��150��$��40��$��10q����#FF8C00
��������� -   $ NotificationButton��$��13(�$��Notification��$	��150��$��40��$��10q����#FF8C00
��������� -   $ UserViolation��$��13(�$��Your Violation��$	��150��$��40��$��10q����#FF8C00
��������� -	   $ Logout��$��13(�$��Logout��$	��150��$��40��$��10q����#FF4500
�������� $��1��.+��� $��YOUR REPORTED DASHBOARD��$
��Left=�$	��Top=�   HeaderLabelStyle#��[  $��	36,10,0,0q�$��63��$	��620��&   System.Windows.Controls.DataGrid  -
     Name$ ReportDataGrid��$��Center=�$	��376��$	��Top=�$
��1580��$��0,89,0,0q�   AutoGenerateColumns$ False�����#FF8C00$��1q�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 ReportID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ReportId+  $
 ViolationType��$	 100  �� *ViolationType+  $
 Description��$ *  �� *Description+  $
 PlateNumber��$ 80  �� *PlateNumber+  $
 Location��$ 80  �� *
Location+  $
 ImageURL��$ *  �� *
ImageUrl+  $
 VideoURL��$ *  �� *
VideoUrl+  $
 
ReportDate��$	 130  �� *
ReportDate+  $
 Status��$ 80  �� *Status+��  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��	0,498,0,0q�.+��� -   $ CreateButton��$��Create Report��$	��183��$��50�����#FF8C00
�������$��50,10q��� -   $ UpdateButton��$��Update Report��$	��183��$��50�����#FF8C00
�������$��50,10q��� $ 
Horizontal=�$��Right=�$	��Top=�$��	0,10,10,0q�$��50��.+��� -   $��X��$��40��$��40�����#FF4500
�������$��10,10q��� $ 
Horizontal=�$
��Left=�$	��Top=�$��
694,25,0,0q�.+��� $��Plate Number:��$	��100��$��Center=��� -    ��Name$ PlateNumberTextBox��$	��120��$��Center=�$��5q��� $��
From Date:��$��80��$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ FromDatePicker��$	��120��$��Center=�$��5q��� $��To Date:��$��80��$��Center=�  -   $ ToDatePicker��$	��120��$��Center=�$��5q��� -   $ SearchButton��$��Search��$��12(�$��60��$��25�����#FF8C00
��������� -   $ ResetButton��$��Reset��$��12(�$��60��$��25��
�������
�������$	��5,0q�