using System;
using System.Text.Json;

namespace BIR_EIS_AWS.Util
{
    public static class Common
    {
        public static string ObjectToString<T>(T[] array)
        {
            string output = "";
            foreach (var item in array)
            {
                output += JsonSerializer.Serialize(array) + Environment.NewLine;
            }
            return output;
        }
    }
}
