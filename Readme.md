Robot Wars Submission for OpenTable.

The project is very simple and requires few inputs from the user.

Below are a list of limitations that the project currently has that can be improved on with more time:

 - The game currently only allows for 2 robots due to the number of loops. This was kept to keep the game simple and to stick to the initial instructions.
 - Due to the restricted input of only allowing 2 numbers in the arena size (top right corner) input. The maximum size of the array is (9,9).
 - Unit testing some input functions is difficult due to the validation loops I've implemented. If I had the time to do it differently, I would make those methods much more test-able.
 - There was no guidelines on what happens if the robot leaves the arena, I have decided to just output it as OutOfBounds.
 - The intial Program.cs file is quite messy, this was due to me not being too familiar with the .Net6 changes to the file structure. I just wanted to get the Dependancy Injection working so I rushed that part...
 - Unit testing was VERY light due being short on time, I'm starting to see the benefits of TDD. Was a bit of a hassle when implementing tests at the end.

 Overall, fun little project 👍