package com.utils.NotificationManager; 

public class NotificationManager{
	private NotificationService notificationService; 

	public NotificationManager (
		NotificationService notificationService) {
			this.notificationService = notificationService; 
		}

	public void notifyCustomerAboutProcessedPayment(PaymentRequest request) { 
		notifier.send(
			request.customerId(),
			"Payment of " + request.amount() + " processed"
		);
	} 
}