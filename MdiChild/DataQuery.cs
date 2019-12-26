using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BaseService;

namespace MdiChild
{
    public class DataQuery
    {
        private Form queryFrom;

        public string QueryText;

        public DataQuery(string aAssembly, string aXml, string aPath)
        {
            if (BaseService.BaseService.QueryWindow == 0)
                queryFrom = new QuerySimpleFrm(aAssembly, aXml, aPath);
            else
                queryFrom = new QueryDifficultFrm(aAssembly, aXml, aPath);
        }

        public DialogResult ShowDialog()
        {
            DialogResult tempDialogResult = queryFrom.ShowDialog();
            if (BaseService.BaseService.QueryWindow == 0)
                QueryText = (queryFrom as QuerySimpleFrm).QueryText;
            else
                QueryText = (queryFrom as QueryDifficultFrm).QueryText;
            return tempDialogResult;
        }
    }
}
