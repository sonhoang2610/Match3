# MATCH 3 IEC



## Getting started
# 3 Step improve performance
 + Pool to recycle item object no more GC alloc  (Item.cs)
 + Pack UI and item to sprite atlas reduce drawcall from 9 to 3
 + Change Physic2D raycast to RaycastNonAlloc prevent GCAlloc in update
 + Disable Physic2D autoSyncTransform and simulationMode change to Scripts mode no need because only use raycast for input
 
 # Add restart button second top left button ingame panel
 
 # Add button change theme on runtime in game panel
  
 # Edit the FillGapsWithNewItems function (of the Board class) to create a new item different from the 4 surrounding cells. At the same time, prioritize choosing the type of item that has the least amount on the board.

