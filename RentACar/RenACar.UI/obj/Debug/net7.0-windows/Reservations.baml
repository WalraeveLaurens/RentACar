   M S B A M L   `   `   `  ����E  ARenACar.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RenACar.UI
RenACar.UI  5   	       RenACar.UI.Reservations   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RenACar.UI     5   	   -   5          � Title$  Reservations��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Reservations��6   $��20(�6(   $
��Bold"�66   $��10q�6H   �� 5   
   -   5        $��1��5      $��Terug naar Hoofdscherm��6!   $��Right=�6B   $	��Top=�6^   $��10q�6v   6�   �� 5   
   $��1��6   $��2��6$   $
��Auto=�68   .��5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6@   ��6   �� *ReservationsList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Reservation ID��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *ReserveringID+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Customer��6-      CellTemplate 5      �� 5      .R�5   "   �� .+�5    &   �� $
��Bold"�6P   ��60   �� *Klant.Voornaam+6P   �� 5!   &   ��60   �� *
Klant.Naam+5"   #   5#      5%        5&      $ Autos��6-    5'      �� 5(      .R�5)   "   �� ��6/   �� *Autos+��5*   &   �� 5+   *   .R�5,   .   ��  �� Orientation$ 
Horizontal=�69   .+�5-   2   �� ��6<   �� *AutoID+�� 5.   2   $��-��6<   �� 5/   2   ��6<   �� *Naam+50   /   51   +   53   #   54      56        57      $ Arrangement��6)    6>   �� *Arrangement.Naam+  58      $ 
Start Date��6)    6=   �� *
StartDatum+	 �� StringFormat$	 {0:dd/MM/yyyy}��  59      $ 
Start Time��6)    6=   �� *
StartUur+  5:      $ 	Hour Type��6)    6<   �� *
SoortUur+  5;      $ Duration (hours)��6)    6C   �� *
AantalUren+  5<      $ Start Location��6)    6A   �� *StartLocatie.Stad+  5=      $ End Location��6)    6?   �� *AankomstLocatie.Stad+  5>      $ 
Unit Price��6)    6=   �� *Eenheidsprijs+$	 {0} €��  5?      $ Subtotal��6)    6;   �� *	Subtotaal+$	 {0} €��5A      5B      5C      5D      