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