   M S B A M L   `   `   `  ����  PROJECT_PRN$    PROJECT_PRN.NotificationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Notifications��5   	   $	��450��6   $	��600��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��Notify��6   $��24(�5      $��Center=�5      $
��0,10q�5      �� 5   
   -   5         ��Name$ NotificationsListView��5      $��1��5      $��20q�5      ��5      �� 5      .R�5      �� .+�5      �� $
��Bold"�6=   ��6$   �� *	Message+6=   �� 5      
���������6$   �� *
SentDate+6>   5      5      5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��20q�6X   .+�5      �� -   5         ��Name$ MarkAll��5   (   $��Mark All��6   $��0,0,10,0q�5       5!      �� 5#      -   5        $ CreateNotification��5#   .   $��Create Notify��6   5$      �� 5%      -   5        $
��Back��5%      $��	10,0,10,0q�6$   $��68��68   6C   5&      5'      5(      