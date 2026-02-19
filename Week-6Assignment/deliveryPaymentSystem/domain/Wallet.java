package domain;

import common.Messages;

public class Wallet {

    private double balance;

    public Wallet(double initialBalance) {
        if (initialBalance < 0) {
            throw new IllegalArgumentException(Messages.NEGATIVE_INITIAL_BALANCE);
        }
        this.balance = initialBalance;
    }

    public boolean debit(double amount) {
        validateAmount(amount);

        if (balance >= amount) {
            balance -= amount;
            return true;
        }

        return false;
    }

    private void validateAmount(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException(Messages.INVALID_AMOUNT);
        }
    }
}