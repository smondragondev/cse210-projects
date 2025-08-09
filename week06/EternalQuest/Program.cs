using System;
/*
Exceeding Requirements:

1. I added a library to enhance the menu options: https://spectreconsole.net/prompts/selection.
    With the same library, I added text that looks like retro game graphics for displaying points, congratulatory messages, and emojis.
2. I ensure that a goal cannot be saved with an amount of points equal to 0; you must set an amount greater than 0 to save a goal.
3. If you record an event for a goal that has already been completed, you will receive a message stating that you can't earn more points for that goal.
4. I added a new attribute to the GoalManager called _level to track the user's current level; every 1000 points is a new level.
*/
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}