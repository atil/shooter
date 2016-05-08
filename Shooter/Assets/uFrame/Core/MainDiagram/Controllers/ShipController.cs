namespace Shooter {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.IOC;
    using uFrame.MVVM;
    using uFrame.Serialization;
    using UniRx;
    
    
    public class ShipController : ShipControllerBase {
        
        public override void InitializeShip(ShipViewModel viewModel) {
            base.InitializeShip(viewModel);
            // This is called when a ShipViewModel is created
        }
    }
}
