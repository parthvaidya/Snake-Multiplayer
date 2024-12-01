# Snake Game (Single Player & Multiplayer)
A modern twist on the classic Snake game! This version includes features such as screen wrapping, power-ups, different types of food, and multiplayer mode where two players can play on the same screen.

# Table of Contents:
1. Features
2. Installation
3. Controls
4. How to Play
5. Video Gameplay
6. Credits

# Features:
1. Core Gameplay:
Snake Movement: The snake can move in all four directions: Up (W), Down (S), Left (A), and Right (D) for Player 1; Arrow Keys for Player 2.
Screen Wrapping: The snake wraps around the screen when it reaches the edge (i.e., the snake appears on the opposite side).
Self-Collision: The game ends if the snake collides with itself.
Snake Growth: The snake grows after consuming Mass Gainer food and shrinks after consuming Mass Burner food.

2. Power-Ups:
Shield: Activates a shield that prevents the snake from dying on collision with itself.
Score Boost: Doubles the score gained from Mass Gainer food.
Speed Up: Increases the snake's speed temporarily (this can be implemented later if desired).
Cooldown Mechanism: Each power-up has a cooldown time of 3 seconds. The cooldown duration is adjustable for flexibility.

3. Food:
Mass Gainer: Increases the snake's length upon consumption.
Mass Burner: Decreases the snake's length (can only appear if the snake's size is above a certain threshold).
Auto Despawn: Foods that are not eaten will automatically disappear after a set amount of time.

4. Multiplayer:
Two Players Mode: One player uses WASD keys to control their snake, while the other uses the Arrow Keys.
Player Interaction: If Snake A collides with Snake B, Snake B will die, and vice versa.

5. Scoring:
Mass Gainer Food increases the score.
Mass Burner Food decreases the score.

6. UI:
Death Screen: Displayed when a snake dies.
Win Screen: Displayed when one player survives while the other dies in multiplayer mode.
Score Display: Shows the current score for both players.
Lobby Screen: Game lobby where players can start a new game.
Pause/Resume: Allows players to pause and resume the game during gameplay.
Restart/Quit: Options to restart the game or quit.

# Installation:
1. Clone this repository to your local machine
2. Open the project in Unity.
3. Ensure you have the correct Unity version (any version that supports the features used).
4. Press the Play button in Unity to start the game.

# Controls:

1. Single Player:
W: Move Up
A: Move Left
S: Move Down
D: Move Right
2. Multiplayer:
Player 1: WASD keys to move.
Player 2: Arrow Keys to move.

# How to Play:
1. Start the Game: Click on the "Start" button in the Lobby.
2. Control Your Snake: Use the keyboard keys mentioned above.
3. Eat Food: Gain points by consuming Mass Gainer food and avoid the Mass Burner food to prevent shrinking.
4. Activate Power-Ups: Collect random power-ups that spawn during the game to enhance your gameplay.
5. Avoid Self-Collision: If your snake bites itself, it will die, and the game will end.
6. Multiplayer Mode: Play with a friend on the same screen by controlling separate snakes using different key sets.
7. Game Over: When a snake dies, a "Game Over" screen will be displayed. In multiplayer mode, the last snake standing wins.

# Video Gameplay:
The video for the Snake Game is as follows: https://drive.google.com/file/d/1NkYYgx384ZdmhPqIOFtGZLWqyBAUJjoz/view?usp=sharing

# Credits:
This Game is inspired by the classic Snake 2D with some touches by: Parth Vaidya !!!
Special thanks to the Unity community for tutorials and resources that made this project possible.






