Sierpinski Attractor
====================

Authors:

Ricky Sidhu
Kamron Javaherpour

This attractor is powered by the algorithm provided. The basic features are described in 'Usage', on the application. We decided not to keep all of the shapes created in an array since all shapes added to the canvas are already in a list called CanvasName.Children. Furthermore, we didn't feel it was necessary to make a whole new class for the new shapes and instead tracked shape sizes for each control point in an array that is parallel to our control point array.

control points
[R B B G C O]

sizes
[2 2 4 4 6 6]

Would refer to six control points where the sizing is as follows:

Red 	2px
Blue 	2px
Blue 	4px
Green	4px
Cyan	6px
Orange	6px

Making the shapes draggable was a matter of noting when the LeftMousedown was fired, and setting a boolean to true OnMouseDown, allowing the MouseMove method to work on the shape near (within a 20px radius) our mouse, and setting that same boolean to false when LeftMouseUp gets fired.

All of the design was done in Blend and all of the programming was done in VS2013.


# The functionality of the bottom bar #

* Sliders are used to create a color for each control point. Three sliders are used which each modify a red, green or blue value of the control point color.
* Preset Shape Colors is a list of colors that can be selected which will move the RGB sliders into known positions for a color. e.g., selecting "Red" will move the sliders to (255, 0, 0).
* New Shape Size specifies the size of the newly created shapes when running the attractor.
* Finally, Run and Clear are self-explanatory buttons.

# Controls #

* Right click to add a control-point. This can be done while the attractor is in a "drawn" state, which will create a new attractor and get rid of the old one, or outside of the "drawn" state, where it will simply add a new control point.
* Left click and drag to move a control point. Similarly, this will behave differently if the attractor has been drawn yet or not.