﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF.Core.UI.UIElements
{
    public interface ITextField : IBaseUIElement
    {
        public string Text
        {
            get => GetText();
        }
    }

}
