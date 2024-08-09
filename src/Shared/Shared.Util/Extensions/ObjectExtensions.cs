using System.Collections;

namespace Shared.Util.Extensions
{
    public static class ObjectExtensions
    {
        public static bool ValueIsNumber(this object obj)
        {
            string value = obj.ToString() ?? "";
            if (!string.IsNullOrWhiteSpace(value))
            {
                int intResult;
                double doubleResult;
                if (double.TryParse(value, out doubleResult) || int.TryParse(value, out intResult))
                {
                    return true;
                }
            }
            return false;
        }

    }
}