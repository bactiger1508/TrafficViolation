   M S B A M L   `   `   `  ����   PROJECT_PRN%    PROJECT_PRN.ViolationListWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Violation List��$	��700��$	��900�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Violation List��$��28(�$
��Bold"�$��Center=�$��	0,20,0,10q��� -    ��Name$ ViolationTabControl��$��10q�$��1��.@��� -    ��Name$ AllViolationsTab��$��All Violations��.���  �� $
��Auto ��� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��	0,10,0,10q�$��0��.+��� $��Plate Number:��$��Center=��� -    ��Name$ AllPlateNumberTextBox��$	��100��$	��5,0q��� $��From:��$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ AllFromDatePicker��$	��120��$	��5,0q��� $	��To:��$��Center=�  -   $ AllToDatePicker��$	��120��$	��5,0q��� -    ��Name$ AllSearchButton��$��Search��$��80��$��30��
��� ���
�������$
��10,0q��� $��1��$
��Auto=�.��&   System.Windows.Controls.DataGrid  -   	  Name$	 AllViolationsDataGrid��
   AutoGenerateColumns$
 False��   CanUserAddRows$ False��   
IsReadOnly$
 True��$��10q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	User Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
UserName+  $ Plate Number��$ *  �� *PlateNumber+  $ Fine Amount��$ *  �� *
FineAmount+  $ 	Fine Date��$ *  �� *
FineDate+ �� StringFormat$ 
dd/MM/yyyy��  $ Fine Status��$ *  �� *
FineStatus+�� $��2��$ Vertical=�$��Center=�$��10q�.+��� -	    ��Name$&  TotalUnpaidFinesForAllUsersLabel��$
��Bold"�
���  ��$��14(�$y�	Collapsed=��� -
   $$ TotalPaidFinesForAllUsersLabel��$
��Bold"�
��� � �$��14(�$y�	Collapsed=��� -   $ YourViolationsTab��$��Your Violations��.���  �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $ 
Horizontal=�$��Center=�$��	0,10,0,10q�$��0��.+��� $��Plate Number:��$��Center=��� -   $ PlateNumberTextBox��$	��100��$	��5,0q��� $��From:��$��Center=�  -   $ FromDatePicker��$	��120��$	��5,0q��� $	��To:��$��Center=�  -   $ ToDatePicker��$	��120��$	��5,0q��� -   $ SearchButton��$��Search��$��80��$��30��
��� ���
�������$
��10,0q��� $��1��$
��Auto=�.��  -   $	 YourViolationsDataGrid��$
 False��$ False��$
 True��$��10q�   $ 	User Name��$ *  �� *
UserName+  $ Plate Number��$ *  �� *PlateNumber+  $ Fine Amount��$ *  �� *
FineAmount+  $ 	Fine Date��$ *  �� *
FineDate+$ 
dd/MM/yyyy��  $ Fine Status��$ *  �� *
FineStatus+�� $��2��$ Vertical=�$��Center=�$��10q�.+��� -   $ TotalUnpaidFinesLabel��$
��Bold"�
���  ��$��14(�$y�	Collapsed=��� -   $ TotalPaidFinesLabel��$
��Bold"�
��� � �$��14(�$y�	Collapsed=��� -   $ 	PayButton��$��3��$��Pay Fine��$	��150��$��40��$��Center=�$��	0,10,0,10q�
��� � �
�������$
��Bold"�