   M S B A M L   `   `   `  ����  PROJECT_PRN#    PROJECT_PRN.UserVehicleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  User Vehicle Management��5   	   $	��600��6)   $	��800��66   ���#F0F8FF � WindowStartupLocation$ CenterScreen=�6W   .��5      � .+�5   
   �� $��Vehicle Management��6   $��Center=�6-   $	��Top=�6J   $��24(�5      $
��Bold"�6   ���#FF4500$��0,20,0,0q�6E   �� 5   
   -   5         ��Name$ VehicleTabControl��5      $��Stretch=�60   $��Stretch=�6N   $��20,60,20,100q�6j   .@�5      �� -   5         ��Name$ AllVehiclesTab��5   ,   $��All Vehicles��6   .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ AllVehiclesDataGrid��5         AutoGenerateColumns$ False��6<   $��10q�6X      
IsReadOnly$
 True��6d      CanUserAddRows$ False��5         CanUserDeleteRows$ False��66   	   SelectionMode$	 Single=�6P   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Plate Number��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *PlateNumber+6g     5      $ Brand��61   $ * 6Z    6@   �� *Brand+6Z     5      $ Model��61   $ * 6Z    6@   �� *Model+6Z     5      $
 Year��61   $ * 6c    6?   �� *ManufactureYear+6c     5      $ FullName��61   $ * 6`    6C   �� *
FullName+6`   5      5      5      �� 5      -   5        $ MyVehiclesTab��5   +   $��My Vehicles��6   .��5      � .+�5        -   5        $ MyVehiclesDataGrid��5      $ False��6;   $��10q�6W   $
 True��6c   $ False��5       $ False��66   $	 Single=�6P   
 5!        5"      $ Plate Number��61   $ * 6g    6G   �� *PlateNumber+6g     5#      $ Brand��61   $ * 6Z    6@   �� *Brand+6Z     5$      $ Model��61   $ * 6Z    6@   �� *Model+6Z     5%      $
 Year��61   $ * 6c    6?   �� *ManufactureYear+6c   5'      5(      5)      5*      �� 5-   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��0,0,0,20q�6f   .+�5.      �� -   5        $
��Back��5.      $	��100��6$   $��40��60   ���#FF8C00
�������5/      50      51      52      