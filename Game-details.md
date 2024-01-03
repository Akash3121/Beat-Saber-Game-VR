# Game Details

This will provide a detailed overview of a Unity game involving two scripts: `CubeKiller.cs` and `CubeSpawner.cs`. These scripts control the spawning and destruction of cubes in the game. I'll explain the functions and how to play the game, including button interactions.

## Game Description

The game consists of cubes that are spawned and move towards the player. The player's goal is to destroy these cubes before they reach a certain distance from the player. There are two types of cubes: blue cubes (`Cube`) and red cubes (`RedCube`). The player can toggle cube spawning on and off with button Q or B, and the cubes spawn to the player's front.

## CubeKiller.cs

`CubeKiller.cs` is responsible for destroying cubes when they come into contact with a specified area, typically referred to as a "kill zone" (which is back of the player). 

The script's key components are:

- **OnTriggerEnter(Collider other):** This method is called when a GameObject with a Collider component enters the Collider of the object this script is attached to. It checks the tags of the entering GameObject and destroys it if the tag matches "Cube," "Arrow," or "RedCube."

## CubeSpawner.cs

`CubeSpawner.cs` is responsible for spawning cubes, managing their behavior, and controlling the game flow. It has several properties and functions:

### Properties:

- **cube:** A reference to the cube GameObject prefab.
- **RedCube:** A reference to the red cube GameObject prefab.
- **song:** An AudioClip for background music.
- **audioSource:** An AudioSource to play the music.
- **spawnOffset:** Offset for spawning cubes relative to the player.
- **xRange:** The range for randomizing cube positions on the X-axis.
- **yRange:** The range for randomizing cube positions on the Y-axis.
- **minDistance:** The minimum distance between the player and spawned cubes.
- **minSpawnDelay:** The minimum delay between cube spawns.
- **maxSpawnDelay:** The maximum delay between cube spawns.
- **beat:** The duration of a beat in seconds.
- **timer:** A timer for tracking the game's progress.
- **beatIndex:** An index to keep track of the current beat.
- **lastSpawnTime:** The timestamp of the last cube spawn.
- **canSpawn:** A boolean to control cube spawning.
- **endTime:** The end time of the game.
- **beats:** An array containing timestamps for beats in the game music.

### Functions:

- **Start():** Initializes properties, sets up audio playback, and invokes the `StartSongPlayback()` method after a delay.
- **StartSongPlayback():** Starts playing the background music.
- **Update():** Manages cube spawning based on the music beats and user input.
- **SpawnCube():** Spawns both blue and red cubes with randomized positions, rotations, and velocities.
- **ToggleSpawn():** Allows the player to toggle cube spawning on and off using the 'Q' key or 'B' button on an Oculus controller.

## How to Play

1. **Start the Game:** When the game starts, cubes will begin spawning towards the player.
2. **Destroy Cubes:** Your goal is to destroy the cubes by clicking on them or hitting them using some in-game mechanic not described in these scripts.
3. **Toggle Spawning:** You can toggle cube spawning on and off by pressing the 'Q' key on your keyboard or the 'B' button on an Oculus controller. (If you toggle cube spawning then the cubes spawning might miss the sync with the music)
4. **Game Progress:** The game's progress is synchronized with the background music beats defined in the `beats` array.
5. **Winning Condition:** You win the game when you successfully destroy all the cubes within the defined time frame (endTime). (Note: The game will not stop once the song is finished)
6. **Losing Condition:** You lose the game if the cubes reach a certain distance from you without being destroyed. (Note: The game will not end if the cubes touch the kill zone)

