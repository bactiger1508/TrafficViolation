   M S B A M L   `   `   `  ���� F  BPROJECT_PRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PROJECT_PRNPROJECT_PRN      PROJECT_PRN.TrafficPolice   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:PROJECT_PRN       � Title$  TrafficPolice��$	��650��$
��1391�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=����#F0F8FF.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�����#FF8C00 �� Padding$ 20q�._�� $
��1570�� � ColumnDefinitions �� �� $��0* ��� $
��Auto �$	��161���� $
��Auto �$��546.964��.+��� $)��#Traffic Violation Management System��
�������$��24(�$
��Bold"�$��0��$��	0,0,388,0q��� $��2��$��30,0,0,0q�.+��� -    ��Name$ UserNameTextBlock��$��Officer Name��
�������$��16(��� -   $ UserRoleTextBlock��$��Traffic Police�����#FFDAB9$��14(��� -   $��Log out��   DangerButtonStyle#��[  $��84��$��Center=�$��3��$��0,5,0,5q���  �� Orientation$ 
Horizontal=�$
��Left=�$	��Top=�$��20,0,0,0q�$��1��.+��� $��Plate Number:��$	��100��$��Center=��� -   	 ��Name$	 PlateNumberTextBox��$	��120��$��Center=�$��5q��� $��
From Date:��$��80��$��Center=�(  "System.Windows.Controls.DatePicker  -   
  Name$
 FromDatePicker��$	��120��$��Center=�$��5q��� $��To Date:��$��80��$��Center=�  -   $
 ToDatePicker��$	��120��$��Center=�$��5q��� -    ��Name$ SearchButton��$��Search��$��12(�$��60��$��25�����#FF8C00
�������$	��5,0q��� -   $ ResetButton��$��Reset��$��12(�$��60��$��25��
�������
�������$	��5,0q�� $��1��$��20,36,20,20q� �� $��* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -	     Name$ ReportsDataGrid��$��0��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   SelectionMode$ Single=�
����������#FF8C00   RowBackground
 �����$��	0,0,10,10q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ReportID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ReportId+  $ ViolationType��$	 100  �� *ViolationType+  $ Description��$ *  �� *Description+  $ PlateNumber��$ 80  �� *PlateNumber+  $ Location��$ 80  �� *
Location+  $ ImageURL��$ *  �� *
ImageUrl+  $ VideoURL��$ *  �� *
VideoUrl+  $ 
ReportDate��$	 130  �� *
ReportDate+  $ Status��$ 80  �� *Status+�� $��1��$	��200��$��20,0,0,0q�.+��� -
   $��View Details��  PrimaryButtonStyle#��[ $
��0,10q��� -   $��Approve Report��  SuccessButtonStyle#��[ $
��0,10q��� -   $��Reject Report��#��[  $
��0,10q��� -   $��List Violation��  SecondaryButtonStyle#��[ $��	0,40,0,10q��� -   $��Manage Vehicle��#��[ $
��0,10q��� -   $��Your Profile��#��[ $��	0,10,0,10q��� -   $��Notification��#��[ $��	0,10,0,10q�