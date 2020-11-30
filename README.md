# Ex5-BrickBreaker    
Short game of Brick-Breaker with different levels made in Unity.

<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/level2.jpg width="400"/>

   
### How we build this Game:   
This Game has sevral **Scenes** while the first one is the **Main Nenu** Scene which you'll see in the begining of the game,
the rest of the Scenes are the leveles which you will play and enjoy.     
Every Lvele Scene has the following objects:
* Main Camera
* Bricks
* Ball
* Surface
* Borders
* Canvas
* GameManager
* EventScene
* Background   

### Bricks   
There are two kinds of bricks; **"Brick"** and **HarderBrick"**.    
Each one is a **prefab** and while both have a Poligon Coillider and Sprite Rendere they each have their own Script.
Brick has its own [BrickScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/BrickScript.cs) and HarderBrick has its own [HarderBrickScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/HarderBrickScript.cs).   
**Brick** - Has one life and when the ball hits it it will be destoyed.   
**Harder Brick** - Has two lives and has a different color to notice the differnce. when hitting the HarderBrick once its color will change to the color of the regular "Brick".   

   
### Ball    
Has RigidBody, Circle Collider and a [BallMoverScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/BallMover.cs).  
* BallMoverScript - Controls the collision with the bricks and when it reaches the Bottom Border by the **OnCollisionEnter2D** function. In this Script we controll the PowerUp of HeartAdder which randomlly drops a "Life" (Prefab) when hitting a brick.   
EveryTime a Brick is being hit an **Explosion Prefab** will be generated from the postion of the current brick which gives a fun effect to the game.   
We used the **Random.Range(1, 1001)** function to generate a number between 1 and 1000 and if a number was chosen in the range that we chose so a a new **LifeAdder Prefab** will be Instantiate from the position of the current Brick.   
All of the collisions are using the Tags to detect which object is in a colision.   

### Surface   
Has RigidBody, Cube(Mesh Rendere), Polygon Collider and a [SurfaceScript]().   
To make sure the ball will move in a different angle when hiting the Surface in differnet areas of the Surface We've used the Polygon Collider instead of a Box Collider which fits perectlly on the rectangle Cube.   
This salution will insure that the player can have more controll on the movment of the ball.   
* Mouse Movemnet - The Surface is contolled by the mouse while its pressed the data member **isDragging** will be true (false if we release our hand from the mouse click) and will move according to the mouse's position.   
* LifeAdder Collision - When Colliderd with an Objcet caryying the **LifeAdder Tag** then a life will be increased to the player.

### Borders




## Issues & Salutions
* Poligon Coillider - We changed the Collider of the Bricks and the Borders to Poligon Coliider and created a slight angle on each 
brick and border so the ball won't stuck in  a specific angle between the borders/two bricks.   


