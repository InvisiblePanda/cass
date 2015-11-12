# CASS

This is supposed to be a useful little tool (mostly for myself) that helps when
there is the need to take a screenshot of the *client area* (that is, without the borders and title bar)
of some external program.

To accomplish this, it makes use of some WinAPI functions from user32.dll.

As of now, this is very unfinished but works well enough for my purposes. Some possible things
to add in the future:

- Decision between "client area only" and "full window"
- Ability to click on the target window instead of entering its title (perhaps not possible with .NET code)
- Different file formats and resolutions
- Specification of the output directory
