   M S B A M L   `   `   `  ����  PROJECT_PRN"    PROJECT_PRN.ViewDetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  DetailWindow��5   	   $	��900��6   $	��800��6+   ���#F0F8FF � WindowStartupLocation$ CenterScreen=�6L    � 
ResizeMode$ NoResize=�6q   .��5      � .+�5   
   �� -   5         ��Name$ ViewDetailWindowModeLabel��5      $��View Detail Report��63      HeaderLabelStyle#��[  5      $��0,0,0,20q�6:   �� 5   
   $��Reporter Name:��6   $
��Left=�6)   $��	38,97,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ UserNameTextBox��5      $
��Left=�6+   $��
175,97,0,0q�6F   $	��Top=�6Z   $	��567��6r   $��30��6~   ���#FF8C00$��1q�5        �� 
IsReadOnly$
 True��64   �� 5   
   $��Violation Type:��6   $
��Left=�6*   $��
38,140,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5        $ ViolationTypeTextBox��5      $
��Left=�60   $��175,140,0,0q�6K   $	��Top=�6`   $	��567��6x   $��30��6�   ���#FF8C00$��1q�6�   $
 True��6�   �� 5   
   $��Plate Number:��6   $
��Left=�6(   $��
38,180,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ PlateNumberTextBox��5      $
��Left=�6.   $��175,180,0,0q�6I   $	��Top=�6^   $	��567��6v   $��30��6�   ���#FF8C00$��1q�6�   $
 True��6�   �� 5   
   $��
Image URL:��6   $
��Left=�6%   $��
38,220,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ ImageUrlTextBox��5      $
��Left=�6+   $��175,220,0,0q�6F   $	��Top=�6[   $	��567��6s   $��30��6   ���#FF8C00$��1q�6�   $
 True��6�   �� 5   
   $��
Video URL:��6   $
��Left=�6%   $��
38,260,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ VideoUrlTextBox��5      $
��Left=�6+   $��175,260,0,0q�6F   $	��Top=�6[   $	��567��6s   $��30��6   ���#FF8C00$��1q�6�   $
 True��6�   �� 5   
   $��	Location:��6   $
��Left=�6$   $��
38,300,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ LocationTextBox��5      $
��Left=�6+   $��175,300,0,0q�6F   $	��Top=�6[   $	��567��6s   $��30��6   ���#FF8C00$��1q�6�   $
 True��6�   �� 5   
   $��Description:��6   $
��Left=�6'   $��
38,340,0,0q�6B   $	��Top=�6V   �� 5    
   -	   5        $ DescriptionTextBox��5       $
��Left=�6.   $��175,340,0,0q�6I   $	��Top=�6^   $	��567��6v   $��74��6�   ���#FF8C00$��1q�6�   $
 True��6�    �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5#   
   $��Violation Image:��6   $
��Left=�6+   $��
38,434,0,0q�6F   $	��Top=�6Z   �� 5$   
   -
   5         ��Name$ ImageViolation��5$      $	��310��6(   $��175,434,60,0q�65   $	��Top=�6K   $��Uniform=�6c   �� 5'   
   -   5        	 ��Name$	 CloseButton��5'      $��Close��6&     DangerButtonStyle#��[ 5(      $��Center=�6<   $��	0,796,0,0q�5)      $	��Top=�6$   $	��120��6<   $��45��6H   6T   5*      5+      