   M S B A M L   `   `   `  ????D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	   -   5          ? 
ResizeMode$  NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5
   	    ? Title$ Настройки??5   	   $	??530??6   $	??500??6(    ? Icon$ Resources/tic logo.ico??64   .??5      ? 
??????? ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $	??10* ?6   .+?5   
   ?? 
???iii?$??0 0.2 0 0.2q?6'   $??1??6E   $??2??6R   $??	10 0 10 0q?6f   ?? 5   
   
???iii?$??0 0.2 0 0.2q?6'   $??3??6E   $??2??6R   $??	10 0 10 0q?6f   ?? 5   
   -   5        $	??Log??5      $??0??6   $??1??6,   $??2??6<   $
??Left=?5       $??Center=?6+    ?? TextAlignment$
 Left=?6F   $??18(?6[   $??0 0 0 0q?6j   @>Использовать случайную генерацию?? 5"   .   " "кто ходит первым"5#      (? 5%   
   $??25??6   $??0??6   $??Center=?6.   $??Center=?6I   $??0q?6f   .??5&      ?? -   5         ??Name$ UseRandomGeneration??5&      $??1??64   6D   5'      ?? 5)   
   -   5        $??AI??5)      $??1??6   $??1??6+   $N??HИспользовать Виртуального партнёра(beta)??6;   $
??Left=?5*      $??Center=?6+   $??18(?6F   $??0 0 0 0q?6T   (? 5-   
   $??25??6   $??1??6   $??Center=?6+   $??Center=?6F   .??5.      ?? -   5        $ UseAI??5.      $??1??6&   66   5/      ?? 51   
   $??2??6   $??1??6"   $
 Left=?62   $
??Left=?52      $??Center=?6+   $??18(?6F   $??0 0 0 0q?6T   LJИспользовать сохранение данных о сессии?? 54   5   виде XML55      (? 57   
   $??25??6   $??2??6   $??Center=?6+   $??Center=?6F   .??58      ?? -   5        $ UseSessionData??58      $??1??6/   6?   59      ?? 5;   
   -   5         ??Name$ SessionsWindow??5;      $
??📁??6)   
???????$??25(?5<      $	??Top=?6   $??2??6>   $??380 10 20 10q?6K   $??1??6a   5=      ?? 5@   
   $??3??6   $??1??6!   $)??#Использовать звуки??61   $
??Left=?5A      $??Center=?6+   $??18(?6F   $??0 0 0 0q?6T   (? 5D   
   $??25??6   $??3??6   $??Center=?6+   $??Center=?6F   .??5E      ?? -   5        $ UseSoundManager??5E      $??1??60   6@   5F      ?? 5H   
   -	   5        $??SaveAndGoBack??5H   -   $&?? Сохранить и выйти??6   
???????$??5q?5I      $??19(?6   $??7??6*   $??2??67   6K   5K      5L      