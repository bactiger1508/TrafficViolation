   M S B A M L   `   `   `  ����   PROJECT_PRN#    PROJECT_PRN.UserVehicleWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  User Vehicle Management��$	��600��$	��800�����#F0F8FF � WindowStartupLocation$ CenterScreen=�.��� .+��� $��Vehicle Management��$��Center=�$	��Top=�$��24(�$
��Bold"����#FF4500$��0,20,0,0q��� -    ��Name$ VehicleTabControl��$��Stretch=�$��Stretch=�$��20,60,20,100q�.@��� -    ��Name$ AllVehiclesTab��$��All Vehicles��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ AllVehiclesDataGrid��   AutoGenerateColumns$ False��$��10q�   
IsReadOnly$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��	   SelectionMode$	 Single=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Plate Number��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *PlateNumber+  $ Brand��$ *  �� *Brand+  $ Model��$ *  �� *Model+  $
 Year��$ *  �� *ManufactureYear+  $ FullName��$ *  �� *
FullName+�� -   $ MyVehiclesTab��$��My Vehicles��.��� .+�  -   $ MyVehiclesDataGrid��$ False��$��10q�$
 True��$ False��$ False��$	 Single=�
   $ Plate Number��$ *  �� *PlateNumber+  $ Brand��$ *  �� *Brand+  $ Model��$ *  �� *Model+  $
 Year��$ *  �� *ManufactureYear+��  �� Orientation$ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,20q�.+��� -   $
��Back��$	��100��$��40�����#FF8C00
�������