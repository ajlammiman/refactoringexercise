# refactoringexercise
Solution to practice refactoring skills

This repo is designed to fill a hole I've noticed in the available code kata's online. 

Code are kata's small coding exercises designed to allow you to try out different concepts and practises in a sandbox problem, like a martial arts kata a way of practising your moves outside of the heat of battle as a way of honing your skills. However all the ones I've come across start from a clean slate, I've not found any that give you some code and task you to practise making it better, which is what most professional programmers find most of their job entails.

When I first started work at my current company I was given a coding exercise as part of my interview, since I did this kata the first time I've come back to it several times and rewritten it. I've found it's a nice little self contained task which has enough depth to allow you to try out different things but requires no set-up or infrastructure and is limited enough that it's finite. The brief for the exercise is as follows:

A game has 1 player with 3 lives, this player moves across a 10x10 board. The player starts in the bottom left square and must reach the top right. 5 mines are hidden on random squares, if a player hits a mine they lose a life, if they lose all their lives the game is over. If the player reaches the top right corner square with more than zero lives they win the game.

This game can be a simple console app, no ui needs to be involved past simple messages.

If you look at this repo there are 2 versions of this project, there is a branch called 'starting good code' this contains what I consider a good version of the code, it's written using TDD it has domain objects, internal validation and consistent naming conventions. Like any code base it's not perfect but I think it represents generally good practise.

The master branch is the same code but put through a process that I've termed awfulisation, I've taken the code (along with some help from a colleague who shall remain nameless in order to protect him from retribution, thanks Chris) and reverse refactored it trying to make it as bad as possible, while still keeping it working (This is a surprisingly difficult endeavour, writing bad code is easy writing bad code that stays working is much harder). It is full of poor practice, poorly named variables, methods that do more than one thing, everything lumped into one class, no tests a few bugs (try and go off the board). It should hopefully be a difficult to understand mess.

Your mission, should you decide to accept it, is to refactor this code so it starts to head towards the good example in the branch (it does not have to be exactly the same, you may have your own ideas, my example is just there to give some ideas). To make it trickier and to really practise good refactoring skills there are a number of rules you need to observe.

1) You do not have to refactor all the code at once.
2) At any point you should be able to finish and leave the code in a (better) but working state.

This should be an exercise in making small incremental non breaking changes, not delete the whole thing and start again.

If you really want to stretch yourself and practice in a more realistic environment then try and refactor around additional requirements.

Can change the game so that it:

1) Has more than one player
2) Has additional squares that restore a lost life
3) Has a vortex that immediately ends the game (Adventure Game!)
4) Random start point

Pick a requirement and try and add it to the game while also refactoring enough to leave the code in a better place, can you go far enough to satisfy both the requirements and the your sense of what is decent in the world?
 
If you want some guidance on different refactoring practises I recommend starting with this book: https://www.amazon.co.uk/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052/ref=sr_1_1?crid=2UCPKL1BTD33L&keywords=working+with+legacy+code&qid=1570720305&sprefix=working+with+le%2Caps%2C144&sr=8-1

It is a brilliant book with lots of techniques to try out here.

Good Luck and happy refactoring.




