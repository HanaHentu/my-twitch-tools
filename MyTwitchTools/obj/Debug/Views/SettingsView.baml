   M S B A M L   `   `   `  ����H  DMyTwitchTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyTwitchTools.ViewsMyTwitchTools.Views  5      &     MyTwitchTools.Views.SettingsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      -local!clr-namespace:MyTwitchTools.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��5         LargeFontSize#��[  5      $��Settings��5      �� 5   
   $��1��5      $
��0,10q�5        BorderHorizontallySplitter#��[ 5      �� 5   
   $��2��5       $
��20,0q�5!      $
��Left=�5"        TextBlockTitleBold#��[ 5#      $��THEME��5$      ,  &HandyControl.Controls.SimpleStackPanel  5&   
   $��3��5'      $
��0,10q�5(         Orientation$ 
Horizontal=�5)      .+�5+      �� $��40,0,0,0q�5,      (  "HandyControl.Controls.TitleElement   Title$ Choose theme��5-        ComboBoxExtend#��[ 50      ��5.      �� *ThemeOptions+ �� SelectedItem 5/      �� *SelectedTheme+50      � 52      $��40,0,0,0q�6     53      �� 54      $
��auto �6$   �� 55      $��* �6$   .+�58      �� $��0��59      $��12(�5:      $��Right=�5;        TextBlockSubTitle#��[ 5<      $��Select color accent��5=      �� 5?      -   5         ��Name$ ChangeColorAccentButton��5@      $��1��5A      $	��110��5B      $��Bottom=�5C      ��5D      �� *BackgroundColor+��5E      �� *ColorAccentCommand+5F      5H      �� 5J   
   $��4��5K      $
��0,10q�5L      #��[ 5M      5O      5P      