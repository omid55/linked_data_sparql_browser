   M S B A M L   `   `   `  ����R  NMyRdfBrowserUserControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:MyRdfBrowserUserControl;assembly=MyRdfBrowserUserControlMyRdfBrowserUserControl  5   D    RdfUsing   RdfUsing.BrowserWindow   6	   MmyFclr-namespace:MyRdfBrowserUserControl;assembly=MyRdfBrowserUserControl  6D   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6�   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   -   5        
����·�  � Title$  BrowserWindow��5     $	��522��6%  $	��881��62  .��5      ]� ��. .+�5      o� -   5        $��MainMenu��5   0   $	��Top=�6	    o� 
IsMainMenu . 
������ |�. .@�5      m� $��Browsing Preferences��6   
����  �.@�5      m� -   5        $��New Tab��5      
����  �66   m� 5      -   5        $��Close This Tab��5      
����  �6=   m� 5      $��Browsing Type��6   
����  �.@�5      m� ��5	      	� 5
      -   5        $��TripleRadio��5
   *   
����  �$��Browsing Triples��6S    d� 	IsChecked$
 TrueY�6n    	� 	GroupName$ 
TypesGroup��6   6�   5      m� 5      ��5      	� 5      -   5        $��RdfRadio��5   *   
����  �$��Browsing Rdf Entity��6P   $ 
TypesGroup��6n   6�   5      5      5      5      �� 5      -   5        $��myTabControl��5       J� 	AllowDrop .   � ContextMenu 5      �� 5       �� HasDropShadow . .@�5      m� -   5        $��AddTab��5      $��Add Tab��63    m� Icon 5      �� 5      $��20��6$   $��20��60   $'��!/RdfUsing;component/Image/Add.png��6;   5      m� 5      -	   5        $��CloseTab��5      $��Close It��67    5      �� 5      $��20��6$   $��20��60   $(��"/RdfUsing;component/Image/exit.png��6;   5!      5"      .@�5$      �� 
�������$��RDF Browser 1��6!   .��5%      (   "MyRdfBrowserUserControl.RdfBrowser  -
   5        $��	myBrowser��5%      5&      �� 5'      -   5        $��+��5'      6   5(      5)      5*      