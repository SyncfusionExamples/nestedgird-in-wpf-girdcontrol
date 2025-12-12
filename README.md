# Nested Grid Inside a Covered with its Rows and Columns Independent of Parent Grid in WPF GridControl

This repository demonstrates the nested gird feature demos in [WPF GridControl](https://www.syncfusion.com/wpf-controls/excel-like-grid).

You can add the nested grid into the parent grid row and column by using [grid.Model.CellModels.Add](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellModelCollection.html#Syncfusion_Windows_Controls_Grid_GridCellModelCollection_Add_System_String_Syncfusion_Windows_Controls_Grid_GridCellModelBase_) method and need to specify the cell type as ScrollGrid in the first parameter and set the nested cell grid model ([GridCellNestedGridModel](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellNestedGridModel.html)) in the second parameter of this collection method. Before that, you must add a row and column to the nested grid and set the cell range for adding the nested grid to the row of parent grid.

In this case, The nested grid maintains its own row heights and column widths. You can scroll through this grid without scrolling the parent grid. You can resize the rows and columns in the nested grid without affect the parent grid.

For example, the below code is how to make rows and columns independent of parent grid.

``` csharp
// Add Nested Grid cell model.
GridCellNestedGridModel gridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Normal, GridNestedAxisLayout.Normal);
gridControl.Model.CellModels.Add("ScrollGrid", gridModel);
gridControl.Model[3, 2].CellType = "ScrollGrid";


// Create a simple nested grid.
GridModel model = new GridModel();
model.Options.AllowSelection = GridSelectionFlags.Cell;
model.RowHeights.DefaultLineSize = 20;
model.RowCount = 20;
model.ColumnWidths.DefaultLineSize = 50;
model.ColumnCount = 8;
model.HeaderRows = 0;
model.FrozenRows = 0;
model.HeaderColumns = 1;
model.FrozenColumns = 1;
for (int i = 0; i < model.RowCount; i++)
{
    for (int j = 0; j < model.ColumnCount; j++)
    {
        GridStyleInfo style = new GridStyleInfo();
        style.CellType = "TextBox";
        style.CellValue = String.Format("{0}:{1}", i, j);
        model.Data[i, j] = style.Store;
    }
}
gridControl.Model[3, 2].CellValue = model;
gridControl.CoveredCells.Add(new CoveredCellInfo(3, 2, 5, 4));
```

![Nested grid inside a parent GridControl](NestedGridInsideParentGrid.png)