   M S B A M L   `   `   `  ????C  ?TodoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoListToDoList  5   	       ToDoList.reg   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ToDoList     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	     ? Title$	  reg??5	   	   $	??700??6   $
??1200??6"   .??5
      ? .+?5   
   ?? -   5         ??Name$ 
Main_Plate??5      
???   ?$	??100??68   $	??100??6H   $??	0 0 0 600q?6X   ._?5      ?? $??
TO DO List??6   
???????$??Center=?6>   $??Center=?6Y   $??0 0 0 20q?6v   $??50(?6?   5      ?? 5   
   $??50??6   $	??300??6   $??50??6.   $	??100??6=   $??	0 0 0 140q?6M   
???????$??Center=?5       ?? Padding$ 20q?6,    ?? CornerRadius$ 20??69   $??3q?6K   
???   ? J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q?6#      Color$ Black??63      ShadowDepth$ 5Q?6A   ._?5      ?? .+?5      ?? -   5         ??Name$ Text_box_post??5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Ваша пошта??61   
???   ?$??19(?6q   
 ? Cursor$
 Arrow??6?   .??6?   5      5      5      ?? 5   
   $??50??6   $	??300??6   $??50??6.   $	??100??6=   $??0 60 0 0q?6M   
???????$??Center=?5      $ 20q?6,   $ 20??69   $??3q?6K   
???   ? 5        5       $ 50Q?6#   $ Black??63   $ 5Q?6A   ._?5"      ?? .+?5#      G? -   5         G?Name$ Passwod_box_1??5#      $	 Пароль??66   
???   ?$??19(?6q   5$      5%      ?? 5&   
   $??50??6   $	??300??6   $??50??6.   $	??100??6=   $??	0 240 0 0q?6M   
???????$??Center=?5'      $ 20q?6,   $ 20??69   $??3q?6K   
???   ? 5(        5)      $ 50Q?6#   $ Black??63   $ 5Q?6A   ._?5+      ?? .+?5,      G? -   5        $ Passwod_box_2??5,      $	 Пароль ще раз??66   
???   ?$??19(?6x   $
 Arrow??6?   5-      5.      ?? 5/   
   
???   ?$??70??6$   $	??200??63   $ 20??6B   $??	0 430 0 0q?6T   ._?50      ?? .+?51      ?? -   5         ??Name$ 
reg_button??51      $??Center=?6-   $??Center=?6H   $??0q?6e   $??0 20 0 0q?6y   
???   ?$??19(?6?   $

 Hand??6?   .??6?   Registration6?   52      54      ?? 55   
   
???   ?$??70??6$   $	??200??63   $ 20??6B   $??	0 590 0 0q?6T   ._?56      ?? .+?57      ?? -   5        $ Sign_in_butoon??57      $??Center=?61   $??0q?6L   $??Center=?6`   $??0 20 0 0q?6}   
???   ?$??19(?6?   $

 Hand??6?   .??6?   	Sign in6?   58      5:      5;      5<      