using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditorApplication {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private string? mode = null;

        private void btnCreate_Click(object sender, RoutedEventArgs e) => mode = "create";

        private void btnDelete_Click(object sender, RoutedEventArgs e) => mode = "delete";

        private void btnEdit_Click(object sender, RoutedEventArgs e) => mode = "edit";

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            switch (mode) {
                case "create":
                    Point startPoint = e.GetPosition(canvas);
                    Line newLine = new Line {
                        X1 = startPoint.X,
                        Y1 = startPoint.Y,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
                    canvas.Children.Add(newLine);

                    break;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) {
            switch (mode) {
                case "create":
                    if (canvas.Children.Count > 0) {
                        Line line = (Line)canvas.Children[canvas.Children.Count - 1];
                        line.X2 = e.GetPosition(canvas).X;
                        line.Y2 = e.GetPosition(canvas).Y;
                    }

                    break;
            }
        }
    }
}
