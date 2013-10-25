using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

namespace TheseusAndTheMinotaur
{
    public class ControllerMap
    {
        public ModelMap myMap { get; set; }

        public LevelDesignerPage view;
        private MapConstructor constructor;

        public ControllerMap(LevelDesignerPage newView)
        {
            this.view = newView;

            this.myMap = new ModelMap();
            this.constructor = new MapConstructor(this);
        }

        private void setCells()
        {
            myMap.myCells.Clear();
            for (int row = 0; row < myMap.rows; row++)
            {
                for (int col = 0; col < myMap.cols; col++)
                {
                    myMap.myCells.Add(new Cell(col, row, new CellSide(0, false), new CellSide(0, false), myMap));
                }
            }
        }

        private int getLargestOutOfRowsAndCols()
        {
            if (myMap.cols > myMap.rows)
            {
                return myMap.cols;
            }
            else
            {
                return myMap.rows;
            }
        }

        private void setCellSize()
        {
            try
            {
                //We have to subtract 1 from the cellSize to allow for the thick outer pen lines
                //The plus 1 leaves room for one more cell for the exit
                double cellSize = (this.view.pbxMap.ActualWidth / getLargestOutOfRowsAndCols()) - 2;
                Math.Round(cellSize, 0);
                myMap.myCellSize = Convert.ToInt32(cellSize);

                foreach (Cell cell in myMap.myCells)
                {
                    cell.mySize = myMap.myCellSize;
                }
            }
            catch
            {
               // this.view.lblWarning.Text = "Please enter atleast 3 columns and 3 rows.";
                
            }
        }

        private void setCanvasSize()
        {
            this.view.pbxMap.Width = this.view.pbxMap.ActualHeight;
        }

        private void setBoardPosition()
        {
            //If these aren't atleast 1, the map edge starts from 
            //off the picturebox because the pen line is thick.
            //They cannot be more than 1 or the map will move off the picturebox.
            //The thick pen line on the outer edge causes this complexity.
            //These -1's come about from the thick outer wall line taking one more pixel on the outside
            //this.setCanvasSize();
            double yPos = (this.view.pbxMap.ActualHeight / 2) - (myMap.myHeight / 2);
            double Xpos = (this.view.pbxMap.ActualWidth / 2) - (myMap.myWidth / 2);
            Math.Round(yPos, 0);
            Math.Round(Xpos, 0);
            myMap.boardXPos = Convert.ToInt32(Xpos);
            myMap.boardYPos = Convert.ToInt32(yPos);
        }

        public void clearRedLine()
        {
            foreach (Cell cell in myMap.myCells)
            {
                cell.myBottomWall.isHighlighted = false;
                cell.myRightWall.isHighlighted = false;
            }
        }

        private void setPbxMapPosition()
        {
            double yPos = (this.view.pbxMap.Height / 2) - (this.view.pbxMap.Height / 2) - 1;
            double Xpos = (this.view.pbxMap.Width / 2) - (this.view.pbxMap.Width / 2) - 1;
            Math.Round(yPos, 0);
            Math.Round(Xpos, 0);
            //this.view.pbxMap. = new Point(Convert.ToInt32(Xpos), Convert.ToInt32(yPos));
        }
        private void setMapDimensions()
        {
            myMap.rows = Convert.ToInt32(this.view.tbxRows.Text);
            myMap.cols = Convert.ToInt32(this.view.tbxColumns.Text);

            this.view.cols = myMap.cols;
            this.view.rows = myMap.rows;
        }

        private void setMapLengthAndHeight()
        {
            myMap.myWidth = myMap.myCellSize * myMap.cols;
            myMap.myHeight = myMap.myCellSize * myMap.rows;
        }

        public void setMapComponents()
        {
            setMapDimensions();
            setCellSize();
            setCells();
            setMapLengthAndHeight();
            setBoardPosition();
            setPbxMapPosition();
            setCellBgImage();
        }

        public void setCellBgImage()
        {
            if (this.view.rbWood.IsChecked == true)
            {
                // Create the image element.
                myMap.cellBgImage = new Image();

                // Create source.
                BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri("wood.png", UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                myMap.cellBgImage.Source = bi;
            }
            else if (this.view.rbBrick.IsChecked == true)
            {
                // Create the image element.
                myMap.cellBgImage = new Image();

                // Create source.
                BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri("brick.png", UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                myMap.cellBgImage.Source = bi;
            }
            else if (this.view.rbDiamond.IsChecked == true)
            {
                // Create the image element.
                myMap.cellBgImage = new Image();

                // Create source.
                BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri("diamond.png", UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                myMap.cellBgImage.Source = bi;
            }
            else if (this.view.rbClay.IsChecked == true)
            {
                // Create the image element.
                myMap.cellBgImage = new Image();

                // Create source.
                BitmapImage bi = new BitmapImage();
                // BitmapImage.UriSource must be in a BeginInit/EndInit block.
                bi.BeginInit();
                bi.UriSource = new Uri("clay.png", UriKind.RelativeOrAbsolute);
                bi.EndInit();
                // Set the image source.
                myMap.cellBgImage.Source = bi;
            }
            foreach (Cell cell in myMap.myCells)
            {
                cell.myBgImage = myMap.cellBgImage;
            }

        }

        public void setMinotaurImage()
        {
             
            // Create the image element.
            myMap.minotaur = new Image();

            // Create source.
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri("minotaur.png",UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            myMap.minotaur.Source = bi;
        }

        public void setTheseusImage()
        {
            // Create the image element.
            myMap.theseus = new Image();

            // Create source.
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri("theseus.png", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            myMap.theseus.Source = bi;
        }

        public void setExitImage()
        {
            // Create the image element.
            myMap.exitImage = new Image();

            // Create source.
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri("exit.png", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            myMap.exitImage.Source = bi;
        }

        public int[] getMapData(int i, List<Cell> cell = null) // Reece changed default to null so can have cell refactored out, because not needed to be passed as parameter at all
        {
            int startOfCol = myMap.boardXPos + myMap.myCells[i].myColumn * myMap.myCellSize;
            int endOfCol = startOfCol + myMap.myCellSize;
            int startOfRow = myMap.boardYPos + myMap.myCells[i].myRow * myMap.myCellSize;
            int endOfRow = startOfRow + myMap.myCellSize;
            int right = myMap.myCells[i].myRightWall.hasWall;
            int bottom = myMap.myCells[i].myBottomWall.hasWall;

            return new int[] { startOfCol, endOfCol, startOfRow, endOfRow, right, bottom };
        }

        public List<Cell> getCells()
        {
            return this.myMap.myCells; 
        }

        public void drawMap()
        {
            this.calculateBgImage();
            if (myMap.cols != 0)
            {
                this.calculateHighlightedCell();
            }
            this.calculateWalls();
            this.calculateBorder();
            this.calculateImages();
            
            //this.constructor.drawMap(e, this.myMap.myCells);
        }

        private void calculateBgImage()
        {
            for (int i = 0; i < this.myMap.myCells.Count; i++)
            {
                int[] mapData = this.getMapData(i, this.myMap.myCells);
                int startOfCol = mapData[0];
                int startOfRow = mapData[2];

                Image cellBG = new Image();
                cellBG.Source = myMap.cellBgImage.Source;
                cellBG.Width = myMap.myCellSize;
                cellBG.Height = myMap.myCellSize;
                cellBG.SetValue(Canvas.TopProperty, Convert.ToDouble(startOfRow));
                cellBG.SetValue(Canvas.LeftProperty, Convert.ToDouble(startOfCol));
                this.view.drawBgImage(cellBG);
            }
        }

        private void calculateHighlightedCell()
        {
            if (this.myMap.cols != 0)
            {
                Point mouse = Mouse.GetPosition(view.pbxMap);// myMapController.view.pbxMap.PointToClient(Cursor.Position);

                int col = (Convert.ToInt32(mouse.X) - this.myMap.boardXPos) / this.myMap.myCellSize;
                int row = (Convert.ToInt32(mouse.Y) - this.myMap.boardYPos) / this.myMap.myCellSize;
                int startOfCol = this.myMap.boardXPos + col * this.myMap.myCellSize;
                int endOfCol = startOfCol + this.myMap.myCellSize;
                int startOfRow = this.myMap.boardYPos + row * this.myMap.myCellSize;
                int endOfRow = startOfRow + this.myMap.myCellSize;
                int leftEdgeOfMap = this.myMap.boardXPos;
                int rightEdgeOfMap = leftEdgeOfMap + this.myMap.myWidth;
                int topEdgeOfMap = this.myMap.boardYPos;
                int bottomEdgeOfMap = topEdgeOfMap + this.myMap.myHeight;
                Rectangle myRect = this.createHighlight();

                if (mouse.X > leftEdgeOfMap &&
                    mouse.X < rightEdgeOfMap &&
                    mouse.Y > topEdgeOfMap &&
                    mouse.Y < bottomEdgeOfMap)
                {
                    if (mouse.X > startOfCol &&
                        mouse.X < endOfCol &&
                        mouse.Y > startOfRow &&
                        mouse.Y < endOfRow)
                    {

                        this.view.drawHighlightedCell(true);
                    }
                }
            }
                //this.view.deleteHighlight(myRect);
                //return;
            
        }

        public Rectangle createHighlight()
        {
            Point mouse = Mouse.GetPosition(view.pbxMap);
            int col = (Convert.ToInt32(mouse.X) - this.myMap.boardXPos) / this.myMap.myCellSize;
            int row = (Convert.ToInt32(mouse.Y) - this.myMap.boardYPos) / this.myMap.myCellSize;
            int startOfRow = this.myMap.boardYPos + row * this.myMap.myCellSize;
            int startOfCol = this.myMap.boardXPos + col * this.myMap.myCellSize;

            System.Windows.Shapes.Rectangle myRect = new System.Windows.Shapes.Rectangle();
            myRect.Fill = System.Windows.Media.Brushes.MediumSeaGreen;
            myRect.Opacity = .4;
            myRect.SetValue(Canvas.TopProperty, Convert.ToDouble(startOfRow));
            myRect.SetValue(Canvas.LeftProperty, Convert.ToDouble(startOfCol));
            myRect.Height = myMap.myCellSize;
            myRect.Width = myMap.myCellSize;
            myRect.IsHitTestVisible = false;
            return myRect;
        }

        private void calculateWalls()
        {
            for (int i = 0; i < this.getCells().Count; i++)
            {
                calculateWall(0, i);
            }
            for (int i = 0; i < this.getCells().Count; i++)
            {
                calculateWall(1, i);
            }
        }

        private void calculateWall(int wall, int cell)
        {
            int[] mapData = this.getMapData(cell);
            int startOfCol = mapData[0];
            int endOfCol = mapData[1];
            int startOfRow = mapData[2];
            int endOfRow = mapData[3];
            CellSide rightSide = this.getCells()[cell].myRightWall;
            CellSide bottomSide = this.getCells()[cell].myBottomWall;

            if (rightSide.hasWall == wall)
            {
                this.view.drawWall(endOfCol, startOfRow - 1, endOfCol, endOfRow + 1, rightSide);
            }
            if (bottomSide.hasWall == wall)
            {
                this.view.drawWall(endOfCol + 1, endOfRow, startOfCol - 1, endOfRow, bottomSide);
            }
        }

        private void calculateBorder()
        {
            foreach (Cell cell in this.getCells())
            {
                int col = cell.myColumn;
                int row = cell.myRow;

                int startOfCol = this.myMap.boardXPos + col * this.myMap.myCellSize;
                int endOfCol = startOfCol + this.myMap.myCellSize;
                int startOfRow = this.myMap.boardYPos + row * this.myMap.myCellSize;
                int endOfRow = startOfRow + this.myMap.myCellSize;

                int cellToRight = this.getCells().FindIndex(item => item.myColumn == col + 1 && item.myRow == row);
                if (cellToRight < 0)
                {
                    this.view.drawWall(endOfCol, startOfRow - 1, endOfCol, endOfRow + 1, null, true);
                    /*g.DrawLine(myPen, endOfCol,
                    startOfRow - 1, endOfCol, endOfRow + 1);*/
                }

                int cellToLeft = this.getCells().FindIndex(item => item.myColumn == col - 1 && item.myRow == row);
                if (cellToLeft < 0)
                {
                    this.view.drawWall(startOfCol, startOfRow - 1, startOfCol, endOfRow + 1, null, true);
                    /*g.DrawLine(myPen, startOfCol,
                    startOfRow - 1, startOfCol, endOfRow + 1);*/
                }

                int cellAbove = this.getCells().FindIndex(item => item.myColumn == col && item.myRow == row - 1);
                if (cellAbove < 0)
                {
                    this.view.drawWall(startOfCol - 1, startOfRow, endOfCol + 1, startOfRow, null, true);
                    /*g.DrawLine(myPen, startOfCol - 1,
                    startOfRow, endOfCol + 1, startOfRow);*/
                }

                int cellBelow = this.getCells().FindIndex(item => item.myColumn == col && item.myRow == row + 1);
                if (cellBelow < 0)
                {
                    this.view.drawWall(startOfCol - 1, endOfRow, endOfCol + 1, endOfRow, null, true);
                    /*g.DrawLine(myPen, startOfCol - 1,
                    endOfRow, endOfCol + 1, endOfRow);*/
                }

            }
        }

        private void calculateImages()
        {
            Image[] images = new Image[] { this.myMap.theseus, this.myMap.minotaur, this.myMap.exitImage };

            for (int i = 0; i < this.getCells().Count; i++)
            {
                for (int j = 0; j < images.Length; j++)
                {
                    if (this.getImageStatus(this.getCells()[i], j))
                    {
                        int[] mapData = this.getMapData(i);
                        int startOfCol = mapData[0];
                        int startOfRow = mapData[2];

                        Image cellChild = new Image();
                        cellChild.Source = images[j].Source;
                        cellChild.Width = myMap.myCellSize;
                        cellChild.Height = myMap.myCellSize;
                        cellChild.SetValue(Canvas.TopProperty, Convert.ToDouble(startOfRow));
                        cellChild.SetValue(Canvas.LeftProperty, Convert.ToDouble(startOfCol));
                        this.view.drawBgImage(cellChild);
                    }
                }
            }
        }

        private bool getImageStatus(Cell cell, int image)
        {
            switch (image)
            {
                case 0:
                    return cell.hasTheseus;

                case 1:
                    return cell.hasMinotaur;

                case 2:
                    return cell.isExit;

                default:
                    return false;
            }
        }

        public void highlightWall(int cellNumber, int wall, bool highlight)
        {
            switch (wall)
            {
                case 1:
                    this.getCells()[cellNumber].myRightWall.isHighlighted = highlight;
                    break;

                case 2:
                    this.getCells()[cellNumber].myBottomWall.isHighlighted = highlight;
                    break;
            }
        }
    }
}