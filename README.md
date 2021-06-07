### SoAnimeSoftware

C# Internal cheat for Counter-Strike: Global Offensive. You can use this as base for educational purposes.

This is a community project. It is understood that the community will help improve and complete this project starting from its publication. Feel free to become a contributor if you have ideas and can implement them. [Discord server](https://discord.gg/Hww4wW4yVV "Discord server") has been created for coordination and discussion (no one here will create and distribute binaries for you, do not think to go here for this).

## Features

Attention, most of the functions have so far been implemented as an example. Some of them are **incomplete or not customizable**.

+ Aimbot
+ Backtrack
+ Visuals
	+ Chams
	+ Glow
	+ Viewmodel override
	+ Esp
	+ World color
	+ Skin changer
	+ Skin coloring [(showcase)](https://www.youtube.com/watch?v=jY6xnzaMk-c&ab_channel=yamadabestgirl "(showcase)")
+ Misc
	+ Movement recorder [(showcase)](https://www.youtube.com/watch?v=BEB8RJT0Ed0 "(showcase)")
		+ Play (silent and normal moves)
		+ Clip
		+ Record
	+ Discord RPC
	+ Bunny hop
	+ Edgebug assist (slowdown jumpbug)
	+ Edgejump
	+ Grenade prediction
	+ Fast stop
	+ Fast crouch
	+ Vote logger
	+ sv_pure bypass
	+ Remove scope
	+ Flash reduce
	+ Autoaccept
	+ Rank reveal
	+ Voice chat events
    + Recoil crosshair
    + Clantag changer
    + Namechanger
	+ No messages/cooldown name changing exploit
+ Grief
	+ Team damage tracker
	+ Blockbot
	+ Doorspammer

## Contribution

We welcome any help, but there is something that needs to be done first. A small sheet that will be updated over time.
+ Switch to ImGui for rendering menus and other stuff.
+ Switch injection method.
+ Complete the functions and add customization to new menu.
+ Implement C# add-on libraries. (like lua/js scripting)
+ Fix code-style and naming problems.

## For devs

The code contains a lot of garbage and bad practices, even the code-style changes very often. This will have to change over time, you can also take part in putting things in order.

#### Building

Better use the latest version of Visual Studio 2019.  
Clone repository and open project to restore NuGet packages.  
Open **DllExport.bat** and click **Apply**.  
Reload project select **Any CPU** property and build.  

#### Injecting

Build and open **Hyper Useful Injector**.  
Select **csgo** process.  
For **Main Method** use **Init**.  
Press **Inject** button.

## Contributed to project
+ [EasyHax](https://github.com/EasyHax "EasyHax")
