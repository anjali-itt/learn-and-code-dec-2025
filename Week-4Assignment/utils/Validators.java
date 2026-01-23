package com.utils.Validators;	

import com.constants.AppConstants
import java.math.BigDecimal;

public class Validators { 
	public void validatePaymentRequest(PaymentRequest request) { 
		if(request.customerId() == null ||
		request.customerId().isBlank()) {
			throw new IllegalArgumentException("Customer ID required");
		} 
		validatePaymentAmount(request.amount)
	}
			
	public void validatePaymentAmount(BigDecimal amount) {
		if(amount == null ||
		amount.compareTo(AppConstants.MIN_PAYMENT_AMOUNT) < 0){
			throw new IllegalArgumentException("Invalid amount");
		}
	}
}