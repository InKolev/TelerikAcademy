
**Singleton**
-------------

***Definition:*** The Singleton class is a class that is supposed to have only one (single) instance inside the whole system and provides a global point of access to it.

***Participants:***
**Singleton** - defines an Instance operation that lets clients access its unique instance. Instance is a class operation responsible for creating and maintaining its own unique instance.

**Benefits of Singleton over Static**

 1. They don't pollute the global namespace (or, in languages with namespaces, their containing namespace) with unnecessary variables.
 2. They permit lazy allocation and initialization, whereas global variables in many languages will always consume resources. 
 3. They allow inheritance (polymorphism in general). Unlike static classes, we can use singletons as parameters or objects. 
 4. Hint: Static classes are lazy in many languages, they are not initialized until they are called.

**Possible problems:** 

 1. Lazy loading (created when first needed). Default implementation (is not thread-safe and) should not be used in multi-threaded environments.
 2. Singleton introduces tight coupling among collaborating classes.
 3. Singletons are difficult to test. Violates SRP (Single
    Responsibility Principle) – by merging 2 responsibilities: managing object lifetime and the type itself.

**Abstract Factory**
----------------

***Definition:*** Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

***Participants:***
**Abstract Factory** - declares an interface for operations that create abstract products.
**Concrete Factory**  - implements the operations to create concrete product objects.
**Abstract Product**  - declares an interface for a type of product object.
**Product** - defines a product object to be created by the corresponding concrete factory, implements the Abstract Product interface.
**Client** - uses interfaces declared by Abstract Factory and Abstract Product classes.

**Builder**
-------

***Definition:*** Separates the construction of a complex object from its representation so that the same construction process can create different representations.

***Participants:*** 
**Builder** - specifies an abstract interface for creating parts of a Product object
**Concrete Builder**  - constructs and assembles parts of the product by implementing the Builder interface, defines and keeps track of the representation it creates, provides an interface for retrieving the product
**Director** - constructs an object using the Builder interface
**Product** - represents the complex object under construction. 
The Concrete Builder builds the product's internal representation and defines the process by which it's assembled, includes classes that define the constituent parts, including interfaces for assembling the parts into the final result.
