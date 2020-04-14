using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
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

namespace Nestedgrid_rows_and_columns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gridControl.Model.RowCount = 10;
            gridControl.Model.ColumnCount = 8;
            gridControl.Model.HeaderStyle.Borders.All = new Pen(Brushes.LightGray, 1);
            gridControl.Model.QueryCellInfo += Model_QueryCellInfo;
            GridCellNestedGridModel gridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Normal, GridNestedAxisLayout.Normal);
            gridControl.Model.CellModels.Add("ScrollGrid", gridModel);
            gridControl.Model[3, 2].CellType = "ScrollGrid";
            for (int i = 0; i < gridControl.Model.RowCount; i++)
            {
                for (int j = 0; j < gridControl.Model.ColumnCount; j++)
                {
                    gridControl.Model[i, j].CellValue = String.Format("{0}:{1}", i, j);
                }
            }
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
        }

        private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex > 0)
            {
                e.Style.Background = SystemColors.InactiveCaptionBrush;
                e.Style.Foreground = Brushes.Black;
            }
            else
            {
                e.Style.Background = Brushes.DarkBlue;
                e.Style.Foreground = Brushes.White;
            }
        }
    }
}
