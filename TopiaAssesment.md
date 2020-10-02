| Cailey Marie Bianchini|
| :---          	|
| s208042    	|
| Computer Graphics |
| Topia Documentation |
| https://github.com/CaileyBianchini/Topia |

## I. Requirements

1. Description of Problem

	- **Name**: Topia

	- **Problem Statement**: Check all the requirments for Assessment
	
	- **Problem Specifications**:  
    

2. Input Information
- Get Input Numbers - Player will be asked to select things out of a list, can be two choices, some will have 6 choices.
- Name? - You will be asked to type in the name you want for the character you will be plaing.

1.  Output Information
- When you enter your choice, that choice will be the only one played and will effect how the game is played, this is in both versions that you can play.
- When you input your name, anywhere that requires to print players name, it will print the name that you inputed.
 
## II. Errors

    1. Save and Load
        - Save and Loading not working. Either keeps looping or doesn't actually do what it is supposed to do.
    2. Weapon Selection PvP
        - When selecting an item for PvP it crashes

## III. Future Ideas
    1. Money 
        - Will be adding a currency in the game that will allow players to buy things, will be gold, silver, copper.
    2. A Shop
        -Will be adding functions to the Shop Class, that will allow player to buy items: weapons, potions, key items.
    3. More episode/days for singleplayer
        - Currently has one day for the single player adventure 
    


### Visuals

## 1. Menu

![image](DocumentPicture/TopiaMenu.png)

## 2. Introduction In SinglePlayer Format
![image](DocumentPicture/IntroductionTopia.png)

### Object Information


**File**: Game.cs

**Attributes**

         Name: Continue()
             Description: Allows for a simpler way to clear console while letting player time
             Type: public void
         Name: GetInput()
             Description: Allows for the player to input two choices and print why they need to choose options
             Type: public void
         Name: Run()
             Description: This will allow the program to runwhat is inside of it, and only that
             Type: public void
         Name: Start()
             Description: This will happen at the "Start" of Run. everything that is inside of this will run first
             Type: public void
         Name: Update()
             Description: Information inside of update will update the information needed for the game to run.
             Type: public void
         Name: End()
             Description: Anything that is put in this will always be played towards the end of the program before closing.
             Type: public void

**File**: Player.cs

**Attributes**

         Name: AddItemToPocket()
             Description: This will add the item that is chosen and put into the inventory slots
             Type: public void
         Name: Contains()
             Description: This will check if there are items inside of the inventory slots
             Type: public bool
         Name: EquipItem()
             Description: this takes an item from the inventory and applies its stats onto the players stats
             Type: public void
         Name: UnequipItem()
             Description: This takes the item from the player and takes out the items stats from the players stats
             Type: public void
         Name: GetPocket()
             Description: This grabs all the items from the characters pocket
             Type: public Items[]

**File**: AdvancedPlayer.cs

**Attributes**

         Name: PrintAdvancedStats()
             Description: this will print the players stats, the name of it and the number of stat
             Type: public void
         Name: AddInventory()
             Description: Description: This will add the item that is chosen and put into the inventory slots
             Type: public void
         Name: Contains()
             Description: This will check if there are items inside of the inventory slots
             Type: public bool
         Name: EquipItem()
             Description: this takes an item from the inventory and applies its stats onto the players stats
             Type: public void
         Name: UnequipItem()
             Description: This takes the item from the player and takes out the items stats from the players stats
             Type: public void
         Name: GetInventory()
             Description: This grabs all the items from the inventory
             Type: public Items[]
         Name: LevelUp()
             Description: pluses 1 to total level
             Type: public int
         Name: CharismaUp()
             Description: pluses 1 to total charisma
             Type: public int
         Name: KarmaUp()
             Description: pluses 1 to total karma
             Type: public int
         Name: LuckUp()
             Description: pluses 1 to total luck
             Type: public int
         Name: Save1(StreamWriter writer)
             Description: this is a basic save that only save name, health and damage
             Type: public virtual void
         Name: Load(StreamReader reader)
             Description: this is the basic load, it will only load the name, health and damage
             Type: public virtual bool

**File**: Character.cs

**Attributes**

         Name: Attack(Character enemy)
             Description: This will have the player attack the enemy and take points from enemy health
             Type: public virtual float
         Name: TakeDamage(float damageVal)
             Description: this is the basic of one character takes damage of another without classifying which does what
             Type: public virtual float
         Name: Save(StreamWriter writer)
             Description: this is a basic save that only save name, health and damage
             Type: public virtual void
         Name: Load(StreamReader reader)
             Description: this is the basic load, it will only load the name, health and damage
             Type: public virtual bool
         Name: GetName()
             Description: this will get the inputed name and return to where it was asked for
             Type: public string
         Name: GetIsAlive()
             Description: this will see if the character's health is more than 0
             Type: public bool
         Name: GetNotAlive()
             Description: this will see if the character's health is less than 1
             Type: public bool
         Name: PrintStats()
             Description: this will print the players stats, the name of it and the number of stat
             Type: public void
         Name: ChangingRaces()
             Description: [Nothing Right Now]
             Type: public void

**File**: PvP.cs

**Attributes**

         Name: GetInput() < there are multiple
             Description: this will give player list, each item in list is numbered, when they select one of the numbers it will return the value
             Type: public void
         Name: InitionalizeItems()
             Description: this will give the private items value
             Type: public void
         Name: Continue()
             Description: this will give the player time to read something and when they want to go on 
             Type: public void
         Name: Save()
             Description: this will save both players stats
             Type: public void
         Name: Load()
             Description: this will load player previous stats
             Type: public virtual void
         Name: SelectWeapon()
             Description: this will allow players to select a weapon that changes their damage stat
             Type: public void
         Name: StartBattle()
             Description: this is the main part of the PvP program. this will make the players fight each other till one perishes.
             Type: public void
         Name: OpenMenu()
             Description: this will allow player to either create or load player stats
             Type: public void
         Name: CreateCharacter()
             Description: this will create a new player 
             Type: public Player

**File**: SinglePlayer.cs

**Attributes**

         Name: GetInput() < there are multiple
             Description: this will give player list, each item in list is numbered, when they select one of the numbers it will return the value
             Type: public void
         Name: InitionalizeItems()
             Description: this will give the private items value
             Type: public void
         Name: Continue()
             Description: this will give the player time to read something and when they want to go on they can press enter (or any other key) and it will clear the screen
             Type: public void
         Name: OpenMenu()
             Description: this will allow player to either create or load player stats
             Type: public void
         Name: CreateCharacter()
             Description: this will create a new player
             Type: public AdvancedPlayer
         Name: CreateEnemy()
             Description: this will create a new character underneath the tag enemy
             Type: public Player
         Name: Adventure()
             Description: this will
             Type: public void