using ApplicaicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicaicationLayer.Interfaces
{
    public interface ICreateOrderHandler
    {
        Task Handle(CreateOrderRequest orderRequest);
    }
}
