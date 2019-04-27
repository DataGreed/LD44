# LD44
[Ludum Dare 44 Theme](https://ldjam.com/events/ludum-dare/44): Your life is currency

# Ideas
- Bullet hell arena where you can exchange your hearts for weapon upgrades
- Astronaut-stuck in space sim inpired by "Helping Hand" where you can use your limbs to proceed and get replacement ones
- Upgrades can be bought by selling years of life (makes you older, slower and less healthy), fountain of youth can give you years back. Continues are your younger clones.
- You life countdowns in realtime. You are a wizard, you search for a fountain of youth, You can by spells, keys and other stuff for time of your life (e.g. limited to 15 minutes). Balancedthe way so you can barely get to the fountain alive (prices can be dynamic depending on your age). Bring up some moral.
- You are an astronaut with limited oxygen. You are forced to fight in arena with foes (who may also have limited oxygen). You can buy upgrades and weapons for oxygen. Upgrades are depletable. You get oxygen by killing an enemy.

# Scope
- two-stick movement of player character
- firing
- HUD
 - oxygen left
 - armor left
 - weapon name
 - ammo left
- weapons characteristics:
 - type of weapon (only projectile for this project due to limited time)
 - range
 - fire rate (time between shots)
 - projectile speed
 - number of projectiles per burst
 - spread (applied to individual projectiles)
 - damage
 - default amount of ammo
- store	
	- buying items
	- weapons
		- shotgun
		- smg
		- carabiner
		- rifle
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



# Name ideas
- till breath do us apart
- oxygen arena
- last breath
- get some air
- thin air



# Plan

- Top Down Character sprite (torso and legs, like in GTA1-GTA2)
- Implement two-stick controls (legs rotate to movement direction, torso to second stick/mouse)
- Implement shooting with default weapon (pistol projectile/unlimited)
