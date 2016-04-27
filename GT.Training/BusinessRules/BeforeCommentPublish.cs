using Grouptree.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GT.Training.BusinessRules
{
    public class BeforeCommentPublish : Grouptree.Core.BizRules.AfterInsertBase
    {
        public override bool RunBizRule(Grouptree.Core.Asset asset)
        {            
            if(asset.TypeAndSubType.Equals("NEWS.COMMENT"))
            {
                asset.Name = "Added by " + UserWrapper.GetCurrent().FullName + " on " + DateTime.Now.ToUniversalTime().ToShortDateString();
                return true;
            }

            return false;
        }
    }
}