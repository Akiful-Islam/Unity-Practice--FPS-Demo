# Zombie FPS

#### Description
A 3D zombie FPS game made with Unity 2021. The project was built using the help of resources provided by GameDev.tv. 

### Running The Project
To run the project, open it with Unity 2021 or later and start the. The project is yet unfinished and will be worked on further.


## Features
### Assets
- FPS player controller used from **Standard Assets** by *Unity*.
- **Zombie** assets by *PXLTIGER* used for zombie texture and animations.
- **NavMesh** for AI Pathfinding.
- Weapon textures assets provided by GameDev.tv.
- **Animator** and **Animation Controller** for Animations.
- **Terrain Painter** for level design.
- Miscellaneous textures, prefabs, and scripts are used from **Standard Assets** by *Unity*.

### Gameplay
##### Control
- Movement: WASD
- Jump: Space
- Shoot: Left Mouse Button
- Zoom: Right Mouse Button
- Change Weapons: 1 to 9 or Scroll Wheel

##### Zombie AI
- Starts in idle mode and stays in that mode until provoked.
- Gets provoked when shot at or when a player gets in close proximity.
- Chases the player when provoked.
- Attacks the player when close.
- Player dies after a certain amount of hits.
- Zombie dies after a certain amount of damage.

##### Environment
- Flashlight on player camera to navigate around dark environments.
- Walk up to a pickup texture to increase specific ammo count (Shells, Bullets, Rockets, Plasma).


## Future
My final goal with this project is a create a playable demo that includes:
- A UI to navigate around. 
- Showing stats and player health using a HUD.
- One fully finished level with an objective to finish.
