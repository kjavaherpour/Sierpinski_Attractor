   M S B A M L   `   `   `  ����  Sierpinski_Attractor%    Sierpinski_Triangles.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Sierpinski Attractor��5   	    � 
ResizeMode$ NoResize=�6&    � WindowStartupLocation$ CenterScreen=�6<   $	��768��6a   $	��576��6m   ���	#FFF3F3F3.��5      � $
��Left=�6   $	��100��6&   $	��Top=�63   $	��100��6K   .+�5      �� -   5         ��Name$ ShapeCanvas��5      $
��Left=�6    $��400.5��6;   $	��Top=�6J   $	��762��6b   
�������$��0,23,-662,-323.5q�6?   � Cursor$ Arrow��6Y  �� 5      $��Preset Shape Colors
��6
   $��18,451,-38,-392.92q�6-   �� 5      $��New Shape Size��6
   $��369,445,-362.87,-370.96q�6#   �� 5	      -   5         ��Name$ 	RunButton��5	      $	��Run��6    �� 	IsDefault . $"��518.782,463,-519.733,-401.96q�6U    � ToolTip$ Run the algorithm��6{   �� 5
      -   5        $ ClearButton��5
      $��Clear��6    $��635.049,463,-636,-401.96q�6J   $ Clear the canvas��6l   �� 5      -   5         ��Name$
 CBox��5      $��18,487,-38,-408.96q�6   $/ )Select the color of the new control point��67   .@�5      �� -   5        	 ��Name$	 RedShapeItem��5      $	��Red��6(   $
��Left=�66   $	��118��6Q   6]   �� 5      -   5        $	 BlueShapeItem��5      $
��Blue��6)   $
��Left=�68   $	��118��6S   6_   �� 5      -   5        $	 GreenShapeItem��5      $��Green��6*   $
��Left=�6:   $	��118��6U   6a   �� 5      -   5        $	 OrangeShapeItem��5      $��Orange��6+   $
��Left=�6<   $	��118��6W   6c   �� 5      -	   5        $	 CyanShapeItem��5      $
��Cyan��6)   $
��Left=�68   $	��118��6S   6_   5      	� 5      -
   5        
 	�Name$
 ShapeSizeTwo��5      $��2��6&   $��364,488,-298.87,-402.04q�62    d� 	IsChecked$
 TrueY�6S   $E ?Selects the size of the shapes created by the new control point��6d   	� 5      -   5        $
 ShapeSizeFour��5      $��4��6'   $ ��403.87,488,-340.74,-402.04q�63   $E ?Selects the size of the shapes created by the new control point��6W   	� 5      -   5        $
 ShapeSizeSix��5      $��6��6&   $ ��445.74,488,-385.61,-402.04q�62   $E ?Selects the size of the shapes created by the new control point��6V   o� 5      $
��Left=�6	   $��23��6$      
SimpleMenu#���   60   $	��Top=�6U   $	��100��6m   .@�5      m� -   5        $��Usage��5      $��23��6   $��Bottom=�6)   6D   m� 5      -   5        $��About��5      $��23��6   $	��Top=�6)   6A   5      �� 5      $��Shape Color (RGB)��6
   $
��Left=�6&   $��25.96��6A   $'��!163.756,432.244,-177.756,-358.204q�6P   $	��Top=�6{   $	��114��6�   �� 5      -   5         ��Name$ RedValueSlider��5      $
��Left=�6#   $��20��6>   $'��!168.756,460.244,-168.756,-380.244q�6J   $	��Top=�6u   $	��100��6�    � Maximum$	 255Q�6�   6�   �� 5   
   -   5        $ GreenValueSlider��5      $
��Left=�6+   $��20��6F   $'��!168.756,483.244,-168.756,-403.244q�6R   $	��Top=�6}   $	��100��6�   $	 255Q�6�   6�   �� 5   
   -   5        $ BlueValueSlider��5      $
��Left=�6*   $��20��6E   $'��!168.756,508.244,-168.756,-428.244q�6Q   $	��Top=�6|   $	��100��6�   $	 255Q�6�    � Value$ -1Q�6�   �� 5      -   5        $ ColorPreviewCanvas��5      $
��Left=�6'   $��53.96��6B   $'��!291.756,463.244,-242.756,-417.204q�6Q   $	��Top=�6|   $��51��6�   
���   �6�   5      5      