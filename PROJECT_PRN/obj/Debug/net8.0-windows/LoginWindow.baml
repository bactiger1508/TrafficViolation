   M S B A M L   `   `   `  ����F  BPROJECT_PRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PROJECT_PRNPROJECT_PRN  5   	       PROJECT_PRN.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PROJECT_PRN     5   	   -   5          � Title$  LOGIN��5   	   $	��550��6   $	��800��6$   ���#F0F8FF � WindowStartupLocation$ CenterScreen=�6E    � 
ResizeMode$ NoResize=�6j    � WindowState$ 	Maximized=�6�   .��5
      � ��5   
   �� 5       �� ImageSource$N HC:\Code C#\PRN_PROJECT\PRN_PROJECT\PROJECT_PRN\Background\background.jpg��6    j� Stretch$
 Fill=�6p   .+�5   
   �� -   5        $	��✖��5      $��Right=�6   $	��Top=�69   $��	0,10,28,0q�6Q   $��47��5      $��37��6   
���  ��
�������
�������$��1q�5   %    � ToolTip$
 Quit��69    J� RenderTransformOrigin$ 0.5,0.5&�6H   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.885Q�6&   T� 5      5      5      �� 5!   
   $	��500��6   $	��400��6   	 �� CornerRadius$	 15��6*   
����������#FF8C00$��2q�6e   $��Center=�6y   $��Center=�6�   
 �� Padding$
 20q�6�   ._�5"      � .+�5$      �� $��LOG IN��6   $��Center=�6)   $	��Top=�6F      HeaderLabelStyle#��[  6^   $��0,10,0,0q�6�   �� 5'      $��Email:��6   $
��Left=�6)   $	��Top=�6D   $��	40,80,0,0q�6\   �� 5(      -   5         ��Name$ EmailTextBox��5(      $
��Left=�60   $��
40,110,0,0q�6K   $	��Top=�6_   $	��400��6w   $��35��6�   $��14(�6�   $��5q�6�   ���#FF8C00$��1q�6�   �� 5+      $��	Password:��6   $
��Left=�6,   $	��Top=�6G   $��
40,160,0,0q�6_   G� 5,      -   5         G�Name$ PasswordBox��5,      $
��Left=�63   $��
40,190,0,0q�6N   $	��Top=�6b   $	��400��6z   $��35��6�   $��14(�6�   $��5q�6�   ���#FF8C00$��1q�6�   �� 5-      -   5        $ txtPassword��5-      $
��Left=�6/   $��
40,190,0,0q�6J   $	��Top=�5.      $	��400��61   $��35��6=   $��14(�6I   $��5q�6W   ���#FF8C00$��1q�5/   /   $y�	Collapsed=�6C   �� 51      -   5        $��Show password��51      $
��Left=�63   $��40,230,0,110q�6N   52   8   �� 54       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Bottom=�6S   $��0,0,0,50q�6n   .+�55      �� -   5         ��Name$ LoginButton��55      $��Login��62   $	��120��6B   $��40��6N   ���#FF8C00
����������#FF4500$��1q�6�   56      �� 59      $ 
Horizontal=�6   $��Center=�66   $��Bottom=�6S   $��0,50,0,0q�6n   .+�5:      �� $"��If you don't have an account��6   
�������$��14(�6U   $��Center=�6c   �� 5;      -   5         ��Name$ RegisterTextBlock��5;       $��	Underline{�6;   $��14(�6W   $��Register��6e   ���#FF4500$��Center=�6�   $��5,0,0,0q�6�    � Cursor$
 Hand��6�   6�   5<      5>      5?      5@      5A      