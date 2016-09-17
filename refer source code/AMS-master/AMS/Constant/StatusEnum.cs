﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.Enum
{
    [Flags]
    public enum StatusEnum
    {
        Open = 1,
        Processing = 2,
        Done = 3,
        Close = 4,
        Cancel = 5,
        AssignTask = 6,
        ChangeDueDate = 7,

    }
}