   M S B A M L   `   `   `  ����  PROJECT_PRN%    PROJECT_PRN.ViolationListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Violation List��5   	   $	��700��6    $	��900��6-    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Violation List��6   $��28(�5      $
��Bold"�5      $��Center=�5      $��	0,20,0,10q�5      �� 5   
   -   5         ��Name$ ViolationTabControl��5      $��10q�62   $��1��6>   .@�5      �� -   5         ��Name$ AllViolationsTab��5   .   $��All Violations��6   .��5      �  5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5#      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�5$   !   $��	0,10,0,10q�5%   !   $��0��5&   !   .+�5'      �� $��Plate Number:��6    $��Center=�68   �� 5(      -   5         ��Name$ AllPlateNumberTextBox��5(   "   $	��100��6A   $	��5,0q�6M   �� 5*      $��From:��6    $��Center=�60   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ AllFromDatePicker��5+   %   $	��120��6@   $	��5,0q�6L   �� 5-      $	��To:��6    $��Center=�6.     5.      -   5        $ AllToDatePicker��5.   %   $	��120��6>   $	��5,0q�6J   �� 50      -   5         ��Name$ AllSearchButton��50   !   $��Search��51   !   $��80��52   !   $��30��6,   
��� ���
�������$
��10,0q�54   !   55   !   56      �� 59      $��1��6#   $
��Auto=�60   .��5:      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 AllViolationsDataGrid��5:   #   
   AutoGenerateColumns$
 False��5;   #      CanUserAddRows$ False��5<   #      
IsReadOnly$
 True��5=   #   $��10q�5>   #      Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 	User Name��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
UserName+6e     5A   "   $ Plate Number��65   $ * 6k    6K   �� *PlateNumber+6k     5B   "   $ Fine Amount��65   $ * 6i    6J   �� *
FineAmount+6i     5C   "   $ 	Fine Date��65   $ * 6�    6H   �� *
FineDate+ �� StringFormat$ 
dd/MM/yyyy��6�     5D   "   $ Fine Status��65   $ * 6i    6J   �� *
FineStatus+6i   5F      5G      �� 5J      $��2��6!   $ Vertical=�6.   $��Center=�6E   $��10q�6b   .+�5K      �� -	   5         ��Name$&  TotalUnpaidFinesForAllUsersLabel��5K       $
��Bold"�5L       
���  ��$��14(�5N       $y�	Collapsed=�5O       �� 5P      -
   5        $$ TotalPaidFinesForAllUsersLabel��5P       $
��Bold"�5Q       
��� � �$��14(�5S       $y�	Collapsed=�5T       5U      5V      5W      �� 5Z      -   5        $ YourViolationsTab��5Z   /   $��Your Violations��6   .��5[      �  5\      �� 5]      $
��Auto �6(   �� 5^      $��* �6(   �� 5_      $
��Auto �6(   �� 5`      $
��Auto �6(   .+�5d      �� $ 
Horizontal=�6!   $��Center=�5e   !   $��	0,10,0,10q�5f   !   $��0��5g   !   .+�5h      �� $��Plate Number:��6    $��Center=�68   �� 5i      -   5        $ PlateNumberTextBox��5i   "   $	��100��6>   $	��5,0q�6J   �� 5k      $��From:��6    $��Center=�60     5l      -   5        $ FromDatePicker��5l   %   $	��120��6=   $	��5,0q�6I   �� 5n      $	��To:��6    $��Center=�6.     5o      -   5        $ ToDatePicker��5o   %   $	��120��6;   $	��5,0q�6G   �� 5q      -   5        $ SearchButton��5q   !   $��Search��5r   !   $��80��5s   !   $��30��6,   
��� ���
�������$
��10,0q�5u   !   5v   !   5w      �� 5z      $��1��6#   $
��Auto=�60   .��5{        -   5        $	 YourViolationsDataGrid��5{   #   $
 False��5|   #   $ False��5}   #   $
 True��5~   #   $��10q�5   #    5�        5�   "   $ 	User Name��65   $ * 6e    6H   �� *
UserName+6e     5�   "   $ Plate Number��65   $ * 6k    6K   �� *PlateNumber+6k     5�   "   $ Fine Amount��65   $ * 6i    6J   �� *
FineAmount+6i     5�   "   $ 	Fine Date��65   $ * 6�    6H   �� *
FineDate+$ 
dd/MM/yyyy��6�     5�   "   $ Fine Status��65   $ * 6i    6J   �� *
FineStatus+6i   5�      5�      �� 5�      $��2��6!   $ Vertical=�6.   $��Center=�6E   $��10q�6b   .+�5�      �� -   5        $ TotalUnpaidFinesLabel��5�       $
��Bold"�5�       
���  ��$��14(�5�       $y�	Collapsed=�5�       �� 5�      -   5        $ TotalPaidFinesLabel��5�       $
��Bold"�5�       
��� � �$��14(�5�       $y�	Collapsed=�5�       5�      �� 5�      -   5        $ 	PayButton��5�      $��3��5�      $��Pay Fine��5�      $	��150��5�      $��40��5�      $��Center=�5�      $��	0,10,0,10q�5�      
��� � �
�������$
��Bold"�5�      5�      5�      5�      5�      5�      5�      