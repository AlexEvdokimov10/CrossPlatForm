   M S B A M L   `   `   `  ����L  HWpfApp8_FrameWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp8_FrameWorkWpfApp8_FrameWork  5   	   "    WpfApp8_FrameWork.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfApp8_FrameWork     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ vykladachTrym��5   /      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 KodVykl��6A   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 120 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	KodVykl+6R     5      $	 	PrizvVykl��6C   $	
 125 6V    6%   �� *	PrizvVykl+6V     5      $	 ImaVykl��6B   $
 80 6S    6%   �� *
ImiaVykl+6S     5      $	 PoBaVylk��6B   $
 80 6T    6%   �� *
PoBaVykl+6T     5      $	 PIBVykl��6A   $
 80 6R    6%   �� *	PIBVykl+6R     5      $	 KodPost��6A   $
 80 6R    6%   �� *	KodPost+6R     5      $	 NomKaf��6@   $
 80 6P    6%   �� *NomKaf+6P   5!      �� 5#   
   $��Center=�6   $��1��63    �� Orientation$ 
Horizontal=�6@   .+�5$      �� -   5         ��Name$ updateButton��5$      $��Update��6+   6<   �� 5%      -   5        $ deleteButton��5%      $��Delete��6+   6<   �� 5&      -   5        $ 	addButton��5&      $	��Add��6(   66   5'      5(      5)      