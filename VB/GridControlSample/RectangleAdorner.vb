Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Media

Namespace GridControlSample
    Public Class RectangleAdorner
        Inherits Adorner

        Public Sub New(ByVal adornedElement As UIElement)
            MyBase.New(adornedElement)
            IsHitTestVisible = False
        End Sub

        Private renderRect_Renamed As New Rect()
        Public Property RenderRect() As Rect
            Get
                Return renderRect_Renamed
            End Get
            Set(ByVal value As Rect)
                If renderRect_Renamed = value Then
                    Return
                End If
                renderRect_Renamed = value
            End Set
        End Property
        Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
            Dim renderBrush As New SolidColorBrush(Colors.Green)
            Dim renderPen As New Pen(New SolidColorBrush(Colors.Navy), 1.5)
            renderBrush.Opacity = 0.2
            drawingContext.DrawRectangle(renderBrush, renderPen, renderRect_Renamed)
        End Sub
    End Class
End Namespace
