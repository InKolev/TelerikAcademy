**Memento**
-------

**Definition:** Without violating encapsulation, capture and externalize an object's internal state so that the object can be returned to this state later. Promote undo or rollback to full object status.

**Problem solved through this pattern:** Need to restore an object back to its previous state (e.g. "undo" or "rollback" operations).

**Short description**: The client requests a Memento from the source object when it needs to checkpoint the source object's state. The source object initializes the Memento with a characterization of its state. The client is the "care-taker" of the Memento, but only the source object can store and retrieve information from the Memento (the Memento is "opaque" to the client and all other objects). If the client subsequently needs to "rollback" the source object's state, it hands the Memento back to the source object for reinstatement.

An unlimited "undo" and "redo" capability can be readily implemented with a stack of Command objects and a stack of Memento objects.

**The Memento design pattern defines three distinct roles:**

 1. Originator - the object that knows how to save itself. 
 2. Caretaker - the object that knows why and when the Originator needs to save and restore itself. 
 3. Memento - the lock box that is written and read by the Originator, and shepherded by the Caretaker.

**Check list:**

 1. Identify the roles of “caretaker” and “originator”. 
 2. Create a Memento class and declare the originator a friend. 
 3. Caretaker knows when to "check point" the originator. 
 4. Originator creates a Memento and copies its state to that Memento. 
 5. Caretaker holds on to (but cannot peek into) the Memento. 
 6. Caretaker knows when to "roll back" the originator.
 7. Originator reinstates itself using the saved state in the Memento.