# 2D Platformer

A short 2D platformer built in Unity. Play as a frog, collect fruit, avoid traps, and reach the goal to clear each level.

**Repo:** [Yared-Yemane/2D-Platformer-Unity-Game](https://github.com/Yared-Yemane/2D-Platformer-Unity-Game)

## Features

- Main menu with level select
- Two levels with tilemap terrain, collectibles, and traps
- Run, jump, and variable jump height
- Lives (3) and scoring
- Game over and restart
- Background music and SFX

## Controls

| Action | Key |
| --- | --- |
| Move left | `A` |
| Move right | `D` |
| Jump | `Space` |

Hold jump for a higher jump. Release early for a shorter jump.

## Getting started

1. Install **Unity 6** (`6000.4.3f1` or compatible).
2. Open this folder in Unity Hub.
3. Open `Assets/Scenes/MainMenu.unity` (or press Play; Main Menu is first in Build Settings).
4. Choose **Play** or pick a level.

Git LFS is used for some assets. After cloning, run `git lfs pull` if sprites or audio are missing.

## Scenes

| Scene | Role |
| --- | --- |
| `MainMenu` | Start screen and level select |
| `Level 1` | First playable stage |
| `Level 2` | Second playable stage |

## Project layout

```
Assets/
  Animation/     Player and collectible animations
  Audio/         Music and sound effects
  Input/         Input System actions
  Prefabs/       Fruit, traps, and effects
  Scenes/        Main menu and levels
  Scripts/       Gameplay scripts
```

## Built with

- Unity 6 (URP 2D)
- Input System
- Cinemachine
- TextMesh Pro
- [Pixel Adventure](https://pixelfrog-assets.itch.io/pixel-adventure-1) art by Pixel Frog
