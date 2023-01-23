using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNine
{
    internal class EnterException : Exception
    {
        public override string Message { get; }
        public EnterException() : base()
        { 
            Message = "Неверный ввод. Число должно быть равно либо 1, либо 2!";
            HelpLink = "learn.microsoft.com";
        }
    }
}
