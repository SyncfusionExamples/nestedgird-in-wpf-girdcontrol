using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace load_grid_to_another_grid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridCellNestedScrollGridModel scrollGridModel = new GridCellNestedScrollGridModel();

        public MainWindow()
        {
            InitializeComponent();
            gridControl.Model.RowCount = 40;
            gridControl.Model.ColumnCount = 20;
            gridControl.Model.HeaderStyle.Borders.All = new Pen(Brushes.LightGray, 1);
            gridControl.Model.QueryCellInfo += Model_QueryCellInfo;
            //Add nested grid to cell model
            gridControl.Model.CellModels.Add("ScrollGrid", scrollGridModel);
            gridControl.Model[2, 2].CellType = "ScrollGrid";



            GridModel nestedGrid = new GridModel();
            nestedGrid.Options.AllowSelection = GridSelectionFlags.Cell;
            nestedGrid.RowHeights.DefaultLineSize = 20;
            nestedGrid.RowCount = 20;
            nestedGrid.ColumnWidths.DefaultLineSize = 50;
            nestedGrid.ColumnCount = 15;
            Brush headerBrush = ColorHelper.CreateFrozenSolidColorBrush(128, Colors.DarkGray);
            nestedGrid.BaseStylesMap["Header"].StyleInfo.Background = headerBrush;

            for (int i = 0; i < nestedGrid.RowCount; i++)
            {
                for (int j = 0; j < nestedGrid.ColumnCount; j++)
                {
                    GridStyleInfo style = new GridStyleInfo();
                    style.CellType = "TextBox";
                    style.CellValue = String.Format("{0}:{1}", i, j);
                    nestedGrid.Data[i, j] = style.Store;
                }
            }
            gridControl.Model[2, 2].CellValue = nestedGrid;
            gridControl.CoveredCells.Add(new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(2, 2, 9, 5));
        }

        private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex == 0 || e.Cell.ColumnIndex == 0)
                e.Style.CellValue = "R"+e.Cell.RowIndex + ", C" + e.Cell.ColumnIndex;
        }
    }
}
