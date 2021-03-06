﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KaliGasService.Core.Domain;

namespace Warehousing.Domain.Product.Events
{
    public class ProductPickedEventHandler : IDomainEventHandler<ProductPickedEvent>
    {
        private readonly IProductHistoryLineRepository _productHistoryLineRepository;

        public ProductPickedEventHandler(IProductHistoryLineRepository productHistoryLineRepository)
        {
            _productHistoryLineRepository = productHistoryLineRepository;
        }

        public Task Handle(ProductPickedEvent productPickedEvent, CancellationToken cancellationToken = default)
        {
            _productHistoryLineRepository.Insert(
                new ProductHistoryLine(
                    productPickedEvent.ProductId, 
                    productPickedEvent.Quantity,
                    ProductHistoryType.Pick,
                    DateTime.Now));

            return Task.CompletedTask;
        }
    }
}
