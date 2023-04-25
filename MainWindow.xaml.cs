using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditorApplication {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private string? mode = null;
        private Point startPoint, endPoint; 


        private void btnCreate_Click(object sender, RoutedEventArgs e) => mode = "create";

        private void btnDelete_Click(object sender, RoutedEventArgs e) => mode = "delete";

        private void btnEdit_Click(object sender, RoutedEventArgs e) => mode = "edit";

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            switch (mode) {
                case "create":
                    startPoint = e.GetPosition(canvas);

                    break;
            }
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            switch (mode) {
                case "create":
                    endPoint = e.GetPosition(canvas);

                    Line newLine = new() {
                        X1 = startPoint.X, Y1 = startPoint.Y,
                        X2 = endPoint.X, Y2 = endPoint.Y,

                        Stroke = Brushes.Black, StrokeThickness = 2
                    };

                    canvas.Children.Add(newLine);

                    startPoint.X = 0; startPoint.Y = 0;
                    endPoint.X = 0; endPoint.Y = 0;

                    break;
            }
        }
    }
}
