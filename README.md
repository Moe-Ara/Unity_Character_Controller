# Unity Character Controller with Physics

This Unity project provides a versatile character controller that utilizes physics for smooth and realistic character movements. The controller is built with a state-based system to manage various actions, keeping the code organized and extensible. The character can perform actions such as dashing, sliding, jumping, crouching, sprinting, walking, and walking on slopes. Please note that stairs implementation is a work in progress.

## Features

- **State-based System:** The character controller uses a state machine to manage different actions and movements. Each state encapsulates specific behavior, making the code modular and clean.

- **Physics-based Movement:** The character's movements are based on Unity's physics engine, providing realistic and responsive interactions with the environment.

- **Dash:** Execute a quick dash in the specified direction. This can be useful for evading obstacles or closing distances rapidly.

- **Slide:** Perform a sliding motion, allowing the character to pass through tight spaces or navigate slopes smoothly.

- **Jump:** Jump to overcome obstacles or reach higher platforms. The jump height and duration can be adjusted based on the game's requirements.

- **Crouch:** Toggle between standing and crouching positions, useful for navigating confined spaces.

- **Sprint:** Increase movement speed for a short duration to cover ground quickly.

- **Walk:** Move at a slower pace, suitable for precise control and exploration.

- **Walk on Slopes:** The character smoothly navigates sloped surfaces, maintaining a natural movement feel.

- **Stairs (Work in Progress):** Implementation for walking up and down stairs is still in progress and will be added in future updates.

## Usage

1. Clone or download the repository.
2. Open the project in Unity.
3. Navigate to the scene containing the character controller.
4. Attach the `CharacterController` script to your character GameObject.
5. Adjust the parameters and settings in the inspector as needed.
6. Play the scene to test the character controller.

## Contributing

Contributions are welcome! If you have ideas, improvements, or bug fixes, feel free to submit a pull request. Make sure to follow the existing coding style and include appropriate comments.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Special thanks to the Unity community for inspiration and support.

Feel free to use, modify, and extend this character controller for your Unity projects. Happy coding!
