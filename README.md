# LD44
[Ludum Dare 44 Theme](https://ldjam.com/events/ludum-dare/44): Your life is currency

# Ideas
- Bullet hell arena where you can exchange your hearts for weapon upgrades
- Astronaut-stuck in space sim inpired by "Helping Hand" where you can use your limbs to proceed and get replacement ones
- Upgrades can be bought by selling years of life (makes you older, slower and less healthy), fountain of youth can give you years back. Continues are your younger clones.
- You life countdowns in realtime. You are a wizard, you search for a fountain of youth, You can by spells, keys and other stuff for time of your life (e.g. limited to 15 minutes). Balancedthe way so you can barely get to the fountain alive (prices can be dynamic depending on your age). Bring up some moral.
- You are an astronaut with limited oxygen. You are forced to fight in arena with foes (who may also have limited oxygen). You can buy upgrades and weapons for oxygen. Upgrades are depletable. You get oxygen by killing an enemy.

# Scope
x two-stick movement of player character
- firing
- HUD
 - oxygen left
 - armor left
 - weapon name
 - ammo left
- weapons characteristics:
 x type of weapon (only projectile for this project due to limited time)
 x range
 x fire rate (time between shots)
 x projectile speed
 - number of projectiles per burst
 x spread (applied to individual projectiles)
 - damage
 - default amount of ammo
- store	
	- buying items
		- weapons
			x shotgun
			x smg
			x carabiner
			x rifle
		- ammo
		- armor shards
		- speed upgrade
	- selling items
- player can have only two weapons at time (default unlimited pistol and other weapon)
- minimum amount of oxygen is ensured, you cannot have less than 7 seconds of oxygen (last breath)
- animations
 - player death
- enemies vary by:
 - color
 - weapons
 - number of armor shards
 - number of oxygen dropped
 - vision radius
- enemies pathfinding (navagent?)
- arena items
 - droppable oxygen tanks

# Nice to have
- graphic: tube connecting tanks to mask
- graphic: bullet collision with wall
- graphic bullet disappear due to range
- enemy evades when player shoots (just randomly strafe when player shoots?)
- Hit animation
	- enemy: blood splatter?
	- wall: sparks
	- floor: same sparks?
- enemy pushed back when killed
- sound: death enemy
- sound: player death due to lack of oxygen
- hud: oxygen left turns red when less than 10 seconds of oxygen
- screen flashes red when hit

# Out of scope
- gamepad controls
- instant kill my shooting oxygen tank (explosion, enemy leaves no tank behind)
- dynamic lighting
- flamethrower
- go to level exit when all enemies are killed to win
- weapon icons
	- in store
	- in HUD
- lack of oxygen death animation variation


# Name ideas
- till breath do us apart (save the "princess" at the end?)
- oxygen arena
- last breath
- get some air
- thin air



# Plan

x Top Down Character sprite (torso and legs, like in GTA1-GTA2)
x Implement crimson-land-like controls
x Implement shooting with default weapon (pistol projectile/unlimited)
	x Animation
x Player walk animation
x Implement enemies
x Enemy AI
	x follows player when near him
	x attack player when in fire range
	x wanders when far from player
x Bullet collision with walls
x Death animation 
	x shot
x Kill enemies
x Sprites:
	x floor
	x heart for HUD
	x armor for HUD	
	x Oxygen tank sprite
x Oxygen depleting
	x player dies without oxygen
x Oxygen tank dropping from enemies
x Oxygen tank pickup mechanic
x Armor mechanic
x HUD
	x find pixelated free-to-use font
	x enemies left
	x current weapon
		x ammo left
	x oxygen left (mins:seconds and bar?)
	x hearts left
	x armor left
- Store
	- buy weapons
	- buy ammo
	- sell ammo
	- sell weapons
- level changing
	- loading screen? May be useful especially for web GL
- items persist through levels
- Levels (10 max)
	- level win condition (kill all enemies)
	- Gameover (permadeath?)
- Enemy variations
	- with rifle
	- with smg
	- with shotgun
	- with with carbine
- Intro
	- reference LD and theme
	- my info
	- tell the story
- Game finale
- sounds
 x fire
 	- play sound
 x hurt player
 	- play sound
 x hurt enemy
 	- play sound
 - game over
 	- play sound
x music
	- play music on levels
	- play music in intro
	- play music in finale
	- play music in shop
 x some synthed beats? 

