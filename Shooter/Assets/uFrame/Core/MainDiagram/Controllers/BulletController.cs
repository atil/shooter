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
    
    
    public class BulletController : BulletControllerBase {
        
        public override void InitializeBullet(BulletViewModel viewModel) {
            base.InitializeBullet(viewModel);
            // This is called when a BulletViewModel is created
        }
    }
}
