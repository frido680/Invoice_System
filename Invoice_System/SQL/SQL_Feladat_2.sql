select distinct OrderId from OrderItems
inner join Products on Products.Id = OrderItems.ProductId
where Products.IsHazardous = 1