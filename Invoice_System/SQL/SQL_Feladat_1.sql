select TOP 3 ProductId, SUM(quantity) as quantity  from OrderItems
group by ProductId
order by SUM(quantity) desc