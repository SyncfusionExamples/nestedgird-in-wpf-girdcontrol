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

namespace Nestedgrid_column_layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gridControl.Model.RowCount = 100;
            gridControl.Model.ColumnCount = 100;
            gridControl.Model.HeaderStyle.Borders.All = new Pen(Brushes.LightGray, 1);
            for (int i = 0; i < gridControl.Model.RowCount; i++)
            {
                for (int j = 0; j < gridControl.Model.ColumnCount; j++)
                {
                    gridControl.Model[i, j].CellValue = String.Format("{0}:{1}", i, j);
                }
            }
            GridCellNestedGridModel shareColumnLayoutGridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Normal, GridNestedAxisLayout.Shared);
            gridControl.Model.CellModels.Add("ScrollGrid", shareColumnLayoutGridModel);
            gridControl.Model[2, 2].CellType = "ScrollGrid";
            gridControl.Model[2, 2].BorderMargins.Top = 0;
            gridControl.Model[2, 2].BorderMargins.Left = 0;
            gridControl.Model[2, 2].BorderMargins.Right = 0;
            gridControl.Model[2, 2].BorderMargins.Bottom = 0;
            gridControl.Model[2, 2].Background = SystemColors.InactiveCaptionBrush;
            GridModel nestedGridWithSharedColumnsModel = GetNestedGridWithSharedColumnsModel();

            // Creates a nested grid with shared column layout.
            gridControl.Model[2, 2].CellValue = nestedGridWithSharedColumnsModel;
            gridControl.CoveredCells.Add(new CoveredCellInfo(2, 2, 20, 1 + nestedGridWithSharedColumnsModel.ColumnCount - 1));

        }
        private GridModel GetNestedGridWithSharedColumnsModel()
        {
            GridModel model = new GridModel();
            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();
            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 10;
            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 13;
            model.RowHeights.DefaultLineSize = 30;
            Color clr = Color.FromArgb(128, 0, 0, 0);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();
            Color clr2 = Color.FromArgb(128, 128, 0, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();

            for (int i = 0; i < model.RowCount; i++)
            {

                for (int j = 0; j < model.ColumnCount; j++)
                {
                    GridStyleInfo style = new GridStyleInfo();
                    style.CellType = "TextBox";
                    style.CellValue = String.Format("{0}:{1}", i, j);
                    style.BorderMargins.Top = gridLinePen.Thickness;
                    style.BorderMargins.Left = gridLinePen.Thickness;
                    style.BorderMargins.Right = gridLinePen.Thickness / 2;
                    style.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    style.Borders.Right = gridLinePen;
                    style.Background = null;
                    style.Borders.Bottom = gridLinePen;
                    model.Data[i, j] = style.Store;

                    if (j == 0 || i == 0)
                    {
                        style.CellType = "Static";
                        style.Background = headerBrush;
                    }

                    if (j == 3 || i == 3)
                    {
                        style.CellType = "CheckBox";
                        style.CellValue = false;
                    }

                    if (j == 4 || i == 4)
                    {
                        style.CellType = "Static";
                        style.CellValue = "Static";
                    }

                    if (i == model.RowCount - 1)
                    {
                        style.CellType = "Static";
                        style.Background = footerBrush;
                    }
                }
            }

            model[4, 2].CellType = "ScrollGrid";
            model[4, 2].BorderMargins.Top = 0;
            model[4, 2].BorderMargins.Left = 0;
            model[4, 2].BorderMargins.Right = 0;
            model[4, 2].BorderMargins.Bottom = 0;
            model[4, 2].Background = SystemColors.InactiveCaptionBrush;
            model.SelectedCells = GridRangeInfo.Empty;

            GridModel nestedGridWithSharedColumnsModel = GetSecondNestedGridWithSharedColumnssModel();
            model[4, 2].CellValue = nestedGridWithSharedColumnsModel;
            model.CoveredCells.Add(new CoveredCellInfo(4, 2, 10, 1 + nestedGridWithSharedColumnsModel.ColumnCount - 1));

            return model;
        }

        private GridModel GetSecondNestedGridWithSharedColumnssModel()
        {
            GridModel model = new GridModel();
            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();
            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 10;
            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 13;
            model.RowHeights.DefaultLineSize = 30;
            Color clr = Color.FromArgb(128, 0, 128, 128);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();
            Color clr2 = Color.FromArgb(128, 128, 128, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();
            for (int i = 0; i < model.RowCount; i++)
            {

                for (int j = 0; j < model.ColumnCount; j++)
                {
                    GridStyleInfo style = new GridStyleInfo();
                    style.CellType = "TextBox";
                    style.CellValue = String.Format("{0}:{1}", i, j);
                    style.BorderMargins.Top = gridLinePen.Thickness;
                    style.BorderMargins.Left = gridLinePen.Thickness;
                    style.BorderMargins.Right = gridLinePen.Thickness / 2;
                    style.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    style.Borders.Right = gridLinePen;
                    style.Background = null;
                    style.Borders.Bottom = gridLinePen;
                    model.Data[i, j] = style.Store;
                    if (j == 0 || i == 0)
                    {
                        style.CellType = "Static";
                        style.Background = headerBrush;
                    }
                    if (i == model.RowCount - 1)
                    {
                        style.CellType = "Static";
                        style.Background = footerBrush;
                    }
                }
            }
            model.SelectedCells = GridRangeInfo.Empty;
            return model;
        }
    }
}
