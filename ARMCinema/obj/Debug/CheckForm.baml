   M S B A M L   `   `   `  ����D  @ARMCinema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ARMCinema	ARMCinema  5   	       ARMCinema.CheckForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ARMCinema     5   	     � Title$  Чек��5   	   $	��600��6   $	��400��6"   $	��600��6.   $	��400��6>   $	��600��6M   $	��400��6]   
������� � 	Resources 5
       �� Color 	  green �� 
StartPoint �� EndPoint  gradient � Color � Offset  ButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� Padding �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 $     &	 �     7   7  �� 5   
   $ Green��6   68   �� 5   
   $	 0,0&�6   $	 1,0&�6/   .��5      � $
 Gray��6   $
 0.01Q�6(   � 5      $ White��6   $ 1Q�6)   5      �� 5   
   " ��6$   .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      �� $ border��6!   8��  $��1q�6V   8�� $ 5q�6�   $ 15��6�   ._�5      �� $��Center=�6/   $��Center=�6J   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
	 �����6S   5      P� 5       � �� . . �5   "   �� $ border��6)    � ��
	 ����6S   �� 5   "   $ border��6)    � ��
	 �����6T   5      5       5"      5#      5$      .��5%      � $��
0,0,10,158q�6    � RowDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $��* �6   �� 5)      $��* �6   .+�5+   
   �� $��1��6   $
��Auto=�6$   $��2��6G   .��5,      �� -   5         ��Name$ check��5,   ?    �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . $	��426��6N   $	��370��6[   5-      �� 5.   
   -   5        $��2��5.      $��Подтвердить��6   $��24,296,5,-140q�64   #��[ 6b   5/      50      