using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditorApplication {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // режим работы графического редактора
        private string? mode = null;
        // точки отрезка
        private Point startPoint, endPoint;
        // динамический массив отрезков
        private List<Line> lines = new();
        // переменная для хранения выбранного отрезк
        private Line? selectedLine = null; 

        private void btnCreate_Click(object sender, RoutedEventArgs e) => mode = "create";

        private void btnDelete_Click(object sender, RoutedEventArgs e) => mode = "delete";

        private void btnEdit_Click(object sender, RoutedEventArgs e) => mode = "edit";

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            switch (mode) {
                case "create":
                    startPoint = e.GetPosition(canvas);

                    break;
                case "edit":


                    break;
            }
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            switch (mode) {
                case "create":
                    endPoint = e.GetPosition(canvas);

                    Line newLine = CreateLine(startPoint, endPoint, Brushes.Black, 2);
                    canvas.Children.Add(newLine);
                    lines.Add(newLine);

                    startPoint.X = 0; startPoint.Y = 0;
                    endPoint.X = 0; endPoint.Y = 0;

                    break;
                case "edit":


                    break;
            }
        }

        /// <summary>
        /// Создание отрезка
        /// </summary>
        /// <param name="startPoint">Начальная точка отрезка</param>
        /// <param name="endPoint">Конечная точка отрезка</param>
        /// <param name="brushColor">Цвет кисти</param>
        /// <param name="strokeThickness">Толщина кисти</param>
        /// <returns>Line newLine</returns>
        private static Line CreateLine(Point startPoint, Point endPoint, Brush brushColor, int strokeThickness) {
            Line newLine = new() {
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = endPoint.X,
                Y2 = endPoint.Y,
                
                Stroke = brushColor,
                StrokeThickness = strokeThickness
            };

            return newLine;
        }
    }
}

