using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace TheseusAndTheMinotaur
{
    /// <summary>
    /// Interaction logic for LevelDesigner.xaml
    /// </summary>
    public partial class LevelDesignerPage : Page
    {
        public int rows { get; set; }
        public int cols { get; set; }
        public ControllerMap myMapController { get; set; }
        //public MapConstructor myMapConstructor { get; set; }
        public MouseEventHandler myDetectMouse { get; set; }
        string dragSourceName;

        public LevelDesignerPage()
        {
            myMapController = new ControllerMap(this);
            myDetectMouse = new MouseEventHandler(myMapController);
            InitializeComponent();

            myMapController.setMinotaurImage();
            myMapController.setTheseusImage();
            myMapController.setExitImage();
            pbxMap.Focus();
        }

        private void btnDrawMap_Click(object sender, RoutedEventArgs e)
        {
            myMapController.setMapComponents();
            this.myMapController.drawMap();
            invalidatePbxMap();
        }

        private void pbxMap_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.myMapController.getCells().Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, this.myMapController.getCells());
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];
                int forgiveness = 10;
                
                if (e.GetPosition(pbxMap).X > endOfCol - forgiveness &&
                    e.GetPosition(pbxMap).X < endOfCol + forgiveness &&
                    e.GetPosition(pbxMap).Y > startOfRow && e.GetPosition(pbxMap).Y < endOfRow)
                {
                    this.myMapController.highlightWall(i, 1, true); // 1 for right wall
                }
                else
                {
                    this.myMapController.highlightWall(i, 1, false);
                }

                if (e.GetPosition(pbxMap).Y > endOfRow - forgiveness &&
                    e.GetPosition(pbxMap).Y < endOfRow + forgiveness &&
                    e.GetPosition(pbxMap).X > startOfCol && e.GetPosition(pbxMap).X < endOfCol)
                {
                    this.myMapController.highlightWall(i, 2, true); // 2 for bottom wall
                }
                else
                {
                    this.myMapController.highlightWall(i, 2, false);
                }
            }
            invalidatePbxMap();
        }

        private void pbxMap_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouse = Mouse.GetPosition(pbxMap);
            int leftEdgeOfMap = myMapController.myMap.boardXPos;
            int rightEdgeOfMap = leftEdgeOfMap + myMapController.myMap.myWidth;
            int topEdgeOfMap = myMapController.myMap.boardYPos;
            int bottomEdgeOfMap = topEdgeOfMap + myMapController.myMap.myHeight;
            if (mouse.X > leftEdgeOfMap &&
                mouse.X < rightEdgeOfMap &&
                mouse.Y > topEdgeOfMap &&
                mouse.Y < bottomEdgeOfMap)
            {
                
                if(e.LeftButton == MouseButtonState.Pressed)
                {
                    
                    myDetectMouse.onMouseClick(e, this.myMapController.getCells());
                }
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    myDetectMouse.editCell(e, this.myMapController.getCells());
                }
                invalidatePbxMap();
            }
        }

        private void pbxMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            if (dragSourceName == "pbxMinotaur")
            {
                myDetectMouse.setMinotaur(e, this.myMapController.getCells());
            }
            else if (dragSourceName == "pbxTheseus")
            {
                myDetectMouse.setTheseus(e, this.myMapController.getCells());
            }
            else if (dragSourceName == "pbxExit")
            {
                myDetectMouse.setExit(e, this.myMapController.getCells());
            }

            invalidatePbxMap();
        }

       

        public void drawBgImage(Image cellBG)
        {
            cellBG.IsHitTestVisible = false;
            this.pbxMap.Children.Add(cellBG);
        }

        public void drawHighlightedCell(bool add)
        {
            if (this.myMapController.myMap.cols != 0)
            {
                Rectangle myRect = this.myMapController.createHighlight();
                if (add)
                {
                    this.pbxMap.Children.Add(myRect);
                }
                else
                {
                    this.pbxMap.Children.Remove(myRect);
                }
            }
        }

        public void deleteHighlight(Rectangle myRect)
        {
            this.pbxMap.Children.Remove(myRect);
            invalidatePbxMap();
        }

        public void drawWall(int endOfCol, int startOfRow, int end, int endOfRow, CellSide cellSide = null, bool border = false)
        {
            Line line = new Line();
            line.X1 = endOfCol;
            line.Y1 = startOfRow;
            line.X2 = end;
            line.Y2 = endOfRow;
            if (border)
            {
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 3;
            }
            else if (cellSide != null) line = setLineProperties(cellSide, line);
            line.IsHitTestVisible = false;
            pbxMap.Children.Add(line);
        }

        private Line setLineProperties(CellSide side, Line line)  
        {
            line.StrokeThickness = 3;
            line.Stroke = Brushes.Black;
            if (side.isHighlighted == true)
            {
                line.Stroke = Brushes.Red;
                return line;
            }

            if (side.hasWall == 0)
            {
                line.Stroke = Brushes.LightBlue;
                line.StrokeThickness = 1;
            }
            return line;
        }

        public void drawImage(Image image, System.Drawing.RectangleF location)
        {
            image.IsHitTestVisible = true;
            this.pbxMap.Children.Add(image);
        }

        public void invalidatePbxMap()
        {
            pbxMap.Children.Clear();
            this.myMapController.drawMap();
        }

        public Point getMousePosition()
        {
            return Mouse.GetPosition(pbxMap);
        }

        private void pbxTheseus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (sender as Image);
            if (image != null)
            {
                dragSourceName = image.Name;
                pbxMap.AllowDrop = true;
                DragDrop.DoDragDrop(pbxTheseus, pbxTheseus, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void pbxMinotaur_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (sender as Image);
            if (image != null)
            {
                dragSourceName = image.Name;
                pbxMap.AllowDrop = true;
                DragDrop.DoDragDrop(pbxMinotaur, pbxMinotaur, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void pbxExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (sender as Image);
            if (image != null)
            {
                dragSourceName = image.Name;
                pbxMap.AllowDrop = true;
                DragDrop.DoDragDrop(pbxExit, pbxExit, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void rbWood_Checked(object sender, RoutedEventArgs e)
        {
            myMapController.setCellBgImage();
            invalidatePbxMap();
        }

        private void rbBrick_Checked(object sender, RoutedEventArgs e)
        {
            myMapController.setCellBgImage();
            invalidatePbxMap();
        }

        private void rbClay_Checked(object sender, RoutedEventArgs e)
        {
            myMapController.setCellBgImage();
            invalidatePbxMap();
        }

        private void rbDiamond_Checked(object sender, RoutedEventArgs e)
        {
            myMapController.setCellBgImage();
            invalidatePbxMap();
        }

        private void pbxMap_MouseLeave(object sender, MouseEventArgs e)
        {
            this.drawHighlightedCell(false);
            this.myMapController.clearRedLine();
            invalidatePbxMap();
        }
    }
}
