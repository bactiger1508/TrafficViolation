   M S B A M L   `   `   `  ����  PROJECT_PRN%    PROJECT_PRN.ManageAccountWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ADMIN MANAGE ACCOUNT��5   	   $	��650��6&   $
��1800��63   ���#F0F8FF � WindowStartupLocation$ CenterScreen=�5       � WindowState$ 	Maximized=�6Z   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5
      $��* �6   .+�5   
   � $��1��6   $��0,2,0,-2q�6   .+�5      �� $��ACCOUNT MANAGEMENT��6   $
��Left=�61   $	��Top=�6L      HeaderLabelStyle#��[  5      $��	36,10,0,0q�6>   $��63��6Q   $	��620��6]   &   System.Windows.Controls.DataGrid  5      -   5          Name$ AccountDataGrid��5      $��Center=�60   $	��Top=�6M   $
��1580��5      $	��376��6$   $��0,89,0,0q�61      AutoGenerateColumns$ False��6C   ���#FF8C00$��1q�6u      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ UserID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 69   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6D   �� *UserId+  5      $ FullName��6)   $	 130 6;   	 6G   �� *
FullName+  5      $ Email��6)   $ * 68   	 6B   �� *Email+  5      $ Password��6)   $ 80 6;   	 6F   �� *
Password+  5      $
 Role��6)   $ 80 67   	 6B   �� *Role+  5      $ Phone��6)   $	 120 68   	 6D   �� *Phone+  5      $ Address��6)   $ * 6:   	 6D   �� *	Address+5      �� 5"      
 �� Orientation$
 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��	0,470,0,0q�6g   .+�5#      �� -   5         ��Name$ UpdateAccountButton��5#      $��Update Account��66   $	��190��6O   $��50��6[   $��50 10q�6g   ���#FF8C00
�������5$   A   5%      �� 5(      $
 
Horizontal=�6   $��Right=�62   $	��Top=�6N   $��	0,14,10,0q�6f   .+�5)      �� -   5        $��X��5)      $��40��6%   $��40��60   ���#FF4500
�������5*   *   5+      5,      �� 5.   
   ���#FFDAB9$��0��6&   ._�5/      �� $	��Top=�6   $��10q�61   .+�50      �� -   5         ��Name$ HelloMsgLabel��50      $��Hello��6/   $��34��6?   $	��300��6K   �� 51      -   5        $ RoleMsgLabel��51      $
��Role��6.   $��34��6=   $	��174��6I   �� 53      -   5        $ ManageReportButton��53      $��13(�65   $��Manage Report��6C   $	��150��6[   $��40��6g   $��10q�6s   ���#FF8C00
�������54   A   �� 55      -   5        $ Logout��55      $��13(�6)   $��Logout��67   $	��150��6H   $��40��6T   $��10q�6`   ���#FF4500
�������56   A   57      58      5;      5<      