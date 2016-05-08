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
    
    
    public class PlayerShipController : PlayerShipControllerBase {
        
        public override void InitializePlayerShip(PlayerShipViewModel viewModel) {
            base.InitializePlayerShip(viewModel);
            // This is called when a PlayerShipViewModel is created
        }
    }
}
