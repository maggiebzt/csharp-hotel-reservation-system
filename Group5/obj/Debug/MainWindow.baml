   M S B A M L   `   `   `  ����A  =Group5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Group5Group5  5   	       Group5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Group5     5   	   -   5          �Name$  winMainMenu��5   	    � Title$ 	Main Menu��5   	   $	��525��6   $	��800��6(   $	��525��64   $	��525��6D   $	��800��6T   $	��800��6c   .��5	      � 
�������$	��795��6   $	��525��6*   .+�5
   
   �� -   5         ��Name$ img_background��5
      $��Images/hotel.jpg��6(   $
��Fill=�6B   $	��795��6Q   $��
0,-15,0,25q�6]    J� Opacity$	 0.8Q�6q   $	��795��6   $	��795��6�   $	��515��6�   $	��515��6�   $	��515��6�   �� 5   
   -   5         ��Name$ lblTitle��5      $*��$Hoosier Hotels - Reservation Manager��6"   $	��Top=�6Q   $��9.993,9,18.334,0q�6i   $��65��6�   ���	#FF990000$��36(�6�   $
��Bold"�6�   $��Center=�6�   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   5      �� 5   
   -   5        $ lblGreeting��5      $�� ��6%   $	��Top=�60   $��35��6H   $��9.167,73.998,18.334,0q�6T   ���	#FF990000$��18(�6�   $��Center=�6�   ��5      �� 5      $ White��6"   $	 0.5Q�60   5      �� 5   
   -   5        $ lblCurrentDate��5      $	��Top=�6(   $��30��6@   $��9.167,108.498,18.334,0q�6L   ���	#FF990000$��14(�6�   $��Center=�6�   ��5      �� 5      $ White��6"   $	 0.5Q�60   5      �� 5   
   -   5        $ lblCurrentTime��5      $	��Top=�6(   $��30��6@   $��9.167,138.498,18.334,0q�6L   ���	#FF990000$��14(�6�   $��Center=�6�   ��5      �� 5      $ White��6"   $	 0.5Q�60   5      �� 5    
   -   5         ��Name$ btnNewReservation��5       $��New Reservation��6,   $��16.667,205.808,0,0q�6F   $	��Top=�6b   $��90.421��6z   $��22(�6�   $
��Left=�6�   $��246.85��6�   ��5!      �� 5"      $ Black��6"   $	 0.5Q�60   ��5$      �� 5%      $ Black��6"   $	 0.7Q�60   ��5'      �� 5(      $ White��6"   5*      �� 5+   
   -   5        $ btnRoomManagement��5+      $��Room Management��6,   $
��Left=�6F   $��418.087,204,0,0q�6a   $��246.85��6z   $��22(�6�   $��92.229��6�   $	��Top=�6�   ��5,      �� 5-      $ Black��6"   $	 0.5Q�60   ��5/      �� 50      $ Black��6"   $	 0.7Q�60   ��52      �� 53      $ White��6"   55      �� 56   
   -	   5        $ imgRoomManagement��56      $
��Left=�6+   $��683.266,204,0,0q�6F   $��90.421��6_   $��Images/RoomManagement.png��6n   $��90.421��6�   $	��Top=�6�   �� 57   
   -
   5        $ btnReservationsReport��57      $��Reservations Report��60   $��16.667,327.218,0,0q�6N   $	��Top=�6j   $��92.229��6�   $��22(�6�   $
��Left=�6�   $��246.85��6�   ��58      �� 59      $ Black��6"   $	 0.5Q�60   ��5;      �� 5<      $ Black��6"   $	 0.7Q�60   ��5>      �� 5?      $ White��6"   5A      �� 5B   
   -   5        $ btnNearbyHoosierHotels��5B      $��Nearby Hoosier Hotels��61   $
��Left=�6Q   $��418.087,327.218,0,0q�6l   $	��Top=�6�   $��246.849��6�   $��92.229��6�   $��22(�6�   ��5C      �� 5D      $ Black��6"   $	 0.5Q�60   ��5F      �� 5G      $ Black��6"   $	 0.7Q�60   ��5I      �� 5J      $ White��6"   5L      �� 5M   
   -   5        $ imgNearbyHoosierHotels��5M      $
��Left=�60   $��92.229��6K   $��676.936,327.218,0,0q�6[   $	��Top=�6x   $��92.23��6�   $$��Images/NearbyHoosierHotels.png��6�   �� 5N   
   -   5        $ imgReservationReport��5N      $��93.134��6.   $��275.517,327.218,0,0q�6>   $	��Top=�6[   $"��Images/ReservationReport.png��6s   $
��Left=�6�   $��94.641��6�   �� 5O   
   -   5        $ imgNewReservation��5O      $
��Left=�6+   $��104.889��6F   $��281.846,205.808,0,0q�6W   $	��Top=�6t   $��104.888��6�   $��Images/NewReservation.png��6�   �� 5P   
   -   5        $ btnExit��5P      $
��Exit��6"   $
��Left=�61   $��720.166,0,0,49.5q�6L   $��Bottom=�6f   $��52��6�   
�������$��30��6�   $��16(�6�   ��6�   Z� ��5Q      �� 5R      $ 	#FF990000��6"   $	 0.8Q�64   5T      5V      5W      