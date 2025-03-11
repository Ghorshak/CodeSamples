# CodeSamples
 
CodeSamples repository have some various systems without whole unity project setup like other my repositories.
They can be added directly to the project.

**Colliders Registration System**

The system allows for registering collider-object pairs. Thanks to this, after such registration, you can easily associate a collider with a selected object.
As a result, such expensive external calls as `GetComponent` are executed only once when registering a pair, and all subsequent queries can be directed to the registry with cached pairs - it will return the appropriate object based on the key (collider).
Useful in functionalities such as OnTriggerEnter/Exit/Stay or OnCollisionEnter/Exit/Stay, especially if they are used often.


**Settings System**

The system allows for game settings creation and configuration.
In this example there are 2 types of settings created: range of values (i.e. for sliders and toggles) and named values (i.e. dropdowns). It comes with 5 settings: Music Mute and Volume, Sfx Mute and Volume and Texture Quality (Low, Medium, High, Ultra) and they use PlayerPrefs to save and load data.
In addition there is a simple UI scene ready for testing.
