   M S B A M L   `   `   `  ����E  ARenACar.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RenACar.UI
RenACar.UI  5   	   #    RenACar.UI.SearchReservations   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RenACar.UI     5   	   -   5          � Title$  SearchReservations��5   	   $	��900��6$   $
��1600��61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��793* �6   �� 5      $
��652* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Reservations��6   $��20(�6(   $
��Bold"�66   $��10,10,10,10q�6H   $��2��6]   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10,10,10,10q�6;   $��2��6P   .+�5      �� $��Search Name:��6   $��Center=�6,   �� 5      -   5         ��Name$ txtSearchName��5      $	��150��6-   $��5q�69   �� 5      $��Start Date:��6   $��Center=�6+   $
��10,0q�6F   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpStartDate��5      $	��150��6.   $��5q�6:   �� 5      $��	End Date:��6   $��Center=�6)   $
��10,0q�6D     5      -   5        $ 	dpEndDate��5      $	��150��6,   $��5q�68   �� 5      -   5        $��Search��5      $
��10,0q�6&   64   �� 5       -   5        $��Clear��5       $
��10,0q�6%   63   5!      �� 5#   
   -   5        $��1��5#      $��2��6   $��Terug naar Hoofdscherm��6.   $��Center=�6O   $	��Top=�6l   $��10q�6�   6�   �� 5%   
   $��2��6   $��3��6$   $
��Auto=�68   .��5&      &   System.Windows.Controls.DataGrid  -   5        $��dataReservations��5&         AutoGenerateColumns$ False��6X   ��6/   �� *ReservationsList+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Reservation ID��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *ReserveringID+4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ Customer��6-   
   CellTemplate
 5*      �� 5+      .R�5,   "   �� .+�5-   &   �� $
��Bold"�6P   ��60   �� *Klant.Voornaam+6P   �� 5.   &   ��60   �� *
Klant.Naam+5/   #   50      52        53      $ Autos��6-   
 54      �� 55      .R�56   "   �� ��6/   �� *Autos+��57   &   �� 58   *   .R�59   .   �� $ 
Horizontal=�69   .+�5:   2   �� ��6<   �� *AutoID+�� 5;   2   $��-��6<   �� 5<   2   ��6<   �� *Naam+5=   /   5>   +   5@   #   5A      5C        5D      $ Arrangement��6)   	 6>   �� *Arrangement.Naam+  5E      $ 
Start Date��6)   	 6=   �� *
StartDatum+ �� StringFormat$ {0:dd/MM/yyyy}��  5F      $ 
Start Time��6)   	 6=   �� *
StartUur+  5G      $ 	Hour Type��6)   	 6<   �� *
SoortUur+  5H      $ Duration (hours)��6)   	 6C   �� *
AantalUren+  5I      $ Start Location��6)   	 6A   �� *StartLocatie.Stad+  5J      $ End Location��6)   	 6?   �� *AankomstLocatie.Stad+  5K      $ 
Unit Price��6)   	 6=   �� *Eenheidsprijs+$ {0} €��  5L      $ Subtotal��6)   	 6;   �� *	Subtotaal+$ {0} €��5N      5O      5P      5Q      