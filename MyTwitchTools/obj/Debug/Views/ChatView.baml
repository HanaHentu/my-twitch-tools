   M S B A M L   `   `   `  ����H  DMyTwitchTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MyTwitchTools.ComponentsMyTwitchTools.Components  5      9!clr-namespace:MyTwitchTools.ViewsMyTwitchTools.Views  5      A%clr-namespace:MyTwitchTools.BehaviorsMyTwitchTools.Behaviors  5	      "    MyTwitchTools.Views.ChatView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =
components&clr-namespace:MyTwitchTools.Components     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      -local!clr-namespace:MyTwitchTools.Views  5      5	behaviors%clr-namespace:MyTwitchTools.Behaviors  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  6L     � 	Resources  5      2  ,System.Windows.Controls.AlternationConverter   AlternationConverter   Values  RegionColor �� Color  ThirdlyRegionColor  ChatListViewItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� RelativeSource �� Path	 �� 	Converter  ChatListViewStyle
 �� BasedOn��%�  &	        &	 N     7   &	 @    7��  5   
   . 5      �� # �  6   �� 5      # �  6   5      �� 5   
   " ��6.   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ��6!   ��  �� *TemplatedParent+$% (ItemsControl.AlternationIndex)�8	   ._�5      �� 5      5      5      5      �� 5    
   8
   " ��5#      .�5$      ��  � ��$ 0q�6(   5%      5&      .��5(      �  � RowDefinitions 5)   
   �� 5*      $
��auto �6   �� 5+      $��* �6   .+�5-   
   �� $��0��5.      $��0,0,0,10q�5/        LargeFontSize#��[ 50      $
��Chat��51      �� 52   
   $��1��53      $��0q�54       �� CornerRadius$ 10��55      ��56      �� 57      # �  6"   ._�59      �  5:      �� 5;      $��* �6$   �� 5<      $
��auto �6$   .+�5?      �� -   5        $��ListViewChat��5@      $��0��5A       �� AlternationCount$ 2��5B      #��[ 5C      ��.  $��Disabled=�5F      #��[ 5G       %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�5I      ��5D      �� *
Messages+*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5J      5   /MyTwitchTools.Behaviors.ScrollListToEndBehavior  5K         Source 6<   �� *
Messages+��5M      �� 5N      .R�5O      ��  �� Orientation$ Vertical=�6)   .+�5P   "   �� $��5q�6-   $ 
Horizontal=�68   .+�5Q   &   �� �� 5R   *   
����p���6I   �� *	Timestamp+ �� Mode$ OneWay=� �� 5S   *   $
��Bold"�5T   -   
��� ����5V   -   �� *User+$ OneWay=� �� 5W   *   $�: ��6.   5X   '   �� 5Y   &   $
��Wrap=�6S   ��60   �� *Text+$ OneWay=�6S   5Z   #   �� 5[   "   
�������  BorderHorizontallySplitter#��[ 6;   5\      5]      5_      �� 5a      $��5��5b      $��50��5c      $ 	0,0,10,10��5d      ��5e      �� 5f      # �  6*   ._�5h      � $��5q�6    � ColumnDefinitions 5i      �� 5j      $
��auto �6/   �� 5k      $��* �6/   .+�5m      $  HandyControl.Controls.ComboBox  $��0��5n      $
��Left=�5o      '  !HandyControl.Controls.InfoElement   Placeholder$ Select an account��5p       �� DisplayMemberPath$ Account.Login��5q       �� SelectedIndex$ 0��5s      ��5r      �� *
Accounts+ �� SelectedItem 5t      �� *SelectedAccount+#  HandyControl.Controls.TextBox  5u      $��1��5v      $��5,0,0,0q�5w      $��8,0,32,0q�5x      $��Center=�5y      $ Send a message��5z       �� TextWrapping$
 Wrap=�5|      ��5{      �� *CurrentMessageText+ �� UpdateSourceTrigger$ PropertyChanged=�.��5|   1    J� InputBindings 5}      �� 5~   "   
 �� Key$ Return��6-    �� Command 6:   �� *SendChatMessageCommand+.��5   9   5�      �� 5�      $��1��5�      $��25��5�      $��25��5�      $��0,0,8,0q�5�      $��0q�5�      $��Right=�5�      $��Center=�5�      )  #HandyControl.Controls.BorderElement   CornerRadius$ 8��5�      ��5�      �� *SendChatMessageCommand+.��5�      ��   FontAwesomeSolid900#��[ 5�   !   $��15(�5�   !   $	����5�   !   5�      �� 5�      $��1��5�      $��5,0,0,0q�5�       �� Padding$ 8,0,32,0q�5�      $	��Top=�5�      $��10(�5�      ��5�      �� *ErrorMessage+$ PropertyChanged=���5�      �� 5�   "     DangerColor# �  62   5�      5�      5�      5�      5�      5�      5�      