


**Decorator**
-----------------

***Definition:*** Attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to sub-classing for extending functionality. 

**Intent**: Client-specified embellishment of a core object by recursively wrapping it. 

**Problem solved by this pattern:** You want to add behavior or state to individual objects at run-time. Inheritance is not feasible because it is static and applies to an entire class. Avoids class explosion.

**Participants:**

 1. **Component** - defines the interface for objects that can have responsibilities added to them dynamically. 
 2. **Concrete Component** - defines an object to which additional responsibilities can be attached. 
 3. **Decorator** - maintains a reference to a *Component* object and defines an interface that conforms to Component's interface. 
 4. **Concrete Decorator** - adds responsibilities to the component.


