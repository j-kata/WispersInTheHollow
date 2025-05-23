# Whispers in the Hollow

A text-based adventure game built in C# for practicing object-oriented programming and backend development skills.

## About the Project

This is a study project created to explore and strengthen the following C# and software design concepts:

- Object-Oriented Programming (OOP)
- Class and object design (composition, encapsulation)
- Working with collections and references
- Basic game loop logic
- JSON-based world configuration and deserialization
- Separation of concerns and modular design

The goal is to gradually evolve the project while learning — starting from a console-based game engine with handcrafted logic, and eventually expanding toward more dynamic and backend-inspired patterns.

## Story Summary

You're trapped in a mysterious forest called _The Hollow_. To escape, you must explore a small interconnected world, inspect your surroundings, collect items, and solve simple puzzles.

The game is intentionally lightweight in features, focusing instead on code structure and interaction logic.

## How to Play

When the game starts, you'll be placed in a room and see a short description.

You interact by typing simple commands. For example:

| Command         | Action                                      |
| --------------- | ------------------------------------------- |
| `look`          | Repeats the description of the current room |
| `go north`      | Moves to the room to the north (if allowed) |
| `inspect glint` | Examines something mentioned in the room    |
| `take key`      | Picks up an item                            |
| `inventory`     | Shows what you're carrying                  |
| `help`          | Lists available commands                    |
| `quit`          | Exits the game                              |
