﻿using System;
using SharedLibrary;

namespace SharedLibrary.Objects
{
    public class Penalty : Database.Models.EFPenalty
    {
        public enum PenaltyType
        {
            Report,
            Warning,
            Flag,
            Kick,
            TempBan,
            Ban,
            Unban,
            Any,
        }
        
        public String GetWhenFormatted()
        {
            return When.ToString("MM/dd/yy HH:mm:ss"); ;
        }
    }
}
