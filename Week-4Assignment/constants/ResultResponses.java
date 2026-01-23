package com.constants.ResultResponses;

import com.constants.AppConstants

public class ResultResponses {
	public PaymentResult successResult(PaymentRequest request) {
		return new PaymentResult( 
			true,
			AppConstants.PAYMENT_SUCCESS, 
			generateTransactionId())
	}
	
	public PaymentResult failureResult(PaymentRequest request) {
		return new PaymentResult(
			false,
			AppConstants.PAYMENT_FAILED,
			null)
	}
}