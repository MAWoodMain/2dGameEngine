SophieEngine
============

A 2d game Engine written in C#

If anyone remembers the previous engine I had worked on, it was bad. Effiantly, it would cause problems.
With this new project, I no longer run a thread for each thing that needs to move.. but instead one thread with everything in it.

Check out Form1.cs for importing the engine into your form, how tp spawn PhysicsObject's and also control.
The Globals.cs file is not required, I just use it to return a single PhysicsObject to control.

Features
==
* Physics
* Circular system (for people to add things like rope or AOE to their game)
* Objects (Can apply their own weight/mass, own gravity)

To Add
===
* Event system
* Possibility for overhead based games
