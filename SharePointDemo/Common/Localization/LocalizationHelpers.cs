using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDemo.Common
{
    class LocalizationHelpers
    {        
        /// <summary>
        /// Use this method to get a localized resource from its name, a resource file and a chosen culture.
        /// </summary>
        /// <param name="resourceFileName">The name of the resource file</param>
        /// <param name="resourceName">The name of the resource</param>
        /// <param name="LCID">The LCID corresponds to a certain language.
        ///                    If the named resource does not have a value for the specified language,
        ///                    the method will return the value for the invariant language
        /// </param>
        /// <returns>Returns the corresponding resource value</returns>
        public static string GetLocalizedString(string resourceFileName, string resourceName, int LCID)
        {
            if (string.IsNullOrEmpty(resourceName) || string.IsNullOrEmpty(resourceFileName))
                return string.Empty;

            return SPUtility.GetLocalizedString("$Resources:" + resourceName, resourceFileName, (uint)LCID);
        }

        /// <summary>
        /// Use this method to get a localized resource from its name, a resource file and the current culture.
        /// </summary>
        /// <param name="resourceFileName">The name of the resource file</param>
        /// <param name="resourceName">The name of the resource</param>
        /// <returns></returns>
        public static string GetLocalizedString(string resourceFileName, string resourceName)
        {
            return GetLocalizedString(resourceFileName, resourceName, CultureInfo.CurrentUICulture.LCID);
        }
    }
}
