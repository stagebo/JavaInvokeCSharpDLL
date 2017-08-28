using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    public delegate void TdqsColunmDefineSortDeleagte(DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e);


    public interface ITdqsGridColumn
    {
        TdqsColunmDefineSortDeleagte ColumnSortComparer { get; set; }
    }
}
