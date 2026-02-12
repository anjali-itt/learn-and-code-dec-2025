using System;
using System.Threading.Tasks;

public class OrderProcessor
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IInventoryService _inventoryService;
    private readonly INotificationService _notificationService;

    public OrderProcessor(
        IPaymentGateway paymentGateway,
        IInventoryService inventoryService,
        INotificationService notificationService)
    {
        _paymentGateway = paymentGateway;
        _inventoryService = inventoryService;
        _notificationService = notificationService;
    }

    public async Task<OrderResult> ProcessOrderAsync(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        if (!IsOrderValid(order))
            return OrderResult.Invalid("Order validation failed");

        if (!await _inventoryService.CheckAvailability(order.Items))
            return OrderResult.Failed("Insufficient inventory");

        await _inventoryService.ReserveItems(order.Items);

        try
        {
            return await ProcessPaymentAndFinalizeAsync(order);
        }
        catch
        {
            // Inventory must be released to avoid dead reservations
            await _inventoryService.ReleaseReservation(order.Items);
            throw;
        }
    }

    private async Task<OrderResult> ProcessPaymentAndFinalizeAsync(Order order)
    {
        var paymentResult = await _paymentGateway.ProcessPayment(
            order.CustomerId,
            order.TotalAmount,
            order.PaymentMethod);

        if (!paymentResult.IsSuccessful)
        {
            await _inventoryService.ReleaseReservation(order.Items);
            return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}");
        }

        await _inventoryService.CommitReservation(order.Items);
        await _notificationService.SendOrderConfirmation(order);

        return OrderResult.Success(paymentResult.TransactionId);
    }

    private bool IsOrderValid(Order order) =>
        order.Items is { Count: > 0 } && order.TotalAmount > 0;

    public async Task CancelOrderAsync(string orderId)
    {
        var order = await GetOrderByIdAsync(orderId);

        if (order.Status == OrderStatus.Paid)
        {
            await RefundPaidOrderAsync(order);
        }

        order.Status = OrderStatus.Cancelled;
        await SaveOrderAsync(order);
    }

    private async Task RefundPaidOrderAsync(Order order)
    {
        await _paymentGateway.RefundPayment(order.TransactionId);
        await _inventoryService.RestoreInventory(order.Items);
    }

    private Task<Order> GetOrderByIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }

    private Task SaveOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
