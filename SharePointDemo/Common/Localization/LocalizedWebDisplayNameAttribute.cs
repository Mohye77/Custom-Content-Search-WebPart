using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SharePointDemo.Common.Localization
{
    /// <summary>
    /// The display name must be written this way : ResourceFileName,ResourceName
    /// </summary>
    public sealed class LocalizedWebDisplayNameAttribute : WebDisplayNameAttribute
    {
        bool m_isLocalized;

        public LocalizedWebDisplayNameAttribute(string displayName)
            : base(displayName)
        { }

        public override string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(base.DisplayName))
                {
                    if (base.DisplayName.Contains(','))
                    {
                        if (!m_isLocalized)
                        {
                            string[] values = base.DisplayName.Split(',');
                            this.DisplayNameValue = LocalizationHelpers.GetLocalizedString(
                                values[0],
                                values[1],
                                CultureInfo.CurrentUICulture.LCID);
                            m_isLocalized = true;
                        }
                        return base.DisplayName;
                    }
                }
                return "";
            }
        }
    }
}

