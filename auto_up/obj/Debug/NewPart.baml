   M S B A M L   `   `   `  ����B  >auto_up, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:auto_upauto_up  5   	       auto_up.NewPart   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:auto_up     5   	   -   5          � Title$  NewPart��5   	   $	��700��6   $	��900��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5    
   �� $��0��6   $��2��6!    �� TextAlignment$ Center=�61   $��20(�6H   $��2��6V   +)Редактирование товара6�   �� 5!   
   $��0��6   $��5��6$   $��17(�61    Название товара:6Q   �� 5"   
   -   5         ��Name$ txtTitle��5"      $��1��6$   $��4��64   $��17(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5#   
   $��0��6   $��6��6$   $��17(�61   Тип товара:6L   �� 5$   
   -   5         ��Name$ cmbType��5$      $��1��6$   $��5��64   $��17(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5%   
   $��0��6   $��7��6$   $��17(�61   " Стоимость товара:6R   �� 5&   
   -   5        $ txtPrice��5&      $��1��6$   $��6��64   $��17(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5'   
   $��0��6   $��8��6$   $��17(�61   Статус:6H   �� 5(   
   -   5        $ 	txtStatus��5(      $��1��6%   $��7��65   $��17(�6B   $��2��6P   $��	0,57,10,0q�6d   $��2��6w   6�   �� 5)   
   $��0��6   $��9��6$   $��17(�61   Количество:6L   �� 5*   
   -   5        $ txtCount��5*      $��1��6$   $��8��64   $��17(�6A   $��2��6O   $��	0,57,10,0q�6c   $��2��6v   6�   �� 5+   
   $��3��6   $��5��6$   $��17(�61   Модель товара:6O   �� 5,   
   -   5        $ cmbModel��5,      $��4��6%   $��4��65   $��17(�6B   $��2��6P   $��	0,57,10,0q�6d   $��2��6w   6�   �� 5-   
   $��3��6   $��6��6%   $��17(�62   Бренд товара:6O   �� 5.   
   -   5        $ cmbBrend��5.      $��4��6%   $��5��65   $��17(�6B   $��2��6P   $��	0,57,10,0q�6d   $��2��6w   6�   �� 5/   
   $��3��6   $��7��6$   $��14(�61   (&Название поставщика:6U   �� 50   
   -	   5        $ cmbProvider��50      $��4��6(   $��6��68   $��17(�6E   $��2��6S   $��	0,57,10,0q�6g   $��2��6z   6�   �� 51      $��3��6   $��8��6&   $��17(�63   	Брак:6I   �� 52   
   -
   5        $ 	cmbDamage��52      $��4��6%   $��7��65   $��17(�6B   $��2��6P   $��	0,57,10,0q�6d   $��2��6w   6�   &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ dtgParts��53      $��6��6&   $��
10,53,10,0q�6:   $��4��6N   �� 54   
   -   5         ��Name$ 	btnDelete��54      $��11��6$   $��2��62   $��20(�6B   .��6h   Удалить6q   �� 55   
   -   5        $ btnAdd��55      $��11��6!   $��3��6/   $��20(�6?   .��6b   Добавить6l   �� 56   
   -   5        $ 	btnChange��56      $��11��6$   $��4��62   $��20(�6B   .��6h   Изменить6r   �� 57   
   -   5        $ 	btnCancel��57      $��0��6$   $��5��61   $��20(�6A   .��6g   
Назад6n   5:      5;      