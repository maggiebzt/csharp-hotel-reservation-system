   M S B A M L   `   `   `  ����A  =Group5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Group5Group5  5   	       Group5.ReservationReport   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Group5     5   	     � Title$  Reservation Report��5   	   $	��400��6$   $	��750��61   .��5	      � ���	#FF990000 � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ lblTitle��5      $��Reservation Report��6"   $
��Left=�6?   $��30,6,0,0q�6Z   $	��Top=�6l   $
��Bold"�6�   $��36(�6�   $��69��6�   $	��359��6�   
�������6�   �� 5   
   -   5        $ lblInstructions��5      $V��PThis form shows the reservations that have
been made in the system as a report.��6)   $
��Left=�6�   $��	30,61,0,0q�6�   $	��Top=�6�   $��78��6�   $��435.879��6�   
�������$��18(�6  �� 5   
   -   5        $ lblStartDate��5      $��Start Date:��6&   $
��Left=�6<   $��
30,144,0,0q�6W   $	��Top=�6k   $��26��6�   $��78��6�   $��14(�6�   
�������6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpStartDate��5      $
��Left=�6+   $��144,144,0,0q�6F   $	��Top=�6[   $	��169��6s   $��28��6   $��14(�6�   $��1��6�   ��. 6�   �� 5   
   -   5        $ lblLastName��5      $��
Last Name:��6%   $
��Left=�6:   $��
30,214,0,0q�6U   $	��Top=�6i   $��26��6�   $��83��6�   $��14(�6�   
�������6�   �� 5   
   -   5         ��Name$ txtLastName��5      $
��Left=�6'   $��26��6B   $��144,216,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��171��6�   $��14(�6�   $��3��6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
35,258,0,0q�6P   $	��Top=�6d   $	��130��6|   $��40��6�   $��14(�6�   
�������
���   �$
��Bold"�6�   $��4��6�   �� 5   
   -   5        $ btnClear��5      $��Clear��6#   $
��Left=�63   $��185,258,0,0q�6N   $	��Top=�6c   $	��130��6{   $��40��6�   $��14(�6�   
�������
���   �$
��Bold"�6�   $��5��6�   �� 5   
   -	   5        $ btnReturntoMainMenu��5      $��Return to Main Menu��6.   $
��Left=�6L   $��
557,24,0,0q�6g   $	��Top=�6{   $	��160��6�   $��40��6�   
�������
���   �$
��Bold"�6�   $��14(�6�   $��6��6  &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ 
dtgResults��5      $
��Left=�6'   $��340,121,0,0q�6B   $	��Top=�6W   $	��218��6o   $	��377��6|      AutoGenerateColumns .  ��6�   �� *MyCollection+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Check-In Date��6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *CheckInDate+ �� StringFormat$ {0: MM/dd/yyyy}��6e     5      $
 Number of Nights��6H    6%   �� *NumberOfNights+6H     5      $
 	Room Type��6B    6%   �� *
RoomType+6B     5      $
 Number of Rooms��6G    6%   �� *NumberOfRooms+6G     5      $
 
Room Price��6C    6%   �� *	RoomPrice+6C     5      $
 Total��6?    6%   �� *Total+6?     5      $
 
First Name��6C    6%   �� *	FirstName+6C     5      $
 	Last Name��6B    6%   �� *
LastName+6B     5       $
 Phone��6?    6%   �� *Phone+6?     5!      $
 Email��6?    6%   �� *Email+6?   5#      �� 5$   
   -   5        $ 
lblEndDate��5$      $��	End Date:��6$   $
��Left=�68   $��
30,180,0,0q�6S   $	��Top=�6g   $��26��6   $��78��6�   $��14(�6�   
���������. 6�     5%   
   -   5        $ 
dtpEndDate��5%      $
��Left=�6)   $��144,180,0,0q�6D   $	��Top=�6Y   $	��169��6q      DisplayDate$ 
2017-11-11��6}   $��28��6�   $��14(�6�   ��. $��2��6�   5&      5'      