   M S B A M L   `   `   `  ����>  :RGZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RGZRGZ  5   	       RGZ.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RGZ     5   	     � Title$  Пользователь��5   	   $	��450��6   $
��1127��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $	��10* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ 
BuyerLabel��5      $)��#Список покупателей��6,   $��20(�6G   5      � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	BuyerGrid��5         AutoGenerateColumns .     
IsReadOnly . $��Visible=�5   #   $��Visible=�5   #   $��20(�5   R   $��0,0,0,5q�5   #      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id покупателя��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5   5   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   5   �� *	BuyerId+  5      $! Серия паспорта��6)   $
 Auto 6A   	 6N   �� *Passport.Serial+  5      $! Номер паспорта��6)   $
 Auto 6A   	 6N   �� *Passport.Number+  5       $ Фамилия��6)   $
 Auto 6:   	 6G   �� *	Surname+  5!      $ Имя��6)   $
 Auto 66   	 6C   �� *Name+  5"      $ Отчество��6)   $
 Auto 6;   	 6H   �� *
MiddleName+  5#      $ Дата рождения��6)   $
 Auto 6@   	 6M   �� *
Birthday+  5$      $! Номер телефона��6)   $
 Auto 6A   	 6N   �� *PhoneNumber+  5%      $ Номер карты��6)   $
 Auto 6>   	 6K   �� *
CardNumber+5'      5(      � 5)   
   $��2��6   .+�5*      �� -   5        
 ��Name$
 AddBuyerBtn��5*      $+��%Добавить покупателя��6*   $
��Auto��6H   $
��Left=�6U   $��20(�6�   �� 5+      -   5        $
 UpdateBuyerGrid��5+      $%��Обновить таблицу��6.   $
��Auto��6I   $��Center=�6V   $��20(�6s   6�   �� 5,      -   5        $
 DeleteBuyer��5,      $)��#Удалить покупателя��6*   $
��Auto��6G   $��Right=�6T   $��20(�6p   6~   5-      5.      5/      