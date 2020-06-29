# Glitch Hollow
This game was created for the Udemy course ["Complete C# Unity Developer 2D: Learn to Code Making Games"](https://www.udemy.com/course/unitycourse/) SECTION 7. 

## Table of contents
* [Game Design](#game-design)
* [Technologies](#technologies)


## Game Design
The playing mode is PvC. The priciple is to protect the player side from attackers by placing different characters fast. 
Defender character as well as attackers have different abilities to give some variety of choices to make. 

The game field is devided into 5x9 squares in which defenders can be placed. Attackers are spawned randomly in each row.

### Characters
   
| Defender       | Ability          | Health  |
| ------------- |:-------------:| -----:|
| Squid      | shoots bubbles| 50 |
| Trophy     | regenerates crystals for character payment |   100 |
| Rock | stops attacker for a while|    50 |
| Ghost | shoots crystals, has short power-up after 5 enemies killed   |    100 |

| Attacker      | Ability          | Health  |
| ------------- |:-------------:| -----:|
| Phantom      |attacks| 50 |
| Puppet    | jumps over Rocks and attacks |   100 |
| Black Ghost | appears randomly and kills all defenders in that particular row|    50 |


### Gameflow
4 levels were implemented. Each introduces a new Defender character. By limiting the game field (rows) in the first two levels the player can get used to the system of the game.

* 1st Level   
  * 2 rows to protect 
  * Defender: Squid character
  * Attacker: phantom robot
 <img align="center" src="/DemoImages/Level1.PNG" width="500">

* 2nd Level 
  * 3 rows to protect 
  * preset rock give some protection
  * Defender: Squid character, Trophy character 
  * Attacker: Phantom,Puppet
 <img align="center" src="/DemoImages/Level2.PNG" width="500">
 
* 3rd Level 
  * 3 full field = 2 rows
  * Defender: Squid character, Trophy character, Rock 
  * no new attacker
  
* 4th Level 
  * Defender: Squid, Trophy, Rock, Ghost
  * Attacker: Phantom, Puppet, Black Ghost
  <img align="center" src="/DemoImages/gameplay2.gif" width="500">

## Technologies
* C# version: 5
* Unity version: 2019.2.8f1
