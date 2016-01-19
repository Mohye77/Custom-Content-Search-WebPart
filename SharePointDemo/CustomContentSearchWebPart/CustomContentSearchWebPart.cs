using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.Office.Server.Search.WebControls;
using SharePointDemo.Common.Localization;
using Microsoft.SharePoint.WebPartPages;
using System.Collections.Generic;

namespace SharePointDemo.CustomContentSearchWebPart
{
    [ToolboxItemAttribute(false)]
    public class CustomContentSearchWebPart : ContentBySearchWebPart
    {
        #region WebPart Properties
        [WebBrowsable(true),
        LocalizedWebDisplayNameAttribute("SharePointDemo,SeeMoreUrl_Name"),
        LocalizedWebDescriptionAttribute("SharePointDemo,SeeMoreUrl_Description"),
        Personalizable(PersonalizationScope.Shared),
        LocalizedCategoryAttribute("SharePointDemo,WebPart_Category")]
        public string SeeMoreUrl { get; set; }

        [WebBrowsable(true),
        LocalizedWebDisplayNameAttribute("SharePointDemo,SeeMoreText_Name"),
        LocalizedWebDescriptionAttribute("SharePointDemo,SeeMoreText_Description"),
        Personalizable(PersonalizationScope.Shared),
        LocalizedCategoryAttribute("SharePointDemo,WebPart_Category")]
        public string SeeMoreText { get; set; }

        [WebBrowsable(true),
        LocalizedWebDisplayNameAttribute("SharePointDemo,ReadMoreUrl_Name"),
        LocalizedWebDescriptionAttribute("SharePointDemo,ReadMoreUrl_Description"),
        Personalizable(PersonalizationScope.Shared),
        LocalizedCategoryAttribute("SharePointDemo,WebPart_Category")]
        public string ReadMoreUrl { get; set; }

        [WebBrowsable(true),
        LocalizedWebDisplayNameAttribute("SharePointDemo,ReadMoreText_Name"),
        LocalizedWebDescriptionAttribute("SharePointDemo,ReadMoreText_Description"),
        Personalizable(PersonalizationScope.Shared),
        LocalizedCategoryAttribute("SharePointDemo,WebPart_Category")]
        public string ReadMoreText { get; set; }
        #endregion

        /// <summary>
        /// Override GetToolParts to put our custom properties into the properties panel
        /// </summary>
        /// <returns></returns>
        public override ToolPart[] GetToolParts()
        {
            List<ToolPart> tp = new List<ToolPart>(base.GetToolParts());
            tp.Add(new CustomPropertyToolPart());
            return tp.ToArray();
        }

        /// <summary>
        /// Override OnLoad to make the custom properties accessible for the displaytemplates
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (this.AppManager != null)
            {
                if (this.AppManager.QueryGroups.ContainsKey(this.QueryGroupName) &&
                    this.AppManager.QueryGroups[this.QueryGroupName].DataProvider != null)
                {
                    this.AppManager.QueryGroups[this.QueryGroupName].DataProvider.BeforeSerializeToClient +=
                        new BeforeSerializeToClientEventHandler(EnhanceQuery);
                }
            }

            base.OnLoad(e);
        }

        private void EnhanceQuery(object sender, BeforeSerializeToClientEventArgs e)
        {
            DataProviderScriptWebPart dataProvider = sender as DataProviderScriptWebPart;
            dataProvider.Properties.Add("Demo_SeeMoreText", this.SeeMoreText);
            dataProvider.Properties.Add("Demo_SeeMoreUrl", this.SeeMoreUrl);
            dataProvider.Properties.Add("Demo_ReadMoreText", this.ReadMoreText);
            dataProvider.Properties.Add("Demo_ReadMoreUrl", this.ReadMoreUrl);
        }
    }
}
