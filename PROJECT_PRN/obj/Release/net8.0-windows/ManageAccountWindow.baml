   M S B A M L   `   `   `  ����   PROJECT_PRN%    PROJECT_PRN.ManageAccountWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  ADMIN MANAGE ACCOUNT��$	��650��$
��1800�����#F0F8FF � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���  � ColumnDefinitions �� $	��200 ��� $��* �.+�� $��1��$��0,2,0,-2q�.+��� $��ACCOUNT MANAGEMENT��$
��Left=�$	��Top=�   HeaderLabelStyle#��[  $��	36,10,0,0q�$��63��$	��620��&   System.Windows.Controls.DataGrid  -     Name$ AccountDataGrid��$��Center=�$	��Top=�$
��1580��$	��376��$��0,89,0,0q�   AutoGenerateColumns$ False�����#FF8C00$��1q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ UserID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *UserId+  $ FullName��$	 130 	 �� *
FullName+  $ Email��$ * 	 �� *Email+  $ Password��$ 80 	 �� *
Password+  $
 Role��$ 80 	 �� *Role+  $ Phone��$	 120 	 �� *Phone+  $ Address��$ * 	 �� *	Address+�� 
 �� Orientation$
 
Horizontal=�$��Center=�$	��Top=�$��	0,470,0,0q�.+��� -    ��Name$ UpdateAccountButton��$��Update Account��$	��190��$��50��$��50 10q����#FF8C00
��������� $
 
Horizontal=�$��Right=�$	��Top=�$��	0,14,10,0q�.+��� -   $��X��$��40��$��40�����#FF4500
��������� ���#FFDAB9$��0��._��� $	��Top=�$��10q�.+��� -    ��Name$ HelloMsgLabel��$��Hello��$��34��$	��300���� -   $ RoleMsgLabel��$
��Role��$��34��$	��174���� -   $ ManageReportButton��$��13(�$��Manage Report��$	��150��$��40��$��10q����#FF8C00
��������� -   $ Logout��$��13(�$��Logout��$	��150��$��40��$��10q����#FF4500
�������