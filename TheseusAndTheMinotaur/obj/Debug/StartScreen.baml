   M S B A M L   `   `   `  ����  TheseusAndTheMinotaur'    !TheseusAndTheMinotaur.StartScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  StartScreen��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��41* �6   �� 5      $	��17* �6   ��5   
   �� 5       �� ImageSource$ MAINLOGO1.png��6    � RowDefinitions 5   
   �� 5      $	��75* �6   �� 5      $	��75* �6   �� 5      $
��103* �6   �� 5      $��6* �6   �� 5      $	��41* �6   .+�5   
   �� $��Segoe UI Black)�6   $��24(�6,   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6:      TextFormattingMode$ Display=�6a   $
��Bold"�6�   $��3��6�   .��6�   Thesues and the Minotaur5      �� 5   
   $��3��6   ���	#FF37373A$��Stretch=�69   $��3��6X   
���   �$��Stretch=�6t   $��2��6�    J� Opacity$
 0.75Q�6�   �� 5    
   -   5         ��Name$ btnLevelDesigner��5       $��4��6+   $��2��68   $��	0,0,10,10q�6H   ���	#FF0A0A0A$
��Bold"�6�   $��24(�6�   ��5!      �� 5"       �� EndPoint$	 0,1&�6&   	 �� 
StartPoint$		 0,0&�65   .��5#      � 
 � Color$
 	#FFF3F3F3��6#    � Offset$ 0.021Q�65   � 5$      $
 	#FFEBEBEB��6#   $ 0.272Q�65   � 5%      $
 	#FFDDDDDD��6#   $ 0.142Q�65   � 5&      $
 	#FFFB5406��6#   $ 1Q�65   5'       J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         Color$ 	#FFDC5B11��6#      Opacity$	 0.3Q�65   .��5+      Design a Level5,      �� 5.   
   -   5        $ btnGamePlayer��5.      $��4��6(   $��0��65   $��	10,0,0,10q�6E   ���	#FF0A0A0A$
��Bold"�6�   $��24(�6�   ��5/      �� 50      $	 0,1&�6&   $		 0,0&�65   .��51      � $
 	#FFF3F3F3��6#   $ 0Q�65   � 52      $
 	#FFEBEBEB��6#   $ 0.247Q�65   � 53      $
 	#FFDDDDDD��6#   $ 0.126Q�65   � 54      $
 	#FFDC5B11��6#   $ 1Q�65   55       57        58      $ 	#FFDC5B11��6#   $	 0.3Q�65   .��59      	Play Game5;      5=      5>      