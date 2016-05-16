#Shooter

Basic 2d scrolling shooter made with Unity.
Gameplay and graphics are nothing fancy, just a practice of an MVC-like architecture on a simple game

Some notes:
- Of course this may seem a textbook overengineering, for a project like this, but I think this kind of decoupling would make things easier on larger codebases
- Model classes are meant to be pure data holders. This way, serializing / syncing them would be much clearer
- Views are used for input and rendering. And since unity provides a nice collision detection, volume triggering comes from views also.
- Controllers are where the game logic goes. They are responsible for handling inputs, mutating data and rendering it
- Downside is, there may be overused inheritence / lots of files or it may seem like using a sledgehammer to crack a nut. Definitely not for prototyping
- Speaking of sledgehammers, my mind went to using [uFrame](https://www.assetstore.unity3d.com/en/#!/content/14381), but.. Let's just say that attempt turned out to be an "orbital artillery canon"
- Simple dependecy injection is used
- Input handling is abstracted in InputDispatcher. This way, any kind of AI, replay via file stream, network syncing can be done without touching the rest
- Documentation is none to zero at the moment
- [Newtonsoft's Json library](http://www.newtonsoft.com/json) is used for reading resource paths