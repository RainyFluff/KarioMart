# KarioMart
The game is an isometric racing game with 2 players, both players need to drive through all the checkpoints on the map in order to increase their laps, first player to achieve 3 laps wins.

The game doesn't have a speed limit or respawns, this is to encourage the player to drive slow and carefully, taking turns at a speed that they know they can manage otherwise they might end up outside the track (due to a bug, I mean feature).

There is a bomb that you can pickup, indicated by a colored square on each players HUD. This bomb is intended to be used as a displacement tool if the other player gets too close. 
Since driving close to each other will often mean bumping and blocking each other.

The first scene, where everything is started is "Main Menu", everything can and will be loaded from there, no additional packages are required. All the code is in the "Scripts" folder. The code itself is simple, not very modular and not easily expanded upon. This is because the project is very small and doesnt require advanced code to funciton.
Some code is a bit more modular such as the "Pick Ups" and "Checkpoints" this is mainly because i saw the approach i took in these scripts to be the quickest and easiest.
All codes design can be simplified to "the quickest and easiest way to achieve my goals without "cluttering up the inspector too much"

# Instructions
Player 1 uses WASD for movement, leftShift for boost and leftControl for using Bombs.
Player 2 uses Arrow keys for movement, rightShift for boost and rightControl for using Bombs.
Pressing Escape will pause the game, this works for both players.
Left side of the screen is Player1 HUD
Right side of the screen is Player2 HUD

# Sources
Unity docs
Old Github projects in my own repository
Brackeys
Classmates

Mostly used Unity docs and old Github projects.

# Nikodemius Ivarsson, Unity 2022.3.8f1
# All compiler errors should be fixed and the game is therefore buildable.
