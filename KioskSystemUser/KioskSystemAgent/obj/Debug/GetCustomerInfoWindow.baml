   M S B A M L   `   `   `  ����K  GKioskSystemAgent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KioskSystemAgentKioskSystemAgent  5   	   ,    &KioskSystemAgent.GetCustomerInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KioskSystemAgent     5   	     � Title$  GetCustomerInfoWindow��5   	   $	��450��6'   $	��800��64    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      � -   5         �Name$ Cusotmer��5      .+�5   
   �� -   5         ��Name$ CustomerInformation��5      $	��400��5      $	��500��5      .+�5      �� -   5        $ CounterPanel��5       �� Orientation$ 
Horizontal=�5      $��20q�5      .+�5      �� $��40��6   $	��150��5      $
��Left=�5      $��0,0,10,0q�5      $
��Bold"�5      $��25(�5      $��
CounterID:��5      5      �� 5      -   5         ��Name$ 	CounterID��5      $��40��5      $	��300��5      $��2q�5      $��25(�5       
������� �� TextWrapping$
 Wrap=�5"       �� AcceptsReturn . .��5#   +   5%      5&      �� 5(      -   5        $ 
TokenPanel��5(      $ 
Horizontal=�5)      $��20q�5*      .+�5+      �� $��40��6   $	��150��5,      $
��Left=�5-      $��0,0,10,0q�5.      $
��Bold"�5/      $��25(�50      $��TokenNo:��51      53      �� 54      -   5        $ TokenNo��54      $��40��55      $	��300��56      $��2q�57      $��25(�58      
�������$
 Wrap=�5:       . .��5;   +   5=      5>      5@      �� 5C   
   -   5        $ Controls��5C      $��50��5D      $ 
Horizontal=�5E      $��Center=�5F      .+�5H      �� -   5        $��50��5H      $	��150��5I      $
��Back��5J      $
��Bold"�5K      $��0,0,10,0q�5L      $��30(�5M      
����+��5P      �� 5R      -	   5        $��50��5R      $	��150��5S      $	��Get��5T      $
��Bold"�5U      $��0,0,10,0q�5V      $��30(�5W      
���"�"�5Z      5[      5\      5]      