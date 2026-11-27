# Last Descent

A 3D Unity sci-fi platformer set in a futuristic space colony. Explore neon-lit habitats, move between elevated platforms, and navigate darker industrial areas.

**[▶ Watch or download the gameplay demo](https://github.com/shaahinnn/Last-Descent/releases/download/demo-v1.0/Last.Descent.mp4)**

## Gameplay systems

- 3D movement and platforming
- Hazards and environmental navigation
- Gameplay UI and player feedback
- Low-poly sci-fi environments

## Technical breakdown

- **Movement:** `Movement` reads thrust and rotation input actions, applies thrust through a `Rigidbody`, and drives booster, particle, and audio feedback.
- **Collision and outcomes:** `CollisionHandler` handles hazards, health display, finish/win states, and the related success or failure feedback.
- **Level interaction:** `Oscillator` moves platforms or hazards between configured endpoints using a ping-pong motion.
- **Challenge:** Make movement and collision results legible during play. Input feedback, health changes, and win/failure transitions are handled by gameplay components rather than relying on environment visuals alone.

## Screenshots

### Title screen
![Last Descent title screen showing a futuristic space colony and shuttle](Screenshots/title-screen.png)

### Exploring the colony
![Astronaut moving through a dimly lit space-colony area](Screenshots/gameplay-astronaut.png)

### Neon-lit platforming area
![Astronaut navigating a futuristic platforming area with glowing structures](Screenshots/gameplay-platforms.png)

### Dark industrial area
![Astronaut above hazards in a dark industrial area](Screenshots/gameplay-dark-area.png)

## Open the project

1. Clone or download this repository.
2. Open the project folder in Unity Hub.
3. Use the Unity Editor version listed in `ProjectSettings/ProjectVersion.txt`.