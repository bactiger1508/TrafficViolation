   M S B A M L   `   `   `  ����  PROJECT_PRN*    $PROJECT_PRN.CreateNotificationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Tạo Thông Báo Mới��5   	   $	��600��6#   $	��600��60   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Create A New Notify��6   $��20(�5      $��Center=�5      $��0,0,0,20q�5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      	� -   5         	�Name$ 
RbAllUsers��5      $��All User��5      $��0,0,20,0q�5      5      	� 5      -   5        $ RbSpecificUser��5      $��Send Specific User��5      5      5      �� 5   
   -   5         ��Name$ UserSearchPanel��5      $��2��5       $��0,0,0,10q�5!      $y�	Collapsed=�5"      .+�5#      �� -   5         ��Name$ UserSearchTextBox��5#      5%      �� 5'      -   5         ��Name$ UserListView��5'      $	��150��5(       �� SelectionMode$ Multiple=�5)      ��5*      �� 5+      .R�5,      �� $ 
Horizontal=�6%   .+�5-      �� $��0,0,10,0q�6B   ��6(   �� *
FullName+6B   �� 5.      ��6(   �� *Email+5/      50      52      53      �� 56   
   -   5        $ MessageTextBox��56      $��3��57       �� TextWrapping$
 Wrap=�58      	 �� AcceptsReturn$
	 True��59      "
 �� VerticalScrollBarVisibility$

 Auto=�5:      �� 5=   
   $��4��6   $ 
Horizontal=�5>      $��Center=�5?      $��0,10,0,0q�5@      .+�5A      �� -   5        $
��Send��5A      $��0,0,10,0q�5C      $	��100��5D      �� 5E      -   5        $��Cancel��5E      $	��100��5G      5H      5I      5J      