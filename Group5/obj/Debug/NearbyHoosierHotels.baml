   M S B A M L   `   `   `  ����A  =Group5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Group5Group5  5   	        Group5.NearbyHoosierHotels   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Group5     5   	     � Title$  Nearby Hoosier Hotels��5   	   $��279.6��6'   $��858.4��66   .��5	      � $��	0,0,0,0.2q�6   ���	#FF990000 � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ lblTitle��5      $��Nearby Hoosier Hotels��6"   $
��Left=�6B   $��	10,10,0,0q�6]   $	��Top=�6p   $
��Bold"�6�   $��36(�6�   
���������6�   Z� 6�   �� 5   
   -   5        $ lblInstructions��5      $N��HEnter your zip code and select "Search" 
to find nearby Hoosier Hotels!��6)   $
��Left=�6�   $��	10,63,0,0q�6�   $	��Top=�6�   $��59��6�   $	��328��6�   $��18(�6�   
�������6�   �� 5   
   -   5        $ 
lblZipCode��5      $��Zip Code��6$   $
��Left=�67   $��
13,131,0,0q�6R   $	��Top=�6f   $��18(�6~   
�������6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
13,187,0,0q�6P   $	��Top=�6d   $	��130��6|   $��40��6�   
���   �
�������
���   �$
��Bold"�6�   $��14(�6�   6�   �� 5   
   -   5        $ btnClear��5      $��Clear��6#   $
��Left=�63   $��164,187,0,0q�6N   $	��Top=�6c   $	��130��6{   $��40��6�   
���   �
�������
���   �$
��Bold"�6�   $��14(�6�   6�   �� 5   
   -   5         ��Name$ 	txtOutput��5      $
��Left=�6%   $	��151��6@   $��
351,76,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��482��6�   $��Courier New)�6�   
����������	#FF060000��.  6�   �� 5   
   -   5        $ btnReturnToMainMenu��5      $��Return to Main Menu��6.   $
��Left=�6L   $��
675,10,0,0q�6g   $	��Top=�6{   $	��160��6�   $��40��6�   
���   �
�������
���   �$
��Bold"�6�   $��14(�6�   6  �� 5   
   -   5         ��Name$ 
cboZipCode��5      $
��Left=�6'   $��112,131,0,0q�6B   $	��Top=�6W   $	��182��6o   $��34��6{   
������� �� SelectedIndex$ 0��6�   $��18(�6�   ��5      �� 5       �� EndPoint$	 0,1&�6&   	 �� 
StartPoint$		 0,0&�65   .��5      � 
 � Color$
 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5      $
 White��6#   $ 1Q�61   5      .@�5      �� $��Select a zipcode��6   �� 5      $��41125��6   �� 5      $��42214��6   �� 5      $��43125��6   5      5!      5"      