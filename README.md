# CodeSamples
 
CodeSamples repository have some various systems without whole unity project setup like other my repositories.
They can be added directly to the project.

**CollidersRegistrationSystem**
The system allows for registering collider-object pairs. Thanks to this, after such registration, you can easily associate a collider with a selected object.
As a result, such expensive external calls as `GetComponent` are executed only once when registering a pair, and all subsequent queries can be directed to the registry with cached pairs - it will return the appropriate object based on the key (collider).
Useful in functionalities such as OnTriggerEnter/Exit/Stay or OnCollisionEnter/Exit/Stay, especially if they are used often.
