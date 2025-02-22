﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FiveOhFirstDataCore.Core.Structures
{
    public class ResultBase
    {
        protected bool Success { get; set; }
        protected List<string>? Errors { get; set; }

        public ResultBase(bool success, List<string>? errors = null)
        {
            Success = success;
            Errors = errors;
        }

        public virtual bool GetResult([NotNullWhen(false)] out List<string>? errors)
        {
            if (Success)
            {
                errors = null;
                return true;
            }
            else
            {
                errors = Errors ?? new();
                return false;
            }
        }
    }
}
