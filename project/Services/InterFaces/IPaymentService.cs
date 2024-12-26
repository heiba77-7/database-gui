

public interface IPaymentService
{
    Payment GetPayment(int id);

    Payment AddPayment(Payment payment);

    Payment UpdatePayment(Payment payment);
    
    Payment DeletePayment(int id);

    Payment GetByOrderID(int orderID);

    List<Payment> GetAllPayments();
}
