Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports System.Linq

Namespace GridControlSample
    Partial Public Class MainWindow
        Inherits Window

        Private source As New SampleSource()
        Public Sub New()
            InitializeComponent()
            DataContext = Me.source

        End Sub

        Private gridAdornerLayer As AdornerLayer = Nothing
        Private rectangleAdorner As RectangleAdorner = Nothing

        Private Sub OnTableViewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            gridAdornerLayer = AdornerLayer.GetAdornerLayer(grid)
        End Sub

        Private Sub OnTableViewSelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GridSelectionChangedEventArgs)
            Dim view = TryCast(sender, TableView)
            Dim grid = view.Grid
            Dim selectedCells = view.GetSelectedCells()
            Dim TL_RowIndex = Integer.MaxValue
            Dim TL_ColumnIndex = Integer.MaxValue
            Dim RB_RowIndex = 0
            Dim RB_ColumnIndex = 0
            For Each cellInfo In selectedCells
                Dim currentRowIndex = grid.GetRowVisibleIndexByHandle(cellInfo.RowHandle)
                Dim currentColumnIndex = cellInfo.Column.VisibleIndex
                If TL_RowIndex > currentRowIndex Then
                    TL_RowIndex = currentRowIndex
                End If
                If TL_ColumnIndex > currentColumnIndex Then
                    TL_ColumnIndex = currentColumnIndex
                End If
                If RB_RowIndex < currentRowIndex Then
                    RB_RowIndex = currentRowIndex
                End If
                If RB_ColumnIndex < currentColumnIndex Then
                    RB_ColumnIndex = currentColumnIndex
                End If
            Next cellInfo
            Dim TL_CellPresenter = view.GetCellElementByRowHandleAndColumn(grid.GetRowHandleByVisibleIndex(TL_RowIndex), view.VisibleColumns.First(Function(column) column.VisibleIndex = TL_ColumnIndex))
            Dim RB_CellPresenter = view.GetCellElementByRowHandleAndColumn(grid.GetRowHandleByVisibleIndex(RB_RowIndex), view.VisibleColumns.First(Function(column) column.VisibleIndex = RB_ColumnIndex))
            Dim TL_Point As Point = TL_CellPresenter.TranslatePoint(New Point(0R, 0R), grid)
            Dim RB_Point As Point = RB_CellPresenter.TranslatePoint(New Point(0R, 0R), grid)
            RB_Point.Offset(RB_CellPresenter.ActualWidth, RB_CellPresenter.ActualHeight)

            If rectangleAdorner IsNot Nothing Then
                gridAdornerLayer.Remove(rectangleAdorner)
            End If
            rectangleAdorner = New RectangleAdorner(grid)
            rectangleAdorner.RenderRect = New Rect(TL_Point, RB_Point)
            gridAdornerLayer.Add(rectangleAdorner)
        End Sub


    End Class
End Namespace
