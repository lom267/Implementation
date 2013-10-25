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

namespace TheseusAndTheMinotaur
{
    public class Cell
    {
        public Cell(int col, int row, CellSide rightWall, CellSide bottomWall, ModelMap map)
        {
            this.myColumn = col;
            this.myRow = row;
            this.myRightWall = rightWall;
            this.myBottomWall = bottomWall;
            this.myMap = map;
        }

        public Cell(int col, int row, CellSide rightWall, CellSide bottomWall, ModelMap map, Image bgImage)
        {
            this.myColumn = col;
            this.myRow = row;
            this.myRightWall = rightWall;
            this.myBottomWall = bottomWall;
            this.myMap = map;
            this.myBgImage = bgImage;
        }

        public ModelMap myMap { get; set; }
        public Image myBgImage { get; set; }
        public bool hasMinotaur { get; set; }
        public bool hasTheseus { get; set; }
        public bool isExit { get; set; }
        public int mySize { get; set; }
        public CellSide myRightWall { get; set; }
        public CellSide myBottomWall { get; set; }
        public int myColumn { get; set; }
        public int myRow { get; set; }
    }

    public class CellSide
    {
        public CellSide(int hasWall, bool highlighted)
        {
            this.hasWall = hasWall;
            this.isHighlighted = highlighted;
        }

        public bool isHighlighted { get; set; }
        public int hasWall { get; set; }
    }
}



