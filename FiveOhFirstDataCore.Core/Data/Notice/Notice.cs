﻿using FiveOhFirstDataCore.Core.Account;

using Microsoft.AspNetCore.Components;

using System;

namespace FiveOhFirstDataCore.Core.Data.Notice
{
    public class Notice
    {
        public Guid NoticeId { get; set; }
        public Trooper Author { get; set; }
        public int? AuthorId { get; set; }
        public NoticeBoardData NoticeBoard { get; set; }
        public string NoticeBoardName { get; set; }
        public DateTime PostedOn { get; set; }
        public bool Sticky { get; set; }
        public string Contents { get; set; } = "";
        public MarkupString Display => new(Contents);
        public NoticeLevel Level { get; set; } = NoticeLevel.PrimaryOutline;
    }
}
