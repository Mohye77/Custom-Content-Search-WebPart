using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDemo.Common.Localization
{
    /// <summary>
    /// The category must be written this way : ResourceFileName,ResourceName
    /// </summary>
    public sealed class LocalizedCategoryAttribute : CategoryAttribute
    {
        public LocalizedCategoryAttribute(string category)
            : base(category)
        { }

        protected override string GetLocalizedString(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains(','))
                {
                    string[] values = value.Split(',');
                    return LocalizationHelpers.GetLocalizedString(
                        values[0],
                        values[1],
                        CultureInfo.CurrentUICulture.LCID);
                }
            }
            return "";
        }
    }
}
