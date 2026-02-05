# Assignment 3: The below program is to check whether the number is Armstrong number or not

def is_armstrong_number(number: int) -> bool:
    """
    An Armstrong number is equal to the sum of its digits each raised
    to the power of the number of digits. ex: 153 = 1**3 + 5**3 + 5**3
    """
    digits = str(number)
    digit_count = len(digits)
    armstrong_sum = sum(int(digit) ** digit_count for digit in digits)
    return number == armstrong_sum

def get_user_input() -> int:
    while True:
        try:
            return int(input("\nEnter a number to check for Armstrong: "))
        except ValueError:
            print("Invalid input. Please enter a valid integer.")

def display_result(number: int) -> None:
    if number < 0:
        print(f"\n{number} is NOT an Armstrong Number (negative numbers are not considered).")
        return

    if is_armstrong_number(number):
        print(f"\n{number} is an Armstrong Number.\n")
    else:
        print(f"\n{number} is NOT an Armstrong Number.\n")

def main() -> None:
    user_number = get_user_input()
    display_result(user_number)

if __name__ == "__main__":
    main()