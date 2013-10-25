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
    public class MouseEventHandler
    {

        public ControllerMap myMapController { get; set; }
        public MouseEventHandler(ControllerMap mapController)
        {
            this.myMapController = mapController;
        }

        public void setMinotaur(DragEventArgs e, List<Cell> cells)
        {
            Point MouseOnCanvas = MouseUtilities.CorrectGetPosition(this.myMapController.view.pbxMap);
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                if (MouseOnCanvas.X > startOfCol &&
                    MouseOnCanvas.X < endOfCol
                    && MouseOnCanvas.Y > startOfRow && MouseOnCanvas.Y <
                    endOfRow)
                {
                    myMapController.myMap.myCells[i].hasMinotaur = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].hasMinotaur = false;
                }
            }
        }

        public void setTheseus(DragEventArgs e, List<Cell> cells)
        {
            Point MouseOnCanvas = MouseUtilities.CorrectGetPosition(this.myMapController.view.pbxMap);
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                if (MouseOnCanvas.X > startOfCol &&
                    MouseOnCanvas.X < endOfCol
                    && MouseOnCanvas.Y > startOfRow && MouseOnCanvas.Y <
                    endOfRow)
                {
                    myMapController.myMap.myCells[i].hasTheseus = true;
                }

                else
                {
                    myMapController.myMap.myCells[i].hasTheseus = false;
                }
            }
        }

        public void setExit(DragEventArgs e, List<Cell> cells)
        {
            Point MouseOnCanvas = MouseUtilities.CorrectGetPosition(this.myMapController.view.pbxMap);
            int col = (Convert.ToInt32(MouseOnCanvas.X) - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (Convert.ToInt32(MouseOnCanvas.Y) - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                Cell cell = myMapController.myMap.myCells[i];
                int index = cells.FindIndex(item => item.myColumn == col && item.myRow == row);
                if (index >= 0)
                {
                    if (cell.myColumn == col && cell.myRow == row)
                    {
                        cell.isExit = true;
                    }
                    else
                    {
                        cell.isExit = false;
                    }
                }

            }
        }

        public void editCell(MouseEventArgs e, List<Cell> cells)
        {
            Point mouse = Mouse.GetPosition(myMapController.view.pbxMap);

            int col = (Convert.ToInt32(mouse.X) - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (Convert.ToInt32(mouse.Y) - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;

            for (int i = 0; i < cells.Count; i++)
            {
                Cell cell = myMapController.myMap.myCells[i];
                int index = cells.FindIndex(item => item.myColumn == col && item.myRow == row);
                if (index >= 0)
                {
                    if (cell.myColumn == col && cell.myRow == row)
                    {
                        cells.Remove(cell);
                        return;
                    }
                }
                else
                {
                    Image image = myMapController.myMap.cellBgImage;
                    cells.Add(new Cell(col, row, new CellSide(0, false), new CellSide(0, false), myMapController.myMap, image));
                    return;
                }
            }
        }

        public void onMouseClick(MouseEventArgs e, List<Cell> cells)
        {
            Point mouse = Mouse.GetPosition(myMapController.view.pbxMap);
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];
                int forgiveness = 10;

                if (mouse.X > endOfCol - forgiveness &&
                    mouse.X < endOfCol + forgiveness &&
                    mouse.Y > startOfRow && mouse.Y < endOfRow)
                {
                    
                    if (myMapController.myMap.myCells[i].myRightWall.hasWall == 1)
                    {
                        myMapController.myMap.myCells[i].myRightWall.hasWall = 0;
                    }
                    else
                    {
                        myMapController.myMap.myCells[i].myRightWall.hasWall = 1;
                    }
                }

                if (mouse.Y > endOfRow - forgiveness &&
                    mouse.Y < endOfRow + forgiveness &&
                    mouse.X > startOfCol && mouse.X < endOfCol)
                {
                    if (myMapController.myMap.myCells[i].myBottomWall.hasWall == 1)
                    {
                        myMapController.myMap.myCells[i].myBottomWall.hasWall = 0;
                    }
                    else
                    {
                        myMapController.myMap.myCells[i].myBottomWall.hasWall = 1;
                    }
                }
            }
        }
    }
}
