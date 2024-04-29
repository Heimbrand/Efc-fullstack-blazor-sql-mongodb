# Api-Specifikation

## Denna Api:n skall hantera data till och från en e-handel, datan kommer alltså att vara produkter, kunder samt en Admin

### Övrig funktionalitet skall vara att man kan logga in med en säker autentiseringsmetod, vidare skall Admin kunne hantera funktioner såsom att lägga till och sa bort produkter ur sortimentet etc

---

## Endpoints

### Customer

| Path                             | Method | Request               | Response         | ResponseCodes |
| -------------------------------- | ------ | --------------------- | ---------------- | ------------- |
| "/Customer"                      | GET    | NONE                  | CustomerList     | 200           |
| "/Customer/{id}"                 | GET    | Customer_id           | CustomerById     | 200, 404      |
| "/Customer/{Email}{id}"          | GET    | Email                 | CustomerByMail   | 200, 404      |
| "/Customer/{PhoneNumber}{id}"    | GET    | PhoneNumber           | CustomerByPhone  | 200, 404      |
| "/Customer/Order/{id}"           | GET    | Customer_id, Order_id | OrdersList       | 200, 404      |
| "/Customer"                      | POST   | Customer              | Create customer  | 200, 400      |
| "/Customer/{id}"                 | PUT    | int Customer_id,      | Update customer  | 200, 400, 404 |
| "/Customer/{id}/name/{name}"     | PUT    | id, name              | Update FirstName | 200, 400, 404 |
| "/Customer/{id}/lastname/{name}" | PUT    | id, name              | Update LastName  | 200, 400, 404 |
| "/Customer/{id}/email/{email}"   | PUT    | id, email             | Update Email     | 200, 400, 404 |
| "/Customer/{id}/phone/{phone}"   | PUT    | id, phone             | Update Phone     | 200, 400, 404 |
| "/Customer/{id}/adress/{adress}" | PUT    | id, adress            | Update Adress    | 200, 400, 404 |
| "/Customer/{id}/city/{city}"     | PUT    | id, city              | Update City      | 200, 400, 404 |
| "/Customer/{id}/zip/{name}"      | PUT    | id, zip               | Update Zip       | 200, 400, 404 |
| "/Customer/{id}"                 | DELETE | Customer_id           | Remove customer  | 200, 400, 404 |

### Products

| Path                                            | Method | Request                  | Response             | ResponseCodes |
| ----------------------------------------------- | ------ | ------------------------ | -------------------- | ------------- |
| "/api/product"                                  | GET    | NONE                     | ProductList          | 200           |
| "/api/product/{id}"                             | GET    | product_id               | Product              | 200, 404      |
| "/api/product/name/{name}"                      | GET    | name                     | Product              | 200, 404      |
| "/api/product"                                  | POST   | Products product         | Create product       | 200, 400      |
| "/api/product/{id}"                             | PUT    | product_id, Product      | Update product       | 200, 404      |
| "/api/product/{id}/price/{price}"               | PUT    | product_id, price        | Update price         | 200, 404      |
| "/api/product/{id}/description/{description}"   | PUT    | product_id, description  | Update description   | 200, 404      |
| "/api/product/{id}/name/{name}"                 | PUT    | product_id, name         | Update  name         | 200, 404      |
| "/api/product/{id}/stockBalance/{stockBalance}" | PUT    | product_id, stockBalance | Update  stockbalance | 200, 404      |
| "/api/product/{id}/status/{status}"             | PUT    | product_id, status       | Update status        | 200, 404      |
| "/api/product/{id}"                             | DELETE | product_id               | None                 | 200, 404      |

### Categories

| Path                        | Method | Request               | Response        | ResponseCodes |
| --------------------------- | ------ | --------------------- | --------------- | ------------- |
| "/api/category"             | GET    | NONE                  | CategoryList    | 200           |
| "/api/category/{id}"        | GET    | category_id           | Category        | 200, 404      |
| "/api/category/name/{name}" | GET    | name                  | Category        | 200, 404      |
| "/api/category"             | POST   | Category category     | Create category | 200, 400      |
| "/api/category/{id}"        | PUT    | category_id, Category | Update category | 200, 404      |
| "/api/category/{id}"        | DELETE | category_id           | None            | 200, 404      |


### Order

| Path                               | Method | Request     | Response      | ResponseCodes |
| ---------------------------------- | ------ | ----------- | ------------- | ------------- |
| "/api/order"                       | GET    | NONE        | OrderList     | 200           |
| "/api/order/customer/{customerId}" | GET    | customerId  | OrderList     | 200, 404      |
| "/api/order"                       | POST   | Order order | Create order  | 200, 400      |
| "/api/order/{id}"                  | DELETE | order_id    | order deleted | 200, 404      |


### OrderDetails

| Path                               | Method | Request                 | Response            | ResponseCodes |
| ---------------------------------- | ------ | ----------------------- | ------------------- | ------------- |
| "/api/orderdetail"                 | GET    | NONE                    | OrderDetailList     | 200           |
| "/api/orderdetail/order/{orderId}" | GET    | orderId                 | OrderDetailList     | 200, 404      |
| "/api/orderdetail"                 | POST   | OrderDetail orderDetail | Create orderDetail  | 200, 400      |
| "/api/orderdetail/{id}"            | DELETE | orderDetail_id          | orderDetail deleted | 200, 404      |

## Data

### Products

| Property Name | Data Type                | Description                                     |
| ------------- | ------------------------ | ----------------------------------------------- |
| Product_id    | int                      | Id for database                                 |
| Category_id   | int                      | fk                                              |
| Name          | string                   | Name of the product                             |
| Price         | double                   | Price of the product                            |
| Description   | String                   | Description of the product                      |
| StockBalance  | int                      | Description of the product                      |
| Status        | Bool                     | Shows if the product has expired from the stock |
| OrderDetails  | ICollection<OrderDetail> | relation to orderdetail                         |
| Category      | Category                 | Specific category (virtual)                     |

### Category

| Property Name | Data Type            | Description      |
| ------------- | -------------------- | ---------------- |
| Category_id   | int                  | Id for database  |
| Name          | string               | product category |
| Products      | ICollection<Product> | virtual relation |

### Customers

| Property Name | Data Type          | Description               |
| ------------- | ------------------ | ------------------------- |
| Id            | int                | Id for database           |
| FirstName     | string             | FirstName of the Customer |
| LastName      | String             | LastName of the Customer  |
| Email         | string             | Customers email           |
| PhoneNumber   | string             | Customers PhoneNumber     |
| Adress        | string             | Customer adress           |
| City          | string             | Customer City             |
| Zip           | string             | Customer ZipCode          |
| Country       | string             | Customer Country          |
| Orders        | Icollection<Order> | Customers orderhistory    |

### Order

| Property Name | Data Type                 | Description                     |
| ------------- | ------------------------- | ------------------------------- |
| Id            | int                       | PK                              |
| CustomerId    | int                       | FK                              |
| OrderDate     | DateTime                  | FirstName of the Customer       |
| Customers     | Customer                  | List of customers with orders   |
| OrderDetails  | ICollection<Orderdetails> | relations collection of details |


### OrderDetails

| Property Name | Data Type | Description           |
| ------------- | --------- | --------------------- |
| ID            | int       | PK                    |
| OrderId       | int       | FK                    |
| ProductId     | int       | FK                    |
| Cuantity      | int       | Stockbalance          |
| Product       | Product   | relations to products |
| Order         | Order     | relations to Order    |