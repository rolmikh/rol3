   M S B A M L   `   `   `  ����B  >auto_up, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:auto_upauto_up  5   	       auto_up.NewFirm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:auto_up     5   	   -   5          � Title$  NewFirm��5   	   $	��700��6   $	��900��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5    
   �� $��0��6   $��2��6!   $��25(�61    �� TextAlignment$ Center=�6?   $��2��6V   $��	0,0,10,10q�6j   !Добавление фирмы6�   �� 5!   
   $��8��6   $��3��6!   $��20(�61   Тип фирмы:6K   �� 5"   
   -   5         ��Name$ cmbType��5"      $��7��6$   $��4��61   $��20(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5#   
   $��5��6   $��0��6!   $��20(�61   Название6I   �� 5$   
   -   5         ��Name$ txtTitle��5$      $��4��6$   $��1��61   $��20(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5%   
   $��6��6   $��0��6!   $��15(�61   $"Юридический адрес:6S   �� 5&   
   -   5        $ txtLegalAddress��5&      $��5��6+   $��1��68   $��2��6H   $��20(�6\   $��	0,57,10,0q�6j   $��2��6}   6�   �� 5'   
   $��7��6   $��0��6!   $��16(�61   " Физический адрес:6R   �� 5(   
   -   5        $ txtPhysicalAddress��5(      $��6��6.   $��1��6;   $��20(�6K   $��2��6Y   $��	0,57,10,0q�6m   $��2��6�   6�   �� 5)   
   $��10��6   $��0��6"   $��20(�62   	БИК:6G   �� 5*   
   -   5        $ txtBIC��5*      $��9��6"   $��1��6/   $��20(�6?   $��2��6M   $��	0,57,10,0q�6a   $��2��6t   6�   �� 5+   
   $��7��6   $��3��6!   $��20(�61   	ИНН:6F   �� 5,   
   -   5        $ txtINN��5,      $��6��6"   $��4��6/   $��20(�6?   $��2��6M   $��	0,57,10,0q�6a   $��2��6t   6�   �� 5-   
   $��5��6   $��3��6!   $��20(�61   	КПП:6E   �� 5.   
   -   5        $ txtKPP��5.      $��4��6"   $��4��6/   $��20(�6?   $��2��6M   $��	0,57,10,0q�6a   $��2��6t   6�   �� 5/   
   $��6��6   $��3��6!   $��20(�61   	ОГРН:6F   �� 50   
   -	   5        $ txtOGRN��50      $��5��6#   $��4��60   $��20(�6@   $��2��6N   $��	0,57,10,0q�6b   $��2��6u   6�   �� 51   
   $��8��6   $��0��6!   $��18(�61   Номер телефона:6Q   �� 52   
   -
   5        $ 	txtNumber��52      $��7��6%   $��1��62   $��20(�6B   $��2��6P   $��	0,57,10,0q�6d   $��2��6w   6�   �� 53   
   $��9��6   $��0��6!   $��20(�61   Почта:6G   �� 54   
   -   5        $ txtEmail��54      $��8��6$   $��1��61   $��20(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 55   
   $��9��6   $��3��6!   $��20(�61   Страна:6H   �� 56   
   -   5        $ 
cmbCountry��56      $��8��6'   $��4��64   $��20(�6D   $��2��6R   $��	0,57,10,0q�6f   $��2��6y   6�   &   System.Windows.Controls.DataGrid  57   
   -   5          Name$ dtgFirms��57      $��6��6%   $��10,57,10,28q�69   $��5��6N      
IsReadOnly . 58      �� 59   
   -   5         ��Name$ btnAdd��59      $��11��6!   $��3��6/   $��25(�6?   .��6b   Добавить6l   �� 5:   
   -   5        $ btnToChange��5:      $��11��6&   $��4��64   $��25(�6D   .��6l   Изменить6v   �� 5;   
   -   5        $ 	btnDelete��5;      $��11��6$   $��5��62   $��25(�6B   .��6h   Удалить6q   �� 5<   
   -   5        $ btnBack��5<      $��0��6"   $��5��6/   $��25(�6?   .��6c   
Назад6j   5?      5@      