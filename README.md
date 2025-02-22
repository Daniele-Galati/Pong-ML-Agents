# Simple Pong AI with Unity's ML-Agents Package
## Description
I used this simple project to gain confidence in the ML-Agents package. In the default scene, the green player is controlled by the user, while the red one by the AI.
To make a mirror match AI vs AI, it is sufficient to restore the Behavior Type inside the *Behavior Parameters* to its default setting.

## Further improvements
The agent scripts work inside the fixed update method, thus using the same script for the player gives sluggish feedback.

## Python packages versions
Since I had many version conflicts while installing _mlagents_ and _tensorflow_ with pip, here's a list of the versions I've used to make everything work together:
- numpy: 1.23.5
- mlagents: 1.1.0
- tensorflow: 2.14.0
