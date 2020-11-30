# Ex5-BrickBreaker    :video_game: 
Short game of Brick-Breaker with different levels made in Unity.

<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/level2.jpg width="400"/>    
   
### [Play on Itch.io](https://game-dev-project-d-a-y.itch.io/brick-breaker)

### How to play   
Very Easy!!    
Just click the mouse to start like it says and hold the Surface!!    
<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/popup.jpg width="250"/>     
### Levels   
* Level 1 - Simple Bricks.
* Level 2 - Simple Bricks in addition to Harder Bricks.
* Level 3 - Simple Bricks in addition to Harder Bricks **however** they are smaller and its harder to hit them.
* Level 4 - Simple Bricks in addition to Harder Bricks and Unbreakable Bricks.



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
<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/leverlHirarchy.jpg width="200"/>   

### Bricks   
   <img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/bricks.jpg width="350"/>
   
There are three kinds of bricks; **"Brick"**, **HarderBrick"** and UnbreakanleBrick.   
Each one is a **prefab** and while both have a Poligon Coillider and Sprite Rendere they each have their own Script.
Brick has its own [BrickScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/BrickScript.cs) and HarderBrick has its own [HarderBrickScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/HarderBrickScript.cs).   
**Brick** - Has one life and when the ball hits it it will be destoyed.   
**Harder Brick** - Has two lives and has a different color to notice the differnce. when hitting the HarderBrick once its color will change to the color of the regular "Brick".       
**UnbreakanleBrick** - Has a Collider and thats all - very simple and everytime the ball hits it the simple physics does its work.

   
### Ball   
 <img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/ball.jpg width="100"/>

     
Has RigidBody, Circle Collider and a [BallMoverScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/BallMover.cs).  
* BallMoverScript - Controls the collision with the bricks and when it reaches the Bottom Border by the **OnCollisionEnter2D** function. In this Script we controll the PowerUp of HeartAdder which randomlly drops a "Life" (Prefab) when hitting a brick.   
EveryTime a Brick is being hit an **Explosion Prefab** will be generated from the postion of the current brick which gives a fun effect to the game.   
We used the **Random.Range(1, 1001)** function to generate a number between 1 and 1000 and if a number was chosen in the range that we chose so a a new :heart: [LifeAdder Prefab](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/LifeAdder.cs) will be Instantiate from the position of the current Brick.   
All of the collisions are using the Tags to detect which object is in a colision.    
By Colliding with the bottom border (see borders) a life will be decreased and the ball is returned to the surface's position (by using a flag "inPlay" we know when to do so).

### Surface  
<img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/Surface.jpg width="200"/>

    
Has RigidBody, Cube(Mesh Rendere), Polygon Collider and a [SurfaceScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/SurfaceScript.cs).   
To make sure the ball will move in a different angle when hiting the Surface in differnet areas of the Surface We've used the Polygon Collider instead of a Box Collider which fits perectlly on the rectangle Cube.   
This salution will insure that the player can have more controll on the movment of the ball.   
* Mouse Movemnet - The Surface is contolled by the mouse while its pressed the data member **isDragging** will be true (false if we release our hand from the mouse click) and will move according to the mouse's position.   
* LifeAdder Collision - When Colliderd with an Objcet caryying the **LifeAdder Tag** then a life will be increased to the player.

### Borders
Four borders - Top, Bottom, Right and Left.   
* Left/Right/Top - We gave an angle to the Box Colider so that the ball wont be stuck between two walls or a wall and a brick/surface.    
* Bottom Border - When collides with the Bottom it is destroyed see: [BottomBorderScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/Scripts/BottomBorderScript.cs).   

### Canvas
Holds the score and lives which are uodated through the GameManager.   
In addition it has a **panel** when the game is over so the player can chhose to play again or exit (using buttons and OnClick commands).    
   
 <img src=https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Images/panel.jpg width="300"/>  

### GameManager   
Managers the entire game.
Loads data every begining of a scene (not the first scene because there' no data to load..).   
Countes the number of Bricks and has these simple and neccessry functions: 

`private void DisplayLives()`   
`private void DisplayScore()`   
`public void DecreaseLives()`   
`public void IncreaseLives()`   
`public void UpdateScore(int points)`    
`public void BricksUpdate()`    
`private void GameOver()`    
`public void PlayAgain()`    
`public void Exit()`    
`public void NextLevel()`      
[GameManagerScript](https://github.com/Game-Dev-Project-D-A-Y/Ex5-BrickBreaker/blob/master/Assets/GameManager.cs)

## Issues & Salutions   

* Poligon Coillider - We changed the Collider of the Bricks  to Poligon Coliider and created a slight angle on each 
brick and border so the ball won't stuck in  a specific angle between the two bricks.     
* Savind the data from previous Scene - by usuing two functions to Load - PlayerPrefs.GetInt and Save - PlayerPrefs.SetInt, the data we managed to fix the problem.
* PopUp message - To create instructions we've gave the text a 5 seconds duration and we destoyed the object (we can disable the view as well).

