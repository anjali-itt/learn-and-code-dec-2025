/* Focus: Apply vertical and horizontal formatting principles 
What Members Will Do: 
1. Analyze poorly formatted working code 
2. Identify formatting violations (vertical and horizontal) 
3. Reformat code following clean code principles 
4. Create team formatting standards document 

Assignment– Clean Code Formatting  
Problem: 
You are given a working Java payment processing class. 
The code follows good design principles, but its formatting is poor. 
Your task is to improve readability by applying all formatting rules from Clean Code – Chapter 5. 
Only formatting is incorrect. Logic must remain unchanged. 


Ordering 
Reorder code as follows: 
1. Constants 
2. Fields 
3. Constructor 
4. Public methods 
5. Private helper methods */

package com.payment.processing;

import java.util.*;
import com.constants.AppConstants;
import com.utils.Validators;
import com.constants.ResultResponses;
import com.utils.NotificationManager; 

public class PaymentProcessor { 
	
	private Logger logger;
	private Map<String,PaymentRecord> paymentHistory; 
	
	public PaymentProcessor(
		Logger logger,
		Map<String,PaymentRecord> paymentHistory) { 
			this.logger = logger;
			this.paymentHistory = new HashMap<>();
		} 

		public PaymentResult processPayment(PaymentRequest request) { 
			Validators.validateRequest(request); 

			int attempt = 0; 
			while(attempt < AppConstants.MAX_RETRIES) { 
				try {
					processSingleAttempt(request);
					return ResultResponses.successResult;
				} 
				catch(PaymentException e) { 
					attempt++; 
					logger.log("Retry attempt: " + attempt); 
				}
			}
			return ResultResponses.failureResult(request);
		} 

		private void processSingleAttempt(PaymentRequest request) {
			executePayment(request); 
			recordPayment(request); 
			NotificationService.notifyCustomerAboutProcessedPayment(request); 
		}
		
		private void executePayment(PaymentRequest request) { 
			logger.log("Executing payment of " + request.amount()); 
			if(request.amount().compareTo(AppConstants.MAX_PAYMENT_LIMIT > 0) { 
				throw new PaymentException("Limit exceeded");
			}
		} 
		
		private void recordPayment(PaymentRequest request) { 
			history.put(generateTransactionId(), 
			new PaymentRecord(
				request.customerId(),
				request.amount(),
				LocalDateTime.now()
			));
		}
)}