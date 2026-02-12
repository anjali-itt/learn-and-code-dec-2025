using System;
using System.Threading.Tasks;

public class OrderProcessor
{
	private readonly IPaymentGateway _paymentGateway;
	private readonly IInventoryService _inventoryService;
	private readonly INotificationService _notificationService;

	public OrderProcessor(IPaymentGateway paymentGateway,
		IInventoryService inventoryService,
		INotificationService notificationService)
	{
		_paymentGateway = paymentGateway;
		_inventoryService = inventoryService;
		_notificationService = notificationService;
	}

	// This method processes an order  -  Redundant Comment
	public async Task<OrderResult> IdentifiedCommentsInProcessOrder(Order order)
	{
		// Check if order is null  -  Redundant Comment
		if (order == null)
		{
			throw new ArgumentNullException(nameof(order));
		}

		// Validate the order  -  Redundant Comment
		if (!IsValidOrder(order))
		{
			return OrderResult.Invalid("Order validation failed");
		}

		// Check inventory  -  Noise Comment
		bool hasInventory = await _inventoryService.CheckAvailability(order.Items);

		// If no inventory, return failure  -  Noise Comment 
		if (!hasInventory)
		{
			return OrderResult.Failed("Insufficient inventory");
		}

		// Reserve inventory  -  Noise Comment
		await _inventoryService.ReserveItems(order.Items);

		try
		{
			// Process payment  -  Redundant Comment
			var paymentResult = await _paymentGateway.ProcessPayment(
				order.CustomerId,
				order.TotalAmount,
				order.PaymentMethod);

			// Check if payment succeeded  -  Noise Comment
			if (paymentResult.IsSuccessful)
			{
				// Update inventory  -  Noise Comment
				await _inventoryService.CommitReservation(order.Items);

				// Send confirmation email  -  Redundant Comment 
				await _notificationService.SendOrderConfirmation(order);

				// Return success  -  Redundant Comment
				return OrderResult.Success(paymentResult.TransactionId);
			}
			else
			{
				// Payment failed, release inventory  -  Noise Comment
				await _inventoryService.ReleaseReservation(order.Items);

				// Return failure  -  Noise Comment
				return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}");
			}
		}
		catch (Exception ex)
		{
			// Something went wrong  -  Misleading Comment
			await _inventoryService.ReleaseReservation(order.Items);

			// Log the error  -  Noise Comment
			Console.WriteLine($"Error: {ex.Message}");

			// Throw it  -  Redendant Comment
			throw;
		}
	}

	private bool IsValidOrder(Order order)
	{
		// TODO: Fix this later  - TODO Comment
		return order.Items?.Count > 0 && order.TotalAmount > 0;
	}

	// Added by John on 12/15/2023 - needed for the new feature  - Journal Comment
	public async Task CancelOrder(string orderId)
	{
		// Get the order  -  Redundant Comment
		var order = await GetOrderById(orderId);

		// John says we need to refund here  -  Journal Comment
		if (order.Status == OrderStatus.Paid)
		{
			// Refund the payment  -  Redundant Comment
			await _paymentGateway.RefundPayment(order.TransactionId);

			// Give back the items  -  Noise Comment
			await _inventoryService.RestoreInventory(order.Items);
		}

		// Update status  -  Noise Comment
		order.Status = OrderStatus.Cancelled;

		// This is important!!!  -  Emotional Comment
		await SaveOrder(order);
	}

	// Gets order by ID  -  Redundant Comment
	private async Task<Order> GetOrderById(string orderId)
	{
		// Implementation here  -  Noise Comment
		return await Task.FromResult(new Order());
	}

	// Saves the order  -  Redundant Comment
	private async Task SaveOrder(Order order)
	{
		// Implementation here   -  Noise Comment
		await Task.CompletedTask;
	}
}