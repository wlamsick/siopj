using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Util.Extensions;
    public static class StringValidationExtensions
    {
        public static string ThrowExceptionIfNull(this string str, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(str)) throw exception;
            return str;
        }
    }
