# Fundamentals of Games Development Project

**Unit Name:** FGCT4015 - Fundamentals of Games Development

**Student Name:** Richard James Mann

**Student ID:** 2317919

**Total Word Count:** XXXX

**Repository Link:** https://github.com/moss0/Egg_group_project

**Build Link:** https://moss-0.itch.io/egg-themed-project

**Video Demonstration Link:** https://dai.ly/k5IAnoxPRp0DYlDlWIO

---

## Abstract *(Approx. 5–10% of word count | 100–300 words)*

Summarise your task, goals, approach, and final outcome. What was the intent of your work? What is the most important thing to know before reading on?

<br>

The task is to create a game themed around the topic: egg, using the Unity Engine and writing scripts in C#, and then publish it onto itch.io as a WebGL game.

My goal is to create a 3 Dimensional platforming game that revolves around getting an egg, which is controlled by the player, to the end of a handful of obstacle courses with a number of bugs as close to zero as possible.

I decided to keep the project at a realistic scope and decided upon four levels seeing as I was working alone in what was supposed to be a two person group.

I feel as though I achieved the objective I set and perhaps a little extra. The project shows that I have a decent foundation of knowledge in regards to the Unity Engine and C# although there are some concepts I have not used such as Inheritance.

---

## Research *(Approx. 20-30% of word count)*

### What sources or references have you identified as relevant to this task?

Reflect on the **type** and **relevance** of sources explored. Justify your research direction in relation to the task brief and target outcomes.

* What types of sources did you explore and why?
* Which types of sources did you avoid and why?
* How does the research relate to the user experience, technical approach, or creative aim?

#### Sources

[Raycasts in Unity (made easy) - by Game Dev Beginner](https://www.youtube.com/watch?v=B34iq4O5ZYI)  
This YouTube Unity Engine tutorial was made by a YouTuber called "Game Dev Beginner" who creates popular tutorials that recieves many views and numerous positive comments commending their usefulness.
>I learned how the raycast functions work and their various inputs.

>I became aware of all the different types of raycast available in Unity.

I applied this learning to my camera system in order to prevent the camera from clipping through walls and floors.

[Unity - Scripting API](https://docs.unity3d.com/6000.1/Documentation/ScriptReference/index.html)  
This is the official Unity Engine scripting guide. It is from Unity itself, so it is reliable to use.

> Learned about functions and variables I was not familiar with, for example, Rigidbody, Collider, Mathf functions.

For example, I used Mathf for its clamping function to restrict certain values in my clamping script. Collider for its CompareTag function in my TriggerDetector script. RigidBody for its constrains and velocity. Limitations include not being able to ask questions and only look up terms, however there are other software best suited to that role.

[The right way to pause a game in Unity - by Game Dev Beginner](https://www.youtube.com/watch?v=ROwsdftEGF0)  
This YouTube Unity Engine tutorial was made by a YouTuber called "Game Dev Beginner" who creates popular tutorials that recieves many views and numerous positive comments commending their usefulness.

> I used this source to create my pausing system, by setting the timescale to 0 if paused, and to 1 when unpausing. I also bound a pause menu to the game to create a user friendly experience.

It was not complicated to use this source at all.

[The Ultimate Introduction to Scriptable Objects in Unity - by samyam](https://www.youtube.com/watch?v=cy49zMBZvhg)


I used a scriptable object to track whether or not the player is alive or dead without having the other script instances that need to follow this variable store a reference to the player script. In retrospect, I realise that I could have used an event.

I created a scriptable object called "LevelManager" and intended to have all sorts of other variables but, I was not able to implement them.

[Unity Learn](https://learn.unity.com/)

This is an official tutorial resource from Unity, featuring many text and video tutorial which singlehandedly taught me the basics of C# in Unity. It has been invaluable to me teaching me classes, switch statements, and properties for example.

[Maths is fun - Vectors](https://www.mathsisfun.com/algebra/vectors.html)

This simple Mathematics website has taught me many things during my A-Level and GCSEs. They make a wide variety of concepts simple and fun to learn and I used it here to learn about Vectors.

> I learnt about Vectors, how adding, subtracting, and multipling them works.

> I used this for my camera script regarding adjusting the camera to move out of clipping geometry and in the player script, for example.

---

## Implementation *(Approx. 30–40% of word count)*

### What was your development process and how did decisions evolve?

Describe your technical and creative approach, including:

* Planning, ideation, and iteration
* Feedback received and how it was integrated
* New tools, workflows, or systems explored

I started this project off a copy of a previous game I made called "PlatformerGame" which featured a ball that is continuously bouncing off the ground and you must navigate through obstacle courses to reach the end of the level. I made this decision of using a previous project I worked on earlier in the year as a base since this egg themed project was originally a group project, however, I was the sole member and needed to make the workload more managable for one person.

![name](https://file.garden/aG_d-JVriWyKKSKN/Capture.PNG)
*Figure 1: The game I used as my base called: "PlatformerGame".*

I made my own 3D egg player model and an alternative broken version which is composed of seperate split pieces of the egg, and every broken fragment aligns together to create the egg model. Later, I used these broken egg fragments for when the player dies/fails.

| ![](https://file.garden/aG_d-JVriWyKKSKN/Capture2.PNG) | ![](https://file.garden/aG_d-JVriWyKKSKN/Capture3.PNG) |
|---|---|
| *Figure 2: The simple egg model I made.* | *Figure 3: The broken egg fragment models fitting together to form the egg's shape with one of the models selected within the prefab.*|

I decided the egg should break by cracking open, so I created a prefab where each broken egg fragment model is a child of the prefab with their own rigidbodies and colliders on them. 

Originally, the idea was to destroy the player gameObject and spawn the broken egg prefab, however, when you destroy the player, the camera is also removed as it is a child of the gameObject, which prevents the player from seeing their miserable end.

The final result was that upon the player getting killed, a broken egg prefab gets spawned at the player's position with its rotation, then, the player's egg model gets rendered invisible, becomes frozen in place, and get its collider disables as to not interfere with the broken egg part rigidbodies (see figure 6). I did this so I could move the camera around the player's point of death so they can see the egg falling apart and think about what went wrong.

| ![](https://file.garden/aG_d-JVriWyKKSKN/Capture5.PNG) | ![](https://file.garden/aG_d-JVriWyKKSKN/Capture4.PNG) |
|---|---|
| *Figure 4: The egg after touching a source of damage and being cracked apart.* | *Figure 5: The hierarchy of the broken egg prefab.* |

```csharp
_player.transform.parent = null;

Transform playerStoreTransform = _player.transform;

_player.GetComponent<Renderer>().enabled = false;

Rigidbody rb = _player.GetComponent<Rigidbody>();
rb.constraints = RigidbodyConstraints.FreezeAll;

Collider collider = _player.GetComponent<Collider>();
collider.enabled = false;

Instantiate(eggBrokenPrefab, playerStoreTransform.transform.position, playerStoreTransform.transform.rotation);
levelManager.playerAlive = false;
```
*Figure 6: Readying the player for death.*

I noticed that when moving about the third-person camera in 3D space, that the camera can freely pass through everything, including the ground and walls, so I set out to create a system to prevent this.

My first idea was to use a raycast starting at the player and ending after a distance float variable called "_currentZoomDistance" alongside vector mathematics to move the camera's position towards the player's position along the vector between the hit point and the player such that the camera would rest on the surface of the colliding geometry if the raycast hits. I used most of this idea in the final result, however, I realised that having the camera rest on the edge of the collider would cause the camera view to clip within the collider, causing the player to see through it.

I mitigated this by, if the raycast hits, taking the difference between the hit point and the player's position. Then multiplying this difference by a scale factor of, for example, 0.9f, would give 90% along the vector, leaving a 10% of the differences length between the hit point and the camera and finally, setting the camera's position to be equal to the player's position plus the aforementioned product to move the vector to the correct position. This brings the camera closer to the player when the raycast hits an object that blocks view.

```csharp
transform.rotation = targetRotation;
if (Physics.Raycast(player.position, targetRotation * Vector3.back, out hit, _currentZoomDistance, 1, QueryTriggerInteraction.Ignore))
{
    Vector3 vectDiff = hit.point - player.position;
    transform.position = player.position + vectDiff * camSnapMultiplier;
    Debug.DrawRay(player.position, vectDiff , Color.blue);
    Debug.DrawRay(player.position, vectDiff * camSnapMultiplier, Color.yellow);
    //print("hit");
}
else
{
    transform.position = player.transform.position - targetRotation * Vector3.forward * _currentZoomDistance;
    Debug.DrawLine(player.position, transform.position , Color.red);
}
```

| ![](https://file.garden/aG_d-JVriWyKKSKN/Capture7.PNG) | ![](https://file.garden/aG_d-JVriWyKKSKN/Capture6.PNG) |
|---|---|
| *Figure : The camera not being blocked by geometry, represented by the red color.⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀* | *Figure : The camera being blocked by geometry, the 0.85f multiplication on the vector determines where the camera should be to prevent clipping. Here, the blue debug line is the reduced amount and the yellow is what is left.* |

<br>

<br>

### What creative or technical methods did you try?

Were any methods unfamiliar or experimental? Did they succeed? Did they change your approach?

### Did you experience any technical challenges?

How did you address problems, bugs, or limitations?

---

## Testing *(Approx. 10–15% of word count)*

### What testing methods did you use?

* Did you conduct internal testing, peer testing, or user testing?
* What were your key goals in testing?
* What did you observe or learn from testing?
* How did testing influence the final result?

I play tested the game myself, frequently testing new features I added in the editor to ensure there were no bugs. I did not gather any data, however, it runs at a consistent 60 frames per second on my machine. I decided to limit the frame rate to 60 to prevent my home computer from being loud and making testing faster.


---

## Critical Reflection *(Approx. 10–15% of word count)*

### What went well?

I reached my goal of creating a handful of levels with a platformer that has 
I am pleased with the outcome of this project, nothing exceeded my expectations, I could have done more I feel if I pushed myself harder, however I will leave it as a work in progress.

I am most proud of my relative platform as it took a while to make it work and the transition between getting on and off work and preventing the scale from being warped due to the parenting and it taught me alot about how children and their scale work in Unity.

### What could be improved or done differently next time?

I have yet to work on anything audio related which has been a consistent trait of mine so far, however, I plan to implement it into my future titles. 
I thought about having the end goal being a frying pan you have to reach in order to become a scrambled egg with a short cutscene and a level win tracking mechanic to track your progress through the levels.
I also would have liked to add textures and other props to make the environment more interesting to look at.



---

## Bibliography

Raycasts in Unity (made easy) (2022) At: https://www.youtube.com/watch?v=B34iq4O5ZYI (Accessed  14/07/2025).

Technologies, U. (s.d.) Unity - Scripting API:. At: https://docs.unity3d.com/6000.1/Documentation/ScriptReference/index.html (Accessed  14/07/2025).

The right way to pause a game in Unity - YouTube (s.d.) At: https://www.youtube.com/watch?v=ROwsdftEGF0&list=PLE67WdbGlOJ_SO8ugv7rMY9vyx0fgzig7&index=30&t=72s (Accessed  14/07/2025).

The Ultimate Introduction to Scriptable Objects in Unity (2022) At: https://www.youtube.com/watch?v=cy49zMBZvhg (Accessed  14/07/2025).

Unity Learn (s.d.) At: https://learn.unity.com (Accessed  14/07/2025).

Vectors (s.d.) At: https://www.mathsisfun.com/algebra/vectors.html (Accessed  14/07/2025).


---

## Declared Assets



---

## Tips for Success

* Use plenty of **images, code snippets, drawn diagrams, tables and embedded media** to support your writing.
* Use **inline citations** for everything that influenced your work, including software and games. Include as many **hyperlinks** as possible for easier navigation to external sources.
* Reference **documentation, tutorials**, and **games** just like academic sources.
* Word count is a guideline – ±10% is allowed.
* You are allowed to use AI tools, but you **must declare** them under *Declared Assets*.