   M S B A M L   `   `   `  ���� F  BPROJECT_PRN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PROJECT_PRNPROJECT_PRN      PROJECT_PRN.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:PROJECT_PRN     -     � Title$  LOGIN��$	��550��$	��800�����#F0F8FF � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=�.��� ����  �� ImageSource$C =C:\C# Coder\PRN_PROJECT\PROJECT_PRN\Background\background.jpg�� j� Stretch$
 Fill=�.+��� -   $	��✖��$��Right=�$	��Top=�$��	0,10,28,0q�$��47��$��37��
���  ��
�������
�������$��1q� � ToolTip$
 Quit�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.885Q�T� �� $	��500��$	��400��	 �� CornerRadius$	 15��
����������#FF8C00$��2q�$��Center=�$��Center=�
 �� Padding$
 20q�._�� .+��� $��LOG IN��$��Center=�$	��Top=�   HeaderLabelStyle#��[  $��0,10,0,0q��� $��Email:��$
��Left=�$	��Top=�$��	40,80,0,0q��� -    ��Name$ EmailTextBox��$
��Left=�$��
40,110,0,0q�$	��Top=�$	��400��$��35��$��14(�$��5q����#FF8C00$��1q��� $��	Password:��$
��Left=�$	��Top=�$��
40,160,0,0q�G� -    G�Name$ PasswordBox��$
��Left=�$��
40,190,0,0q�$	��Top=�$	��400��$��35��$��14(�$��5q����#FF8C00$��1q��� -   $ txtPassword��$
��Left=�$��
40,190,0,0q�$	��Top=�$	��400��$��35��$��14(�$��5q����#FF8C00$��1q�$y�	Collapsed=��� -   $��Show password��$
��Left=�$��40,230,0,110q���  �� Orientation$ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,50q�.+��� -    ��Name$ LoginButton��$��Login��$	��120��$��40�����#FF8C00
����������#FF4500$��1q��� $ 
Horizontal=�$��Center=�$��Bottom=�$��0,50,0,0q�.+��� $"��If you don't have an account��
�������$��14(�$��Center=��� -    ��Name$ RegisterTextBlock��$��	Underline{�$��14(�$��Register�����#FF4500$��Center=�$��5,0,0,0q� � Cursor$
 Hand��