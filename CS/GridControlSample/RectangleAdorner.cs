using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace GridControlSample {
    public class RectangleAdorner : Adorner {
        public RectangleAdorner(UIElement adornedElement)
            : base(adornedElement) {
            IsHitTestVisible = false;
        }
        Rect renderRect = new Rect();
        public Rect RenderRect {
            get { return renderRect; }
            set {
                if(renderRect == value) return;
                renderRect = value;
            }
        }
        protected override void OnRender(DrawingContext drawingContext) {
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            renderBrush.Opacity = 0.2;
            drawingContext.DrawRectangle(renderBrush, renderPen, renderRect);
        }
    }
}
