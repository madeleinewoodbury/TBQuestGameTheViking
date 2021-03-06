﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.White;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.White;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.White;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.White;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuBorderColor = ConsoleColor.DarkBlue;

        //
        // message box colors
        //
        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkBlue;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.White;
        
        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkBlue;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // status box colors
        //
        public static ConsoleColor StatusBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor StatusBoxBorderColor = ConsoleColor.DarkBlue;
        public static ConsoleColor StatusBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // battle theme colors
        public static ConsoleColor BattleMessageBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor BattleMessageBoxForegroundColor = ConsoleColor.Red;
        public static ConsoleColor BattleMessageBoxBorderColor = ConsoleColor.DarkBlue;
        public static ConsoleColor BattleMessageBoxHeaderBackgroundColor = ConsoleColor.DarkRed;
        public static ConsoleColor BattleMessageBoxHeaderForegroundColor = ConsoleColor.Black;

    }
}
