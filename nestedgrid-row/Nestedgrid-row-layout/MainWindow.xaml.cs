using Syncfusion.Windows.Controls.Cells;
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

namespace Nestedgrid_row_layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Add Nested Grid cell model.
            GridCellNestedGridModel shareRow = new GridCellNestedGridModel(GridNestedAxisLayout.Shared, GridNestedAxisLayout.Normal);
            gridControl.Model.CellModels.Add("ScrollGrid", shareRow);
            gridControl.Model.HeaderStyle.Borders.All = new Pen(Brushes.LightGray, 1);
     
            gridControl.Model.RowCount = 100;
            gridControl.Model.ColumnCount = 12;
            gridControl.Model[1, 2].CellType = "ScrollGrid";
            gridControl.Model[1, 2].Background = SystemColors.InactiveCaptionBrush;

            for (int i = 0; i < gridControl.Model.RowCount; i++)
            {
                for (int j = 0; j < gridControl.Model.ColumnCount; j++)
                {
                    gridControl.Model[i, j].CellValue = String.Format("{0}:{1}", i, j);
                }
            }
            
            GridModel nestedGridWithSharedRowsModel = GetNestedGridWithSharedRowsModel();
            gridControl.Model[1, 2].CellValue = nestedGridWithSharedRowsModel;
            gridControl.CoveredCells.Add(new CoveredCellInfo(1, 2, 1 + nestedGridWithSharedRowsModel.RowCount - 1, 9));
        }

        private GridModel GetNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();
            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();
            model.Options.AllowSelection = GridSelectionFlags.Cell;           
            model.ColumnWidths.DefaultLineSize = 50;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 13;
            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 13;

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

                    if (i == model.RowCount - 1)
                    {
                        style.CellType = "Static";
                        style.Background = footerBrush;
                    }
                }
            }
            
            model[2, 2].CellType = "ScrollGrid";
            model[2, 2].BorderMargins.Top = 0;
            model[2, 2].BorderMargins.Left = 0;
            model[2, 2].BorderMargins.Right = 0;
            model[2, 2].BorderMargins.Bottom = 0;
            model[2, 2].Background = SystemColors.InactiveCaptionBrush;
            model.SelectedCells = GridRangeInfo.Empty;

            // Creates a nested grid for second level.
            GridModel nestedGridWithSharedRowsModel = GetSecondNestedGridWithSharedRowsModel();
            model[2, 2].CellValue = nestedGridWithSharedRowsModel;
            model.CoveredCells.Add(new CoveredCellInfo(2, 2, 2 + nestedGridWithSharedRowsModel.RowCount - 1, 7));

            return model;
        }

        //Setup second level nested grid
        private GridModel GetSecondNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();
            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();
            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.DefaultLineSize = 40;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 10;
            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 10;

            Color clr = Color.FromArgb(128, 0, 0, 128);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();

            Color clr2 = Color.FromArgb(128, 0, 128, 0);
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
                    style.Background = null;// Brushes.White;
                    style.Borders.Bottom = gridLinePen;
                    model.Data[i, j] = style.Store;

                    if (i == 0 || j == 0)
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
            model[2, 2].CellType = "ScrollGrid";
            model[2, 2].BorderMargins.Top = 0;
            model[2, 2].BorderMargins.Left = 0;
            model[2, 2].BorderMargins.Right = 0;
            model[2, 2].BorderMargins.Bottom = 0;
            model[2, 2].Background = Brushes.Wheat;
            model.SelectedCells = GridRangeInfo.Empty;

            //Creates a nested grid for third level.
            GridModel nestedGridWithSharedRowsModel = GetThirdNestedGridWithSharedRowsModel();
            model[2, 2].CellValue = nestedGridWithSharedRowsModel;
            model.CoveredCells.Add(new CoveredCellInfo(2, 2, 2 + nestedGridWithSharedRowsModel.RowCount - 1, 5));

            return model;
        }

        private GridModel GetThirdNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();
            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.DefaultLineSize = 35;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 6;
            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 7;

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
                    style.Background = null;// Brushes.White;
                    style.Borders.Bottom = gridLinePen;
                    model.Data[i, j] = style.Store;

                    if (i == 0 || j == 0)
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
