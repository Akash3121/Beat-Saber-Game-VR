## Rubric

Graded out of 20 points. 

1. Make a single cube that starts at the far end of the room and moves towards the user's start position.  Adjust the size and velocity so that it provides an appropriate challenge. (2)
1. When the user hits a cube with a laser sword, the cube should be destroyed. (2)
1. Play a sound when the cube is destroyed. There are plenty of websites for free sound effects.  You should find one that you like and import it into your project. (1)
1. Create a `CubeSpawner` that creates new cubes at random time intervals between 0.5 and 2.0 seconds.  You can feel free adjust these time thresholds to reach an appropriate difficulty.  The cubes should also start at the far end of the environment (>10 units away from the user), fly towards the user, and should be destroyed when hit by a laser sword. *Hint: you can create a prefab for the cube and then use `GameObject.Instantiate` to instantiate copies of it.* (3)
1. The exact X and Y positions of the spawned cubes should be chosen randomly, but should always be within reach of the user's swords when standing at the start position. (2)
1. If a cube goes past the user, it should also be destroyed, but no sound effect should be played.  We don't want to end up with infinite cubes that would slow down the Quest! (2)
1. Create a new material, and apply the `arrow.png` texture to it (found in the `Textures` directory). This material should then be applied to your cube, such that a single face (the one facing the user) has the arrow. [This YouTube video](https://www.youtube.com/watch?v=TfuoB_S8BM8) and Google will be your friend here. The cube should now have an arrow that indicates the direction in which to swing the sword.  Modify your script so that the cube is only destroyed when hit by a sword swung in that direction.  *Hint: you can use the velocity of the rigid body to determine the direction.*  (3)
1. When a cube is spawned, it should be rotated so that the direction of the arrow is either up, down, left, or right, selected randomly.  (2)
1. Finally, modify your `CubeSpawner` so that it spawns two different types of cubes, depending on the sword the user should hit them with.  For example, blue cubes could only be destroyed by the left sword, and red cubes could only be destroyed by the right sword. Finally, adjust the colors of each laser sword to match the cubes. *Hint: you can make a copy of the cube and sword materials and then change their colors in the object inspector.* (3)

**Bonus Challenge:** Transform your project into a real rhythm game!  Find a music track that you like and add it as an audio source in the scene.  Then, modify your `CubeSpawner` so that instead of spawning cubes randomly, the user will need to hit them according to the beat of the music.  You will need to store the time for spawning each cube in a data structure that the `CubeSpawner` can iterate through.  To accomplish this, you may want to play the music track in an external application such as [Audacity](https://www.audacityteam.org/) and make a list of times for each beat.  When you start playing the music, make sure to insert a delay to account for the time for the cubes to travel to the player.  You do not need to do this for the entire song; approximately 20-30 seconds of gameplay will be sufficient for bonus credit. (2)

## My project based on Rubric

1. Done (2)
1. Cube gameObject destroyes when cut by blade (2)
1. ting-sound.mp3 plays when cube is destroyed (1)
1. Created a `CubeSpawner` that creates new cubes at random time intervals between 0.5 and 2.0 seconds. 
The cubes should starts at 12 units away from player(0,0,0), flys towards the user, and should be destroyed when hit by a laser sword. (3)
1. The exact X and Y positions of the spawned cubes are chosen randomly (2)
1. If a cube goes past the user, it touches the plane that is behind the player and gets destroyed.(2)
1. Added Arrow.png image on Quad which is on from of Cube. (3) 
> **Note**: the angle between blade and the top of the cube should be greater than 130degree
{Vector3.Angle((transform.position - previousControllerPosition), CubeGameObject.transform.up) > 130 => this condition added in script}
1. Randomly rotating the cube.  (2)
1. Red and Blue cubes are spawned, based on the colour player is able to cut them. (3)

**Bonus Challenge:** Added TheFatRat-Unity.mp3, added timer variable which checks time and plays for each beat. (2)
