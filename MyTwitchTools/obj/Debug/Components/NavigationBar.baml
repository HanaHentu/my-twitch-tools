   M S B A M L   `   `   `  ����H  DMyTwitchTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MyTwitchTools.ComponentsMyTwitchTools.Components  5      ,    &MyTwitchTools.Components.NavigationBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      2local&clr-namespace:MyTwitchTools.Components  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � 	Resources  5
       �� 
TargetType �� Property   FontAwesomeSolid900 �� Value   BooleanToVisibilityConverter@  :HandyControl.Tools.Converter.Boolean2VisibilityReConverter " BooleanToVisibilityReConverter��%�   '��       7   &	 D     &	 W     �� 5   
   " ��6   .�5      ��  � ��8   6+   5      �� 5   
   6'     5   
   6+   5      .��5      $  HandyControl.Controls.SideMenu  $	��125��5   	   $��1q�5   	      	SideBrush 5   	   �� *SideBrushColor+.  (HandyControl.Controls.SimpleItemsControl   Items. 5   
   (  "HandyControl.Controls.SideMenuItem  6  0HandyControl.Controls.HeaderedSimpleItemsControl   Header$
 Home��5         Command 5      �� *NavigateHomeCommand+   CommandParameter 5      �� *Header+	 �� RelativeSource	 �� *Self+
   Icon
 5      �� 5      $	����6   5        5   
   $ Accounts��5        5      �� * NavigateAccountsListingCommand+ 5      �� *Header+	 �� *Self+
 5!      �� 5"      $	����6   5$        5%   
   $
 Chat��5(       5&      �� *NavigateChatCommand+ 5'      �� *Header+	 �� *Self+
 5)      �� 5*      $	����6   5,        5-   
   $ Settings��50       5.      �� *NavigateSettingsCommand+ 5/      �� *Header+	 �� *Self+
 51      �� 52      $	����6   54      55      56      