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

# Out of scope
- gamepad controls
- instant kill my shooting oxygen tank (explosion, enemy leaves no tank behind)
- dynamic lighting
- flamethrower


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
- Enemy AI
	x follows player when near him
	x attack player when in fire range
	- evades when player shoots
	- wanders when far from player
- Bullet collision with walls
- Death animation 
	- lack of oxygen
	- shot
- Kill enemies
- Hit animation
	- blood splatter?
- Oxygen depleting
- Oxygen tank sprite
- Oxygen tank dropping from enemies
- Oxygen tank pickup mechanic
- Armor mechanic
- Store
- Levels (10 max)
- Intro
	- reference LD and theme
	- my info
	- tell the story
- Gameover (permadeath)
- Game finale

