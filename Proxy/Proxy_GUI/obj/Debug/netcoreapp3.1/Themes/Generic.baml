   M S B A M L   `   `   `  ����D  @Proxy_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Proxy_GUI	Proxy_GUI  5          Proxy_GUI.EventClass\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   RepeatButtonModUp  �� 
TargetType ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value	 F�Name
 �� Stretch �� Left  RepeatButtonModDown   Proxy_GUI.NumericUpDown �� 
TargetType �� Property �� Value % !NumericUpDown_Settings_Background �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   	Direction , (NumericUpDown_Settings_Background_Shadow   Color  NonButton_ShadowDepth   ShadowDepth   
BlurRadius   Opacity ��Name �� RelativeSource �� AncestorType �� Path ��Name � Cursor   Proxy_GUI.DataGridMod&   System.Windows.Controls.DataGrid J� SnapsToDevicePixels �� Padding ��Name � ColumnDefinitions  � RowDefinitions!   SelectAllCommand" �� 
ResourceId# �� TypeInTargetAssembly7	  1System.Windows.Controls.DataGridHeadersVisibility
$ 	  All% �� ConverterParameter!&   HeadersVisibilityConverter' �� 	ConverterG
  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter( 
 Name) 	  Column* ��Name+ �� CanContentScroll, ��Name- �� Orientation. �� ViewportHeight/ �� ViewportSize0 �� ScrollableHeight1 � Maximum*2 �� #ComputedVerticalScrollBarVisibility3 � Value4 �� Mode5 �� ViewportWidth6 �� ScrollableWidth,7 �� %ComputedHorizontalScrollBarVisibility8 �Name9   UpshowVisibility: A�Name  ProgressBar_Loading_Shadow  Button_ShadowDepth  DataGrid_Results_Path_Up; J� IsHitTestVisible< �� Triggers= P� 
SourceName> P� Property? P� Value@ �� 
TargetNameA :� RoutedEventB :� 
SourceNameC �� Triggers  ComboBoxToggleMod9  3System.Windows.Media.Animation.EasingDoubleKeyFrameD O� KeyTimeE O� ValueF R� KeyTimeG R� Value -	 )Combobox_Settings_Proxy_Background_Shadow 
 ComboboxitemModH ��Name 4 0Combobox_Settings_Proxy_List_Selected_Background   Proxy_GUI.ComboboxModde  System.Windows.VisibilityI   VisibleJ   HiddenK �� 	ClickModeL d� 	IsCheckedM �� SelectionBoxItemN �� SelectionBoxItemTemplateO   LtextP   LvisQ �� IsDropDownOpenR � AllowsTransparencyS � ActualWidthT �� MaxDropDownHeight + 'Combobox_Settings_Proxy_List_BackgroundU K� IsItemsHost-  'System.Windows.Input.KeyboardNavigationV   DirectionalNavigation   5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !localclr-namespace:Proxy_GUI  5      %�*  &	        &	 �    '  	    7   7  '  ;    &	 @    &	
 s     '  �"    7 
 7  �� 5      "  ��60   .R�5   
   �� $ border��6   
������ $��11.18��6:   $
��6.59��6H    5        5      CommonStates��. 5        
Normal��6"     5      	MouseOver��. 5      �� .��5      �� $ PathUp��6;   $* $(Shape.Fill).(SolidColorBrush.Color)�6Z   .g�5   "     $ 00:00:00��66   $ 	#FF0061FF��6I   5      5      5        5      Pressed��. 5      �� .��5      �� $ PathUp��6;   $* $(Shape.Fill).(SolidColorBrush.Color)�6Z   .g�5   "     $ 00:00:00��66   $ 	#B20061FF��6I   5      5      5        5      Disabled��6"   5      ._�5!      F� $	 PathUp��6   $��11.18��6#   $
��6.59��61   $
 uniform=�6?   ����0   �p= @����k-@Q � ������%@  `��/@����k-@����E0@  @33.@���_f�0@  @33.@���=J1@����k-@   ��1@   ף,@   ��1@  �Ga+@���=J1@������*@  `ff)@    �k!@���?��(@    ף @����(\'@    ף @  �z�&@    �k!@   ���@������*@   �p=@  �Ga+@   �p=@   ף,@   ���@����k-@   �(\@   �..@    ��@  @33.@   �p= @����k-@	���	#FF369FFF$ 0.000030517578125��6@  5"      5#      �� 5%      "  ��62   .R�5&   
   �� $ border��6   
������ $��11.18��6:   $
��6.59��6H    5'        5(      CommonStates��. 5)        
Normal��6"     5*      	MouseOver��. 5+      �� .��5,      �� $ PathDown��6;   $* $(Shape.Fill).(SolidColorBrush.Color)�6\   .g�5-   "     $ 00:00:00��66   $ 	#FF0061FF��6I   5.      5/      50        51      Pressed��. 52      �� .��53      �� $ PathDown��6;   $* $(Shape.Fill).(SolidColorBrush.Color)�6\   .g�54   "     $ 00:00:00��66   $ 	#B20061FF��6I   55      56      57        58      Disabled��6"   59      ._�5;      F� $	 PathDown��6   $��11.18��6%   $
��6.59��63   $
 uniform=�6A   ����0   �p= @   �z�"@Q �   @
W*@  `��/@   �z�"@����E0@   ���!@���_f�0@   ���!@���=J1@   �z�"@   ��1@    )\#@   ��1@���?��$@���=J1@  `ff%@���ff)@  �z�.@   `��(@����(\/@����(\'@����(\/@����z�&@  �z�.@   ���@  `ff%@   �p=@���?��$@   �p=@    )\#@   ���@   �z�"@   �(\@   ���!@    ��@   ���!@   �p= @   �z�"@	���	#FF369FFF$��Bottom=�6A  5<      5=      �� 5?      "  6   .�5@   
   ��  � �� 5A      �� 5B      "   6"   .R�5C      �� $ BorderNumUpDown��6   #���  66   $��63��6w   $��31��6�   $ 10,10,10,10��6�    5D        5E      $	 270Q�6/   # �  6?   # �  6�   $ 10Q�6�   $	 0.5Q�6�   ._�5G      � .+�5H      �� $ TextblockNumUpDown��6(   $+��%pack://application:,,,/Fonts/#Poppins)�6E   $��	10,5,26,5q�5J   &   $��27��69   $��15(�6D   $��Regular"�6R   ���	#FFF4F4F4$��21��6~   ��5H   x   ��  �� *FindAncestor+"  $ Valore�5J   ~   �� 5K      $ RepeatUp��6+   8��  $��42,6.4,9.9,17q�6k   $
 Hand��6�   �� 5L      $ 
RepeatDown��6+   8�� $��	42,0,10,6q�6o   $��Bottom=�6�   $
 Hand��6�   5M      5N      5O      5Q      5R      �� 5U      "  6   .�5V   
   ��  � ��# � ��5W      �� 5X   
     �@ RowDetailsVisibilityMode$ VisibleWhenSelected=�5Y      �� 5Z   
    � ��$
 true��5[      �� 5\   
    �@��PanningMode$
 Both=�5]      �� 5^   
    �@��IsFlicksEnabled$ False��5_      �� 5`   
    � �� 5a      �� 5b      "   6"   .R�5c      � .+�5d      �� $ border��6!   $
 True��5e      #��z��5f      #��z��5g      # z��5h      ��65   Z� ._�5i      �� $ DG_ScrollViewer��6+   $|�false��5j      
���   ���5l   "   �� 5m   &   "  ��66   .R�5n   *   �  5o   .   �� 5p   2   $
��Auto �6C   �� 5q   2   $��* �6C   �� 5r   2   $
��Auto �6C     5t   .   �� 5u   2   $
��Auto �6@   �� 5v   2   $��* �6@   �� 5w   2   $
��Auto �6@   .+�5z   .   �� $|�false��65   #��Z! 5{      ��5|      C� *�� $"" DataGridSelectAllButtonStyle��"#  +y�5      �� *HeadersVisibility+#% Z$ #' Z&  �� "  ��5�      �� *CellsPanelHorizontalOffset+ �� "  
  5�   .   $!( PART_ColumnHeadersPresenter��6M   $��1��5�   3   y�5�   3   �� *HeadersVisibility+#% Z) #' Z&  �� "  �� 5�   .   $!* PART_ScrollContentPresenter��6E   $��2��5�   +   $��1��5�   +   #+ z��5�   +   �� 5�   .   $, PART_VerticalScrollBar��68   $��2��5�      $��1��5�      $- Vertical=�5�      #/ z. 5�      #1 z0 5�      #y�z2 5�      3 5�      �� *VerticalOffset+$4 OneWay=� �� *TemplatedParent+� 5�   .   $��1��63   $��2��5�       5�   2   �� 5�   6   ��6G   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "  �� 5�   6   $��* �6G   .+�5�   2   �� $, PART_HorizontalScrollBar��6<   $��1��5�       $- 
Horizontal=�5�       #/ z5 5�       #1 z6 5�       #y�z7 5�       3 5�       �� *HorizontalOffset+$4 OneWay=� �� *TemplatedParent+5�   /   5�   +   5�   '   .��5�   "   �� # z 61   5�      5�      � 5�      $8 Grid_Up��6   $��239,267,16,16q�60   $��Bottom=�6G   $��40��6b   $��40��6m   #y�z9 6y   .+�5�      A� $: 
Ellipse_Up��6&   ���	#FF369FFF$��40��6K   $��40��6W   $
 Hand��6b    5�   "     5�   &   # �  67   $	 270Q�6l   # �  6|   $ 10Q�6�   $	 0.5Q�6�   5�      F� 5�      $	 Path_Up��6#   ����0   `��+@   �_.4@   `��+@   �z6 @���߾3@���_j�*@   `��3@   E�+@   �P94@   E�+@   3�4@���_j�*@���5@���ߏ�)@���5@���?��(@   3�4@�����'@������*@   �L�@�����*@    �?@  @�(@    �?@   P�'@   �L�@   ���@����|�'@   `e4@  `W�(@   `e4@   �)@   ���@  ��*@   `z�@   ��+@   @[@   ��+@   ��@  ��*@   �1'@   �z6 @   �1'@   �_.4@   �1'@  ���4@  �-(@����C5@����.`)@����C5@   �K�*@����C5@   `��+@  ���4@   `��+@   �_.4@	#���  6F  $��16.84��6x  $
 uniform=�6�  $��16.56��6�  $; False��6�  5�      5�      < 5�      P� 5�      $= 
Ellipse_Up��6F   > �@J�IsMouseOver$
? true��69   . �5�      �� $@ 
Ellipse_Up��6E    � �� �#0061FF5�      :� 5�      $A MouseLeftButtonDown��6'   $B 
Ellipse_Up��6I   .[�5�      �� .��5�   "   �� .��5�   &   �� $ 
Ellipse_Up��6C   $* $(Shape.Fill).(SolidColorBrush.Color)�6f   .g�5�   *     $ 00:00:00��6>    	#B20061FF6Q   5�   '   5�   #   5�      5�      :� 5�      $A MouseUp��6'   $B 
Ellipse_Up��6=   .[�5�      �� .��5�   "   �� .��5�   &   �� $ 
Ellipse_Up��6C   $* $(Shape.Fill).(SolidColorBrush.Color)�6f   .g�5�   *     $ 00:00:00��6>    #0061FF6Q   5�   '   5�   #   5�      5�      5�      5�      C 5�   
   P� 5�      > �@��
IsGrouping$
? true��5�      . �5�      ��  � ��$ false��5�      5�      5�      �� 5�      "  d�60   .R�5�   
   �  5�        5�      CheckStates��. 5�        Checked��. 5�      �� .��5�      U� $ Border_Toggle��6<   $ (FrameworkElement.Height)�6b   .\�5�   "     $D 00:00:00��67   $E 41Q�6J   5�      T� 5�      $ Border_Toggle��6<   $ (Border.CornerRadius)�6b   ..�5�   "   i� $F 00:00:00��69   G 5�   &   ��5�   *   	10,10,0,0��6B   5�   #   5�      U� 5�      $ Border_Toggle��6<   $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6b   .\�5�   "     $D 00:00:00��67   $E 0Q�6J   5�      5�      5�        5�      	Unchecked��6"   5�      .+�5�      �� $ Border_Toggle��6   -   5        $ 10,10,10,10��5�   ,   $��0q�6G   ���	#FF369FFF$��88��6s   $��31��6~    5�        5�      Border_Shadow��# � 	 6>   $	 270Q�6�   $ 2Q�6�   $ 10Q�6�   $	 0.5Q�6�   ._�5�      F� $	 Arrow��6   $
 uniform=�6&   ����0    �k!@����k'@������&@������,@  �Ga'@  �Ga-@   ף(@  �Ga-@����k)@������,@������.@����k'@����(�/@�����(&@������.@���    �.-@��� �   ���"@��� �   `=
!@���    ��( @�����(&@    �k!@����k'@	���	#fff4f4f4$��Right=�6�  $	��Top=�6  $
��7.18��6,  $
��4.59��69  $��66,14,9.8,12.4q�6G  5�      5�      5�      �� 5     " ��5     .�5  
   ��  �@�Cursor$
 Hand��6#   �� 5  
    �@J�SnapsToDevicePixels$
 true��5     �� 5  
    �@�OverridesDefaultStyle$
 true��5     �� 5  
    � �� 5	     �� 5
     "  ��6"   .R�5     �� $ Border��6   $ 0q�5     $
 true��5     
������ $ 5,5,5,5��5  *   $��8,0,8,0q�6A   ._�5     �� $H Border_F��6+   $��5,5,0,5q�6=   5     < 5     P� 5     > �@J�IsMouseOver$
? True��69   . �5     �� # �  6;   $@ Border��6�    � ��5     5     5     5     �� 5     "  6   .�5  
   ��  � ��8   6/   �� 5  
    � �� 5     �� 5      "   6"   .R�5!     �  5"       5#     
EditStates��. 5$  "     Editable��. 5%  &   �� .��5&  *   T� $ (UIElement.Visibility)�6H   $ PART_EditableTextBox��5'  2   ..�5(  .   i� $F 0��6E   #G ZI 5)  -   5*  +   T� 5+  *   $ (UIElement.Visibility)�5,     $ ContentSite��5-  2   ..�5.  .   i� $F 0��6E   #G ZJ 5/  -   50  +   51  '   52  #     53  "   
Uneditable��6.   54     .+�57     d� $��ToggleButtone��58     8�� $K Press=�5;     L 5:     �� $ IsDropDownOpen�$4 TwoWay=� �� *TemplatedParent+5<     �� 5>     $��	10,4,34,6q�6!   .+�5?     �� $��ContentSite��5@     $; False��5A     #��zM 5B     #��zN 5C     #��z��5D     $��Center=�5E     $��Stretch=�5F     �� 5G     $��ContentSite_Copy��5H     $; False��5I     #��zO 5J     #��zN 5K     #��z��5L     $��Center=�5M     $��Stretch=�5N     #y�zP 5O     5P     � 5S     $��Popup��5T     $��Bottom=�5U     #��zQ 5V     $
R True��5W     $|�False��5X     $��Slide=�5Y     $��Stretch=�64   $��Center=�6R   .��5[     � $��DropDown��5\     $
 True��5]     #��zS 5^     #��zT 5_     $��	3,20,3,20q�6O   .+�5a  "   �� $ DropDownBorder��5b  %   $��0q�5c  %   #���  69   $ 10,10,10,10��6�    5d  &     5e  *   $ 90Q�6;   $ 2Q�6J   $ 10Q�6Z   $	 0.5Q�6j   $ #606060��6x   5g  #   �� 5h  "   $ DropDownBorder_Down��5i  %   $��0q�5j  %   #���  69   $ 10,10,10,10��6�    5k  &     5l  *   $	 270Q�6;   $ 1Q�6K   $ 10Q�6[   $	 0.5Q�6k   # � 	 6y   5n  #   �� 5p  "   $
 True��5q     $��0,8,0,8q�68   .��5r  &   �� $
U True��61   $V 	Contained=�5s     5t  #   5u     5v     5w     5x     5z     5{     5}     