# MEP - Custom stock manager application for a waterproof paint factory

## About this project
This WinForms application was thought to operate with 3 main functions:
- Add painting productions 	( + major product stock, - raw product stock )
- Add order sales 			( - major product stock )
- Add raw product stock 	( + raw product stock )

With just these 3 things, you can practically control and manage the raw materials and major products in the factory.
It was thought to be flexible to changes in the factory, so new products, new raw materials, new recipes, etc. can be added.
But it is not at all flexible to implement this app in a different factory. It has custom business logic that is not configurable.

Horrible code btw...i was learning C# and object oriented programming while i made this project...
But I think I did a very good job with the graphical interface (Windows Forms).

## More details

The program uses SQLite for the database and some HTML and CSS to create some reports.

## Images

Graphic interface mainly consist in a side by side panels view.

 ![](Mep3.0/Resources/showcase/ProductionPanel.png)
 >  Left side: Major product stock panel. Right side: Production input panel.
 
 
 ![](Mep3.0/Resources/showcase/RawProductsAndOrders.png)
 >  Left side: Raw materials stock panel. Right side: Order input history thing.
 
 
 ![](Mep3.0/Resources/showcase/OrderInputPanel.png)
 > Left side: Major product stock panel. Right side: Order input panel.
 
 
 
