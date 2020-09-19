# VideoGameOrderingSystem

## Add Item Flow

Create Item Object -> Must have name, description, category, price, total inventory -> Call AddItemToDatabase() which will return a bool, true if inserted, and false if not

## Create Order Flow

Create Order Object -> Must specify fulfillDate -> Add items to order using AddItemToOrder() which will return a bool, true if added, false if not -> call CommitOrderToDatabase() to insert order into the database
