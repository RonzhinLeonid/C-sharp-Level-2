   M S B A M L   `   `   `  ����?  ;Les7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Les7Les7  5   	       Les7.CardEmployees   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Les7     5   	     � Title$%  Карта сотрудника��5   	   $	��250��6"   $	��500��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Stretch=�5      $��Stretch=�5      $��0��5      $��0��5      .+�5      �� -   5         ��Name$ lblName��5      $��Label��6%   $
��Left=�65   $��Center=�6P   $��50,0,0,0q�6k   �� 5      -   5        $ 	lblSuname��5      $��Label��6'   $
��Left=�67   $��Center=�6R   $��50,0,0,0q�6m   �� 5      -   5        $ lblAge��5      $��Label��6$   $
��Left=�64   $��Center=�6O   $��50,0,0,0q�6j   �� 5      -   5        $ 	lblSalary��5      $��Label��6'   $
��Left=�67   $��Center=�6R   $��50,0,0,0q�6m   �� 5      -   5        $ lblPhoneNumber��5      $��Label��6,   $
��Left=�6<   $��Center=�6W   $��50,0,0,0q�6r   �� 5      -   5        $ lblDepartmentID��5      $��Label��6-   $
��Left=�6=   $��Center=�6X   $��50,0,0,0q�6s   5      �� 5    
   $ Vertical=�6   $��Stretch=�5!      $��Stretch=�5"      $��1��5#      $��0��5$      .+�5%      �� -   5         ��Name$ tbName��5%      $
��Left=�6&   $��Center=�6A   $��23��5&      $	��120��6   $��50,0,0,3q�6*    �� TextWrapping$
 Wrap=�5'      ��6&   ��  �� ElementName$ lblName�� �� Path$ Content�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 5+      -   5        $ tbSuname��5+      $
��Left=�6(   $��Center=�6C   $��23��5,      $	��120��6   $��50,0,0,3q�6*   $
 Wrap=�5-      ��6&   �� $ 	lblSuname��$ Content�$	 PropertyChanged=�$
 TwoWay=��� 51      -	   5        $ tbAge��51      $
��Left=�6%   $��Center=�6@   $��23��52      $	��120��6   $��50,0,0,3q�6*   $
 Wrap=�53      ��6&   �� $ lblAge��$ Content�$	 PropertyChanged=�$
 TwoWay=��� 57      -
   5        $ tbSalary��57      $
��Left=�6(   $��Center=�6C   $��23��58      $	��120��6   $��50,0,0,3q�6*   $
 Wrap=�59      ��6&   �� $ 	lblSalary��$ Content�$	 PropertyChanged=�$
 TwoWay=��� 5=      -   5        $ tbPhoneNumber��5=      $
��Left=�6-   $��Center=�6H   $��23��5>      $	��120��6   $��50,0,0,3q�6*   $
 Wrap=�5?      ��6&   �� $ lblPhoneNumber��$ Content�$	 PropertyChanged=�$
 TwoWay=��� 5C      -   5         ��Name$ cbDepartment��5C      $
��Left=�6-   $��Center=�6H   $��23��5D      $	��120��6   $��50,0,0,3q�6+   ��5F      �� 5G      .R�5H      �� ��6$   �� $
 Name�5I      5K      5L      �� 5M   
   -   5         ��Name$ btnClose��5M      $��Отмена��6#   $��0��64   $��1��6D   $��Center=�6Q   $��Center=�6n   $��75��6�   6�   �� 5N   
   -   5        $ btnSave��5N      $��Сохранить��6"   $��1��66   $��1��6F   $��Center=�6S   $��Center=�6p   $��75��6�   6�   5O      5P      