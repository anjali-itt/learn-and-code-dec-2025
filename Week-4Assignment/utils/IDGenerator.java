package com.utils.IDGenerator;

import java.time.LocalDateTime;

public class IDGenerator { 
	public String generateTransactionId(){ 
		return "TXN-" + System.currentTimeMillis();
	} 
}