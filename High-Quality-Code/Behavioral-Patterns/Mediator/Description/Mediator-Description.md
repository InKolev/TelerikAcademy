**Mediator**
--------
***Definition:*** Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

**Intent:** Design an intermediary to decouple many peers. Promote the many-to-many relationships between interacting peers to "full object
    status".

**Problem (which is solved through this pattern): ** We want to design reusable components, but dependencies between the potentially reusable pieces demonstrates the "spaghetti code" phenomenon (trying to scoop a single serving results in an "all or nothing clump").

**Structure:** Colleagues (or peers) are not coupled to one another. Each talks to the Mediator, which in turn knows and conducts the orchestration of the others. The "many to many" mapping between colleagues that would otherwise exist, has been "promoted to full object status". This new abstraction provides a locus of indirection where additional leverage can be hosted.

**Check list:**

 1. Identify a **collection of interacting objects** that would benefit from **mutual decoupling**.
 2. Encapsulate those interactions in the abstraction of a new class.
 3. Create an instance of that new class and rework all "peer" objects to interact with the Mediator only.
 4. Balance the principle of decoupling with the principle of distributing responsibility evenly.
 5. Be careful **not to create a** **"controller"** or **"god"** object.