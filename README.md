# BS_Patstrap_support
A free IPA mod for Beat Saber which adds [Patstrap](https://github.com/danielfvm/Patstrap) support to the game.

How it works? It makes your Patstrap vibrate when you walk into the wall (or obstacle, how it's officially called), that's it!

## Setup

### PatStrap side
I assume that you already built hardware and setup software of PatStrap itself. If not, [follow original instructions first](https://github.com/danielfvm/Patstrap?tab=readme-ov-file#hardware). You don't have to setup VRC avatar if you won't play VRC, though.

### Beat Saber side
This mod is made for PCVR version of Beat Saber (both Steam and Oculus). It won't work on Quest in standalone mode *(at least for now)*, but it will work in tethered mode *(Virtual Desktop, Steam Link, Meta Quest (Air) Link, ALVR etc.)*

Of course, your game copy has to be modded. If it isn't, [BSMG Wiki](https://bsmg.wiki/pc-modding.html) is the best place to get started.

To install it, you have to download both *.dll files, drag `BS_Patstrap_support.dll` into `%BeatSaber_directory%/Plugins/` folder. The second file is `CoreOSC.dll` library, which is used by this mod, and which is distributed with it for your convenience. You should drag it into `%BeatSaber_directory%/Libs/` folder.

When you bootup the game, `VRChat connection` in PatStrap server should turn blue. If it is, congrats.

If not, and you did everything correctly, but VRC works and it's also setup correctly, feel free to open an issue.

## Demonstration

[![BS_Patstrap_support demo on YouTube](https://img.youtube.com/vi/aXWG7DCr3hw/0.jpg)](https://www.youtube.com/watch?v=aXWG7DCr3hw)

## License

Licensed under [MIT License](https://opensource.org/license/mit), like every other GlobalGameJam stuff by default.

## Credits

[PatStrap](https://github.com/danielfvm/Patstrap) for the original project. This mod wouldn't exist without it.

[CoreOSC](https://github.com/dastevens/CoreOSC) for the C# library to implement OSC protocol. Licensed under MIT License.

## You would also like

[SR_Patstrap_support](https://github.com/tapafon/SR_Patstrap_support) same mod, but for Synth Riders