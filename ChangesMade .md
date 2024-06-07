- `PlayerController.cs`:
    - Removed call to `Destroy()` function in `Start()` function to prevent auto-destruction of the script
    - Change initial value of `health` to not be `0`. Because, if its zero player will instantly die
    - Added variables `characterController`, `moveDirection` and `speed` and logic for the player movement

- Enable `CharacterController` component in `Player` for it to be able to move

- `PlayerLook.cs`:
    - Replaced variable `playerArms` by `camera` in order to rotate just the view in the xAxis
    - Change the scope of the variables `rotPlayer`, `rotCamera`, `rotateX` and `rotateY` to be global (and not initialize them each frame in the `Update` function)
    - Replaced `if...else` statment for the `Mathf.Clamp` function
    - Adjusted `mouseSense` fot it to not be zero.

- `Bullet.cs`:
    - Calling `Destroy` function for enemy and bullet on impact

- Added the `Enemy` tag to the enemies gameobjects in scene

- Assign the `Finish` tag to the ship in scene to be able to win