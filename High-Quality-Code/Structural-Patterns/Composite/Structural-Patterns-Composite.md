**Composite**
---------

***Definition:*** Compose objects into ***tree structures*** to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

**Problem solved through this pattern:** Application needs to manipulate a hierarchical collection of "primitive" and "composite" objects. Processing of a primitive object is handled one way, and processing of a composite object is handled differently. Having to query the "type" of each object before attempting to process it **is not desirable**.

**Short description:** Define an abstract base class (Component) that specifies the behavior that needs to be exercised uniformly across all primitive and composite objects. Subclass the Primitive and Composite classes off of the Component class. Each Composite object "couples" itself only to the abstract type Component as it manages its "children".

Use this pattern whenever you have "composites that contain components, each of which could be a composite".



