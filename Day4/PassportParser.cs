using System;
using System.Collections.Generic;
using System.Reflection;

namespace Day4
{
    internal static class PassportParser
    {
        public static Passport Parse(IEnumerable<string> data)
        {
            var passport = new Passport();

            foreach (string line in data)
            {
                string[] attributes = line.Split(' ');

                foreach (string attribute in attributes)
                {
                    string[] keyValuePair = attribute.Split(':');

                    if (keyValuePair.Length != 2)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    string key = keyValuePair[0], value = keyValuePair[1];

                    PropertyInfo property = typeof(Passport).GetProperty(key);
                    if (property != null && property.GetValue(passport) == null)
                    {
                        // key exists and isn't filled - assign new value
                        property.SetValue(passport, value);
                    }
                }
            }

            return passport;
        }
    }
}
