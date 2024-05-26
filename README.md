# BS_Patstrap_support
A free IPA mod for Beat Saber which adds [Patstrap](https://github.com/danielfvm/Patstrap) support to the game. Still WIP *(Work In Progress)*, but now it got to useable state.

How it works? It makes your Patstrap vibrate when you walk into the wall (or obstacle, how it's officially called), that's it!

## Setup

### PatStrap side
I assume that you already built hardware and setup software of PatStrap itself. If not, [follow original instructions first](https://github.com/danielfvm/Patstrap?tab=readme-ov-file#hardware). You don't have to setup VRC avatar if you won't play VRC, though.

### Beat Saber side
This mod is made for PCVR version of Beat Saber (both Steam and Oculus). It won't work on Quest in standalone mode *(at least for now)*, but it will work in tethered mode *(Virtual Desktop, Steam Link, Meta Quest (Air) Link, ALVR etc.)*

Of course, your game copy has to be modded. If it isn't, [BSMG Wiki](https://bsmg.wiki/pc-modding.html) is the best place to get started.

To install it, you have to download both *.dll files and drag it into `%BeatSaber_directory%/Plugins/` folder. The second file is CoreOSC library, which is used by this mod, and which is distributed with it for your convenience.

When you bootup the game, `VRChat connection` in PatStrap server should turn blue. If it is, congrats.

If not, and you did everything correctly, but VRC works and it's also setup correctly, feel free to open an issue.

## Demonstration

[![BS_Patstrap_support demo on YouTube](https://img.youtube.com/vi/aXWG7DCr3hw/0.jpg)](https://www.youtube.com/watch?v=aXWG7DCr3hw)

## Credits

[PatStrap](https://github.com/danielfvm/Patstrap) for the original project. This mod wouldn't exist without it.

[CoreOSC](https://github.com/dastevens/CoreOSC) for the C# library to implement OSC protocol. Licensed under MIT License.
