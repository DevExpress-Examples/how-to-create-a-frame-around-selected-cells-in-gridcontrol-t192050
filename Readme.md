<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/GridControlSample/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/GridControlSample/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/GridControlSample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/GridControlSample/MainWindow.xaml.vb))
* [RectangleAdorner.cs](./CS/GridControlSample/RectangleAdorner.cs) (VB: [RectangleAdorner.vb](./VB/GridControlSample/RectangleAdorner.vb))
* [SampleSource.cs](./CS/GridControlSample/SampleSource.cs) (VB: [SampleSource.vb](./VB/GridControlSample/SampleSource.vb))
<!-- default file list end -->
# How to create a frame around selected cells in GridControl 


<p>This example demonstrates how to allocate selected cells using adorners. To determine the adorner location, it is necessary to calculate upper left and lower right points of a rectangle that allocates the area of selected cells. The upper left point is calculated based on minimum column and row indexes within indexes of selected cells. The lower right point is calculated based on maximum indexes.</p>

<br/>


