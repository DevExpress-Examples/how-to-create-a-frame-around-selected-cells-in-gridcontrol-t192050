using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Linq;

namespace GridControlSample
{
    public partial class MainWindow : Window
    {
        SampleSource source = new SampleSource();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this.source;

        }

        AdornerLayer gridAdornerLayer = null;
        RectangleAdorner rectangleAdorner = null;

        void OnTableViewLoaded(object sender, RoutedEventArgs e)
        {
            gridAdornerLayer = AdornerLayer.GetAdornerLayer(grid);
        }

        void OnTableViewSelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            var view = sender as TableView;
            var grid = view.Grid;
            var selectedCells = view.GetSelectedCells();
            var TL_RowIndex = int.MaxValue;
            var TL_ColumnIndex = int.MaxValue;
            var RB_RowIndex = 0;
            var RB_ColumnIndex = 0;
            foreach (var cellInfo in selectedCells)
            {
                var currentRowIndex = grid.GetRowVisibleIndexByHandle(cellInfo.RowHandle);
                var currentColumnIndex = cellInfo.Column.VisibleIndex;
                if (TL_RowIndex > currentRowIndex) TL_RowIndex = currentRowIndex;
                if (TL_ColumnIndex > currentColumnIndex) TL_ColumnIndex = currentColumnIndex;
                if (RB_RowIndex < currentRowIndex) RB_RowIndex = currentRowIndex;
                if (RB_ColumnIndex < currentColumnIndex) RB_ColumnIndex = currentColumnIndex;
            }
            var TL_CellPresenter = view.GetCellElementByRowHandleAndColumn(
                grid.GetRowHandleByVisibleIndex(TL_RowIndex),
                view.VisibleColumns.First((column) => column.VisibleIndex == TL_ColumnIndex));
            var RB_CellPresenter = view.GetCellElementByRowHandleAndColumn(
                grid.GetRowHandleByVisibleIndex(RB_RowIndex),
                view.VisibleColumns.First((column) => column.VisibleIndex == RB_ColumnIndex));
            Point TL_Point = TL_CellPresenter.TranslatePoint(new Point(0d, 0d), grid);
            Point RB_Point = RB_CellPresenter.TranslatePoint(new Point(0d, 0d), grid);
            RB_Point.Offset(RB_CellPresenter.ActualWidth, RB_CellPresenter.ActualHeight);

            if (rectangleAdorner != null)
            {
                gridAdornerLayer.Remove(rectangleAdorner);
            }
            rectangleAdorner = new RectangleAdorner(grid);
            rectangleAdorner.RenderRect = new Rect(TL_Point, RB_Point);
            gridAdornerLayer.Add(rectangleAdorner);
        }


    }
}
