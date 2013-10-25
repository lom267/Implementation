using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusAndTheMinotaur
{
    public class MapConstructor
    {
        public ControllerMap myMapController { get; set; }

        public MapConstructor(ControllerMap mapController)
        {
            this.myMapController = mapController;
        }
    }
}
