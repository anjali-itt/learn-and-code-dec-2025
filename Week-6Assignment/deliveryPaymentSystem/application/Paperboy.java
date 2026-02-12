package application;

import domain.customer.Customer;

public class Paperboy {

    public void collectPayment(Customer customer, double amount) {
        boolean paymentSuccessful = customer.pay(amount);

        if (!paymentSuccessful) {
            System.out.println("Payment failed. Will come back later.");
        }
    }
}