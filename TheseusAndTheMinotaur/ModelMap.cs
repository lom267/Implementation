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
    public class ModelMap
    {
        public ModelMap()
        {
            this.cellBgImage = new Image();
            this.exitImage = new Image();
            this.theseus = new Image();
            this.minotaur = new Image();
        }

        public int rows { get; set; }
        public int cols { get; set; }
        public int boardXPos { get; set; }
        public int boardYPos { get; set; }
        public int myCellSize { get; set; }
        public Image cellBgImage { get; set; }
        public Image minotaur { get; set; }
        public Image theseus { get; set; }
        public Image exitImage { get; set; }
        public string exitCellPlacement { get; set; }
        public int myWidth { get; set; }
        public int myHeight { get; set; }
        private List<Cell> m_cells = new List<Cell>();
        public List<Cell> myCells
        {
            get
            {
                return m_cells;
            }
            set
            {
                m_cells = value;
            }
        }
    }
}