   M S B A M L   `   `   `  ����E  ARenACar.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RenACar.UI
RenACar.UI  5   	       RenACar.UI.NewReservation   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RenACar.UI     5   	     � Title$  NewReservation��5   	   $	��900��6    $
��1500��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��New Reservation��6   $��24(�67   $��Center=�6E   $
��0,20q�6b   � 5   
   $��1��6   $��20q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5       $
��Auto �6#   �� 5!      $��* �6#   .+�5%      �� $��Klant:��6   $��0��6%   $��Center=�62   �� 5&      $��0��6   $��1��6#    �� 
IsReadOnly$
 True��6W   $��10q�6i   ��63   �� *SelectedKlant.Naam+6i   �� 5)      $��Auto:��6   $��1��6$   $��Center=�61   �� 5*      -   5        $��lbAuto��5*      $��1��6$   $��1��61    �� SelectionMode$ Multiple=�6b   $��10q�6{   ��6A   �� *
AutoList+��5+      �� 5,      .R�5-      ��  �� Orientation$ 
Horizontal=�6%   .+�5.      �� ��6(   �� *AutoID+�� 5/      $��5,0,0,0q�6>   ��6(   �� *Naam+6>   50      51      53      �� 57      $��Arrangement:��6   $��2��6+   $��Center=�68   �� 58      -   5        $��cmbArrangment��58      $��2��6,   $��1��69    �� DisplayMemberPath$
 Naam��6q    �� SelectedValuePath$ ArrangementID��6�   $��10q�6�   ��6I   �� *ArrangementList+ �� SelectedItem 6�   �� *SelectedArrangement+6�   �� 5;      $��Start Datum:��6   $��3��6+   $��Center=�68   (  "System.Windows.Controls.DatePicker  5<      -   5        $��dpStartDate��5<      $��3��6,   $��1��69   $��10q�6m   	   SelectedDate	 6I   �� *
StartDatum+6m   �� 5?      $��
Start Uur:��6   $��4��6)   $��Center=�66   �� 5@      -   5        $��tpStartTime��5@      $��4��6)   $��1��66   $��10q�6`   ��6F   �� *
StartUur+6`   �� 5C      $��Aantal Uren:��6   $��5��6+   $��Center=�68   �� 5D      -   5        $��txtDuration��5D      $��5��6)   $��1��66   $��10q�6b   ��6F   �� *
AantalUren+{�6n   �� *IsArrangementSelected+
 �� Mode$
 OneWay=��� 5G      $��Start Locatie:��6   $��6��6-   $��Center=�6:   �� 5H      -   5         ��Name$ cmbStartLocatie��5H      $��6��60   $��1��6=   $
 Stad��6v   $��10q�6�   ��6M   �� *StartLocatieList+ 6�   �� *SelectedStartLocatie+6�   �� 5K      $��Aankomst Locatie:��6   $��7��60   $��Center=�6=   �� 5L      -   5        $ cmbAankomstLocatie��5L      $��7��63   $��1��6@   $
 Stad��6|   $��10q�6�   ��6P   �� *AankomstLocatieList+ 6�   �� *SelectedAankomstLocatie+6�   5M      �� 5P   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $
��0,20q�6X   .+�5Q      �� -   5        $��Add Reservation��5Q      $	��120��6/   $��10q�6;   6G   �� 5R      -	   5        $��Cancel��5R      $	��120��6&   $��10q�62   6>   5S      5T      5U      