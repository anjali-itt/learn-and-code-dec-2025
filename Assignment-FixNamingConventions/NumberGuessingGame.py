import random

def is_valid_guess(guess):
    return guess.isdigit() and 1 <= int(guess) <= 100

def number_guessing_game():
    secret_number = random.randint(1, 100)
    guessed_correctly = False
    attempts = 0

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

number_guessing_game()