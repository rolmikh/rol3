   M S B A M L   `   `   `  ����B  >auto_up, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:auto_upauto_up  5   	       auto_up.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:auto_up     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��700��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��2��6!   $��18(�61    �� TextAlignment$ Center=�6?   АВТОРИЗАЦИЯ6d   �� 5    
   $��17(�6   $��2��6"   $��1��6/   Логин:6H   �� 5!   
   -   5         ��Name$ txtLogin��5!      $��2��6$   $��1��61   $��3��6A   $��0,58,0,0q�6U   $��2��6g   $��17(�6x   6�   �� 5"   
   $��4��6   $��1��6!   $��17(�61   Пароль:6H   G� 5#   
   -   5         G�Name$ txtPassword��5#      $��4��6+   $��1��68   $��17(�6H   $��3��6V   $��	0,58,0,58q�6j   $��3��6}   6�   �� 5$   
   -   5         ��Name$ btnLogIn��5$      $��2��6#   $��7��63   $��17(�6@   .��6e   
Войти6l   �� 5%   
   -   5        $ btnRegister��5%      $��2��6&   $��8��66   $��17(�6C   .��6l   Регистрация6y   5&      5'      