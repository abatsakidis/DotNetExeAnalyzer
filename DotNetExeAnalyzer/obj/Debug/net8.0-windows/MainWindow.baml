   M S B A M L   `   `   `  ����  DotNetExeAnalyzer"    DotNetExeAnalyzer.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f8metro,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  .Net EXE Analyzer��5   	   $	��600��6#   $	��900��60   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5        $��	Open File��5      $	��130��6@   �� 5      -   5        $��	Export IL��5      $	��100��6@   $��10,0,0,0q�6L   �� 5      -   5        $��Copy IL��5      $	��100��6<   $��10,0,0,0q�6H   �� 5      -   5         ��Name$ txtFileInfo��5      $��20,0,0,0q�6-   $��Center=�6?   
�������6Z   5      �� 5   
   -   5         ��Name$ 	txtFilter��5      $��1��6   $��0,0,0,10q�62   $	��300��6D   $��25��6P   $��	Search...��5      
�������5      � 5   
   $��2��6    � ColumnDefinitions 5       �� 5!      $��2* �6#   �� 5"      $��2* �6#   �� 5#      $��4* �6#   .+�5'      �� $��
References��6   $��5q�6+   $��0��66   .��5(      �� -   5         ��Name$ lstReferences��5(      5)      �� 5,      $��Types & Methods��6   $��5q�64   $��1��6?   .��5-      R� -   5         R�Name$ treeView��5-      6-   5.      �� 51      $��IL Code��6   $��5q�6(   $��2��63   .��52      �� $
��Auto=�6   .��53      �� -   5        $ txtIL��53      $��Consolas)�6-   $��12(�6C    �� 
IsReadOnly$
 True��54      	 �� TextWrapping$	 NoWrap=�60   
 �� AcceptsReturn$

 True��55      " �� VerticalScrollBarVisibility$
 Auto=�63   56      57      58      �� 5;   
   $��3��6   $ ��DotNet EXE Analyzer by You��6!   $��Italic$�5<      $��Right=�6'   $��0,10,0,0q�6C   
�������6U   5=      5>      