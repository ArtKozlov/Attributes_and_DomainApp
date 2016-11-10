using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    public class Validator
    {
        public static bool StringIsValid(User user)
        {

            foreach (FieldInfo elem in typeof(User).GetFields())
            {
                StringValidatorAttribute attr = (StringValidatorAttribute)elem.GetCustomAttribute(typeof(StringValidatorAttribute));
                if (ReferenceEquals(attr, null))
                {
                    return false;
                }
                if (elem.GetValue(user).ToString().Length > attr.Length)
                    return false;

            }
            foreach (PropertyInfo elem in typeof(User).GetProperties())
            {
                StringValidatorAttribute attr = (StringValidatorAttribute)elem.GetCustomAttribute(typeof(StringValidatorAttribute));
                if (ReferenceEquals(attr, null))
                {
                    return false;
                }
                if (elem.GetValue(user).ToString().Length > attr.Length)
                    return false;

            }
            return true;
        }

        public static bool IntIsValid(User user)
        {

            foreach (FieldInfo elem in typeof(User).GetFields())
            {
                IntValidatorAttribute attr = (IntValidatorAttribute)elem.GetCustomAttribute(typeof(IntValidatorAttribute));
                if (ReferenceEquals(attr, null))
                {
                    return false;
                }
                if ((int)elem.GetValue(user) < attr.Min || (int)elem.GetValue(user) > attr.Max)
                    return false;

            }
            foreach (PropertyInfo elem in typeof(User).GetProperties())
            {
                IntValidatorAttribute attr = (IntValidatorAttribute)elem.GetCustomAttribute(typeof(IntValidatorAttribute));
                if (ReferenceEquals(attr, null))
                {
                    return false;
                }
                if ((int)elem.GetValue(user) < attr.Min || (int)elem.GetValue(user) > attr.Max)
                    return false;

            }
            return true;
        }
    }
}
