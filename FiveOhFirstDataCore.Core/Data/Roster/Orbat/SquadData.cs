﻿using FiveOhFirstDataCore.Core.Account;

namespace FiveOhFirstDataCore.Core.Data.Roster
{
    public class SquadData : IAssignable<Trooper>
    {
        public Trooper Lead { get; set; }
        public Trooper RT { get; set; }
        public TeamData[] Teams { get; set; } = new TeamData[] { new(), new() };
        public Trooper ARC { get; set; }

        public void Assign(Trooper t)
        {
            switch (t.Role)
            {
                case Role.RTO:
                    RT = t;
                    break;
                case Role.ARC:
                    ARC = t;
                    break;
                default:
                    switch (t.Team)
                    {
                        case null:
                            switch (t.Role)
                            {
                                case Role.Lead:
                                    Lead = t;
                                    break;
                            }
                            break;
                        case Team.Alpha:
                            Teams[0].Assign(t);
                            break;
                        case Team.Bravo:
                            Teams[1].Assign(t);
                            break;
                    }
                    break;
            }
        }
    }
}
