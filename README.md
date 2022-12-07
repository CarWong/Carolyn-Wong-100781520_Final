# GED Final

## How to Play:
- WASD to move
- Mouse to look around
- SPACE to jump
- LMB to attack
- ESC to quit game

## Build:
You can fine the exe file in the published release.

## Scripts:
- EnemyController.cs : used to control enemy's actions such as patrolling and attacking
- GameControls.cs : used for defining input actions for player such as moving
- GameplayManager.cs : used to hide the mouse cursor in play mode
- PlayerController.cs : used to control player's actions such as move, attack, rotate, and jump
- PlayerInputController.cs : global access to Game input actions using singleton pattern
- PlayerSword.cs : used to manage player's sword collision with enemies

## Notes:
A player, two enemies, and platforms are placed in the scene. Enemies are able to move around and attack using AI. 
Some animations were added to all the characters.
One singleton pattern is used in PlayerInputController.cs. No other design patterns or elements such as collectables and win/lose condition were implemented.<br />
3D Model Resource: https://quaternius.com/packs/cyberpunkgamekit.html

## Object Pooling:
Object pooling would be created by making a pool of duck enemies on start. These ducks would be enabled and disabled when needed. The pool could be small depending on how many ducks are needed in the scene simultaniously. When the player shoots the ducks they will become disabled until they are needed again. Instantiating new ducks every time the player needs one will just reduce the performance. When using object pooling you can instantiate the small pool at the beginning that will create only one spike of RAM usage on start. If you were to instantiate repeatedly without using object pooling, the game will run into issues where spikes in performance will happen mid game. Ducks that do not get shot will simply sit off to the side using up memory. If the game were to have a frenzy mode with 100s of ducks the game would use up all the RAM and possibly crash.

## Command Design Pattern:
The command design pattern will swap the commands of the mouse. Instead of the reticle going upwards when the mouse moves up it will go down. This will be implemented by making different commands for the player movement. There will be four executes one for each motion with the mouse direction. If no ducks are hit then the execute command will change which command each mouse motion activates. If the player's mouth moves upwards then the reticle down command will execute instead of the usual reticle up command. 

## Sound Management System:
A sound management system would be able to play sounds depending on what happens in game. It would have to use the observer design pattern to know what's happening. For example if the player shoots a duck and a function that tracks if the duck is shot gets called, the method would notify the sound manager and it would play the sound(s) that are associated with the action. OnNotify, the sound manager would play the sound that's required. It would also use the singleton design pattern becuase there will only be one sound manager. Each object will use the one sound manager.

## Note:
