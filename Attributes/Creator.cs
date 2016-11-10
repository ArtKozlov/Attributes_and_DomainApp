using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class Creator
    {
        public static IEnumerable<AdvancedUser> CreateAdvancedUsers()
        {
            List<AdvancedUser> listOfAdvancedUsers = new List<AdvancedUser>();
            Assembly asmbly = typeof(User).Assembly;
            InstantiateAdvancedUserAttribute[] instanciateAttrs = (InstantiateAdvancedUserAttribute[])Attribute.GetCustomAttributes(asmbly, typeof(InstantiateAdvancedUserAttribute));

            Type[] typeOfInt = { typeof(int), typeof(int) };
            MatchParameterWithPropertyAttribute[] matchAttr = (MatchParameterWithPropertyAttribute[])typeof(AdvancedUser).GetConstructor(typeOfInt).GetCustomAttributes(typeof(MatchParameterWithPropertyAttribute), false);

            DefaultValueAttribute defValAttrId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.First(a => a.ParametrName == "id").PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            int defaultValueId = (int)defValAttrId.Value;

            DefaultValueAttribute defValAttrExtId = (DefaultValueAttribute)typeof(AdvancedUser).GetProperty(matchAttr.First(a => a.ParametrName == "externalId").PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            int defaultValueExternalId = (int)defValAttrExtId.Value;

            foreach (var attr in instanciateAttrs)
            {
                int id = ReferenceEquals(attr.Id, null) ? defaultValueId : attr.Id;
                int externalId = ReferenceEquals(attr.ExternalId, null) ? defaultValueExternalId : attr.ExternalId.Value;

                AdvancedUser user = new AdvancedUser(id, externalId) { FirstName = attr.Firstname, LastName = attr.LastName };
                listOfAdvancedUsers.Add(user);
            }

            return listOfAdvancedUsers;
        }

        public static IEnumerable<User> CreateUsers()
        {
            InstantiateUserAttribute[] attrs = (InstantiateUserAttribute[])typeof(User).GetCustomAttributes(typeof(InstantiateUserAttribute), false);
            List<User> listOfUsers = new List<User>();

            Type[] typeOfInt = { typeof(int) };
            MatchParameterWithPropertyAttribute matchAttr = (MatchParameterWithPropertyAttribute)typeof(User).GetConstructor(typeOfInt).GetCustomAttribute(typeof(MatchParameterWithPropertyAttribute), false);

            DefaultValueAttribute defValAttrId = (DefaultValueAttribute)typeof(User).GetProperty(matchAttr.PropertyName).GetCustomAttribute(typeof(DefaultValueAttribute));
            int defaultValueId = (int)defValAttrId.Value;

            foreach (var attr in attrs)
            {
                int id = ReferenceEquals(attr.Id, null) ? defaultValueId : attr.Id;

                User user = new User(id) { FirstName = attr.Firstname, LastName = attr.LastName };
                listOfUsers.Add(user);
            }

            return listOfUsers;
        }
    }
}
