using HandyControl.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyTwitchTools.Services;
using MyTwitchTools.ViewModels;
using MyTwitchTools.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyTwitchTools.Commands
{
    public class PopupWindowCommand : CommandBase
    {
        public PopupWindowCommand()
        {

        }

        public override void Execute(object parameter)
        {
            PopupWindow popup = new PopupWindow()
            {
                Title = "PopupWindow",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                DataContext = new AddAccountView()
            };
            popup.ShowDialog();
        }
    }
}
