   M S B A M L   `   `   `  ����M  IMyRdfResultControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:MyRdfResultControl;assembly=MyRdfResultControlMyRdfResultControl  5      R NMyRdfBrowserUserControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MyRdfBrowserUserControlMyRdfBrowserUserControl 5      (   "MyRdfBrowserUserControl.RdfBrowser   5      Cmy<clr-namespace:MyRdfResultControl;assembly=MyRdfResultControl  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:MyRdfBrowserUserControl     5      -   5        .��5      ]� -   5        $��myDockPanel��5   )     � UseLayoutRounding  . ��. ��5   
   �� 5      .��5      �  � Color$ LightYellow��6    � Offset$	 0.0Q�63   � 5      $	 1.0Q�6   $ 	#00EFC7C7��6,   5      .+�5   
   �   . $	��Top=�6(   $��70��6=    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��445* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��promptLabel��5   M   $��Center=�6   $��Stretch=�6/   $)��#Enter The URI Of Your Entity Here :��6`   $��0��6�   �� 5      $��1��6   $��Center=�6)   $��Center=�6D    �� Orientation$ 
Horizontal=�6a   .+�5      �� -   5        $��
BackButton��5      ��5      �� 5      $8��2/MyRdfBrowserUserControl;component/Images/back.png��6    $��50��6\   $��Uniform=�6j   $��50��6|   5       �� 5!      -   5        $��ForwardButton��5!      $��45��6.   ��5"      �� 5#      $;��5/MyRdfBrowserUserControl;component/Images/forward.png��6    $��50��6_   $��Uniform=�6m   $��50��6   5%      5&      �� 5'      -   5        $��browseComboBox��5'   S   $��23��6    �� 
IsEditable . $��Center=�68   $��Stretch=�6i   $��2��6�   $��5q�6�   6�   �� 5(      -   5        $��TypesComboBox��5(   C   $	��150��6   $��5q�6&   
 � Tag$ Select Type��61   $��Stretch=�6X   $��Center=�6v   $��3��6�   �� 5)      -   5        $��BrowseButton��5)   <   $��Right=�6   $��5q�61   $��Center=�6P   $��4��6�   ��5*      �� 5+      $6��0/MyRdfBrowserUserControl;component/Images/go.png��6   $��50��6V   $��Uniform=�6d   $��50��6v   5-      5.      � 5/   
   $��0,0,0,10q�6   $	��Top=�6!   .+�50   
   �� -	   5        $��Connect2WebButton��50   l   $��5q�6   $��5q�6   $#��Connect To Link Data Resource��6(   $��Right=�6P   6�   �� 51   
   -
   5        $��SaveGraphButton��51   `   $��5q�6   $��5q�6   $��Save Graph To File��6(   $
��Left=�6E   6w   52      .   (MyRdfResultControl.MyWpfRdfResultControl  53   
   -   5        $��MyRdfRes��53   #   � 54   
   -   5        $��loadingPopup��54       � 	StaysOpen .  $��
MousePoint=�66   $	��400��6M   $	��400��6\   $
��Fade=�55       � AllowsTransparency . $	��100��6>   .��56      �� 
�������$��2q�6)   ��57      �� 58      .��59      � $ LightYellow��6'   $	 0.0Q�6;   � 5:      $	 1.0Q�6'   $ 	LightBlue��64   5;      ._�5=      (� $��50��6   $��50��6%   $��Center=�61   $��Center=�6N   .��5>      1  +MyRdfBrowserUserControl.CircularProgressBar  5?      5@      5A      � 5B   
   -   5        $��popLink��5B   N   {�.   .  $��Mouse=�6o   $	��400��6�   $	��400��6�   $��Slide=�5C       . .��5D      �� 
�������$��2q�6)   ��5E      �� 5F      .��5G      � $ LightYellow��6'   $	 0.0Q�6;   � 5H      $	 1.0Q�6'   $ 	LightBlue��64   5I      ._�5K      � .+�5L      (� $��50��6   $��50��6)   $��Center=�65   $��Center=�6R   .��5M        5N        5O      -   5        $��MyRdfResInPopup��5O   /   5P      5Q      5R      5S      5T      