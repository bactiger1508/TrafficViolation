   M S B A M L   `   `   `  ����   PROJECT_PRN*    $PROJECT_PRN.CreateNotificationWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Tạo Thông Báo Mới��$	��600��$	��600��.��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Create A New Notify��$��20(�$��Center=�$��0,0,0,20q��� $��1�� �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+�	� -    	�Name$ 
RbAllUsers��$��All User��$��0,0,20,0q�	� -   $ RbSpecificUser��$��Send Specific User���� -    ��Name$ UserSearchPanel��$��2��$��0,0,0,10q�$y�	Collapsed=�.+��� -    ��Name$ UserSearchTextBox���� -    ��Name$ UserListView��$	��150�� �� SelectionMode$ Multiple=����� .R��� $ 
Horizontal=�.+��� $��0,0,10,0q����� *
FullName+�� ���� *Email+�� -   $ MessageTextBox��$��3�� �� TextWrapping$
 Wrap=�	 �� AcceptsReturn$
	 True��"
 �� VerticalScrollBarVisibility$

 Auto=��� $��4��$ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� -   $
��Send��$��0,0,10,0q�$	��100���� -   $��Cancel��$	��100��