   M S B A M L   `   `   `  ����   PROJECT_PRN%    PROJECT_PRN.ProfileDetailWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Profile Detail��$	��400��$	��600�����#F0F8FF � WindowStartupLocation$ CenterScreen=�.��� $��20q�.+��� $��PROFILE DETAIL��$��Center=�$	��Top=�$��24(�$
��Bold"����#FF4500$��0,10,0,0q�� $	��Top=�$��Center=�$��0,60,0,0q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��170 ��� $	��300 �.+��� $��
Full Name:��$��0��$��0��$��16(�$��Center=��� -    ��Name$ FullNameTextBox��$��0��$��1��$��30�����#FF8C00$��1q��� $��Email:��$��1��$��0��$��16(�$��Center=��� -   $ EmailTextBox��$��1��$��1��$��30�����#FF8C00$��1q��� $��Phone:��$��2��$��0��$��16(�$��Center=��� -   $ PhoneTextBox��$��2��$��1��$��30�����#FF8C00$��1q��� $��Address:��$��3��$��0��$��16(�$��Center=��� -   $ AddressTextBox��$��3��$��1��$��30�����#FF8C00$��1q��� -    ��Name$ ChangePasswordTextBlock��$��Change Password��$��Center=�$��	0,230,0,0q�$	��Top=�$��16(����#FF4500$��	Underline{� � Cursor$
 Hand���� -    ��Name$ PasswordFields��$	��Top=�$��Center=�$��	0,220,0,0q�$y�	Collapsed=�.+���  �� Orientation$ 
Horizontal=�$��0 4 0 0q�.+��� -   	 ��Name$	 CurrentPasswordLabel��$��Old Password:��$	��160��$��16(�G� -	   
 G�Name$
 CurrentPasswordBox��$	��300��$��30�����#FF8C00$��1q��� $ 
Horizontal=�$��0 2 0 0q�.+��� -
   $	 NewPasswordLabel��$��New Password:��$	��160��$��16(�G� -   $
 NewPasswordBox��$	��300��$��30�����#FF8C00$��1q��� $ 
Horizontal=�$��0 2 0 0q�.+��� -   $	 ConfirmPasswordLabel��$��Confirm Password:��$	��160��$��16(�G� -   $
 ConfirmPasswordBox��$	��300��$��30�����#FF8C00$��1q��� $ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,20q�.+��� -    ��Name$ SaveChangesButton��$��Save Changes��$	��150��$��40�����#FF8C00
�������$��16(��� -   $ CancelTextBlock��$��Cancel��$��20,0,0,0q�$��16(�
�������$��	Underline{�$y�	Collapsed=�