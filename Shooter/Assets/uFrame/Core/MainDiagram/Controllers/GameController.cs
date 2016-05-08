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
    
    
    public class GameController : GameControllerBase {
        
        public override void InitializeGame(GameViewModel viewModel) {
            base.InitializeGame(viewModel);
            // This is called when a GameViewModel is created
        }
    }
}
