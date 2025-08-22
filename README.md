# Nestedgrid in WPF GridControl

This repository demonstrates the nested gird feature demos in [WPF GridControl](https://help.syncfusion.com/wpf/gridcontrol/overview).

### Nested grid inside a row or column

You can add the nested grid into the parent grid row by using [grid.Model.CellModels.Add](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellModelCollection.html#Syncfusion_Windows_Controls_Grid_GridCellModelCollection_Add_System_String_Syncfusion_Windows_Controls_Grid_GridCellModelBase_) method and need to specify the cell type as `ScrollGrid` in the first parameter and set the nested scroll grid model ([GridCellNestedScrollGridModel](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellNestedScrollGridModel.html)) in the second parameter of this collection method. Before that, you must add a row and column to the nested grid and set the cell range for adding the nested grid to the row of parent grid.


### Multiple nested grid inside a covered range with its columns using column layout

You can add the multiple number of nested grid into the parent grid column using column layout. You can achieve this requirement by the following way.

First, You can add the nested grid into the parent grid column by using [grid.Model.CellModels.Add](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellModelCollection.html#Syncfusion_Windows_Controls_Grid_GridCellModelCollection_Add_System_String_Syncfusion_Windows_Controls_Grid_GridCellModelBase_) method and need to specify the cell type as `ScrollGrid` in the first parameter and set the nested cell grid model ([GridCellNestedGridModel](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellNestedGridModel.html)) in the second parameter of this collection method. Before that, you must add a row and column to the nested grid and set the cell range for adding the nested grid to the column of parent grid.

Next, you can add another nested grid inside the first nested grid by setting the specific range of first nested grid and again do this for adding another nested grid.

### Nested grid inside a covered with its rows and columns independent of parent grid

You can add the nested grid into the parent grid row and column by using [grid.Model.CellModels.Add](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellModelCollection.html#Syncfusion_Windows_Controls_Grid_GridCellModelCollection_Add_System_String_Syncfusion_Windows_Controls_Grid_GridCellModelBase_) method and need to specify the cell type as ScrollGrid in the first parameter and set the nested cell grid model ([GridCellNestedGridModel](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCellNestedGridModel.html)) in the second parameter of this collection method. Before that, you must add a row and column to the nested grid and set the cell range for adding the nested grid to the row of parent grid.

In this case, the nested grid maintains its own row heights and column widths. You can scroll through this grid without scrolling the parent grid. You can resize the rows and columns in the nested grid without affect the parent grid.