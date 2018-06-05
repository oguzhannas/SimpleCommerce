using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce.Models
{
    public enum OrderStatus
    {
        WaitingPaymentApproval =1,
        PaymentApproved =2,
        PreparingForDelivery=3,
        OnShipping=4,
        DeliverySuccess =5

    }
}
