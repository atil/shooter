// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;


public abstract class GameControllerBase : Controller {
    
    public abstract void InitializeGame(GameViewModel game);
    
    public override ViewModel CreateEmpty() {
        return new GameViewModel(this);
    }
    
    public virtual GameViewModel CreateGame() {
        return ((GameViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeGame(((GameViewModel)(viewModel)));
    }
}

public abstract class ShipControllerBase : Controller {
    
    public abstract void InitializeShip(ShipViewModel ship);
    
    public override ViewModel CreateEmpty() {
        return new ShipViewModel(this);
    }
    
    public virtual ShipViewModel CreateShip() {
        return ((ShipViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeShip(((ShipViewModel)(viewModel)));
    }
}

public abstract class PlayerShipControllerBase : ShipController {
    
    public abstract void InitializePlayerShip(PlayerShipViewModel playerShip);
    
    public override ViewModel CreateEmpty() {
        return new PlayerShipViewModel(this);
    }
    
    public virtual PlayerShipViewModel CreatePlayerShip() {
        return ((PlayerShipViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializePlayerShip(((PlayerShipViewModel)(viewModel)));
    }
}

public abstract class BulletControllerBase : Controller {
    
    public abstract void InitializeBullet(BulletViewModel bullet);
    
    public override ViewModel CreateEmpty() {
        return new BulletViewModel(this);
    }
    
    public virtual BulletViewModel CreateBullet() {
        return ((BulletViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeBullet(((BulletViewModel)(viewModel)));
    }
}
