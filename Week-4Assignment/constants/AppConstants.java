package com.constants.AppConstants;

import java.math.BigDecimal;

public class AppConstants {
	public static final BigDecimal MIN_PAYMENT_AMOUNT = 
		new BigDecimal("0.01"); 

	public static final BigDecimal MAX_PAYMENT_LIMIT =
        new BigDecimal("5000");

	public static final int MAX_PAYMENT_RETRIES = 2; 

	public static final String PAYMENT_SUCCESS =
		"Payment successful"; 
	public static final String PAYMENT_FAILED = 
		"Payment failed";
}