   M S B A M L   `   `   `  ����F  BPROJECT_PRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PROJECT_PRNPROJECT_PRN  5   	       PROJECT_PRN.TrafficPolice   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PROJECT_PRN     5   	     � Title$  TrafficPolice��5   	   $	��650��6   $
��1391��6,    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O    � WindowState$ 	Maximized=�6t   ���#F0F8FF.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���#FF8C00 �� Padding$ 20q�63   ._�5      � $
��1570��6    � ColumnDefinitions 5      �� 5      �� 5      $��0* �6'   �� 5      $
��Auto �6'   $	��161��64   �� 5      $
��Auto �6'   $��546.964��64   .+�5      �� $)��#Traffic Violation Management System��6   
�������$��24(�5      $
��Bold"�5      $��0��5       $��	0,0,388,0q�6,   �� 5"      $��2��6   $��30,0,0,0q�6-   .+�5#      �� -   5         ��Name$ UserNameTextBlock��5#       $��Officer Name��5$       
�������$��16(�5&       �� 5'      -   5        $ UserRoleTextBlock��5'       $��Traffic Police��5(       ���#FFDAB9$��14(�5*       5+      �� 5-      -   5        $��Log out��5-         DangerButtonStyle#��[  5.      $��84��50      $��Center=�51      $��3��52      $��0,5,0,5q�6)   53      54      �� 56   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��20,0,0,0q�6a   $��1��6s   .+�57      �� $��Plate Number:��6   $	��100��6,   $��Center=�68   �� 58      -   5        	 ��Name$	 PlateNumberTextBox��58      $	��120��62   $��Center=�6>   $��5q�6Y   �� 5:      $��
From Date:��6   $��80��6)   $��Center=�64   (  "System.Windows.Controls.DatePicker  5;      -   5        
  Name$
 FromDatePicker��5;      $	��120��61   $��Center=�6=   $��5q�6X   �� 5=      $��To Date:��6   $��80��6'   $��Center=�62     5>      -   5        $
 ToDatePicker��5>      $	��120��6/   $��Center=�6;   $��5q�6V   �� 5@      -   5         ��Name$ SearchButton��5@      $��Search��6+   $��12(�6<   $��60��6J   $��25��6U   ���#FF8C00
�������$	��5,0q�6�   �� 5A      -   5        $ ResetButton��5A      $��Reset��6*   $��12(�6:   $��60��6H   $��25��6S   
�������
�������$	��5,0q�6�   5C      � 5F   
   $��1��6   $��20,36,20,20q�6    5G      �� 5H      $��* �6#   �� 5I      $
��Auto �6#   .+�5M      &   System.Windows.Controls.DataGrid  -	   5          Name$ ReportsDataGrid��5M      $��0��5N         AutoGenerateColumns$ False��5O         
IsReadOnly$
 True��5P         SelectionMode$ Single=�5Q      
����������#FF8C00   RowBackground
 �����$��	0,0,10,10q�5U         Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ ReportID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *
ReportId+  5X      $ ViolationType��6)   $	 100 6@    6L   �� *ViolationType+  5Y      $ Description��6)   $ * 6>    6H   �� *Description+  5Z      $ PlateNumber��6)   $ 80 6>    6I   �� *PlateNumber+  5[      $ Location��6)   $ 80 6;    6F   �� *
Location+  5\      $ ImageURL��6)   $ * 6;    6E   �� *
ImageUrl+  5]      $ VideoURL��6)   $ * 6;    6E   �� *
VideoUrl+  5^      $ 
ReportDate��6)   $	 130 6=    6I   �� *
ReportDate+  5_      $ Status��6)   $ 80 69    6D   �� *Status+5a      �� 5d      $��1��6   $	��200��6)   $��20,0,0,0q�65   .+�5e      �� -
   5        $��View Details��5e        PrimaryButtonStyle#��[ 5f      $
��0,10q�5g      5h      �� 5i      -   5        $��Approve Report��5i        SuccessButtonStyle#��[ 5j      $
��0,10q�5k      5l      �� 5m      -   5        $��Reject Report��5m      #��[  5n      $
��0,10q�5o      5p      �� 5q      -   5        $��List Violation��5q        SecondaryButtonStyle#��[ 5r      $��	0,40,0,10q�5s      5t      �� 5u      -   5        $��Manage Vehicle��5u      #��[ 5v      $
��0,10q�5w      5x      �� 5y      -   5        $��Your Profile��5y      #��[ 5z      $��	0,10,0,10q�5{      5|      �� 5}      -   5        $��Notification��5}      #��[ 5~      $��	0,10,0,10q�5      5�      5�      5�      5�      5�      