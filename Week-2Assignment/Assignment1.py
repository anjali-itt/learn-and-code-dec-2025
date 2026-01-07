# Assignment 1: The below program is to guess the correct number between 1 to 100

import random

def is_valid_guess(guess: str) -> bool:
    return guess.isdigit() and 1 <= int(guess) <= 100

def play_guessing_game() -> None:
    secret_number = random.randint(1, 100)
    attempts = 0
    guessed_correctly = False

    guess = input("Guess a number between 1 and 100: ")

    while not guessed_correctly:
        if not is_valid_guess(guess):
            guess = input("Invalid input. Please enter a number between 1 and 100: ")
            continue

        guess_int = int(guess)
        attempts += 1

        if guess_int < secret_number:
            guess = input("Too low. Guess again: ")
        elif guess_int > secret_number:
            guess = input("Too high. Guess again: ")
        else:
            print(f"You guessed it in {attempts} guesses! The number was {secret_number}.")
            guessed_correctly = True

def main() -> None:
    play_guessing_game()

if __name__ == "__main__":
    main()