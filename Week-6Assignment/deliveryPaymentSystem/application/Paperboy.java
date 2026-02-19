package application;

import domain.Customer;
import common.Messages;

public class Paperboy {

    public void collectPayment(Customer customer, double amount) {
        boolean paymentSuccessful = customer.pay(amount);

        if (paymentSuccessful) {
            System.out.println(Messages.PAYMENT_SUCCESS);
        } else {
            System.out.println(Messages.PAYMENT_FAILED);
        }
    }
}