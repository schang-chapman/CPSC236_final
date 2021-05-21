# CPSC236_final

## Identifying Information
* Name: Sharon Chang
* Student ID: 2344341
* Email: shchang@chapman.edu
* Course: CPSC236
* Assignment: Final Project

## Assets Files
* Slippery

Animations:
* PlayerAttack
* PlayerIdle
* PlayerRun

Prefabs:
* BlueBullet
* InteractableBlock
* RedBullet
* Start
* YellowBullet

Scenes:
* SampleScene

Scripts:
* BlockController
* BulletController
* CameraSize
* CharacterController2D (Script downloaded from https://github.com/Brackeys/2D-Character-Controller)
* EndLevel
* PlayerController

(Sprites from https://pixelfrog-assets.itch.io/pixel-adventure-1 & https://pixelfrog-assets.itch.io/pixel-adventure-2)
Sprites:
* Checkpoints:
  * End(Idle)
  * Start(Idle)
* Trunk:
  * Attack
  * Bullet
  * Idle
  * Player
  * Run
* Terrain

TextMeshPro:
* -

Tilemaps:
* Background
* Terrain
* Black Text

References:
* Unity2D subreddit:
  * Setting fixed camera size
* Unity forums:
  * Setting up the InteractableBlock prefab (Vector3 movetowards implementation, making it not move unless hit by a blue bullet)
* Stack overflow:
  * Compiler errors
* Brackeys:
  * Set up method of firing bullets from Character
  * Minor edit to CharacterController2D's flip() method
* CPSC236 playlists:
  * Player movement
  * Tilemap setup
  * Player animation setup
  * Destroy bullets out of camera
  * How to bound character within camera

  Known Errors:
  * If you shoot a bullet, then turn around, the bullet will teleport to the other side of the screen, but maintain its trajectory
  * The character sometimes gets caught on seemingly nothing, cause unknown
  * The character sometimes won't jump with space bar is pressed, cause unknown

  Removed Features:
  * Lives system: It occurred to me that the lives system was not necessary given that nothing in the maps will actually kill the player
  * Pickup potions: The levels can be solved with just the given set of powers, rendering the potions unnecessary
