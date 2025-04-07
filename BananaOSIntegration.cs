using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static WhoIsThatMonke.PublicVariablesGatherHere;

namespace BananaOS.Pages
{
    public class ExamplePage : WatchPage
    {
        public override string Title => "WhoIsThatMonke";
        public override bool DisplayOnMainMenu => true;
        public override void OnPostModSetup()
        {
            selectionHandler.maxIndex = 3;
        }

        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=yellow>== WhoIsThatMonke ==</color>");
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "<color=magenta> Platform Checker </color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(1, "<color=magenta> Velocity Checker </color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(2, "<color=magenta> FPS Checker </color>"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(3, "<color=magenta> Color Code Spoofer </color>"));
            return stringBuilder.ToString();
        }

        private string GetTheEnabled(bool varvar)
        {
            return varvar ? "Enabled" : "Disabled";
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                    {
                        isPlatformEnabled = !isPlatformEnabled;
                        SendNotification($"<align=center><size=5> Platform Checker is now: {GetTheEnabled(isPlatformEnabled)}");
                        return;
                    }
                    if (selectionHandler.currentIndex == 1)
                    {
                        isVelocityEnabled = !isVelocityEnabled;
                        SendNotification($"<align=center><size=5> Velocity Checker is now: {GetTheEnabled(isVelocityEnabled)}");
                        return;
                    }
                    if (selectionHandler.currentIndex == 2)
                    {
                        isFPSEnabled = !isFPSEnabled;
                        SendNotification($"<align=center><size=5> FPS Checker is now: {GetTheEnabled(isFPSEnabled)}");
                        return;
                    }
                    if (selectionHandler.currentIndex == 3)
                    {
                        isColorCodeEnabled = !isColorCodeEnabled;
                        SendNotification($"<align=center><size=5> Color Code Spoofer is now: {GetTheEnabled(isColorCodeEnabled)}");
                        return;
                    }
                    break;

                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
        private void SendNotification(string message)
        {
            BananaNotifications.DisplayNotification(message, Color.yellow, Color.white, 0.8f);
        }
    }
}
