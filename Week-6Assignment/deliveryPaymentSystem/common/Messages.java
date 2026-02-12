package com.delivery.common;

public final class Messages {

    private Messages() { }

    public static final String PAYMENT_SUCCESS =
            "Payment collected successfully.";

    public static final String PAYMENT_FAILED =
            "Payment failed. Will come back later.";

    public static final String INVALID_AMOUNT =
            "Amount must be positive.";

    public static final String NEGATIVE_INITIAL_BALANCE =
            "Initial balance cannot be negative.";
}
