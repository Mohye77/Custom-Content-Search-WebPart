using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace SharePointDemo.Common.Localization
{
    /// <summary>
    /// The description must be written this way : ResourceFileName,ResourceName
    /// </summary>
    public sealed class LocalizedWebDescriptionAttribute : WebDescriptionAttribute
    {
        bool m_isLocalized;

        public LocalizedWebDescriptionAttribute(string description)
            : base(description)
        { }

        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Description))
                {
                    if (base.Description.Contains(','))
                    {
                        if (!m_isLocalized)
                        {
                            string[] values = base.Description.Split(',');
                            this.DescriptionValue = LocalizationHelpers.GetLocalizedString(
                                    values[0],
                                    values[1],
                                    CultureInfo.CurrentUICulture.LCID);
                            m_isLocalized = true;
                        }
                        return base.Description;
                    }
                }
                return "";
            }
        }
    }
}
