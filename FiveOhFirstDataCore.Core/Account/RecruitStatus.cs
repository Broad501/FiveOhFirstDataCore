﻿using FiveOhFirstDataCore.Core.Data;

using System;

namespace FiveOhFirstDataCore.Core.Account
{
    public class RecruitStatus
    {
        public Guid RecruitStatusId { get; set; }
        public bool OverSixteen { get; set; } = true;
        public int Age { get; set; }
        public bool ModsInstalled { get; set; } = true;
        public bool PossibleTroll { get; set; } = false;
        public PrefferedRole PreferredRole { get; set; } = PrefferedRole.Trooper;

        public int TrooperId { get; set; }
        public Trooper Trooper { get; set; }
    }
}
