﻿using FiveOhFirstDataCore.Core.Data;

namespace FiveOhFirstDataCore.Core.Structures
{
    public class NewTrooperData
    {
        public int Id { get; set; }
        public string NickName { get; set; } = "";
        public TrooperRank StartingRank { get; set; } = TrooperRank.Recruit;
        public bool Sixteen { get; set; } = false;
        public bool ModsDownloaded { get; set; } = false;
        public bool PossibleTroll { get; set; } = false;
        public int Age { get; set; }
        public PrefferedRole PreferredRole { get; set; } = PrefferedRole.Trooper;
    }
}
